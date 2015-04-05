using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {


	public int hp=1;
	public bool isEnemey=true;

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
			// Dead!
			Destroy(gameObject);
		}
	}	
}
