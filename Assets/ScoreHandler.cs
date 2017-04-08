using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour {

	public GameObject touchEffectPrefub;

	// Use this for initialization
	void Start () {
		int tick = 3100;
		Invoke ("AutoDestroy", (60 * tick) / (TimeManager.tempo * 480f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ゲームオブジェクトを削除する
	public void OnScoreClick() {
		Destroy (this.gameObject);
		GameObject obj = Instantiate (this.touchEffectPrefub);

		obj.transform.position = this.transform.position;
		obj.transform.localScale = Vector3.zero;

		obj.GetComponent<Animator> ().Play (0);

	}

	public void AutoDestroy() {
		Destroy (this.gameObject);
	}
}