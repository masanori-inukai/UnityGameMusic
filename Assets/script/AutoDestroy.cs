using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// アニメーション終了時
	public void OnAnimationStop() {
		Destroy (this.gameObject);
	}

	// アニメーション終了時
	public void OnAnimationStopParent() {
		Destroy (this.transform.parent.gameObject);
	}
}
