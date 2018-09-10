using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PhysicsObject {
	public float maxSpeed = 7;
    private SpriteRenderer spriteRenderer;
    Vector2 move = Vector2.zero;   
	// Use this for initialization
    private Animator animator;

	 void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();
    }
	protected override void ComputeVelocity(){
		 move.x = Input.GetAxis ("Horizontal");//人物左右移动

        if(move.x > 0.01f)
        {
            //↓该部分代码注释后结果：人物动画无法转身移动
            if(spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        } 
        else if (move.x < -0.01f)
        {
            if(spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }
        //↓改变是否接触地面？
        animator.SetBool ("grounded", grounded);
        //↓控制动画播放速度
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
	void OnTriggerStay2D(Collider2D Collections){
		if (Collections.gameObject.name==("Door_close")&&Input.GetKeyDown(KeyCode.Z))
		{
			Debug.Log("Door_close");
		}

		if (Collections.gameObject.name==("Door_open")&&Input.GetKeyDown(KeyCode.Z))
		{
			Debug.Log("Door_open");
		}

		if (Collections.gameObject.name==("Chose_Computer")&&Input.GetKeyDown(KeyCode.Z))
		{
			Debug.Log("Chose_Computer");
		}
	}
}

