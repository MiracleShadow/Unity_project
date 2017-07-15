using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	#region 单例模式
	//静态变量
	static GameController instance;
	//静态变量实例化
	void Awake()
	{
		instance = this;
	}
	//对外界提供一个可以访问静态市里的属性或方法
	public static GameController Instance{
		get {
			return instance;	
		}
	}
	#endregion

	//敌机初始位置
	public Transform EnemyTransfrom;
	//飞机预设体
	public GameObject EnemyPrefab;

	//玩家飞机预设体
	public GameObject playerPerfab;

	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	//计时器
	float timer = 0;	//用于计时：一秒产生一只敌机
	float lefttime = 0;	//无敌时间
	float timer_B = 0;	//波次间间隔时间
	int jsq = 1;		//累计波次

	public int score = 0;

	void Update () {
		if(player){
			timer_B += Time.deltaTime;
			if(timer_B <= jsq*5)
				GameRule ();//产生敌机
			if(timer_B >= jsq*5+5){
				jsq++;
				timer_B = 0;
			}
		}
		else {
			jsq = 1;
			timer_B = 0;
		}
	}
	//游戏规则：一秒产生一只敌机
	void GameRule(){
		timer += Time.deltaTime;
		if(timer >= 1.0){
			timer = 0;
			float randomX = Random.Range (-4.5f, 4.5f);
			Vector3 enemPos = new Vector3 (randomX, 6, -1);
			GameObject.Instantiate (EnemyPrefab, enemPos, EnemyPrefab.transform.rotation);
		}
	}
	//持续调用，用于刷新界面
	void OnGUI(){
		//显示分数
		Rect scoreRect = new Rect (Screen.width-180,30, 100, 30);
		GUI.Label (scoreRect, "人生经验:" + score);

		//剩余血量
		if(player!=null){
			Rect nowHP = new Rect (Screen.width-180,50, 100, 30);
			GUI.Label (nowHP, "-1s：" + player.gameObject.GetComponent<PlayerController>().HP/10);
		}

		//显示子弹伤害
		Rect EnemyHeat = new Rect (Screen.width-180,70, 100, 30);
		GUI.Label (EnemyHeat, "批判の力：" + (10+10*(score/300)));

		//退出按键
		Rect QuitBtnRect = new Rect (20, 30, 100, 50);
		if(GUI.Button(QuitBtnRect,"I'am angry")){
			Application.Quit ();
		}

		if(player==null){
			//中间的文本
			Rect textRect = new Rect (Screen.width/2-100,Screen.height/2-30,200,60);
			//文本样式
			GUIStyle textStyle = new GUIStyle();
			textStyle.normal.textColor = Color.white;
			textStyle.fontSize = 25;
			textStyle.alignment = TextAnchor.MiddleCenter;
			//60以下 :too young，too simple    60~90:sometimes naive   90~150:美国的华莱士不知道比你高到哪里去了 
			if(score<100){
				GUI.Label (textRect, "你毕竟还是too young,too simple!" + score, textStyle);
			}else if(score < 300){
				GUI.Label (textRect, "sometimes naive" + score, textStyle);
			}else if(score < 500){
				GUI.Label (textRect, "美国的华莱士不知道比你高到哪里去了" + score, textStyle);
			}else {
				GUI.Label (textRect, "中央决定了，你来当特首！" + score, textStyle);
			}

			Rect ReStariBtnRect = new Rect (Screen.width/2-50,textRect.y/2+70,100,20);
			if(GUI.Button(ReStariBtnRect,"ReStart!!")){
				Vector3 playerPos = new Vector3 (0, -4.4f, -1);
				player = GameObject.Instantiate (playerPerfab, playerPos, playerPerfab.transform.rotation);
				score = 0;//游戏分数清零
				lefttime = 0;
			}
		}

		if (player != null && lefttime <= 10f){
			player.gameObject.GetComponent<PlayerController>().HP = 30;//无敌时间
			Rect lifttimeRect = new Rect (Screen.width/2-100,Screen.height/2-30,200,60);
			GUI.Label (lifttimeRect, "蛤蛤附体"+(10f-lefttime));
		}
		lefttime += Time.deltaTime;

	}
}
