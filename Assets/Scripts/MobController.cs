using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    
    public enum AiState {
        Idle,
        Chase,
        Attack,
    }

    [SerializeField] public float moveSpeed = 5.0f;
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
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= attackRange) {
            currentState = AiState.Chase;
        }
    }

    private void HandleChaseState() {
        Vector3 moveDirection = (playerTransform.position - transform.position).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= attackRange) {
            currentState = AiState.Attack;
        } else if (distanceToPlayer > attackRange * 2) {
            currentState = AiState.Idle;
        }
    }

    private void HandleAttackState() {
        if (Time.time - lastAttackTime >= attackCooldown) {

            Debug.Log("Mob Attacks");
            lastAttackTime = Time.time;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer > attackRange) {
            currentState = AiState.Chase;
        }
    }
}
