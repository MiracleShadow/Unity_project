using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenyController : MonoBehaviour {
	/*
	 * 飞机往下飞，速度为2
	*/
	// Use this for initialization
	//爆炸预设体
	public float speed = 2;
	public int HP = 10;
	public int damage = 10;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += Vector3.down * speed * Time.deltaTime;

		//超出一定范围后销毁
		if(transform.position.y < -6.2f){
			GameObject.Destroy (gameObject);
		}
	}
		
	//敌机碰到飞机就要销毁掉，玩家飞机扣血，扣完后判断剩余血量是否小于零
	//小于零玩家飞机销毁
	void OnCollisionEnter(Collision other)
	{
		//print ("peng!");
		if(other.gameObject.tag == "Player"){
			GameObject.Destroy (gameObject);//销毁敌机


			GameController.Instance.score += 10;
			other.gameObject.GetComponent<PlayerController> ().HP -= damage;
			if(other.gameObject.GetComponent<PlayerController> ().HP <= 0){
				GameObject.Destroy (other.gameObject);//销毁玩家飞机
			}
		}
	}
}
