using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

    public float m_BaseSpeed;
    public float m_Speed;
    public float m_Direction;
    public Quaternion m_Angle;

    private GameManager m_manager;

    //void Start() {
    //    m_manager = FindObjectOfType<GameManager>();
    //    m_Speed = m_BaseSpeed + (m_manager.m_DifficultyLevel / m_manager.m_SkillLevel);
    //}

    //void Update() {
    //    transform.Rotate(Vector3.right * m_Speed * m_Direction * Time.deltaTime);
    //}
}
