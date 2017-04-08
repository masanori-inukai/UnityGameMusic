using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour {

	public GameObject touchEffectPrefub;

	// Use this for initialization
	void Start () {
		int tick = 3100;
		Invoke ("AutoDestroy", (60f * tick) / (TimeManager.tempo * 480f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ゲームオブジェクトを削除する
	public void OnScoreClick() {

		// Board外の位置を計算
		Vector3 PositionInGame = 
			GetComponentInParent<BoardMove>().transform.localPosition + this.transform.localPosition;

		// 距離を計算
		int Distance = (int) Mathf.Abs( PositionInGame.y - ( - 350 ) );

		// ポイントを計算し正規化
		float distancePoint = ( 100 - Distance ) / 100f;

		// ポイントが０以下の場合はポイントを0にする
		if (distancePoint < 0) distancePoint = 0;

		// ポイントを加算
		GameData.score += (int)( distancePoint * 1000 );

		// ゲージを加算
		GameData.gagePoint += distancePoint * 2;

		// ゲージを制限
		if (GameData.gagePoint > 100) GameData.gagePoint = 100;

		// ポイントを確認
		Debug.Log( GameData.score );

		// ポイントが0の時は削除しない。あんまり早く押せてもあれなので
		if (distancePoint > 0) {
			Destroy (this.gameObject);
			GameObject obj = Instantiate (this.touchEffectPrefub);
			obj.transform.position = this.transform.position;
			obj.transform.localScale = Vector3.zero;
			obj.GetComponent<Animator> ().Play (0);
		}
	}

	public void AutoDestroy() {
		Destroy (this.gameObject);
	}
}