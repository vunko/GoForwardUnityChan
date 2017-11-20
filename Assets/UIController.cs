using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class UIController : MonoBehaviour {
	private GameObject gameOverText;
	private GameObject runLengthText;
	private float len = 0;
	private float speed = 0.03f;
	//ゲームオーバの判定
	private bool isGameOver = false;

	// Use this for initialization
	void Start () {
		//シーンビューからオブジェクトの実態を検索する
		this.gameOverText = GameObject.Find("GameOver");
		this.runLengthText = GameObject.Find ("RunLength");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isGameOver == false) {
			//走った距離を更新する
			this.len += this.speed;
			//走った距離を表示する
			this.runLengthText.GetComponent<Text> ().text = "Distance:  "  + len.ToString ("F2") + "m";
		}
		//ゲームオーバになった場合
		if (this.isGameOver) {
			// クリックされたらシーンをロードする（追加）
			if (Input.GetMouseButtonDown (0)) {
				//GameSceneを読み込む（追加）
				SceneManager.LoadScene ("GameScene");
			}
		}
	}
	public void GameOver() {
		//ゲームオーバになったときに、画面上にゲームオーバを表示
		this.gameOverText.GetComponent<Text>().text = "GameOver";
		this.isGameOver = true;
	}
}
