using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivindToilet : MonoBehaviour {
	// KeyStructural Toilet_key=new KeyStructural();
	private SpriteRenderer Toilet_door;
	private GameObject Toilet_doorBox;
	public Sprite[] Toilet_door2;

	public static LivindToilet _instance;

	void Awake()
	{
		_instance=this;
	}
	void Start()
	{
		Toilet_door=this.GetComponent<SpriteRenderer>();
		Toilet_doorBox=GameObject.Find("ToiletDoor_1");
		// Toilet_door2=Resources.LoadAll<Sprite>("Toilet_Door2");
	}

	// void OnTriggerStay2D(Collider2D Collections)
	// {
	// 	// if (Collections.CompareTag("Player"))
	// 	// {
	// 	// 	if (Input.GetKeyDown(KeyCode.Z))
	// 	// 	{
				
	// 	// 	}
	// 	// }
	// }
	public void OpenToiletDoor(){
		
				//↓改变为开门的图片
				Toilet_door.sprite=Toilet_door2[0];
				Toilet_doorBox.GetComponent<BoxCollider2D>().enabled=false;
			
		}
}
