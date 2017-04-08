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
		StopCoroutine ("GageAnimation");
		StartCoroutine (
			this.GageAnimation(
				this.transform.localScale.x,
				length,
				0.2f
			)
		);
	}

	private IEnumerator GageAnimation(float start, float end, float time) {
		float startTime = TimeManager.time;
		float endTime = startTime + time;
		do {
			float t = (TimeManager.time - startTime) / time;
			float updateValue = ((end - start) * t + start);
			this.transform.localScale = new Vector3(updateValue, 1, 1);
			yield return null;
		} while (TimeManager.time < endTime);

		this.transform.localScale = new Vector3(end, 1, 1);
	}
}
