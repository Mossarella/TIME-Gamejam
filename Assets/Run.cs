using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{

    [SerializeField] float speed;
    private float moveInput;

    private Rigidbody2D rb;










    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
