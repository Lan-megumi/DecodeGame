using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Time0 : MonoBehaviour {


	private float timer_f = 0f;//最后时间
    private float timer_i = 0;//当前时间//秒

	public GameObject m_ClockText;
	public static Time0 _instance;
    private int m_Minute;//分
    private int m_Second;//秒
	public GameObject BgImage;//评分背景图片
	public GameObject AImage;//评分背景图片A
	public GameObject BImage;//评分背景图片B
	public GameObject CImage;//评分背景图片C
	public GameObject SImage;//评分背景图片S

	void Awake(){
		_instance=this;
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame  FixedUpdate
   void FixedUpdate(){
       timer_f = Time.time;
		this.rrr();
       Debug.Log(timer_f);
    }
	public float rrr(){
       timer_i=Mathf.FloorToInt(timer_f);
	   m_Second = (int)timer_i;
	   if(m_Second>59.0f){
		   m_Second=(int)(timer_i-(m_Minute*60));
		   //m_Second=0;
	   }
	   m_Minute = (int)(timer_i/60);
	      m_ClockText.GetComponent<Text>().text = m_Minute+":"+ m_Second+"";
        // m_ClockText.GetComponent<Text>().text = string.Format("%M %M",m_Minute,timer_i); 
		//  m_ClockText.GetComponent<Text>().text = timer_i+"";
		
	     //m_ClockText.GetComponent<Text>().text = "11111"; 

		return timer_i;
	}
	public void Settlement(){
			BgImage.SetActive(true);
			if(timer_i > 600){
				CImage.SetActive(true);
			}else if(timer_i < 600 && timer_i>360){
				BImage.SetActive(true);
			}else if(timer_i < 360 && timer_i > 240){
				AImage.SetActive(true);
			}else if(timer_i < 240){
				SImage.SetActive(true);
			}

	}
	public void Butoon(){

	SceneManager.LoadScene(1);
}
}
