using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GageHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setGage(float point) {
		float length = point / 100f;
		this.transform.localScale = new Vector3 (length, 1, 1);
	}
}
