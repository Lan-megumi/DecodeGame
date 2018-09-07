using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	//门变量命名规则：前往目的地xx的门 （目的地-出发地）
	private Transform Study_livingDoor;
	private Transform LivingDoor_Study;
	private Transform Ktichen_livingDoor;
	private Transform LivingDoor_Kitchen;
	private GameObject DoorOpenAudio;

	public GameObject Player;
//V_xxx xxx=要去的地方
	private	Vector3 V_Study,V_Kitchen,V_Living0,V_Living1;

	public static DoorScript _instance;
	void Awake()
	{
		_instance=this;
	}
	
	void Start()
	{
		Study_livingDoor=GameObject.Find("Living_Door1").transform;
		V_Living0=Study_livingDoor.position;


		Ktichen_livingDoor=GameObject.Find("Living_Door2").transform;
		V_Living1=Ktichen_livingDoor.position;

		LivingDoor_Study=GameObject.Find("Study_Door").transform;
		V_Study=LivingDoor_Study.position;

		LivingDoor_Kitchen=GameObject.Find("Kitchen_door").transform;
		V_Kitchen=LivingDoor_Kitchen.position;

		DoorOpenAudio=GameObject.Find("Living_Door1");

	}
	/*MoveToDoor(DoorNum)说明
		用于各个场景间移动的方法
		DoorNum为门牌编号，根据传回值判断进了哪一扇门
		0:客厅 Living  ------ 书房 Study
		1:客厅 Living  ------ 厨房 Kitchen
		2:书房 Study   ------ 客厅Living
		3:厨房 Kitchen ------ 客厅Living
	 */

	public void MoveToDoor(int DoorNum){
		// Debug.Log(V_Study);
		if (DoorNum==0)
		{
			Player.transform.position=new Vector3(V_Study.x,V_Study.y-0.2f,V_Study.z);
		}else if (DoorNum==1)
		{
			Player.transform.position=V_Kitchen;
		}else if (DoorNum==2)
		{
			Player.transform.position=V_Living0;
			
		}else if (DoorNum==3)
		{
			Player.transform.position=V_Living1;			
		}
		DoorOpenAudio.GetComponent<AudioSource>().Play();
	}
	public void Exit(){
		Application.Quit();
	}

}
