using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{

	private Transform enemyHolder;
	public float speed;

	void Start()
	{
		InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
		enemyHolder = GetComponent<Transform>();
	}

	void MoveEnemy()
	{
		enemyHolder.position += Vector3.right * speed;

		foreach (Transform enemy in enemyHolder)
		{
			if (enemy.position.x < -12.5 || enemy.position.x > 12.5)
			{
				speed = -speed;
				enemyHolder.position += Vector3.down * 0.5f;
				return;
			}
		}
	}
}