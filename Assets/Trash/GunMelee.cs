using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMelee : MonoBehaviour
{

    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    private KeyCode meleeAttackButton;

    public Transform attackCircle;
    public float attackRange;

    public LayerMask whatIsEnemy;

    public int damage;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (timeBetweenAttack<=0)
        {
            timeBetweenAttack = startTimeBetweenAttack;
            if (Input.GetKeyDown(meleeAttackButton))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackCircle.position,attackRange,whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    //enemiesToDamage[i].GetComponent</*enemycomeponent*/>().TakeDamage(damage);
                }
            }
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackCircle.position, attackRange);

    }
}
