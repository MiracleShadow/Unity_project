using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerController : MonoBehaviour {

	#region
		static GamerController instance;	//静态实例类

		void Awake(){			//在Awake中赋值
			instance = this;
		}

		//对外提供一个访问路径
		public static GamerController Instance{
			get{
				return instance;
			}
		}
	#endregion

	public int score = 0;		//记录分数

	public Transform lastBGTransform;	//记录最后一个背景Transform 


	public GameObject playerPerfab;		//玩家飞机预设体

	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Bird");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI(){
		Rect scoreRect = new Rect (Screen.width - 180, 30, 100, 30);
		GUI.Label (scoreRect, "分数：" + score);


		var groundWidth = 120;  
		var groundHeight = 150;  

		var screenWidth = Screen.width;  
		var screenHeight = Screen.height;  

		var groupx = (screenWidth - groundWidth) / 2;  
		var groupy = (screenHeight - groundHeight) / 2;  

		if(player.gameObject.GetComponent<BirdController> ().isAlive == false){
			
			Rect BeginGroupRect =new Rect (groupx, groupy, groundWidth, groundHeight);
			GUI.BeginGroup(BeginGroupRect);

			Rect BoxRect = new Rect (0, 0, groundWidth, groundHeight);
			GUI.Box(BoxRect," 选 项 ");

			Rect QuitRect = new Rect (10, 30, 100, 30);
			if(GUI.Button(QuitRect,"退出游戏")){
				Application.Quit ();
			}

			Rect RebeginRect = new Rect (10, 70, 100, 30);
			if(GUI.Button(RebeginRect,"重新开始")){
				GameObject.Destroy (player.gameObject);
				Vector3 playerPos = new Vector3 (-10f, 0, -2f);			//重新开始后新鸟的位置
				player = GameObject.Instantiate (playerPerfab, playerPos, playerPerfab.transform.rotation);
				score = 0;//游戏分数清零
			}

			Rect textRect = new Rect(10,110,100,30);
			GUIStyle textStyle = new GUIStyle();
			textStyle.normal.textColor = Color.white;	//字体颜色
			textStyle.fontSize = 20;					//字体大小
			GUI.Label (textRect, "得分：" + score, textStyle);
		}
	}
}
