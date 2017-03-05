using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    private float m_DifficultyLevel;
    private float m_Funds;
    private List<Upgrades> m_Upgrades;

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
                if (!u.m_Own) {
                    if (m_Funds >= u.m_Cost) {
                        u.m_Own = true;
                        m_Funds -= u.m_Cost;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void AddFunds(float amount) {
        m_Funds += amount;
    }
}

public class Upgrades {
    public string m_Name;
    public float m_Cost;
    public bool m_Own;
}
