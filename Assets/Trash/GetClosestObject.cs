using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClosestObject : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] float fireRadiusBefore=7f;
    private float fireRadius;



    private KeyCode shootButton = KeyCode.A;

    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        fireRadius = fireRadiusBefore * fireRadiusBefore;
        //if (Input.GetKeyDown(shootButton))
        FindClosest(); 
        
    }

    

    public void FindClosest()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = FindObjectsOfType<Enemy>();
        

        foreach (Enemy currentEnemy in allEnemies)
        {
            //Vector3 distanceToEnemy = (currentEnemy.transform.position-firePoint.transform.position);
            //float sqrDisatanceToEnemy = distanceToEnemy.sqrMagnitude;
            float sqrDisatanceToEnemy = (currentEnemy.transform.position - firePoint.transform.position).sqrMagnitude;
            
            if (sqrDisatanceToEnemy <= fireRadius)
            {
                
                if (sqrDisatanceToEnemy < distanceToClosestEnemy)
                {

                    distanceToClosestEnemy = sqrDisatanceToEnemy;
                    closestEnemy = currentEnemy;
                    
                }

                
            }
            
        }
        Debug.DrawLine(firePoint.transform.position, closestEnemy.transform.position);
        Debug.Log(closestEnemy);







    }

    


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(firePoint.position, fireRadiusBefore);







    }

}



