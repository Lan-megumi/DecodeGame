using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;


public class ComputerScript : MonoBehaviour {
	public static ComputerScript _instance;

	public Button[] Arr_Btn;
	public Sprite[] Arr_Spr,Arr_UnSpr;
	/*说明&&渲染顺序：
		Computer：用于电脑Ui	
		All_Button:所有button的父部件
		Deatil:所有任务说明栏(Details);
	 */
	private GameObject Deatil,Computer,All_Button;
	int N_Btn;
	private ChoseSceManager choseSceManager;
	// Use this for initialization
	void Awake(){
		_instance=this;
	}
	void Start () {
		Deatil=GameObject.Find("Computer_Canves/Menu/Details");
		Computer=GameObject.Find("Computer_Canves/Computer");
		All_Button=GameObject.Find("Computer_Canves/Button");
		Deatil.SetActive(false);
		Computer.SetActive(false);
		All_Button.SetActive(false);
		Debug.Log(Arr_Spr[0]);

		choseSceManager=gameObject.GetComponent<ChoseSceManager>();

	}
	

	/*
		该方法用于绑定按钮，根据传回的值不同启用第x个按钮
	 */
	public void BtnOnClick(int i){
		
		if (i==0)
		{
			ChangeBtn_Ui(0);
			Deatil.SetActive(true);
		}
		if (i==1)
		{
			ChangeBtn_Ui(1);
			
		}
		choseSceManager.DoorOpen0(true);
		N_Btn=i;
	}
	public void ExitBtn(){
		ShowUi(false);
	}

	public void ShowUi(bool b){
		if (b==true)
		{
			Computer.SetActive(true);
			All_Button.SetActive(true);
		}else{
			Computer.SetActive(false);
			All_Button.SetActive(false);
			Deatil.SetActive(false);
			
		}
	}

	public int GetLoad(){
		return N_Btn;
	}

	/*
	该方法用于改变Computer-Btn的选中效果
		实现一个类似多个选项的单选效果
	 */
	private void ChangeBtn_Ui(int a){
		for (int i = 0; i < Arr_Btn.Length; i++)
		{
			Arr_Btn[i].GetComponent<Image>().sprite=Arr_UnSpr[i];
		}
		Arr_Btn[a].GetComponent<Image>().sprite=Arr_Spr[a];

	}


}
