using UnityEngine;
using System.Collections;

public class TargetExit : MonoBehaviour
{
	public float exitAnimationSeconds = 2f; // should be >= time of the exit animation

	private bool startDestroy = false;

	private void  Start()
    {
		if (this.GetComponent<Animator>() == null)
			// no Animator so just destroy right away
			Destroy(gameObject);
		else if (!startDestroy)
		{
			// set startDestroy to true so this code will not run a second time
			startDestroy = true;

			// Call KillTarget function after exitAnimationSeconds to give time for animation to play
			KillTarget();
		}
	}

	// destroy the gameObject when called
	void KillTarget ()
	{
		// remove the gameObject
		if (this != null)
		{
			Vector3Int pos = gameObject.GetComponent<FieldBlock>().PositionInGraph;
			transform.parent.GetComponent<PlaySpaceGenerator>().minefield.RemoveNode(pos.x, pos.y, pos.z);
		}
	}
}
