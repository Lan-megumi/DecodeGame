using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.GetComponent<InputField> ().onValueChanged.AddListener (Changed_Value);
		transform.GetComponent<InputField> ().onEndEdit.AddListener (End_Value);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Changed_Value(string inp){
		// print ("正在输入："+inp);
		
	}
	public void End_Value(string inp){

		// print ("文本内容："+inp);
		if (inp == "760908") {
			TextScript._instance.ChangeText("打开了保险箱！");

			StealScript._instance.ShowStealUi();
		}else{
				TextScript._instance.ChangeText("密码有误");

				Debug.Log("你输入有误");
		}
	}
}
