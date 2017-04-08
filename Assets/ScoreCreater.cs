using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCreater : MonoBehaviour {

	// プレハブ
	public GameObject scorePrefab;
	private float timer; 
	private static float[] ScorePositionXList = new float[]{
		-480, -160, 160, 480	
	};

	// Use this for initialization
	void Start () {
		Random.seed = 100;
		this.timer = TimeManager.time + 1f;
	}
	
	// Update is called once per frame
	void Update () {

		if (this.timer < TimeManager.time) {
			GameObject obj = Instantiate (scorePrefab);
			obj.transform.parent = this.transform;

			int index = Random.Range (0, ScoreCreater.ScorePositionXList.Length);
			float x = ScoreCreater.ScorePositionXList [index];

			obj.transform.localPosition = new Vector3 (x, TimeManager.time * 100 + 500, 0);

			obj.transform.localScale = new Vector3 (1, 1, 1);

			obj.transform.SetAsFirstSibling ();

			this.timer = TimeManager.time + 1f;
		}

	}
}