using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {
	public GameObject currentBG;
	public GameObject pipe1;
	public GameObject pipe2;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerExit(Collider other){
		//将当前背景移到最前面
		Vector3 lastPos = GameController.Instance.lastBGTransform.position;
		currentBG.transform.position = new Vector3 (lastPos.x + 10, lastPos.y, lastPos.z);
		//更新单例保存的背景
		GameController.Instance.lastBGTransform = currentBG.transform;
		//other可以随便取名
		//管道随机
		pipe1.GetComponent<PipeController> ().RandomPos();//为什么没想起来
		pipe2.GetComponent<PipeController> ().RandomPos();
	}

}
