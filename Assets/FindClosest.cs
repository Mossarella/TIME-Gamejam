using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour {

	public Transform firePoint;
	[SerializeField]public float fireRadius;

	public Enemy closestEnemy = null;




	public float distanceAsFloat;



	void Update () 
	{
		
			FindClosestEnemy();
		
	}

	void FindClosestEnemy()
	{
		float distanceToClosestEnemy = Mathf.Infinity;
		
		
		Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

		
			foreach (Enemy currentEnemy in allEnemies)
			{
			
				float enemyDistance = Vector2.Distance(currentEnemy.transform.position, firePoint.transform.position);
			

			if (enemyDistance < distanceToClosestEnemy)
				{
					distanceToClosestEnemy = enemyDistance;
					closestEnemy = currentEnemy;
				distanceAsFloat = enemyDistance;
			}

			}
		Debug.DrawLine(firePoint.transform.position, closestEnemy.transform.position);
		/*if (distanceAsFloat < fireRadius)
		{
			
		}
		Debug.Log(distanceAsFloat);*/
	}
	



}
