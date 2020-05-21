using System.Collections;
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


    public float intervalOfDoubleTap;
    public float fastMoveSpeed = 4f;
    public float slowMoveSpeed = 2f;
    bool waitingForDoubleTap_Left = false;
    bool waitingForDoubleTap_Right = false;
    bool normal_isMovingLeft = false;
    bool fast_isMovingLeft = false;
    bool normal_isMovingRight = false;
    bool fast_isMovingRight = false;
    //run


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

        RunFixedUpdate();

    }


    void Update()
    {
        Run();
        Jump();


        

    }

    void Jump()
    {


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && moveInput == 0)
        {               
                rb.velocity = Vector2.up * jumpForce;
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && moveInput == 1)
        {
            rb.velocity = Vector2.up * jumpForce + (Vector2.right * speed); ;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && moveInput == -1)
        {
            rb.velocity = Vector2.up * jumpForce + (Vector2.left * speed); ;

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

    void Run()
    {
        
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);



        if (Input.GetKeyDown(KeyCode.A))
        {
            if (waitingForDoubleTap_Left)
            {
                normal_isMovingLeft = false;
                fast_isMovingLeft = true;
            }
            waitingForDoubleTap_Left = true;
            normal_isMovingLeft = true;
            StartCoroutine(WaitForDoubleTap_Left());
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (waitingForDoubleTap_Right)
            {
                normal_isMovingRight = false;
                fast_isMovingRight = true;
            }
            waitingForDoubleTap_Right = true;
            normal_isMovingRight = true;
            StartCoroutine(WaitForDoubleTap_Right());
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            normal_isMovingLeft = false;
            fast_isMovingLeft = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            normal_isMovingRight = false;
            fast_isMovingRight = false;
        }











        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
           



        }

        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            
        }

   
    }
    private void RunFixedUpdate()
    {
        if (normal_isMovingLeft)
        {
            gameObject.transform.Translate(-1 * transform.right * Time.fixedDeltaTime * slowMoveSpeed);
        }

        if (fast_isMovingLeft)
        {
            gameObject.transform.Translate(-1 * transform.right * Time.fixedDeltaTime * fastMoveSpeed);
        }

        if (normal_isMovingRight)
        {
            gameObject.transform.Translate(transform.right * Time.fixedDeltaTime * slowMoveSpeed);
        }

        if (fast_isMovingRight)
        {
            gameObject.transform.Translate(transform.right * Time.fixedDeltaTime * fastMoveSpeed);
        }
    }
    private IEnumerator WaitForDoubleTap_Left()
    {
        yield return new WaitForSecondsRealtime(intervalOfDoubleTap);
        waitingForDoubleTap_Left = false;
    }
    private IEnumerator WaitForDoubleTap_Right()
    {
        yield return new WaitForSecondsRealtime(intervalOfDoubleTap);
        waitingForDoubleTap_Right = false;
    }
}
