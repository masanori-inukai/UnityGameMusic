using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ゲームオブジェクトを削除する
	public void OnScoreClick() {
		Destroy (this.gameObject);
	}
}