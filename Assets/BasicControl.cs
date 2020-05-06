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
    
    private int jumpCounter;
    public int canJumpTimes;
    //double jump

    private float jumpDuration1;
    private float jumpDuration2;
    public float canJumpDuration;
    //jump higher
    
    
    public bool isJumping=false;

    void Start()
    {
        jumpDuration1 = canJumpDuration;
        jumpDuration2 = canJumpDuration;
        jumpCounter = canJumpTimes;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround))
            {
            isGrounded = true;
            
            }
        if(!isGrounded)
        {
            isJumping=true;
        }
    }


    void Update()
    {
        Run();
        Jump();

        
        Debug.Log(moveInput);

    }

    void Jump()
    {


        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {               
                rb.velocity = Vector2.up * jumpForce;            
        }
        if (Input.GetKey(KeyCode.Space)&&isJumping==true)
        {
            
            if (jumpDuration1 > 0&&moveInput==0)
            {
                
                rb.velocity = (Vector2.up * jumpForce);
                jumpDuration1 -= Time.deltaTime;
            }
            else if (jumpDuration1 > 0 && moveInput == 1)
            {

                rb.velocity = (Vector2.up * jumpForce)+ (Vector2.right * speed);
                jumpDuration1 -= Time.deltaTime;
            }
            else if (jumpDuration1 > 0 && moveInput == -1)
            {

                rb.velocity = (Vector2.up * jumpForce) + (Vector2.left * speed);
                jumpDuration1 -= Time.deltaTime;
            }

        }

        if (Input.GetKeyDown(KeyCode.Space)&& jumpCounter > 0 && !isGrounded)
        {
            
            
                jumpDuration2 -= Time.deltaTime;
                rb.velocity = Vector2.up * jumpForce;
                jumpCounter--;

        }
        if (isGrounded==true)
        {
            jumpCounter = canJumpTimes;
            jumpDuration1 = canJumpDuration;
            jumpDuration2 = canJumpDuration;
            isJumping = false;
        }

    }

    void Run()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
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
