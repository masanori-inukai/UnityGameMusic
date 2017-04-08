using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<AudioSource> ().PlayDelayed (2.475f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
