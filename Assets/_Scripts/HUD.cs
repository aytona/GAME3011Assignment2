using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HUD : Singleton<HUD> {

    public Text m_DifficultText;
    public Text m_FundsText;

    private GameManager m_manager;
    private List<GameObject> m_canvas;

    void OnEnable() {
        m_manager = FindObjectOfType<GameManager>();
        m_canvas = new List<GameObject>();
        for (int i = 0; i < gameObject.transform.childCount; i++) {
            m_canvas.Add(gameObject.transform.GetChild(i).gameObject);
        }


    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {

    }

    void Update() {
        switch ((int)m_manager.GetDifficultyLevel()) {
            case 1:
                m_DifficultText.text = "Difficulty: Easy";
                break;
            case 2:
                m_DifficultText.text = "Difficulty: Medium";
                break;
            case 3:
                m_DifficultText.text = "Difficulty: Hard";
                break;
            default:
                m_DifficultText.text = "";
                break;
        }
        m_FundsText.text = m_manager.GetFundsAmount().ToString();
    }

    public void PlayGame() {
        SceneManager.LoadScene("Game");
    }

    public void SwitchCanvas(GameObject target) {
        for (int i = 0; i < m_canvas.Count; i++) {
            if (m_canvas[i] == target) {
                m_canvas[i].SetActive(true);
            } else if (m_canvas[i].activeInHierarchy) {
                m_canvas[i].SetActive(false);
            }
        }
    }

    public void Purchase(string name) {
        if (m_manager.PurchaseUpgrade(name)) {
            m_manager.PurchaseUpgrade(name);
        } else {

        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
