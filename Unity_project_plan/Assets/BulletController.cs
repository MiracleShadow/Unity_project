using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	//让子弹向y轴正方向飞行，速度16

	float speed = 16;
	public int damage = 10;

	//爆炸预设体
	public GameObject explosinPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//沿着Y轴正方向速度为16
		transform.position += Vector3.up * speed * Time.deltaTime;
		//超出一定范围后销毁
		if(transform.position.y > 6){
			GameObject.Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		//子弹销毁，敌机扣血，判断血量是否小于等于0，是的话飞机销毁
		GameObject.Instantiate (explosinPrefab, transform.position, Quaternion.identity);
		GameObject.Destroy (gameObject);
		other.gameObject.GetComponent<EnenyController> ().HP -= damage + 10*(GameController.Instance.score/300);
		//每得300分伤害加10（每消灭30个敌机伤害加10
		if(other.gameObject.GetComponent<EnenyController> ().HP <= 0){
			//飞机销毁位置产生粒子效果
			GameObject.Instantiate (explosinPrefab, other.gameObject.transform.position, Quaternion.identity);
			GameObject.Destroy (other.gameObject);
			//累加分数
			GameController.Instance.score += 10;
		}
	}
}
