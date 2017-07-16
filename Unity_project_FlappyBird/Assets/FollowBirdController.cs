using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBirdController : MonoBehaviour {
	/*
	 * 跟随小鸟移动（只改变X轴，不改变Y轴，Z轴
	*/

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(BirdController.Instance.isAlive){
			gameObject.transform.position = new Vector3 (BirdController.Instance.gameObject.transform.position.x + 4, transform.position.y, transform.position.z);
		}
	}
}
