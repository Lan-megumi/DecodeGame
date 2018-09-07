using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextScript : MonoBehaviour {
	private bool IfText=false;
	private Text UiText;
	private string oldText;
	public static TextScript _instance;
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_instance=this;
	}
	// Use this for initialization
	void Start () {
		UiText=this.GetComponent<Text>();
	}
	public void ChangeText(string Text){
		if (oldText!=Text)
		{
			StopAllCoroutines();
			IfText=false;
		}
		if (IfText==true)
		{
			StopAllCoroutines();
			IfText=false;
		}
		UiText.text=Text;
		IfText=true;
		oldText=Text;
		StartCoroutine("ClearText");

	}
	IEnumerator ClearText(){
		yield return new WaitForSeconds(4f);
		UiText.text="";
	}
}
