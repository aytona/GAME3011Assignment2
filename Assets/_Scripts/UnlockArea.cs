using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockArea : MonoBehaviour {

	public void ChangeScale(float scale) {
		gameObject.transform.localScale = new Vector2(scale, 1);
	}

	public void MoveArea() {
		float halfScale = gameObject.transform.localScale.x / 2f;
		float randomPos = Random.Range(-10.8f + halfScale, 10.8f - halfScale);
		gameObject.transform.position = new Vector2(randomPos, 0);
	}
}
