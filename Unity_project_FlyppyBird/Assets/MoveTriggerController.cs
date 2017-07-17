using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTriggerController : MonoBehaviour {

	public GameObject currentBG;
	public GameObject pipe1;
	public GameObject pipe2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//触发结束
	void OnTriggerExit(Collider other){
		//将当前背景移到最前面
		Vector3 lastPosition = GamerController.Instance.lastBGTransform.position;
		currentBG.transform.position = new Vector3 (lastPosition.x + 10, lastPosition.y, lastPosition.z);

		//更新单例类里面保存的最后一个背景的transfrom
		GamerController.Instance.lastBGTransform = currentBG.transform;

		//管道位置随机
		float randomY = Random.Range (-0.42f, -0.15f);
		pipe1.transform.localPosition = new Vector3 (pipe1.transform.localPosition.x, randomY, pipe1.transform.localPosition.z);
		randomY = Random.Range (-0.42f, -0.15f);
		pipe2.transform.localPosition = new Vector3 (pipe2.transform.localPosition.x, randomY, pipe2.transform.localPosition.z);

	}
}
