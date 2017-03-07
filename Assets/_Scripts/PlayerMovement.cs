using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public GameObject m_Unlock;
	public GameObject m_Arrow;
    public bool m_AllowMovement;

    private GameManager m_manager;

    public void Movement(bool allow) {
        m_AllowMovement = allow;
    }

    private void Start() {
        m_manager = FindObjectOfType<GameManager>();
    }

    void Update() {
		if (Input.GetMouseButtonDown(0) && m_AllowMovement) {
            gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, 0);
            m_Arrow.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2);
		}
		else if (Input.GetMouseButtonDown(1)) {
			CheckIfCorrect();
		}
	}

	void CheckIfCorrect() {
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

	void Unlock() {
        m_manager.FinishLevel();
	}

	void ShowDirection(bool direction) {
		if (direction) {
			GameObject arrow = Instantiate(m_Arrow, new Vector3(transform.position.x, transform.position.y + 3f), Quaternion.Euler(0, 0, -90));
			Destroy(arrow, 2f);
		} else {
			GameObject arrow = Instantiate(m_Arrow, new Vector3(transform.position.x, transform.position.y + 3f), Quaternion.Euler(0, 0, 90f));
			Destroy(arrow, 2f);
		}
	}
}
