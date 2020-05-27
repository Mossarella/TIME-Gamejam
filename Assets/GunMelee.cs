using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMelee : MonoBehaviour
{

    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    private KeyCode meleeAttackButton;

    public Transform attackCircle;
    public LayerMask whatIsEnemy;
    [SerializeField] float attackRange;

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
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            timeBetweenAttack = startTimeBetweenAttack;
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
