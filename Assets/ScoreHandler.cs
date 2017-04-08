using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// タッチの優先順位を変更する
		this.transform.SetSiblingIndex ((int)this.transform.localPosition.y);
	}

	// ゲームオブジェクトを削除する
	public void OnScoreClick() {
		Destroy (this.gameObject);
	}
}