using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class ScoreCreater : MonoBehaviour {

	// Scoreのプレハブ
	public GameObject scorePrefab;

	// Jsonテキストデータ
	public TextAsset jsonData;

	// 音楽データを格納する構造体の配列
	public List<MusicData> scoreData;

	public GameObject[] touchBars;

	// スコアのXの位置 //
	private static float[] ScorePositionXList = new float[]{
		-480, -160, 160, 480
	};

	// Use this for initialization
	void Start () {

		// scoreDataを初期化 //
		scoreData = new List<MusicData> ();

		// ランダム生成のシードをセット
		Random.InitState (100);

		// テキストデータを配列に変換 //
		IDictionary tmpData = (IDictionary)Json.Deserialize (jsonData.text);

		// 値「”score”」に配列が格納されている
		List<object> arrayData = (List<object>)tmpData ["score"];

		// arrayDataを解析
		foreach (IDictionary val in arrayData) {

			// eventがnote_onの時のみ格納
			if ((string)val ["event"] == "note_on") {
				scoreData.Add (new MusicData ((long)val ["tick"], (int)(long)val ["value"]));
			}

			// eventがset_tempoの時はテンポ情報
			if ((string)val ["event"] == "set_tempo") {
				TimeManager.tempo = (int)(long)val ["value"];
			}
		}
	}

	// Update is called once per frame
	void Update () {

		foreach( MusicData tmp in scoreData ){
			// 指定したTickを超えたものから生成
			if( !tmp.isCreated && TimeManager.tick > tmp.tick ){

				// 譜面を生成
				GameObject scoreObject = Instantiate( scorePrefab );

				// 譜面のヒエラルキーを移動
				scoreObject.transform.SetParent(this.transform);

				// 譜面のXの位置を決定
				int rand = Random.Range( 0, ScoreCreater.ScorePositionXList.Length );
				float x  = ScoreCreater.ScorePositionXList[rand];

				// 譜面のYの位置を決定
				float y  = tmp.tick * 0.5f + 950; 

				// 譜面の位置を移動
				scoreObject.transform.localPosition = new Vector3(x, y, 0);

				scoreObject.GetComponent<ScoreHandler> ().touchBar = this.touchBars [rand];

				// 譜面のスケールをリセット
				scoreObject.transform.localScale = Vector3.one;

				// 出現したものの表示順を最奥に設定
				scoreObject.transform.SetAsFirstSibling();

				// 生成フラグをセット
				tmp.isCreated = true;
			}
		}
	}
}