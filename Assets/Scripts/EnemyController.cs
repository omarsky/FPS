using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    protected Animator m_animator;

    [Header("Animation values")]
    [SerializeField]
    protected float m_distanceToPlayerToWalk;
    [SerializeField]
    protected float m_distanceToPlayerToRun;
    [SerializeField]
    protected float m_distanceToAttack;

    [Header("Attack values")]
    [SerializeField]
    Transform m_damageDealingObj;
    [SerializeField]
    float m_damageObjectRadius = 0.5f;
    [SerializeField]
    float m_damageDeal = 10f;
    [SerializeField]
    LayerMask m_objectsThatReceiveDamage;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        RegisterHealthEvents();
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(Tags.Player);
        float distanceToPlayer = (player.transform.position - transform.position).magnitude;

        bool isAttacking = false;
        bool isRunning = false;
        bool isWalking = false;

        if (distanceToPlayer < m_distanceToAttack)
        {
            isAttacking = true;
            LookAtPlayer(player);
        }
        else if (distanceToPlayer < m_distanceToPlayerToRun)
        {
            isRunning = true;
            LookAtPlayer(player);
        }
        else if (distanceToPlayer < m_distanceToPlayerToWalk)
        {
            isWalking = true;
            LookAtPlayer(player);
        }

        UpdateRoaming();
        UpdateAnimatorValues(isAttacking, isRunning, isWalking);
        UpdateDamageDeal();
    }

    private void UpdateDamageDeal()
    {
        RaycastHit hitInfo;
        if (m_damageDealingObj.gameObject.activeSelf && Physics.SphereCast(m_damageDealingObj.position, m_damageObjectRadius, Vector3.forward, out hitInfo, 0.1f, m_objectsThatReceiveDamage))
        {
            hitInfo.collider.gameObject.GetComponent<HealthComponent>().ReceiveDamage(m_damageDeal);
            m_damageDealingObj.gameObject.SetActive(false);
        }
    }

    protected void LookAtPlayer(GameObject player)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane((player.transform.position - transform.position), Vector3.up));
    }

    public void DeactivateEnemy()
    {
        GetComponent<HealthComponent>()?.m_healthBar.SetActive(false);
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        enabled = false;
    }

    public void SetDamageDealingObjActive(int isActive)
    {
        m_damageDealingObj.gameObject.SetActive(isActive > 0);
    }

    public void DisableAnimator()
    {
        m_animator.enabled = false;
    }

    protected virtual void OnHealthEnded()
    {
        UnregisterHealthEvents();
    }
    protected virtual void OnHealthChanged(float healthBefore, float newHealth)
    {
    }

    private void RegisterHealthEvents()
    {
        GetComponent<HealthComponent>()?.RegisterHealthEndedEvent(OnHealthEnded);
        GetComponent<HealthComponent>()?.RegisterHealthChangedEvent(OnHealthChanged);
    }

    private void UnregisterHealthEvents()
    {
        GetComponent<HealthComponent>()?.UnregisterHealthEndedEvent(OnHealthEnded);
        GetComponent<HealthComponent>()?.UnregisterHealthChangedEvent(OnHealthChanged);
    }


    protected virtual void UpdateRoaming()
    {
    }


    protected virtual void UpdateAnimatorValues(bool isAttacking, bool isRunning, bool isWalking)
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(m_damageDealingObj.position, m_damageObjectRadius);
    }
}
