using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LitJson;

public class ChatScript : MonoBehaviour {
	public GameObject Chat,ChatText;
	public GameObject two;

	private bool IfChat=false,IfAdd=true;
	float n=0,m=0;
	// Use this for initialization
	void Start () {
		Chat=GameObject.Find("Chose_Computer/Chat");
		ChatText=GameObject.Find("Chose_Computer/Chat_Text01");
		LoadByJson();
	}
	
	void FixedUpdate(){
		if (IfAdd==true)
		{
			if (m<1)
			{
				m += 1f*Time.deltaTime*0.8f;
				Chat.GetComponent<SpriteRenderer>().color=new Color(255,255,255,m);
				if (m>1)
				{
					StartCoroutine("ChatTextAnim");
					
				}
			}

			if (n<1.3&&IfChat==true)
			{
				n += 1f*Time.deltaTime*0.5f;
				ChatText.GetComponent<SpriteRenderer>().color=new Color(255,255,255,n);
				StartCoroutine("ChatTextFalse");
			}		
		}else
		{
			if (n>-1)
			{
				n -= 1f*Time.deltaTime*0.8f;
				m -= 1f*Time.deltaTime*0.5f;
				ChatText.GetComponent<SpriteRenderer>().color=new Color(255,255,255,n);
				Chat.GetComponent<SpriteRenderer>().color=new Color(255,255,255,m);
			}
		}
		
		
	}
	IEnumerator ChatTextAnim(){
		yield return new WaitForSeconds(0.2f);
		IfChat=true;
	}
	IEnumerator ChatTextFalse(){
		yield return new WaitForSeconds(3f);
		// Chat.SetActive(false);
		// ChatText.SetActive(false);
		IfAdd=false;
	}
	
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
			int position = save.doors[i];
			Debug.Log(position);
			if(position == 1){
				two.SetActive(true);
			}else{
				Debug.Log("请过第一关");
			}
		}
		
}
public void Butoon(){

	SceneManager.LoadScene(1);
}
}
