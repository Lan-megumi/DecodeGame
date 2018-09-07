using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	该脚本用于实现淡出淡入效果
	1.通过改变目标下的组件Color来实现效果，使用 new Color(R,G,B,Alpha)中Alpha不透明度试时变化实现效果
	2.实时变化使用 Time.deltaTime来改变
	3.淡入 不透明 -> 透明 即应当不断增加Alpha，故而 If_alpha 变量应调整为正值+1,
	4.淡出 透明 -> 不透明 
 */
public class OneScript : MonoBehaviour {
	public GameObject FadeOut;				//需要改变透明度的物体
	public float alpha=0;					//用于改变透明度a的变量
	private float Speed=0.3f;				//用于改变透明度变化速度的变量
	private float If_alpha=1;				//用于改变淡出/淡入效果的变量
	public float PanelAlpha;				//（测试用）用于实时查看被改变透明度物体的alpha值

	public static OneScript _instance;
	void Awake(){
		_instance=this;
	}


	/*
		在OnGUi下不断改变alpha值
		我设置了 alpha 在-1 和 2 区间内才进行更改alpha值，节省资源
	 */
	void OnGUI(){
		if (alpha>-1f&&alpha<2f)
		{
			PanelAlpha=FadeOut.GetComponent<Image>().color.a;

			alpha+=If_alpha*Speed*Time.deltaTime;
			Debug.Log(alpha);
			FadeOut.GetComponent<Image>().color=new Color(0,0,0,alpha);
		}
	}
	/*
		按钮改变淡出淡入
		1.支持实时改变
		2.默认状态为淡出
	 */
	public void Fade(){
		if (If_alpha==1f)
		{
			If_alpha=-1f;
			if (alpha>1f)
			{
			//监测是否超过100%
				alpha=1f;
				Fade();
			}
		}else
		{
			If_alpha=1f;
			if (alpha<0)
			{
				alpha=0;
			}
		}
		
	}
}
