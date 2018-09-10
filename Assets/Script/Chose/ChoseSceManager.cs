using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChoseSceManager : MonoBehaviour {
	public static ChoseSceManager _instance;

	private GameObject Door_open,Door_close,Chose_open,Chose_close;
	// Use this for initialization
	void AWake () {
		_instance=this;
	}
	void Start(){
		Door_open=GameObject.Find("Door_open");
		Door_close=GameObject.Find("Door_close");

		Chose_open=GameObject.Find("Chose_open");
		Chose_close=GameObject.Find("Chose_close");

		Chose_open.SetActive(false);
		Door_open.SetActive(false);
	}

	public void Open_Or_Close(bool state0){
		if (state0==true)
		{
			Chose_open.SetActive(true);
			Door_open.SetActive(true);

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
	
}
