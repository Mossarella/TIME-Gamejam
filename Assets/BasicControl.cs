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
    public float canJumpDuration2;
    public bool firstJump;
    //jump higher
    
    
    public bool isJumping=false;

    void Start()
    {
        jumpDuration1 = canJumpDuration;
        jumpDuration2 = canJumpDuration2;
        jumpCounter = canJumpTimes;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);
        if (isGrounded == true)
        {
            jumpCounter = canJumpTimes;
            jumpDuration1 = canJumpDuration;
            jumpDuration2 = canJumpDuration2;
            isJumping = false;
            firstJump = false;
        }
        if (isGrounded == false)
        {
            isJumping = true;
        }

    }


    void Update()
    {
        Move();
        Jump();

        
        Debug.Log(jumpDuration2);

    }

    void Jump()
    {


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {               
                rb.velocity = Vector2.up * jumpForce;
            
        }
        if (Input.GetKey(KeyCode.Space)&&isJumping==true)
        {
            
            if (jumpDuration1 > 0&&moveInput==0)
            {
                
                rb.velocity = (Vector2.up * jumpForce);
                
                jumpDuration1 -= Time.deltaTime;
                
                jumpDuration1 = Mathf.Clamp(jumpDuration1, 0, canJumpDuration);

            }
            else if (jumpDuration1 > 0 && moveInput == 1)
            {

                rb.velocity = (Vector2.up * jumpForce)+ (Vector2.right * speed);
                
                jumpDuration1 -= Time.deltaTime;
                
                jumpDuration1 = Mathf.Clamp(jumpDuration1, 0, canJumpDuration);
            }
            else if (jumpDuration1 > 0 && moveInput == -1)
            {

                rb.velocity = (Vector2.up * jumpForce) + (Vector2.left * speed);
                
                jumpDuration1 -= Time.deltaTime;
               
                jumpDuration1 = Mathf.Clamp(jumpDuration1, 0, canJumpDuration);
            }

            
        }

        if (firstJump == true)
        {


            if (jumpCounter > 0 && Input.GetKey(KeyCode.Space) && !isGrounded && jumpDuration2 > 0 && moveInput == 0)
            {
               





                rb.velocity = (Vector2.up * jumpForce);
                jumpDuration2 -= Time.deltaTime;
                Debug.Log("test");
                jumpDuration2 = Mathf.Clamp(jumpDuration2, 0, canJumpDuration2);
                

            }
            else if (jumpCounter > 0 && Input.GetKey(KeyCode.Space) && !isGrounded && jumpDuration2 > 0 && moveInput == 1)
            {
                




                rb.velocity = (Vector2.up * jumpForce) + (Vector2.right * speed);
                jumpDuration2 -= Time.deltaTime;
                Debug.Log("test");
                jumpDuration2 = Mathf.Clamp(jumpDuration2, 0, canJumpDuration2);
                
            }
            else if (jumpCounter > 0 && Input.GetKey(KeyCode.Space) && !isGrounded && jumpDuration2 > 0 && moveInput == -1)
            {
                




                rb.velocity = (Vector2.up * jumpForce) + (Vector2.left * speed);
                jumpDuration2 -= Time.deltaTime;
                Debug.Log("test");
                jumpDuration2 = Mathf.Clamp(jumpDuration2, 0, canJumpDuration2);
                
            }








            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpDuration2 = canJumpDuration2;
                jumpCounter--;
                if (jumpCounter==0&& Input.GetKeyUp(KeyCode.Space))
                {
                    jumpDuration2 = 0;
                }


            }





        }
        if (Input.GetKeyUp(KeyCode.Space))
        { 
            jumpDuration1 = 0;
            firstJump = true;

        }
        if (jumpDuration1 == canJumpDuration && isJumping == true)
        {

            firstJump = true;

        }



    }

    void Move()
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
