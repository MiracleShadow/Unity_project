using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//导入UGUI系统
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	//记录最后一个背景Transform
	public Transform lastBGTransform;
	public int score =0;
	public bool gameover = false;

	#region 单例模式
	static GameController instance;
	void Awake(){
		instance = this;
	}
	//提供一个对外可访问的一个静态属性
	public static GameController Instance{
		get{
			return instance;
		}
	}
	#endregion

	Text scoreText;
	Button ReStartBtn;
	GameObject canvas;

	void Start () {
		//获取组件
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		ReStartBtn = GameObject.Find ("Button").GetComponent<Button> ();
		canvas = GameObject.Find ("Canvas");
		//给按钮添加监听事件
		ReStartBtn.onClick.AddListener(ReStartListener);
		canvas.SetActive (false);
	}

	public void ReStartListener(){
		//重新加载整个场景
		SceneManager.LoadScene(0);

	}

	void Update () {

		if(gameover==true){
			canvas.SetActive (gameover);
			scoreText.text = "" + score;
		}

	}

	void OnGUI(){
		//绘制分数
		Rect scoreRect = new Rect (Screen.width - 120, 30, 100, 30);
		GUI.Label (scoreRect, "Score=" + score);
		//退出按钮
		Rect quitBtnRect = new Rect (20, 30, 100, 30);
			if(GUI.Button(quitBtnRect,"退出游戏")){
				Application.Quit();
			}
	}

}
