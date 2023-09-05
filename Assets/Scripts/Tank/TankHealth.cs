using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{

    public float m_StartingHealth = 100f;
    public GameObject m_ExplosionPrefab;
    private float m_CurrentHealth;
    private bool m_Dead;
    private ParticleSystem m_ExplosionParticles;

    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionParticles.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        //UI
    }

    public void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;
        SetHealthUI();
        if (m_CurrentHealth <= 0f && !m_Dead)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        m_Dead = true;

        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);
        m_ExplosionParticles.Play();

        gameObject.SetActive(false);
    }



}
