using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class PlayerController : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] private float _speed;

    [Header("Animations")] 
    private Animator _animator;
    [SerializeField] private Sprite _head;
    [SerializeField] private Sprite _headFront;
    [SerializeField] private Sprite _headBack;

    [SerializeField] private GameObject _body;
    [SerializeField] private Sprite _bodyFront;
    [SerializeField] private Sprite _bodyBack;
    

    private Rigidbody2D _rigibody;
    void Start() {
        _rigibody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update() {
        var playerInput =
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        var playerInputNormalized = playerInput.normalized;

        _rigibody.velocity = playerInputNormalized * _speed;
        
        _animator.SetBool("isWalking", playerInput != Vector2.zero);

        if (playerInput.x != 0) {
            transform.localScale = new Vector3(
            Math.Sign(playerInput.x),
            1,
            1
            );
        }

        var headSpriteRenderer = _head.GetComponent<SpriteRenderer>();
        var bodySpriteRenderer = _body.GetComponent<SpriteRenderer>();

        if (playerInput.y > 0) {
            headSpriteRenderer.sprite = _headBack;
            bodySpriteRenderer.sprite = _bodyBack;
        }

        if (playerInput.y < 0) {
            headSpriteRenderer.sprite = _headFront;
            bodySpriteRenderer.sprite = _bodyFront;
        }
        //Interactable
        if (Input.GetKeyDown(KeyCode.E)) {
            Interactor interactable = GetComponent<Interactor>();
            if (interactable != null) {
                
            }
        }
    }
}
