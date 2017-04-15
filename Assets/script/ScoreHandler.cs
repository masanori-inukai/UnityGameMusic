using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour {

	public GameObject touchEffectPrefub;
	public GameObject pointTextPrefub;
	public PointHandler pointHandler;
	public GageHandler gageHandler;
	public GameObject touchBar;

	// 各ポイント評価用のテキストスプライト
	public Sprite[] textSprite;

	// 各ポイントのスプライト用変数
	public enum PointTextKey {
		Miss, Bad, Good, Great, Perfect
	}

	// Use this for initialization
	void Start () {
		int tick = 2500 + 200;
		Invoke ("AutoDestroy", (60f * tick) / (TimeManager.tempo * 480f));

		this.pointHandler = FindObjectOfType<PointHandler> ();
		this.gageHandler = FindObjectOfType<GageHandler> ();
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
		int Distance = (int) Mathf.Abs( PositionInGame.y - ( - 300 ) );

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

		// ポイントが0の時は削除しない。あんまり早く押せてもあれなので
		if (distancePoint > 0) {

			// TouchBarをアニメーション
			this.touchBar.GetComponent<Animator>().SetTrigger( "Touch" );

			// ミス以外は音を鳴らさないように
//			FindObjectOfType<AudioManager> ().GetComponent<AudioSource> ().PlayOneShot (
//				FindObjectOfType<AudioManager> ().onClick
//			);

			Destroy (this.gameObject);
			GameObject obj = Instantiate (this.touchEffectPrefub);
			obj.transform.position = this.touchBar.transform.position;
			obj.transform.localScale = Vector3.zero;
			obj.GetComponent<Animator> ().Play (0);

			this.showText (distancePoint);

			this.pointHandler.setPoint (GameData.score);

			this.gageHandler.setGage (GameData.gagePoint);
		}
	}

	// 評価用テキスト作成
	private void showText( float point ){

		// エフェクトオブジェクトを生成
		GameObject pointObject = Instantiate( this.pointTextPrefub );

		// エフェクトの位置の移動とサイズをリセット
		pointObject.transform.position   = this.touchBar.transform.position + new Vector3( 0, 1f, 0 );
		pointObject.transform.localScale = Vector3.one;

		// ポイントに応じて画像を入替え
		if( point > 0.8f )
			pointObject.GetComponentInChildren<SpriteRenderer>().sprite = textSprite[(int)PointTextKey.Perfect];
		else if( point > 0.6f )
			pointObject.GetComponentInChildren<SpriteRenderer>().sprite = textSprite[(int)PointTextKey.Great];
		else if( point > 0.4f )
			pointObject.GetComponentInChildren<SpriteRenderer>().sprite = textSprite[(int)PointTextKey.Great];
		else if( point > 0.2f )
			pointObject.GetComponentInChildren<SpriteRenderer>().sprite = textSprite[(int)PointTextKey.Good];
		else if( point > 0 )
			pointObject.GetComponentInChildren<SpriteRenderer>().sprite = textSprite[(int)PointTextKey.Bad];
		else
			pointObject.GetComponentInChildren<SpriteRenderer>().sprite = textSprite[(int)PointTextKey.Miss];

		// アニメーションを開始 //
		pointObject.GetComponentInChildren<Animator>().Play( 0 );
	}

	public void AutoDestroy() {
		Destroy (this.gameObject);
		this.showText( 0 );
		FindObjectOfType<AudioManager> ().GetComponent<AudioSource> ().PlayOneShot (
			FindObjectOfType<AudioManager> ().onMiss
		);
		GameData.gagePoint -= 2;
		if (GameData.gagePoint < 0) GameData.gagePoint = 0;
		this.gageHandler.setGage (GameData.gagePoint);
	}
}