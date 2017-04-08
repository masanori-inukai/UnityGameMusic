using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMove : MonoBehaviour {

	// 時間管理
	public float time;

	// Use this for initialization
	void Start () {
		this.time = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		this.time += Time.deltaTime;
		this.transform.localPosition = new Vector3 (0, -this.time * 100, 0);
	}
}