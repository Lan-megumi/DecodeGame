using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChoseSceManager : MonoBehaviour {

	public GameObject Door_open,Door_close,Chose_open,Chose_close;
	public GameObject two;//第二关显示
	// Use this for initialization
	
	void Start(){
		// Door_open=GameObject.Find("Door_open");
		// Door_close=GameObject.Find("Door_close");

		// Chose_open=GameObject.Find("Chose_open");
		// Chose_close=GameObject.Find("Chose_close");

		Chose_open.SetActive(false);
		Door_open.SetActive(false);
		Debug.Log("1111");
	}

	public void DoorOpen0(bool state0){
		Debug.Log(0);

		if (state0==true)
		{
			Chose_open.SetActive(true);
			Door_open.SetActive(true);
			Debug.Log(1);
			Chose_close.SetActive(false);
			Door_close.SetActive(false);
		}else
		{
			Chose_open.SetActive(false);
			Door_open.SetActive(false);

			Chose_close.SetActive(true);
			Door_close.SetActive(true);
		}
	}
	public void GoScenc(int a){
		if (a==0)
		{
			SceneManager.LoadScene(2);
		}
		if (a==1)
		{
			Debug.Log("Null Scence");
		}
		
	}
}
