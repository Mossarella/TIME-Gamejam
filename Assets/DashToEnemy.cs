using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashToEnemy : MonoBehaviour
{
    FindClosest findClosest;
    private KeyCode dash = KeyCode.A;
    private Rigidbody2D rb;
    [SerializeField] float dashSpeed = 2000f;
    Vector2 enemyPos;
    Vector2 direction;
    Vector2 directionFirst;
    float directionNewX;
    float directionNewY;
    Vector2 firePoint;
    BoxCollider2D boxCollider2D;
    public bool isDashing= false;
    BasicControl basicControl;
    SlowMotion slowMotion;
    [SerializeField]public float maxDashCoolDown;
    private float dashCoolDown;
    [SerializeField] public float maxDashCharge;
    private float dashCharge;
    


    // Start is called before the first frame update
    void Start()
    {
        dashCharge = maxDashCharge;
        dashCoolDown = maxDashCoolDown;
        basicControl = GetComponent<BasicControl>();
        rb = GetComponent<Rigidbody2D>();
        findClosest = GetComponent<FindClosest>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        slowMotion = GetComponent<SlowMotion>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dashCharge<maxDashCharge)
        {
            if (dashCoolDown < maxDashCoolDown)
            {

                dashCoolDown += Time.deltaTime;
            }
            else if (dashCoolDown >= maxDashCoolDown)
            {
                dashCharge++;
                dashCoolDown = 0;
            }
        }
        if( dashCharge>=maxDashCharge)
        {
            dashCharge = maxDashCharge;
        }

        
        
        
        
        enemyPos = findClosest.closestEnemy.transform.position;
        firePoint = findClosest.firePoint.transform.position;
        directionFirst = enemyPos - firePoint;
        direction = directionFirst;
        directionNewX = direction.x;
        Dash();
        //Debug.Log(enemyPos + "enemy");
        //Debug.Log(findClosest.firePoint.transform.position + "firepoint");
        //Debug.Log(direction);




       

    }

    
    





    public void Dash()
    {
        if (slowMotion.timeAfterPress >= slowMotion.timeToEnterAfterPress && slowMotion.canDash == true &&dashCharge>0)
        {
            if (findClosest.distanceAsFloat <= findClosest.fireRadius && Input.GetKeyUp(dash))
            {
                slowMotion.timeAfterPress = 0;

                isDashing = true;

                rb.drag = 1000f;

                this.rb.velocity = new Vector2(direction.x * dashSpeed, direction.y * dashSpeed);
                dashCharge--;

                //rb.velocity = Vector2.MoveTowards(this.transform.position,direction,dashSpeed);

                Invoke("Eh", 0.15f);

                Debug.Log(isDashing);
                slowMotion.canSlowTimeTimes++;
                slowMotion.RefillLenghtSoYouCanStopTimeAgain();


            }
            else if (Input.GetKeyUp(dash))
            {
                slowMotion.timeAfterPress = 0;
            }

        }
        




    }

    public void Eh()
    {
        this.rb.velocity = new Vector2(this.transform.position.x * 0, this.transform.position.y * 0);
        rb.drag = 0f;
        

        
    }

    
}
