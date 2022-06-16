using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmAnimatorHelper : MonoBehaviour
{
    [SerializeField] Collider m_swordCollider;
    [HideInInspector] static public bool m_isActionInProgress = false; //don't like this, DO SOMETHING WITH IT

    // Animation events
    public void OnSwordSliceAttack_Start()
    {
        m_swordCollider.enabled = true;
    }

    public void OnSwordSliceAttack_Stop()
    {
        m_swordCollider.enabled = false;
    }

    public void ResetAnimFlags()
    {
        m_isActionInProgress = false;
    }

    public void SetRunning(InputAction.CallbackContext value)
    {
        GetComponent<Animator>().SetBool(AnimationConstants.PlayerRun, value.phase == InputActionPhase.Performed);
    }
}
