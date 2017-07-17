using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {
	AudioSource[] birdASs;
	//通过控制材质球的显示让小鸟做序列帧动画
	//一秒做几帧
	int FrameNumber=10;
	//当前做到第几帧
	int FrameCount=0;
	//计时器
	float timer=0;
	float speed=5;
	Rigidbody rb;
	public bool isAlive = true;

	void Start () {
		rb =gameObject.GetComponent<Rigidbody> ();
		rb.velocity = Vector3.right * speed;
		birdASs = GetComponents<AudioSource> ();
	}

	void Update () {
		//rb.velocity = Vector3.right * speed;//测试用的语句
		if(isAlive==true){
			//播放序列帧动画
			FrameAnimation ();
			if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0)){
				rb.velocity = new Vector3 (rb.velocity.x, 5, rb.velocity.z);
				birdASs [0].Play ();
			}
		}

	}

	//碰撞事件
	void OnCollisionEnter(Collision other){
		//速度为0，直接掉落下去,修改成触发器
		birdASs [1].Play ();
		rb.velocity = Vector3.zero;
		gameObject.GetComponent<SphereCollider> ().isTrigger = true;
		isAlive = false;
		GameController.Instance.gameover = true;
	}

	//序列帧动画
	void FrameAnimation (){
		timer += Time.deltaTime;
		//是否超过动画帧的时间
		if(timer>=1.0f/FrameNumber){
			//清空计时器0
			timer = 0;
			//累加帧数
			FrameCount++;
			//接下来显示第几段图片
			int index = FrameCount % 3;
			MeshRenderer mr = gameObject.GetComponent<MeshRenderer> ();
			mr.material.SetTextureOffset ("_MainTex", new Vector2 (index * 0.333f, 0));
		}
	}

}
