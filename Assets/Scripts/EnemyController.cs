using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected Animator m_animator;

    [SerializeField]
    protected float m_distanceToPlayerToWalk;
    [SerializeField]
    protected float m_distanceToPlayerToRun;
    [SerializeField]
    protected float m_distanceToAttack;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(Tags.Player);
        float distanceToPlayer = (player.transform.position - transform.position).magnitude;

        bool isAttacking = false;
        bool isRunning = false; 
        bool isWalking = false;

        if(distanceToPlayer < m_distanceToAttack)
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
    }
    protected void LookAtPlayer(GameObject player)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane((player.transform.position - transform.position), Vector3.up));
    }

    protected virtual void UpdateRoaming()
    {

    }


    protected virtual void UpdateAnimatorValues(bool isAttacking, bool isRunning, bool isWalking)
    {
    }
}
