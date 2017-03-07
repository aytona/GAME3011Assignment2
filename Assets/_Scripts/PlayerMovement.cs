using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public GameObject m_Unlock;
	public GameObject m_Arrow;

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			gameObject.transform.position = new Vector3(Input.mousePosition.x, 0, 0);
		}
		else if (Input.GetMouseButtonDown(1)) {
			CheckIfCorrect();
		}
	}

	void CheckIfCorrect() {
		gameObject.GetComponent<BoxCollider2D>().enabled = true;
		if (transform.position.x + transform.localScale.x / 2f <= m_Unlock.transform.position.x + m_Unlock.transform.localScale.x / 2f 
		&& transform.position.x - transform.localScale.x >= m_Unlock.transform.position.x - m_Unlock.transform.localScale.x / 2f) {
			Unlock();
		} else {
			if (transform.position.x > m_Unlock.transform.position.x) {
				ShowDirection(true);
			} else {
				ShowDirection(false);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D _other) {
		if (_other.tag == "Unlock") {
			Unlock();
		}
	}

	void Unlock() {

		
	}

	void ShowDirection(bool direction) {
		if (direction) {
			GameObject arrow = Instantiate(m_Arrow, new Vector3(transform.position.x, transform.position.y + 10f), Quaternion.Euler(0, 0, -90));
			Destroy(arrow, 2f);
		} else {
			GameObject arrow = Instantiate(m_Arrow, new Vector3(transform.position.x, transform.position.y + 10f), Quaternion.Euler(0, 0, 90f));
			Destroy(arrow, 2f);
		}
	}
}
