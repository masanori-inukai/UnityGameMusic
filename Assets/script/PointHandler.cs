using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setPoint(long point) {
		StopCoroutine ("PointAnimation");
		StartCoroutine (
			this.PointAnimation(
				long.Parse(this.gameObject.GetComponent<Text> ().text),
				point,
				0.2f
			)
		);
	}

	private IEnumerator PointAnimation(long start, long end, float time) {
		float startTime = TimeManager.time;
		float endTime = startTime + time;
		do {
			float t = (TimeManager.time - startTime) / time;
			long updateValue = (long)((end - start) * t + start);
			this.gameObject.GetComponent<Text> ().text = updateValue.ToString ();
			yield return null;
		} while (TimeManager.time < endTime);
		this.gameObject.GetComponent<Text> ().text = end.ToString ();
	}
}
