using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int HP = 30;
	//控制飞机的左右上下移动 速度为8
	float speed=8;
	//子弹预设体
	public GameObject bulletPrefab;
	//子弹初始位置
	public Transform bulletTransfrom;

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		Move ();
		Shoot();
	}
	void Move(){
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");

		//根据水平跟竖直方向上的偏移量构建一个运动的方向
		Vector3 direction = new Vector3 (horizontal, vertical, 0);
		transform.position += direction * speed * Time.deltaTime;
		//限定飞机的位置:x(-4.5,4.5) y(-4.5,3.1)

		Vector3 tempPos = transform.position;
		tempPos.x = Mathf.Clamp (tempPos.x, -4.6f, 4.6f);
		tempPos.y = Mathf.Clamp (tempPos.y, -4.5f, 3.4f);
		transform.position = tempPos;
	}

	void Shoot(){
		if(Input.GetMouseButtonDown(0)){
			GameObject.Instantiate (bulletPrefab, bulletTransfrom.position, transform.rotation);
		}
	}
}
