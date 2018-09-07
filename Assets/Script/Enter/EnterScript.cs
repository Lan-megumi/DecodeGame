using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnterScript : MonoBehaviour {
	public RawImage Image,BackImage;
	public MovieTexture Movie;
	public MovieTexture BackMovie;
	public GameObject Go,End,Archives_room,Achievement;

	private int i = 0;

	// Use this for initialization
	void Start () {
		Screen.SetResolution(1280,720,true);
		Movie.loop=false;
		Image.texture=Movie;//设置 RawImage 纹理为电影
		// BackMovie.Play();
		Movie.Play();
		Go.SetActive(false);
		End.SetActive(false);
		Archives_room.SetActive(false);

		Achievement.SetActive(false);


		
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (i==0)
		{
			if (Movie.isPlaying)
			{
				
			}else
			{	
				BackImage.GetComponent<RawImage>().enabled=true;
				Go.SetActive(true);
				End.SetActive(true);
				Archives_room.SetActive(true);
				Achievement.SetActive(true);

				BackImage.color=new Color(1,1,1,100);
				BackMovie.loop=true;
				BackImage.texture=BackMovie;
				BackMovie.Play();
				

					
				i++;
			}
		}
		
	}
	public void GoVoid(){
		SceneManager.LoadScene(3);
	}
	public void EndVoid(){
		Debug.Log("Exit Game!");
		Application.Quit();
	}
	
}
