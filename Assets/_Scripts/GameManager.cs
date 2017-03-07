using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    public List<Upgrades> m_Upgrades;

    public float m_DifficultyLevel = 1;
    public float m_Funds = 0;
    public float m_Width = 1;
    public float m_Tries = 3;
    public string m_UpgradeBought = "";

    public GameObject m_Unlock;

    public float m_TriesLeft;

    void Start() {
        m_Funds = 0;
        m_Tries = 3;
    }

    private void SetUnlockWidth(float difficulty) {
        switch((int)difficulty) {
            case 1:
                m_Unlock.transform.localScale = new Vector2(6, 2);
                break;
            case 2:
                m_Unlock.transform.localScale = new Vector2(4, 2);
                break;
            case 3:
                m_Unlock.transform.localScale = new Vector2(2, 2);
                break;
            default:
                m_Unlock.transform.localScale = new Vector2(4, 2);
                break;
        }
        float halfScale = m_Unlock.transform.localScale.x / 2f;
        float randomXPos = Random.Range(-10f + halfScale, 10f - halfScale);
        m_Unlock.transform.position = new Vector3(randomXPos, 0, 0);
    }

    public float GetDifficultyLevel() {
        return m_DifficultyLevel;
    }

    public void SetDifficultyLevel(float difficulty) {
        m_DifficultyLevel = difficulty;
        SetUnlockWidth(m_DifficultyLevel);
    }

    public float GetFundsAmount() {
        return m_Funds;
    }

    public void PurchaseUpgrade(string name) {
        foreach (Upgrades u in m_Upgrades) {
            if (u.m_Name == name) {
                if (m_Funds >= u.m_Cost) {
                    m_Funds -= u.m_Cost;
                    BuyUpgrade(name);
                    return;
                }
            }
        }
    }

    public void AddFunds(float amount) {
        m_Funds += amount;
    }

    public void BuyUpgrade(string name) {
        if (name == "IncreaseWidth") {
            IncreaseWidth();
        }
        if (name == "IncreaseTries") {
            IncreaseTries();
        }
    }

    public void IncreaseWidth() {
        GameObject _player = FindObjectOfType<PlayerMovement>().gameObject;
        if (_player) {
            Vector3 currentScale = _player.transform.localScale;
            _player.transform.localScale = new Vector2(currentScale.x + 1, currentScale.y);
        }
    }

    public void IncreaseTries() {
        m_Tries++;
    }

    public void DecreaseTriesLeft() {
        m_TriesLeft--;
    }

    public void FinishLevel() {
        switch((int)m_DifficultyLevel) {
            case 1:
                AddFunds(100 + (m_TriesLeft * 50));
                break;
            case 2:
                AddFunds(300 + (m_TriesLeft * 50));
                break;
            case 3:
                AddFunds(750 + (m_TriesLeft * 50));
                break;
        }
        var _hud = FindObjectOfType<HUD>();
        if (_hud) {
            _hud.FinishGame();
        }
    }
}

[System.Serializable]
public class Upgrades {
    public string m_Name;
    public float m_Cost;
}
