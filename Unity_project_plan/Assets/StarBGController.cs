using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBGController : MonoBehaviour {

	//控制背景往Y轴负方向移动，速度为1
	//当第一个看不见的时候放到最上面去

	float moveSpeed=1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//往y轴负方向移动
		transform.position += Vector3.down * moveSpeed * Time.deltaTime;
		if(transform.position.y<=-10){
			Vector3 newPos = new Vector3 (transform.position.x, 10, transform.position.z);
			transform.position = newPos;
		}
	}
}
