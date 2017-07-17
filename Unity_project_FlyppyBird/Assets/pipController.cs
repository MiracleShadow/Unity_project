using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipController : MonoBehaviour {

	/*
	 * 随机管道y轴坐标
	*/
	// Use this for initialization

	public AudioClip PointAC;//碰撞音效

	void Start () {
		
		float randomY = Random.Range (-0.42f, -0.15f);
		Vector3 randomPos = new Vector3 (transform.localPosition.x, randomY, transform.localPosition.z);
		transform.localPosition = randomPos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//小鸟飞过触发器的时候触发代码
	void OnTriggerExit(Collider other){
		//累加分数，播放音频
		if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<BirdController> ().isAlive) {
			GamerController.Instance.score += 10;
			print ("score=" + GamerController.Instance.score);
			AudioSource.PlayClipAtPoint (PointAC, transform.localPosition);
		}
	}
}
