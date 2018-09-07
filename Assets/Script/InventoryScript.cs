using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
背包系统流程：
	用户按下指定按钮 c 时：
	执行方法 ChangeInventory() 判断是否有该物品 
	在ChangeInventory方法下会执行一个循环，切换到下一物品
	根据数组 goods[i] 判断是否为，否则跳出循环并将i作为返回值导出给其他方法调用
	随后调用改变图片方法 ChangeInventoryimg(int) ，传参i

	-------存在问题
	初始值在游戏中什么都没有情况下若触发了该循环会怎么样（测试后无出先BUG）
	鸡蛋放入后需要让物品栏中的鸡蛋UI消失
	物品无法重头循环启用
		*增加一个判断，区别开所有物品都没有 (ArrNum==0) 的情况，并且判断数组最后一个数是否等于0
		*当你持有最后一个物品时会执行到 init 部分，所以会自动从头开始
 */
public class InventoryScript : MonoBehaviour {

	// Use this for initialization
	public GameObject InventoryUi;						//绑定更改图片的组件
	public static InventoryScript _instance;
	public Sprite[] InventoryImg;					//用于储存图片的数组，第7个是一个空数组
	private int [] goods={0,0,0,0,0,0,0,0};		//用于储存会否获取到物品的判断用数组
	void Start(){

	}
	void Awake(){
		_instance=this;
	}
	//----------------------

	void Update(){
		if (Input.GetKeyDown(KeyCode.C))
		{
			ChangeInventory();
		}
	}
	//----------------------
	private int Num,ArrNum=0;
	public int ChangeInventory(){
		// ArrNum=Num;
		Debug.Log("ArrNum="+ArrNum);

		if (ArrNum>=goods.Length)								//防止 ArrNum 为最后一个数组时+1大于数组长度的情况
		{
			ArrNum=0;
			Debug.Log("init");
		}
		for (int i = ArrNum; i <goods.Length; i++)
		{
			Debug.Log("第"+i+"个数组="+goods[i]);

			if (goods[i]!=0)
			{
				Num=i;											//给用于储存 传参、返回 的Num赋值
				ArrNum=i+1;										//为下一次按下做准备

				ChangeInventoryimg(Num);
				Debug.Log("++");
				break;
			}else if (ArrNum!=0&&goods[goods.Length-1]==0)		//用于判断是否需要重新循环
			{
				ArrNum=0;
				Debug.Log("返回初始");
				ChangeInventoryimg(6);
			}
		}
		return Num;
	}

	public int GetInventory(){
		return Num;
	}
	public void ChangeInventoryimg(int i){
		// Debug.Log("ChangeImg! i"+i);
		if (i==0)
		{
			InventoryUi.GetComponent<Image>().sprite=InventoryImg[i];
		}
		if (i==1)
		{
			InventoryUi.GetComponent<Image>().sprite=InventoryImg[i];
			
		}
		if (i==2)
		{
			InventoryUi.GetComponent<Image>().sprite=InventoryImg[i];
			
		}
		if (i==3)
		{
			InventoryUi.GetComponent<Image>().sprite=InventoryImg[i];
			
		}
		if (i==4)
		{
			InventoryUi.GetComponent<Image>().sprite=InventoryImg[i];
			
		}
		if (i==5)
		{
			InventoryUi.GetComponent<Image>().sprite=InventoryImg[i];
			
		}
		if (i==6)
		{
			//该数组下的没有图片
			InventoryUi.GetComponent<Image>().sprite=InventoryImg[i];

		}
		if (i==7)
		{
			InventoryUi.GetComponent<Image>().sprite=InventoryImg[i];
			
		}
		Debug.Log("---------------------");
	}
/*
	下面方法用于写入物品键值
		0 - 铁钩 MasterKey
		1 - 除锈剂 Toliet_Key
		2 - 书房钥匙 Study_Key
		3 - 衣柜钥匙 Chest_Key
		4 - 保险柜钥匙 Steal_Key
		5 - 鸡蛋 Egg
		6 - 鸡蛋消失 Egg
		7 - 梯子 Ladder
 */
	public void WriteInventory(int o){
		if (o==0)
		{
			goods[0]=1;
		}else if (o==1)
		{
			goods[1]=1;
		}else if (o==2)
		{
			goods[2]=1;
		}else if (o==3)
		{
			goods[3]=1;
		}else if (o==4)
		{
			goods[4]=4;
		}else if (o==5)
		{
			goods[5]=1;
		}else if (o==6)
		{
			goods[5]=0;					//鸡蛋消失
		}else if (o==7)
		{
			goods[7]=1;
		}
		
	}

}
