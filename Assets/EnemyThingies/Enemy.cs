using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int health;
    public float speed;
    public CircleCollider2D circleCollider2D;

    void Start()
    {
        health = maxHealth;
       circleCollider2D= GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        print("damaged");

        if(health<=0)
        {
            Die();
        }
    }
    public void Die()
    {
        //die
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(circleCollider2D.transform.position,circleCollider2D.radius);

    }
}
