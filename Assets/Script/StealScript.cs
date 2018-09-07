using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StealScript : MonoBehaviour {
	public GameObject StealInsideImg;
	public Sprite OpenStealInside;
	private GameObject btn,Exit_btn,Knief,KniefBtn;
	public static StealScript _instance;
	void Awake(){
		_instance=this;
	}
	// Use this for initialization
	void Start () {
		btn=GameObject.Find("StealInSide/Button");
		Exit_btn=GameObject.Find("StealInSide/Exit");
		Knief=GameObject.Find("StealInSide/Knife");
		KniefBtn=GameObject.Find("StealInSide/Knife/KnifeBtn");

		btn.GetComponent<Button>().enabled=false;
		Exit_btn.SetActive(false);

		KniefBtn.GetComponent<Button>().enabled=false;

		StealInsideImg.GetComponent<Image>().enabled=false;
		Knief.GetComponent<Image>().enabled=false;

	}
	//该方法用于绑定触发暗格的按钮
	public void FindKnief(){
		if (InventoryScript._instance.GetInventory()==0)
		{
			StealInsideImg.GetComponent<Image>().sprite=OpenStealInside;
			Knief.GetComponent<Image>().enabled=true;
			KniefBtn.GetComponent<Button>().enabled=true;
			btn.SetActive(false);
		}else
		{
			TextScript._instance.ChangeText("");
		}
	}
	//该方法用于显示Ui的按钮
	public void ShowStealUi(){
		btn.GetComponent<Button>().enabled=true;
		StealInsideImg.GetComponent<Image>().enabled=true;
		Exit_btn.SetActive(true);

		PlayerPlatformerController1._instance.Con_Player(false);

	}

	public void ExitUi(){
		PlayerPlatformerController1._instance.Con_Player(true);

		btn.GetComponent<Button>().enabled=false;
		StealInsideImg.GetComponent<Image>().enabled=false;
		Exit_btn.SetActive(false);
	}
	//该方法用于最终获取小刀的方法
	public void GetKniefBtn(){
		//获取声音
		this.GetComponent<AudioSource>().Play();
		TextScript._instance.ChangeText("获得最后的任务物品!");
		PlayerPlatformerController1._instance.AddKnief();						//将小刀获得写入数据中
		new WaitForSeconds(2f);
		Knief.GetComponent<Image>().enabled=false;
		KniefBtn.GetComponent<Button>().enabled=false;

	}
}
