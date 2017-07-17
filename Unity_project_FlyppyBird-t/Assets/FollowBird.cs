using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBird : MonoBehaviour {
	//跟随小鸟移动，yz轴不变
	GameObject bird;//也可以拖拽赋值

	void Start () {
		bird = GameObject.Find ("Bird");
	}
	
	void Update () {
		transform.position = new Vector3 (bird.transform.position.x+7.86f, transform.position.y, transform.position.z);
	}
}
