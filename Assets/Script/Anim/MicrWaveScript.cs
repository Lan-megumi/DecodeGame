using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrWaveScript : MonoBehaviour {
	private GameObject Back,End,start;
	private Animator anim;
	private AudioSource Audio;
	public static MicrWaveScript _instance;

	// Use this for initialization
	void Start () {
		Back=GameObject.Find("MicrowaveBack");
		End=GameObject.Find("Microwave2");
		start=GameObject.Find("Microwave0");
		//init
		Back.GetComponent<SpriteRenderer>().enabled=false;
		End.GetComponent<SpriteRenderer>().enabled=false;
		start.GetComponent<SpriteRenderer>().enabled=false;

		anim=this.GetComponent<Animator>();
		Audio=this.GetComponent<AudioSource>();
	}

	void Awake()
	{
		_instance=this;
	}

	

	public void StarAnimate(){
		Debug.Log("开始播放！");

		InventoryScript._instance.ChangeInventoryimg(6);

		start.GetComponent<SpriteRenderer>().enabled=true;

		Back.GetComponent<SpriteRenderer>().enabled=true;
		
		anim.SetInteger("Control",2);
		// Back.GetComponent<Animator>().Play("Microwave");
	}
	public void EndAnimate(){
		Audio.Play();
		Back.GetComponent<SpriteRenderer>().enabled=false;
		start.GetComponent<SpriteRenderer>().enabled=false;
		PlayerPlatformerController1._instance.MicroWaveAniEnd();

		Debug.Log("播放结束！");

	}
	
}
