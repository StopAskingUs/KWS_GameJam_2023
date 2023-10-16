using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour {
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D _rb;
    Animator _animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        // If movement input is not 0, try to move
        if (movementInput != Vector2.zero) {
            int count = _rb.Cast(
                movementInput,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);
            if (count == 0) {
                _rb.MovePosition(_rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);

                // Ustal kierunek ruchu (Front, Back, Left, Right) na podstawie wartości movementInput
                if (movementInput.y > 0) {
                    _animator.SetBool("FrontWalk", true);
                    _animator.SetBool("BackWalk", false);
                    _animator.SetBool("LeftWalk", false);
                    _animator.SetBool("RightWalk", false);
                }
                else if (movementInput.y < 0) {
                    _animator.SetBool("FrontWalk", false);
                    _animator.SetBool("BackWalk", true);
                    _animator.SetBool("LeftWalk", false);
                    _animator.SetBool("RightWalk", false);
                }   
                else if (movementInput.x < 0) {
                    _animator.SetBool("FrontWalk", false);
                    _animator.SetBool("BackWalk", false);
                    _animator.SetBool("LeftWalk", true);
                    _animator.SetBool("RightWalk", false);
                }
                else if (movementInput.x > 0) {
                    _animator.SetBool("FrontWalk", false);
                    _animator.SetBool("BackWalk", false); 
                    _animator.SetBool("LeftWalk", false);
                    _animator.SetBool("RightWalk", true);
                }
            }
        }
        else {
            // Gracz stoi w miejscu (Idle)
            _animator.SetBool("FrontWalk", false);
            _animator.SetBool("BackWalk", false);
            _animator.SetBool("LeftWalk", false);
            _animator.SetBool("RightWalk", false);
        }
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
}
