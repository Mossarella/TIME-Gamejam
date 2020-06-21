using System.Collections;
using UnityEngine;

public class BasicControl : MonoBehaviour
{

    [SerializeField] float jumpForce;

    private float moveInput;

    private Rigidbody2D rb;
    //private CircleCollider2D circleCollider2D;

    public Transform groundPos;
    public bool isGrounded = false;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int jumpCounter;//jumpleft
    public int bonusJump;
    public int defaultBonusJump = 0;
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

    private KeyCode moveLeftKey = KeyCode.LeftArrow;
    private KeyCode moveRightKey = KeyCode.RightArrow;


    public bool isJumping = false;
    public bool currentSpriteFacing;


    public DashToEnemy dashToEnemy;



    void Start()
    {
        dashToEnemy = GetComponent<DashToEnemy>();
        rb = GetComponent<Rigidbody2D>();
    }




    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        Increasejump();


        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);
        if (isGrounded == true)
        {
            jumpCounter = canJumpTimes;
            jumpDuration1 = canJumpDuration;
            jumpDuration2 = canJumpDuration2;
            isJumping = false;
            firstJump = false;
            bonusJump = defaultBonusJump;
        }
        else
        {
            isJumping = true;
        }





    }
    void FixedUpdate()
    {
        
        RunFixedUpdate();
        //transform.position += transform.right *moveInput* (Time.deltaTime * slowMoveSpeed);
    }
    void Jump()
    {
        jumpCounter = Mathf.Clamp(jumpCounter, 0, canJumpTimes + 1);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && moveInput == 0)
        {
            rb.velocity = Vector2.up * jumpForce;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && moveInput > 0)
        {
            rb.velocity = Vector2.up * jumpForce + (Vector2.right * slowMoveSpeed); ;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && moveInput < 0)
        {
            rb.velocity = Vector2.up * jumpForce + (Vector2.left * slowMoveSpeed); ;

        }



        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {

            if (jumpDuration1 > 0 && moveInput == 0)
            {

                rb.velocity = (Vector2.up * jumpForce);

                jumpDuration1 -= Time.deltaTime;

                jumpDuration1 = Mathf.Clamp(jumpDuration1, 0, canJumpDuration);

            }
            else if (jumpDuration1 > 0 && moveInput > 0)
            {

                rb.velocity = (Vector2.up * jumpForce) + (Vector2.right * slowMoveSpeed);

                jumpDuration1 -= Time.deltaTime;

                jumpDuration1 = Mathf.Clamp(jumpDuration1, 0, canJumpDuration);
            }
            else if (jumpDuration1 > 0 && moveInput < 0)
            {

                rb.velocity = (Vector2.up * jumpForce) + (Vector2.left * slowMoveSpeed);

                jumpDuration1 -= Time.deltaTime;

                jumpDuration1 = Mathf.Clamp(jumpDuration1, 0, canJumpDuration);
            }


        }

        if (firstJump == true)
        {


            if ((jumpCounter > 0 && Input.GetKey(KeyCode.Space) && !isGrounded && jumpDuration2 > 0 && moveInput == 0))
            {






                rb.velocity = (Vector2.up * jumpForce);
                jumpDuration2 -= Time.deltaTime;
                //Debug.Log("test");
                jumpDuration2 = Mathf.Clamp(jumpDuration2, 0, canJumpDuration2);



            }
            else if ((jumpCounter > 0 && Input.GetKey(KeyCode.Space) && !isGrounded && jumpDuration2 > 0 && moveInput > 0))
            {





                rb.velocity = (Vector2.up * jumpForce) + (Vector2.right * slowMoveSpeed);
                jumpDuration2 -= Time.deltaTime;
                //Debug.Log("test");
                jumpDuration2 = Mathf.Clamp(jumpDuration2, 0, canJumpDuration2);


            }
            else if ((jumpCounter > 0 && Input.GetKey(KeyCode.Space) && !isGrounded && jumpDuration2 > 0 && moveInput < 0))
            {





                rb.velocity = (Vector2.up * jumpForce) + (Vector2.left * slowMoveSpeed);
                jumpDuration2 -= Time.deltaTime;
                //Debug.Log("test");
                jumpDuration2 = Mathf.Clamp(jumpDuration2, 0, canJumpDuration2);


            }






            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpDuration2 = canJumpDuration2;
                jumpCounter--;

                /*if (jumpCounter==-1&& Input.GetKeyUp(KeyCode.Space))
                {
                    jumpDuration2 = 0;
                }*/


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
    public void Increasejump()
    {
        if (dashToEnemy.isDashing == true && jumpCounter != canJumpTimes)
        {
            dashToEnemy.isDashing = false;
            jumpCounter += 1;
            //Debug.Log(jumpDuration2);
        }
        else if (dashToEnemy.isDashing == true && jumpCounter == canJumpTimes)
        {
            dashToEnemy.isDashing = false;


        }
    }




    void Run()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(moveLeftKey))
        {
            if (waitingForDoubleTap_Left == true)
            {
                normal_isMovingLeft = false;
                fast_isMovingLeft = true;
            }
            waitingForDoubleTap_Left = true;
            normal_isMovingLeft = true;
            StartCoroutine(WaitForDoubleTap_Left());
        }
        else if (Input.GetKeyUp(moveLeftKey))
        {
            normal_isMovingLeft = false;
            fast_isMovingLeft = false;
        }

        if (Input.GetKeyDown(moveRightKey))
        {
            if (waitingForDoubleTap_Right == true)
            {
                normal_isMovingRight = false;
                fast_isMovingRight = true;
            }
            waitingForDoubleTap_Right = true;
            normal_isMovingRight = true;
            StartCoroutine(WaitForDoubleTap_Right());
        }
        else if (Input.GetKeyUp(moveRightKey))
        {
            normal_isMovingRight = false;
            fast_isMovingRight = false;
        }

        RunFixedUpdate();
    }

    private void RunFixedUpdate()
    {

       
           

            rb.velocity = new Vector2(moveInput * slowMoveSpeed, rb.velocity.y);
        


        if (fast_isMovingLeft == true)
        {
            rb.velocity = new Vector2(moveInput * fastMoveSpeed, rb.velocity.y);
            //rb.MovePosition((Vector2)transform.position + new Vector2(moveInput, 0) * fastMoveSpeed * Time.deltaTime);
            //transform.position -= transform.right * (Time.deltaTime * fastMoveSpeed);
            //transform.position = new Vector2( moveInput , 0) * speed * Time.deltaTime;
            //gameObject.transform.Translate(moveInput * transform.right * Time.fixedDeltaTime * fastMoveSpeed);
        }



        if (fast_isMovingRight == true)
        {
            rb.velocity = new Vector2(moveInput * fastMoveSpeed, rb.velocity.y);
            //rb.MovePosition((Vector2)transform.position + new Vector2(moveInput, 0) * fastMoveSpeed * Time.deltaTime);
            //rb.velocity = new Vector2(moveInput * slowMoveSpeed, rb.velocity.y);
            //transform.position -= transform.right * (Time.deltaTime * fastMoveSpeed);
            // transform.position = new Vector2( moveInput ,0) * speed * Time.deltaTime;
            //gameObject.transform.Translate(moveInput*transform.right * Time.fixedDeltaTime * fastMoveSpeed);
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

    private void FlipSprite()
    {
        if (currentSpriteFacing == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (currentSpriteFacing == false)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (moveInput == 1)
        {
            currentSpriteFacing = true;
        }
        else if (moveInput == -1)
        {
            currentSpriteFacing = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPos.position, checkRadius);

    }
}
