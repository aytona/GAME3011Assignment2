using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	private float m_Timer = 0;
    public bool m_TimerStart;

	public void StartTimer() {
		m_Timer = 60;
        m_TimerStart = true;
	}

    private void Update() {
        if (m_TimerStart) {
            m_Timer -= Time.deltaTime;
        }
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
