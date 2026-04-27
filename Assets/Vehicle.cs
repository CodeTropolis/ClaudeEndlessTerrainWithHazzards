using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Vehicle : MonoBehaviour
{
    [Header("Movement")]
    public float moveForce = 10f;
    public float jumpForce = 12f;

    [Header("Ground Check")]
    public float groundCheckRadius = 0.55f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        float input = 0f;
        if (Input.GetKey(KeyCode.RightArrow)) input =  1f;
        if (Input.GetKey(KeyCode.LeftArrow))  input = -1f;

        rb.AddForce(new Vector2(input * moveForce, 0f), ForceMode2D.Force);

        // Motor-based movement (wheel torque)
        // float motorInput = 0f;
        // if (Input.GetKey(KeyCode.RightArrow)) motorInput = -1f; // negative torque rolls right
        // if (Input.GetKey(KeyCode.LeftArrow))  motorInput =  1f;
        // rb.AddTorque(motorInput * motorTorque);
    }
}
