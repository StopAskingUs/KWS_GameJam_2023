using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public enum AiState {
        Idle,
        Chase,
        Attack,
    }

    [SerializeField] public float moveSpeed = 4.0f;
    [SerializeField] public float attackRange = 1.0f;
    [SerializeField] public float attackCooldown = 2.0f;

    private float lastAttackTime;
    private AiState currentState = AiState.Idle;
    private Transform playerTransform; //Reference to the player's transform

    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        switch (currentState) {
            case AiState.Idle:
                HandleIdleState();
                break;
            case AiState.Chase:
                HandleChaseState();
                break;
            case AiState.Attack:
                HandleAttackState();
                break;
        }
    }

    private void HandleIdleState() {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= attackRange) {
            currentState = AiState.Chase;
        }
    }

    private void HandleChaseState() {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= attackRange) {
            currentState = AiState.Attack;
        } else if (distanceToPlayer > attackRange * 3) {
            currentState = AiState.Idle;
        } else {
            Vector2 moveDirection = (playerTransform.position - transform.position).normalized;
            Vector2 move = moveDirection * moveSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void HandleAttackState() {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer > attackRange) {
            currentState = AiState.Chase;
        } else if (Time.time - lastAttackTime >= attackCooldown) {
            Debug.Log("Mob Attacks");
            lastAttackTime = Time.time;
        }
    }
}
