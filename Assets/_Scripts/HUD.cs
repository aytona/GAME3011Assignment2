using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HUD : Singleton<HUD> {

    public Text[] m_DifficultText;
    public Text[] m_FundsText;
    public Text[] m_Tries;
    public Text[] m_Reward;
    public GameObject m_Game;
    public GameObject m_Unlock;

    private GameManager m_manager;
    private List<GameObject> m_canvas;
    private GameObject m_prevCanvas;

    void OnEnable() {
        m_manager = FindObjectOfType<GameManager>();
        m_canvas = new List<GameObject>();
        for (int i = 0; i < gameObject.transform.childCount; i++) {
            m_canvas.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    void Update() {
        switch ((int)m_manager.GetDifficultyLevel()) {
            case 1:
                foreach(Text i in m_Reward) {
                    i.text = "Reward: $100";
                }
                foreach (Text i in m_DifficultText) {
                    i.text = "Difficulty: Easy";
                }
                break;
            case 2:
                foreach(Text i in m_Reward) {
                    i.text = "Reward: $300";
                }
                foreach (Text i in m_DifficultText) {
                    i.text = "Difficulty: Medium";
                }
                break;
            case 3:
                foreach(Text i in m_Reward) {
                    i.text = "Reward: $750";
                }
                foreach (Text i in m_DifficultText) {
                    i.text = "Difficulty: Hard";
                }
                break;
            default:
                foreach(Text i in m_Reward) {
                    i.text = "Reward: ";
                }
                foreach (Text i in m_DifficultText) {
                    i.text = "Difficulty: ";
                }
                break;
        }
        foreach(Text i in m_FundsText) {
            i.text = "Funds: " + m_manager.GetFundsAmount().ToString();
        }
        foreach(Text i in m_Tries) {
            i.text = "Tries Left: " + m_manager.m_TriesLeft.ToString();
        }
    }

    public void PlayGame(GameObject _canvas) {
        SwitchCanvas(_canvas);
    }

    public void FinishGame() {
        m_Game.SetActive(false);
        SwitchCanvas(m_Unlock);
    }

    public void StartGame() {
        m_Game.SetActive(true);
        m_manager.m_TriesLeft = m_manager.m_Tries;
    }

    public void BackToMenu(GameObject _canvas) {
        SwitchCanvas(_canvas);
        m_Game.SetActive(false);
    }

    public void SwitchCanvas(GameObject target) {
        for (int i = 0; i < m_canvas.Count; i++) {
            if (m_canvas[i] == target) {
                m_canvas[i].SetActive(true);
            } else if (m_canvas[i].activeInHierarchy) {
                m_prevCanvas = m_canvas[i];
                m_canvas[i].SetActive(false);
            }
        }
    }

    public void BackCanvas() {
        for (int i = 0; i < m_canvas.Count; i++) {
            if(m_canvas[i].activeInHierarchy) {
                m_canvas[i].SetActive(false);
            }
        }
        m_prevCanvas.SetActive(true);
    }

    public void Purchase(string name) {
        m_manager.PurchaseUpgrade(name);
    }

    public void EasyDifficulty() {
        m_manager.SetDifficultyLevel(1);
    }

    public void MediumDifficulty() {
        m_manager.SetDifficultyLevel(2);
    }

    public void HardDifficulty() {
        m_manager.SetDifficultyLevel(3);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
