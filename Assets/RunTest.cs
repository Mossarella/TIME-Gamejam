using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTest : MonoBehaviour
{



    public float moveInput;
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        
        

            moveInput = Input.GetAxisRaw("Horizontal");/* *Time.fixedDeltaTime * speed;*/
        
        









        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            transform.position -=transform.right * Time.deltaTime * speed;
            //gameObject.transform.Translate(-1 * transform.right * Time.fixedDeltaTime * slowMoveSpeed);
            print("SHIT");
        }

        

        if (Input.GetKey(KeyCode.RightArrow))
        {
             transform.position = new Vector2( moveInput , 0) * speed * Time.deltaTime;
            //gameObject.transform.Translate(transform.right * Time.fixedDeltaTime * slowMoveSpeed);
        }

        
    }
}
