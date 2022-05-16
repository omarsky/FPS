using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordScript : WeaponScript
{
    bool m_isCharging = false;
    float m_chargeAttackValue = 0f;

    [Header("Sword section")]
    [SerializeField]
    float m_maxChargeBonus = 10f;
    [SerializeField]
    float m_chargeSpeed = 1f;

    protected override float GetDamageDeal()
    {
        return base.GetDamageDeal() + m_chargeAttackValue;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        m_weaponActionMap["SwordSlicePrepare"].performed += OnSwordSliceAttack_Prepare;
        m_weaponActionMap["CancelSwordSlice"].performed += OnSwordSliceAttack_CancelPreparation;
        m_weaponActionMap["SwordSlice"].performed += OnSwordSliceAttack;
    }

    void Update()
    {
        if (m_isCharging)
        {
            m_chargeAttackValue += m_chargeSpeed * Time.deltaTime;
            m_chargeAttackValue = Mathf.Min(m_chargeAttackValue, m_maxChargeBonus);
        }
    }

    public void OnSwordSliceAttack_Prepare(InputAction.CallbackContext value)
    {
        m_armAnimator.SetBool(AnimationConstants.SwordSliceAttack_PrepareAttack, true);
        m_chargeAttackValue = 0f;
        m_isCharging = true;
    }

    public void OnSwordSliceAttack_CancelPreparation(InputAction.CallbackContext value)
    {
        m_armAnimator.SetBool(AnimationConstants.SwordSliceAttack_PrepareAttack, false);
        m_chargeAttackValue = 0f;
        m_isCharging = false;
    }

    public void OnSwordSliceAttack(InputAction.CallbackContext value)
    {
        if (!ArmAnimatorHelper.m_isActionInProgress && m_isCharging)
        {
            m_armAnimator.SetBool(AnimationConstants.SwordSliceAttack_PrepareAttack, false);
            m_armAnimator.SetTrigger(AnimationConstants.SwordSliceAttackTrigger);
            m_isCharging = false;
            ArmAnimatorHelper.m_isActionInProgress = true;
        }
    }
}
