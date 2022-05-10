using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmAnimatorHelper : MonoBehaviour
{
    Animator m_armAnimator;
 
    static public bool m_isActionInProgress = false;

    public float m_cooldown = 2f;
    float m_currentCooldown = 0;

    // Start is called before the first frame update
    void Awake()
    {
        m_armAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_currentCooldown -= Time.deltaTime;
    }

    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.performed && m_currentCooldown <= 0)
        {
            m_armAnimator.SetTrigger(AnimationConstants.ShouldShootTrigger);
            m_isActionInProgress = true;
            m_currentCooldown = m_cooldown;
        }
    }
    public void OnZieg(InputAction.CallbackContext value)
    {
        if (value.performed && !m_isActionInProgress)
        {
            m_armAnimator.SetTrigger(AnimationConstants.ShouldZiegTrigger);
            m_isActionInProgress = true;
        }
    }

    public void ResetAnimFlags()
    {
        m_isActionInProgress = false;
    }

    public void Attack()
    {
        GetComponentInParent<PlayerController>().OnAttack();
    }
}
