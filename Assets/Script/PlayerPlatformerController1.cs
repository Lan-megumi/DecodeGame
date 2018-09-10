using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlatformerController1 : PhysicsObject {

    public float maxSpeed = 7;
    private SpriteRenderer spriteRenderer;
    Vector2 move = Vector2.zero;                    //共用移动
    private Animator animator;

//----------------------------------------

    public static PlayerPlatformerController1 _instance;
    private bool IfSteal,IfBorad,IfChest,IfStudyObj,IfFridge,IfLadder,IfCheckLadder,Iffchest,IffToiletKey,IfMasterKey=false;

    private bool If_LivingDoor=true,If_StealKey=true;
    private bool  isOpen=true;
    private GameObject Darak,BoradText,Open,Chest_Open;
    public Image ChestTips,FridgeTips,IdCard;
    // public RawImage WinImage;
    public GameObject Passwordlock;
    private int vv,zz = 0; //定义一个v/Z数值用来计算按V的次数以及初始值

	KeyStructural Get_Structural=new KeyStructural();

//----------------------------------------
    void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();
      
        _instance=this;
    }
//----------*跳跃部分--------------
    void Start()
    {
        Darak=GameObject.Find("Dark");
        BoradText=GameObject.Find("BoradText");
        Open = GameObject.Find("Fridge_Open");
        Chest_Open = GameObject.Find("Chest_Open");

        //init
        Darak.GetComponent<SpriteRenderer>().enabled=true;
        Open.GetComponent<SpriteRenderer>().enabled=false;
        Chest_Open.GetComponent<SpriteRenderer>().enabled=false;

        IdCard.GetComponent<Image>().enabled=false;
        BoradText.GetComponent<SpriteRenderer>().enabled=false;

        FridgeTips.GetComponent<Image>().enabled=false;
        // WinImage.GetComponent<RawImage>().enabled=false;

        StartCoroutine("StarPlay");
    }

    protected override void ComputeVelocity()
    {
    //----------------------   
        /*
            IfCheckLadder 判断是否正在使用梯子，False为未使用，True为正在使用
            IfLadder      判断是否获得了梯子
        */ 
        if (Input.GetKeyDown(KeyCode.X)&&IfLadder==true&&InventoryScript._instance.GetInventory()==7)
        {
            if (IfCheckLadder==false&&grounded)                 
            {
                LadderScript._instance.GoStandPoint();
                IfCheckLadder=true;
            }else if (IfCheckLadder==true)
            {
                LadderScript._instance.OutStandPoint();
                IfCheckLadder=false;  
            }else
            {
                TextScript._instance.ChangeText("那么粗暴使用梯子游戏会崩溃的！");
            }
            
        }
    //----------------------
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
//------------*判断玩家与什么物体进行碰撞----------
    private void OnTriggerEnter2D(Collider2D Collections)
    {
        if (Collections.CompareTag("Red"))
        {
            Debug.Log("保险箱被红外线所保护，怎么才能解除呢？");
            TextScript._instance.ChangeText("保险箱被红外线所保护，怎么才能解除呢？");
        }
    }
    void OnTriggerStay2D(Collider2D Collections)
    {
       //------------*判断玩家与坐便器物体进行碰撞----------
        if (Collections.gameObject.tag == "ToiletObject1") {
			if (Input.GetKeyDown (KeyCode.Z)) {
				vv++;
				if (Input.GetKeyDown (KeyCode.Z) && vv == 2) {
                    // Debug.Log("坐便器2");
                    Get_Structural.WriteStu_key(1);
                    Debug.Log(Get_Structural.ReedStruct().study_key);
                    TextScript._instance.ChangeText("获得一把钥匙！");
                    PlayGetAudio();
                    vv++;
				}else{
                    TextScript._instance.ChangeText("肮脏的坐便器");
                    Debug.Log("肮脏的坐便器");
                }
			}
		} 
        //------------判断玩家与坐便器物体进行碰撞*----------

        //------------*判断玩家与医疗箱物体进行碰撞----------
      
        if (Collections.gameObject.tag == "ToiletObject31"&&Input.GetKeyDown (KeyCode.Z)) {
            if (IfMasterKey!=true)
            {
                PlayGetAudio();
                Get_Structural.WriteMaster_key(1);
                TextScript._instance.ChangeText("发现一个铁钩！");
                IfMasterKey=true;
            }else{
                TextScript._instance.ChangeText("没有其他东西了");
            }               
		}
        //------------判断玩家与医疗箱物体进行碰撞*----------

        //------------*判断玩家与冰箱物体进行碰撞-----------
        if (Collections.gameObject.tag == "Fridge1"&&Input.GetKeyDown (KeyCode.Z)) {
            if (FridgeTips.GetComponent<Image>().enabled!=true)
            {
                if (zz == 1&&IfFridge==true) {//按第二次Z时出现鸡蛋
                    // Debug.Log("");
                    Open.GetComponent<SpriteRenderer>().enabled=true;
                    Get_Structural.WriteEgg(1);                                             //写入 物品系统 Egg=1
                    TextScript._instance.ChangeText("获得一个鸡蛋！");
                    PlayGetAudio();
                    zz++;
                    StartCoroutine("CloseFridge");                                          //执行关闭冰箱效果动画
                } else {
                    FridgeTips.GetComponent<Image>().enabled=true;
                    FridgeTips.GetComponent<AudioSource>().Play();
                    Debug.Log("冰箱小贴士");
                    
                    //按的次数超过两次出现的一直都是提示语
                }
            }
                
                
		}
        //------------判断玩家与冰箱物体进行碰撞*----------

        //------------*判断玩家与电箱物体进行碰撞----------
      
        if (Collections.gameObject.tag == "Switch1"&&Input.GetKeyDown (KeyCode.Z)) {
            GameObject SwitchObj=GameObject.Find("Switch");                                 //找到相对应的组件
            SwitchObj.GetComponent<AudioSource>().Play();
               if (IfBorad==false)                                                          //IfBorad 用于判断是否打开电闸，默认值为false
               {
                    Darak.GetComponent<SpriteRenderer>().enabled=false;
                    BoradText.GetComponent<SpriteRenderer>().enabled=true;
                    TextScript._instance.ChangeText("打开了电闸!");
                    IfBorad=true;
               }else{
                    Darak.GetComponent<SpriteRenderer>().enabled=true;
                    BoradText.GetComponent<SpriteRenderer>().enabled=false;
                    TextScript._instance.ChangeText("关闭了电闸!");
                    IfBorad=false;
               }         
		}
        //------------判断玩家与电箱物体进行碰撞*----------

        //------------*判断玩家与微波炉物体进行碰撞----------
        if (Collections.gameObject.tag == "Micrwave"&&Input.GetKeyDown (KeyCode.Z)) {
                if (Get_Structural.ReedStruct().egg!=0&&InventoryScript._instance.GetInventory()==5)
                {
                    Debug.Log("触发短路事件");
                    Get_Structural.WriteEgg(0);                                              //鸡蛋归零
		            InventoryScript._instance.WriteInventory(6);
                    InventoryScript._instance. ChangeInventory();
                    GameObject Microwave1=GameObject.Find("Microwave");
                    Microwave1.GetComponent<SpriteRenderer>().enabled=false;
                    Microwave1.GetComponent<BoxCollider2D>().enabled=false;
                    MicrWaveScript._instance.StarAnimate();
                }else
                {
                    TextScript._instance.ChangeText("这是一个微波炉，好像还可以用");
                    Debug.Log("这是一个微波炉，好像还可以用");
                } 
		}
        //------------判断玩家与微波炉物体进行碰撞*----------

        //------------*判断玩家与保险箱物体进行碰撞----------
        //If_StealKey 用于判断是否是第一次开启保险箱,默认值为True
        if (Collections.gameObject.tag == "Steal"&&Input.GetKeyDown (KeyCode.Z)) {
            if (If_StealKey==true)
            {
                if (Get_Structural.ReedStruct().steel_key!=0&&InventoryScript._instance.GetInventory()==4)
                {
                    //执行输入密码操作
                    Passwordlock.gameObject.SetActive(true);
                    If_StealKey=false;
                    
                }else{
                    TextScript._instance.ChangeText("保险箱好像需要一把钥匙");
                }       
            }else
            {
                Passwordlock.gameObject.SetActive(true);
            }
               
		}
        //------------判断玩家与保险箱物体进行碰撞*----------

        //------------*判断玩家与书房门物体进行碰撞----------
        //If_LivingDoor 用于判断是否为第一次使用钥匙 true为是，默认值为true
        if (Collections.gameObject.tag == "Living_Door1"&&Input.GetKeyDown (KeyCode.Z)) {  
            if (If_LivingDoor==true)
            {
                Debug.Log("true");

                if (Get_Structural.ReedStruct().study_key!=0&&InventoryScript._instance.GetInventory()==2)
                {
                    DoorScript._instance.MoveToDoor(0);
                    If_LivingDoor=false;
                }else{
                    TextScript._instance.ChangeText("没有书房的钥匙");
                }
            }else
            {
                DoorScript._instance.MoveToDoor(0);
                Debug.Log("else");
            }
              
		}
        //------------判断玩家与书房门物体进行碰撞*----------

        //------------*判断玩家与厕所门物体进行碰撞----------
        if (Collections.CompareTag("ToiletDoor")&&Input.GetKeyDown(KeyCode.Z))
       {
           if (Get_Structural.ReedStruct().toilte_key!=0&&InventoryScript._instance.GetInventory()==1)
           {
                LivindToilet._instance.OpenToiletDoor(); 
                TextScript._instance.ChangeText("使用除锈剂打开了厕所门！");
           }else
           {
                TextScript._instance.ChangeText("厕所门生锈卡住了");
           }
       }
        //------------判断玩家与厕所门物体进行碰撞*----------

        //------------*判断玩家与除锈剂物体进行碰撞----------
        if (Collections.CompareTag("l")&&Input.GetKeyDown(KeyCode.Z))
		{
            if(IffToiletKey!=true){
                Get_Structural.WriteToilet_key(1);
                PlayGetAudio();
                TextScript._instance.ChangeText("获得除锈剂！");
                IffToiletKey=true;
            }
			
		}
        //------------判断玩家与除锈剂物体进行碰撞*----------        

        //------------*判断玩家与书架物体进行碰撞----------
        if (Collections.CompareTag("BookObject")&&Input.GetKeyDown(KeyCode.Z))
		{
            if (IfStudyObj==false)
            {
			    Get_Structural.WriteChest_key(1);
                TextScript._instance.ChangeText("发现了一把钥匙！");
                PlayGetAudio();
                IfStudyObj=true;
                FridgeTips.GetComponent<AudioSource>().Play();

                ChestTips.GetComponent<Image>().enabled=true;

            }else
            {
                TextScript._instance.ChangeText("书架上没什么东西了");
            }
		}
        //------------判断玩家与书架物体进行碰撞*----------        

        //------------*判断玩家与衣柜物体进行碰撞----------
        if (Collections.CompareTag("Chest0")&&Input.GetKeyDown(KeyCode.Z))
		{
            if (Get_Structural.ReedStruct().chest_key!=0&&InventoryScript._instance.GetInventory()==3)
            {
                if(Iffchest!=true){
                     GameObject chset = GameObject.Find("chest");
                    chset.GetComponent<AudioSource>().Play();   
                    IdCard.GetComponent<Image>().enabled=true;
                    Chest_Open.GetComponent<SpriteRenderer>().enabled=true;
                    if (IfChest==false)
                    {
                        Get_Structural.WriteStell_key(1);
                        TextScript._instance.ChangeText("发现一把铁制的钥匙!");
                        PlayGetAudio();
                        IfChest=true;
                    }
                    StartCoroutine("CloseChest");
                }
               
            }else
           {
                TextScript._instance.ChangeText("衣柜锁住了");
            }
		}
        //------------判断玩家与衣柜物体进行碰撞*----------   
        
        //------------*判断玩家与沙发、凳子物体进行碰撞----------
        if (Collections.CompareTag("Desk")&&Input.GetKeyDown(KeyCode.Z))
        {
            TextScript._instance.ChangeText("这是一个凳子");
        }
        if (Collections.CompareTag("Sofa")&&Input.GetKeyDown(KeyCode.Z))
        {
            TextScript._instance.ChangeText("这是一个沙发");
        }          
        //------------判断玩家与沙发、凳子物体进行碰撞*----------   

        //------------*判断玩家与梯子物体进行碰撞----------
            if (Collections.CompareTag("Ladder")&&Input.GetKeyDown(KeyCode.Z))
            {
                if (IfLadder!=true)
                {
                    TextScript._instance.ChangeText("发现一个梯子似乎可以使用");
                    GameObject Ladder = GameObject.Find("Ladder");
                    Ladder.GetComponent<SpriteRenderer>().enabled=false;
                    InventoryScript._instance.WriteInventory(7);
                    IfLadder=true;
                }
            }
        //------------判断玩家与梯子物体进行碰撞*----------  

        //------------*判断玩家与外门物体进行碰撞----------
            if (Collections.CompareTag("Door")&&Input.GetKeyDown(KeyCode.Z))
            {
                if (Get_Structural.ReedStruct().winKnief!=0)
                {
                    TextScript._instance.ChangeText("收容成功！");
                    StartCoroutine("WinPlay");
                }else{
                    TextScript._instance.ChangeText("还未达成任务目标");
                }
            }
        //------------判断玩家与外门物体进行碰撞*----------        
    }
    private void OnTriggerExit2D(Collider2D Collections)
    {
         if (Collections.CompareTag("Steal"))
        {       
             Passwordlock.gameObject.SetActive(false);
        }

        if (Collections.CompareTag("Chest0")&&IdCard.GetComponent<Image>().enabled==true)
        {
            IdCard.GetComponent<Image>().enabled=false;
            TextScript._instance.ChangeText("这是一张身份证，上面有所有者的生日1976-09-08");
            Iffchest=false;
        }

        if (Collections.CompareTag("Fridge1")&&FridgeTips.GetComponent<Image>().enabled==true)
        {
            FridgeTips.GetComponent<Image>().enabled=false;
            if (IfFridge==false)
            {
                zz++;
                IfFridge=true;
            }
        }

        if (Collections.CompareTag("BookObject")&&ChestTips.GetComponent<Image>().enabled==true)
        {
            ChestTips.GetComponent<Image>().enabled=false;
        }

    }
//------------判断玩家与什么物体进行碰撞*----------

    public void MicroWaveAniEnd(){
        GameObject Micrwave2=GameObject.Find("Microwave2");
        Micrwave2.GetComponent<SpriteRenderer>().enabled=true;
        GameObject Red0=GameObject.Find("Red");
        Red0.GetComponent<SpriteRenderer>().enabled=false;
        Red0.GetComponent<BoxCollider2D>().enabled=false;
    }
    private void PlayGetAudio(){
        GameObject GetAudio = GameObject.Find("GameManager");
        GetAudio.GetComponent<AudioSource>().Play();
    }
   
    IEnumerator CloseFridge(){
        yield return new WaitForSeconds(1.2f);
        Open.SetActive(false);
    }
    IEnumerator CloseChest(){
        yield return new WaitForSeconds(1.2f);
        Chest_Open.GetComponent<SpriteRenderer>().enabled=false;
    }
    IEnumerator StarPlay(){
        yield return new WaitForSeconds(0.5f);
        MoviePlay._instance.Play_StarMovie();
    }
    IEnumerator WinPlay(){
        yield return new WaitForSeconds(0.5f);
        MoviePlay._instance.Play_WinMovie();
    }
    public void Con_Player(bool Con){
        if (Con==false)
        {
            this.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Static; 
            IfLadder=false;                                                         //关闭梯子  
        }else
        {
            this.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Kinematic;
            IfLadder=true;                                                          //开启梯子  
        }
    }
    public void AddKnief(){
        Get_Structural.WriteWinKnief(1);
    }

}