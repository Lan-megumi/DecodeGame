using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingKit : MonoBehaviour {
	DoorScript DoorScript = new DoorScript();
	// KeyStructural precious=new KeyStructural();
	
	void OnTriggerStay2D(Collider2D Collections)
	{
		if (Collections.CompareTag("Player"))
		{
			if (Input.GetKeyDown(KeyCode.Z))
			{
				
				DoorScript._instance.MoveToDoor(1);

				// DoorScript.MoveToDoor(1);
			}
			
			
		}
		
	}
}
