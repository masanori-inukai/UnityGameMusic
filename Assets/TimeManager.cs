using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public static float time;

	// Use this for initialization
	void Start () {
		TimeManager.time = 0;

	}
	
	// Update is called once per frame
	void Update () {
		TimeManager.time += Time.deltaTime;
	}
}
