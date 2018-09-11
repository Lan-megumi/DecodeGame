using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class OutScene : MonoBehaviour {
	public RawImage image;
	public MovieTexture moive;
	
	public GameObject Button;

	private bool IfPlay=false;

/// <summary>
/// Start is called on the frame when a script is enabled just before
/// any of the Update methods is called the first time.
/// </summary>
	void Start()
	{
		Button.SetActive(false);
		StartCoroutine("Skip0");
		StartCoroutine("PlayAnimation");
	}

	void Update()
	{
		if (IfPlay==true)
		{
			if (moive.isPlaying)
			{
				
			}else
			{	
				SceneManager.LoadScene(3);
			}
		}
			
		
	}
	public void Skip(){
		moive.Stop();
		this.GetComponent<AudioSource>().Stop();
		SceneManager.LoadScene(3);
	}
	IEnumerator Skip0(){
		yield return new WaitForSeconds(4f);
		Button.SetActive(true);
		
	}
	IEnumerator PlayAnimation(){
		yield return new WaitForSeconds(1f);
		moive.loop=false;
		image.texture=moive;
		moive.Play();
		this.GetComponent<AudioSource>().Play();
		IfPlay=true;
		
	}
}