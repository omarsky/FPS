using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    float m_maxHealth = 100f;
    float m_health;

    [SerializeField]
    GameObject m_healthBar;
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
        m_health -= damageAmount;
        m_healthBarSlider.value = m_health / m_maxHealth;

        Animator animator = GetComponent<Animator>();
        if (animator && m_health <= 0)
        {
            //TODO: Think about a refactoring of this part
            animator.SetTrigger(AnimationConstants.CubeDestroy);
            animator.SetTrigger(AnimationConstants.ZombieFallback);
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

    public void DeactivateEnemy()
    {
        m_healthBar.SetActive(false);
        EnemyController enemyController = GetComponent<EnemyController>();
        if (enemyController)
        {
            enemyController.enabled = false;
        }
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
