using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	private float m_Timer = 0;

	public void StartTimer() {
		m_Timer = 60;
		StartCoroutine(UpdateTime());
	}

	public float GetTimer() {
		return m_Timer;
	}

	private IEnumerator UpdateTime () {
		m_Timer--;
		yield return new WaitForSeconds (1);
		if (m_Timer > 0) {
			UpdateTime ();
		}
	}
}
