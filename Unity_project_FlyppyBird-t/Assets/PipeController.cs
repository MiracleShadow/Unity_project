using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour {
	//让管道位置随机（x,z不随机，y随机（-0.42，-0.07））
	AudioSource point;

	void Start () {
		RandomPos ();
		point = gameObject.GetComponent<AudioSource> ();
	}

	public void RandomPos (){
		float randomY = Random.Range (-0.47f, -0.13f);
		Vector3 randomPos = new Vector3 (transform.localPosition.x, randomY,transform.localPosition.y);
		transform.localPosition = randomPos;//随机出来的位置赋值到原来的位置。
	}

	//小鸟移出触发器代码
	void OnTriggerExit(Collider other){
		//添加分数，播放音频
		if(other.gameObject.tag=="Player"){
			if(other.gameObject.GetComponent<BirdController>().isAlive==true){
				GameController.Instance.score += 10; 
				point.Play ();
			}

		}

	}

	void Update () {
			
	}
}
