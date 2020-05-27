using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashToEnemy : MonoBehaviour
{
    FindClosest findClosest;
    private KeyCode dash = KeyCode.A;
    private Rigidbody2D rb;
    [SerializeField] float dashSpeed = 4f;
    Vector2 enemyPos;
    Vector2 direction;
    Vector2 directionFirst;
    float directionNewX;
    float directionNewY;
    Vector2 firePoint;
    BoxCollider2D boxCollider2D;
    public bool isDashing= false;
    BasicControl basicControl;
    


    // Start is called before the first frame update
    void Start()
    {
        basicControl = GetComponent<BasicControl>();
        rb = GetComponent<Rigidbody2D>();
        findClosest = GetComponent<FindClosest>();
        boxCollider2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
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
        if (findClosest.distanceAsFloat <= findClosest.fireRadius && Input.GetKeyUp(dash))
        {
            
            
            isDashing = true;

            rb.drag = 1000f;
            
            this.rb.velocity = new Vector2(direction.x*dashSpeed,direction.y*dashSpeed);


            //rb.velocity = Vector2.MoveTowards(this.transform.position,direction,dashSpeed);

            Invoke("Eh", 0.15f);

            //Debug.Log(isDashing );
            
            
        }



    }

    public void Eh()
    {
        this.rb.velocity = new Vector2(this.transform.position.x * 0, this.transform.position.y * 0);
        rb.drag = 0f;
        

        
    }
    
}
