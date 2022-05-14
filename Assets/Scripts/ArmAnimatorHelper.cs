using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmAnimatorHelper : MonoBehaviour
{
    Animator m_armAnimator;
 
    static public bool m_isActionInProgress = false;

    [SerializeField]
    Collider m_swordCollider;

    // Start is called before the first frame update
    void Awake()
    {
        m_armAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnSwordSliceAttack(InputAction.CallbackContext value) // think about moving it to the playercontroller somehow
    {
        if (value.performed && !m_isActionInProgress)
        {
            m_armAnimator.SetTrigger(AnimationConstants.SwordSliceAttackTrigger);
            m_isActionInProgress = true;
        }
    }

    public void ResetAnimFlags()
    {
        m_isActionInProgress = false;
    }

    public void OnSwordSliceAttack_Start()
    {
        m_swordCollider.enabled = true;
    }

    public void OnSwordSliceAttack_Stop()
    {
        m_swordCollider.enabled = false;
    }
}
