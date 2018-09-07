using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStructural : MonoBehaviour {
	//该脚本用于储存玩家是否有剧情物品
	public struct Precious{
		//masterkey:铁钩
		public int study_key,
		toilte_key,chest_key,steel_key,
		masterkey,winKnief,egg;
	}
	
	Precious precious = new Precious();
	void Start()
	{
		initStruct();
	}
	//初始化
	public Precious initStruct(){
		precious.study_key=0;
		precious.toilte_key=0;
		precious.chest_key=0;
		precious.steel_key=0;
		precious.masterkey=0;
		precious.winKnief=0;
		precious.egg=0;
		return precious;
	}
	public Precious ReedStruct(){
		return precious;
	}
	public Precious WriteStu_key(int i){
		precious.study_key=i;
		Debug.Log("获得书房钥匙！");
		InventoryScript._instance.WriteInventory(2);
		return precious;
	}
	public Precious WriteEgg(int i){
		precious.egg=i;
		Debug.Log("获得"+i+"鸡蛋！");
		if (i!=0)
		{
			InventoryScript._instance.WriteInventory(5);
		}else
		{
			InventoryScript._instance.WriteInventory(6);
		}

		return precious;
	}

	public Precious WriteToilet_key(int i){
		precious.toilte_key=i;
		Debug.Log("获得除锈剂！");
		InventoryScript._instance.WriteInventory(1);

		return precious;
	}
	public Precious WriteChest_key(int i){
		precious.chest_key=i;
		Debug.Log("获得衣柜钥匙！");
		InventoryScript._instance.WriteInventory(3);

		return precious;
	}
	public Precious WriteStell_key(int i){
		precious.steel_key=i;
		Debug.Log("获得保险柜钥匙！");
		InventoryScript._instance.WriteInventory(4);

		return precious;
	}
	public Precious WriteMaster_key(int i){
		precious.masterkey=i;
		Debug.Log("获得铁钩！");
		InventoryScript._instance.WriteInventory(0);

		return precious;
	}
	public Precious WriteWinKnief(int i){
		precious.winKnief=i;
		Debug.Log("获得目的物品！");
		return precious;
	}
}
