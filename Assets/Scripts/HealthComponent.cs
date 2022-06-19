using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public delegate void OnHealthChanged(float previousHealth, float newHealth);
    public event OnHealthChanged HealthChangedEvent;
    public delegate void OnHealthEnded();
    public event OnHealthEnded HealthEndedEvent;

    [SerializeField]
    float m_maxHealth = 100f;
    float m_health;

    public GameObject m_healthBar;
    Slider m_healthBarSlider;
    
    [SerializeField]
    GameObject m_explosionPrefab;

    //DEBUG
    public InputAction m_debugActionToReceiveDamage;
    bool m_debugSelected = false;
    //END DEBUG

    void Awake()
    {
        m_health = m_maxHealth;
        if (m_healthBar)
        {
            m_healthBarSlider = m_healthBar.GetComponent<Slider>();
        }

        m_debugActionToReceiveDamage.Enable();
        m_debugActionToReceiveDamage.performed += ctx => { if (m_debugSelected) ReceiveDamage(30); };
    }

    public void ReceiveDamage(float damageAmount)
    {
        m_healthBar.SetActive(true);
        float healthBeforeDamage = m_health;
        m_health -= damageAmount;
        m_healthBarSlider.value = m_health / m_maxHealth;

        HealthChangedEvent?.Invoke(healthBeforeDamage, m_health);

        if (m_health <= 0)
        {
            HealthEndedEvent?.Invoke();
        }

        Debug.LogFormat("{1}: Received damage: {0}", damageAmount, gameObject.ToString());
    }

    public void SetupDestruction()
    {
        if (m_explosionPrefab)
        {
            GameObject.Instantiate(m_explosionPrefab, transform.position, Quaternion.identity);
        }
        GameObject.Destroy(this.gameObject);
    }

    public void RegisterHealthEndedEvent(OnHealthEnded ev)
    {
        HealthEndedEvent += ev;
    }
    public void UnregisterHealthEndedEvent(OnHealthEnded ev)
    {
        HealthEndedEvent -= ev;
    }
    public void RegisterHealthChangedEvent(OnHealthChanged ev)
    {
        HealthChangedEvent += ev;
    }
    public void UnregisterHealthChangedEvent(OnHealthChanged ev)
    {
        HealthChangedEvent -= ev;
    }
    private void OnDrawGizmos()
    {
        m_debugSelected = false;
    }

    private void OnDrawGizmosSelected()
    {
        m_debugSelected = true;
    }
}
