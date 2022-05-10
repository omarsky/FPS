using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : EnemyController
{
    float m_timer = 0f;

    protected override void UpdateAnimatorValues(bool isAttacking, bool isRunning, bool isWalking)
    {
        base.UpdateAnimatorValues(isAttacking, isRunning, isWalking);

        m_animator.SetBool(AnimationConstants.ZombieAttack, isAttacking);
        m_animator.SetBool(AnimationConstants.ZombieWalking, isWalking);
        m_animator.SetBool(AnimationConstants.ZombieRunning, isRunning);
    }

    protected override void UpdateRoaming()
    {
        base.UpdateRoaming();

        m_timer -= Time.deltaTime;
        if (m_timer <= 0f)
        {
            m_timer = 5f;
            bool isRoaming = m_animator.GetBool(AnimationConstants.ZombieRoaming);
            isRoaming = !isRoaming;
            if (isRoaming)
            {
                transform.Rotate(transform.up, Random.Range(0, 360f));
            }
            m_animator.SetBool(AnimationConstants.ZombieRoaming, isRoaming);
        }
    }
}
