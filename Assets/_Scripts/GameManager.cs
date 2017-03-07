using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    public List<Upgrades> m_Upgrades;

    private float m_DifficultyLevel;
    private float m_Funds;
    private float m_width;

    void Start() {
        m_Funds = 0;

    }

    public float GetDifficultyLevel() {
        return m_DifficultyLevel;
    }

    public float GetFundsAmount() {
        return m_Funds;
    }

    public bool PurchaseUpgrade(string name) {
        foreach (Upgrades u in m_Upgrades) {
            if (u.m_Name == name) {
                if (m_Funds >= u.m_Cost) {
                    m_Funds -= u.m_Cost;
                    return true;
                }
            }
        }
        return false;
    }

    public void AddFunds(float amount) {
        m_Funds += amount;
    }

    public void IncreaseWidth() {

    }
}

[System.Serializable]
public class Upgrades {
    public string m_Name;
    public float m_Cost;
}
