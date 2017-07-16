using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {
	/*
	 * 通过控制材质球的显示的图片让小鸟做序列帧动画
	*/

	#region
	static BirdController instance;	//静态实例类

	void Awake(){			//在Awake中赋值
		instance = this;
	}

	//对外提供一个访问路径
	public static BirdController Instance{
		get{
			return instance;
		}
	}
	#endregion

	int FrameNumber = 10;	//1秒做几帧
	int framCount =0;		//当前做到第几帧
	float timer =0;			//计时器
	int speed = 2;			//小鸟的速度
	Rigidbody rb;
	public AudioClip WingAC;//小鸟飞行翅膀的声音
	public AudioClip DieAC;	//小鸟死亡的声音
	public AudioClip HitAC;	//小鸟撞击的声音
	public bool isAlive = true;	//小鸟生死状态

	// Use this for initialization
	void Start () {
		
		rb = gameObject.GetComponent<Rigidbody> ();		//获取小鸟身上的刚体组件

		rb.velocity = Vector3.right * speed;			//通过刚体添加一个速度
	}
	
	// Update is called once per frame
	void Update () {
		if(isAlive){
			
			FrameAnimation ();		//播放序列帧动画

			Move ();				//控制玩家小鸟移动

		}
	}

	//小鸟碰到障碍物
	void OnCollisionEnter(Collision other){
		AudioSource.PlayClipAtPoint(HitAC, transform.localPosition);	//播放撞击音效
		AudioSource.PlayClipAtPoint(DieAC, transform.localPosition);	//播放死亡音效
		rb.velocity = Vector3.zero;		//速度为0，直接掉下去
		gameObject.GetComponent<SphereCollider> ().isTrigger = true;	//设为触发器
		isAlive = false;
		//GameObject.Destroy (gameObject);
	}

	void FrameAnimation(){			//序列帧动画
		
		timer += Time.deltaTime;		//累加计时

		if(timer >= 1.0f/FrameNumber){		//是否超过动画帧

			timer = 0;			//清空计时器

			framCount++;		//累加帧数

			int index = framCount % 3;		//接下来显示第几段图片

			gameObject.GetComponent<Renderer> ().material.
			SetTextureOffset("_MainTex",new Vector2(index * 0.3333f,0));//设置材质球偏移量
		}
	}

	void Move(){
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")){
			rb.velocity = Vector3.up * speed * 3 + Vector3.right * speed;
			//rb.velocity = new Vector3 (rb.velocity.x, 5f, rb.velocity.z);
			AudioSource.PlayClipAtPoint(WingAC, transform.localPosition);
		}
	}
}
