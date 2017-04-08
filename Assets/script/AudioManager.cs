using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public GameObject gameClear;
	public GameObject gameOver;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<AudioSource> ().PlayDelayed (2.48f);

		this.gameObject.GetComponent<AudioSource> ().time =
			this.gameObject.GetComponent<AudioSource> ().clip.length - 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!this.gameObject.GetComponent<AudioSource> ().isPlaying) {
			if (GameData.gagePoint >= 75) {
				this.gameClear.SetActive (true);
			} else {
				this.gameOver.SetActive (true);
			}

			this.enabled = false;
		}
	}
}
