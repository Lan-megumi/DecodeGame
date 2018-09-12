using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Video;

using UnityEngine.UI;



public class MoviePlay : MonoBehaviour {
	public GameObject StarMovie,WinMovie;
	public static MoviePlay _instance;

	private bool IF_StarM=false,If_WinM=false;

	void Awake(){
		_instance=this;
	}
	// public MovieTexture StarMovieTexture;
	// Use this for initialization
	void Start () {
		StarMovie.SetActive(false);
		WinMovie.SetActive(false);


	}
	
	
	// Update is called once per frame
	void Update () {
		if (StarMovie.GetComponent<VideoPlayer>().isPlaying==false&&IF_StarM!=false)
		{
			StarMovie.SetActive(false);
			Debug.Log("StarMovie End");
			IF_StarM=false;
		}
		if (WinMovie.GetComponent<VideoPlayer>().isPlaying==false&&If_WinM!=false)
		{
			WinMovie.SetActive(false);
			Debug.Log("WinMovie End");
			// SceneManager.LoadScene(1);
			 Time0._instance.Settlement();
			If_WinM=false;

		}
	}
	public void Play_StarMovie(){
		IF_StarM=true;
		StarMovie.SetActive(true);

		StarMovie.GetComponent<VideoPlayer>().Play();
		Debug.Log("StarMovie Star");

	}
	public void Play_WinMovie(){
		If_WinM=true;
		WinMovie.SetActive(true);

		WinMovie.GetComponent<VideoPlayer>().Play();
		Debug.Log("WinMovie Star");

	}
}
