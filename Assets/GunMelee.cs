using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMelee : MonoBehaviour
{

    public float attackRate;
    private float nextAttackTime; //never change this value

    private KeyCode meleeAttackButton=KeyCode.A;

    public Transform attackCircle;
    public LayerMask whatIsEnemy;
    [SerializeField] float attackRange;

    public int myDamage;
    



    void Start()
    {
        
    }

    
    void Update()
    {
        if(Time.time>=nextAttackTime)
        {
            if (Input.GetKeyDown(meleeAttackButton))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }


        Debug.Log(nextAttackTime);



    }

    public void Attack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackCircle.position, attackRange, whatIsEnemy);


        foreach (Collider2D enemy in enemiesToDamage)
        {
            enemy.GetComponent<Enemy>().TakeDamage(myDamage);
            Debug.Log("we got him");
            
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackCircle.position, attackRange);

    }
}
