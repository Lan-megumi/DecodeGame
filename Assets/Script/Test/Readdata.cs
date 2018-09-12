using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LitJson;
using UnityEngine.UI;

public class Readdata : MonoBehaviour {


	public GameObject two;
	private void LoadByJson(){
		string filePath = Application.dataPath + "/StreamingFile" + "/byJson.json";
		if(File.Exists(filePath))
		{
			//创建一个StreamReader, 用来读取流
			StreamReader sr = new StreamReader(filePath);
			//将读取到的流赋值给jsonStr
			string jsonStr = sr.ReadToEnd();
			//关闭
			sr.Close();
			//将字符串jsonStr转换为Save对象
			Save save = JsonMapper.ToObject<Save>(jsonStr);
			SetGame(save);

		}else{
			Debug.Log("存档不存在");
		}
	}
	//通过读档信息重置我们的游戏状态
	private void SetGame(Save save){

		for(int i = 0; i < save.doors.Count;i++){
			int position  = save.doors[i];
		}
		Debug.Log("position");
	}
	private void LoadGame(){
		if(two == true){
			LoadByJson();
		}
	}
}
