using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatScript : MonoBehaviour {
	public GameObject Chat,ChatText;
	private bool IfChat=false,IfAdd=true;
	float n=0,m=0;
	// Use this for initialization
	void Start () {
		Chat=GameObject.Find("Chose_Computer/Chat");
		ChatText=GameObject.Find("Chose_Computer/Chat_Text01");
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
}
