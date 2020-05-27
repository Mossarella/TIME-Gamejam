using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuck : MonoBehaviour

{

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.rb.velocity = new Vector2(5, 0);
            //Debug.Log("press");
        }


    }
}
