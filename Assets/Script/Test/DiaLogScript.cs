using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiaLogScript : MonoBehaviour {
	private GameObject DiaLog;
	private Image BackStyle;
	private GameObject T_Name,T_Note;

	// Use this for initialization
	void Start () {
	}
	public void DialogBox(string Name,string Note){
		this.gameObject.SetActive(true);
		T_Name=GameObject.Find("Dialog/NameText");
		T_Name.GetComponent<Text>().text=Name;

		T_Note=GameObject.Find("Dialog/NoteText");
		T_Note.GetComponent<Text>().text=Note;
	}

}
