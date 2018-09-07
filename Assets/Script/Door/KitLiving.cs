using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitLiving : MonoBehaviour {

	void OnTriggerStay2D(Collider2D Collections)
	{
		if (Collections.CompareTag("Player"))
		{
			if (Input.GetKeyDown(KeyCode.Z))
			{
				//有钥匙时做的事情
				DoorScript._instance.MoveToDoor(3);
			}
		}
		
	}
}
