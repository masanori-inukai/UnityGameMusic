using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public GameObject gameClear;
	public GameObject gameOver;

	public AudioClip onClick;
	public AudioClip onMiss;
	public AudioClip onGameOver;
	public AudioClip onGameClear;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<AudioSource> ().PlayDelayed (2.40f);
//		this.gameObject.GetComponent<AudioSource> ().time = this.gameObject.GetComponent<AudioSource> ().clip.length - 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!this.gameObject.GetComponent<AudioSource> ().isPlaying) {
			if (GameData.gagePoint >= 75) {
				this.gameClear.SetActive (true);
				this.gameObject.GetComponent<AudioSource> ().PlayOneShot (
					this.onGameClear	
				);
			} else {
				this.gameOver.SetActive (true);
				this.gameObject.GetComponent<AudioSource> ().PlayOneShot (
					this.onGameOver	
				);
			}
			this.enabled = false;
		}
	}
}