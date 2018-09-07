using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour {
	private GameObject Ladder;
	private Transform StandPoint;
	private Vector3 V_StandPoint,V_Ladder,V_Player;
	public  Transform Player;
	public static LadderScript _instance;
	// Use this for initialization
	void Start () {
		Ladder=GameObject.Find("Ladder");

		StandPoint=GameObject.Find("StandPoint").transform;
		V_StandPoint=StandPoint.position;

		Player=GameObject.Find("PennyPixel").transform;
		V_Player=Player.position;

		Ladder.GetComponent<PolygonCollider2D>().enabled=false;

	}
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_instance=this;
	}
	public void GoStandPoint(){
		V_Player=Player.position;
		Ladder.GetComponent<BoxCollider2D>().enabled=true;
		Ladder.GetComponent<SpriteRenderer>().enabled=true;
		Ladder.GetComponent<PolygonCollider2D>().enabled=true;
		
		// Debug.Log("0");
		Ladder.transform.position=new Vector3(V_Player.x,V_Player.y+0.8f,V_Player.z);
		// StandPoint.transform.position=new Vector3(V_Player.x,V_Player.y+1.2f,V_Player.z);
		// Debug.Log("1");
		V_StandPoint=StandPoint.position;
		Player.transform.position=V_StandPoint;
		// Debug.Log("2");
		// Player.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Static;
	}
	public void OutStandPoint(){
		Ladder.GetComponent<SpriteRenderer>().enabled=false;
		Ladder.GetComponent<BoxCollider2D>().enabled=false;
		Ladder.GetComponent<PolygonCollider2D>().enabled=false;

		Player.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Kinematic;

	}
	 
}
