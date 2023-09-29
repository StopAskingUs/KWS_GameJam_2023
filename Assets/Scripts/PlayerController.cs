using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    public float moveSpeed = 5f;
    [SerializeField]
    public float jumpForce = 10f;
    private bool isGrounded;
    private Rigidbody2D rb2;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is "Grounded"
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Ground"));
        
        //Handle player input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb2.velocity.y);
        rb2.velocity = movement;
        Debugging.Handle Jumping;
         if (isGrounded && Input.GetButtonDown("Jump")) {
         rb2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
          }
         
    }
}
