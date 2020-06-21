using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRange : MonoBehaviour
{
    
    private KeyCode shootButton=KeyCode.A;

    

    public bool thereAreEnemyInRadius=false;
    public Transform firePoint;
    [SerializeField] float fireRadius;
    
    public LayerMask whatIsEnemy;
    public int numberOfEnemyInRadius;

    
    public GameObject[] enemy;
    GameObject lockedTarget;
    private Vector2 enemyPosition;





    void Start()
    {

        


    }
    //make it find multiple enemy 

    // Update is called once per frame
    void FixedUpdate()
    {

        
        if (Input.GetKey(shootButton))
        {
            Aim();
        }
    }

    public void Aim()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        thereAreEnemyInRadius = Physics2D.OverlapCircle(firePoint.position, fireRadius, whatIsEnemy);
        numberOfEnemyInRadius = Physics2D.OverlapCircleAll(firePoint.position, fireRadius, whatIsEnemy).Length;



        

        //positionOfEnemyInRadius = Physics2D.CircleCastAll(firePoint.position, fireRadius, enemy);

        //Debug.Log(enemyPosition);



        foreach (GameObject target in enemy)
        {
            float dist = Vector2.Distance(firePoint.transform.position, target.transform.position);

            //float angle = Vector2.Angle(transform.position, target.transform.position);

            


            if (dist <= fireRadius)
            {
                
                lockedTarget = target;
                enemyPosition = target.transform.position;
                Debug.DrawLine(firePoint.position, lockedTarget.transform.position, Color.red, 0.1f);
                //Debug.Log(enemyPosition);

                
            }
        }


        
        //this script will find distance from you to enemy, neat.



        //Vector3 enemyLocation =Camera.main.ScreenPointToRay(enemy.transform.position,)


        //RaycastHit2D hitInfo= Physics2D.RaycastAll(firePoint.position,firePoint.)
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(firePoint.position,fireRadius);

        

        
            
        

    }


}
