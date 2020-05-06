using UnityEngine;

public class BasicControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    private float moveInput;

    private Rigidbody2D rb;

    public Transform groundPos;
    public bool isGrounded=false;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    [SerializeField] int jumpCounter;
    [SerializeField] int jumpTimes;
    private bool isJumping;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if(isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround))
            {
            isGrounded = true;
            }
        
    }


    void Update()
    {
        Run();
        Jump();



    }

    void Jump()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;

            isJumping = true;
        }

    }

    void Run()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);



        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
}
