using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	// 時間管理用 
	public static float time;

	// テンポ情報
	public static int tempo;

	// MIDI時間管理用
	public static long tick;

	// Use this for initialization
	void Start () {

		// timeを初期化
		TimeManager.time = 0;

		// tickを初期化
		TimeManager.tick = 0;

	}
	
	// Update is called once per frame
	void Update () {
		TimeManager.time += Time.deltaTime;

		// timeからtickを計算
		TimeManager.tick = (long) (
			TimeManager.time * (TimeManager.tempo * 480f) / 60f
		);
	}
}