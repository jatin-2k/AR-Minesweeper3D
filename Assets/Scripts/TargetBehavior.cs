using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour
{

	// target impact on game
	public float explosionTimeAfter = 1f;

	// explosion when hit?
	public GameObject explosionPrefab;

    // when collided with another gameObject
    void Start()
	{
		Invoke("MakeExplosion", explosionTimeAfter);
		Invoke("KillTarget", explosionTimeAfter);
	}

	void MakeExplosion()
    {
		if (explosionPrefab)
		{
			// Instantiate an explosion effect at the gameObjects position and rotation
			Instantiate(explosionPrefab, transform.position, transform.rotation, transform.parent);
		}
	}
	void KillTarget()
	{
		// remove the gameObject
		Destroy(gameObject);
	}
}
