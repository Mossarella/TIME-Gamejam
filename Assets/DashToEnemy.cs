using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashToEnemy : MonoBehaviour
{
    FindClosest findClosest;
    private KeyCode dash = KeyCode.A;
    private Rigidbody2D rb;
    [SerializeField]float dashSpeed=4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        findClosest = GetComponent<FindClosest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (findClosest.distanceAsFloat <= findClosest.fireRadius && Input.GetKey(dash))
        {
            Vector2 enemyPos = new Vector2(findClosest.closestEnemy.transform.position.x,findClosest.closestEnemy.transform.position.y) ;
            rb.velocity = Vector2.MoveTowards(findClosest.firePoint.transform.position,enemyPos,findClosest.fireRadius) * dashSpeed;
            //rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * 0);
            Debug.Log(rb.velocity);
        }
    }
}
