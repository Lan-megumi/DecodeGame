using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChoseSceScript : MonoBehaviour {
	public static ChoseSceScript _instance;

	void Awake(){
		_instance=this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BackBtn(){
		SceneManager.LoadScene(0);
	}
	public void ChoseSceBtn(int i){
		if (i==0)
		{
			SceneManager.LoadScene(2);
		}
		if (i==1)
		{
			// SceneManager.LoadScene(2);
		}
	}

	public void OpenSceBtn(int i){
		if (i==0)
		{
			
		}
		if (i==1)
		{
			// SceneManager.LoadScene(2);
		}
	}
}
