using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SwordScript : WeaponScript
{
    bool m_isCharging = false;
    float m_chargeAttackValue = 0f;

    [Header("Sword section")]
    [SerializeField] float m_maxChargeBonus = 10f;
    [SerializeField] float m_chargeSpeed = 1f;
    [SerializeField] GameObject m_chargeMeter;
    Slider m_chargeAttackSlider;

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

    private void Awake()
    {
        m_chargeAttackSlider = m_chargeMeter.GetComponent<Slider>();
        m_chargeAttackSlider.maxValue = m_maxChargeBonus;
    }

    void Update()
    {
        if (m_isCharging)
        {
            m_chargeAttackValue += m_chargeSpeed * Time.deltaTime;
            m_chargeAttackValue = Mathf.Min(m_chargeAttackValue, m_maxChargeBonus);
            m_chargeAttackSlider.value = m_chargeAttackValue;
        }
    }

    public void OnSwordSliceAttack_Prepare(InputAction.CallbackContext value)
    {
        if (!PauseMenu.m_gameIsPaused)
        {
            m_armAnimator.SetBool(AnimationConstants.SwordSliceAttack_PrepareAttack, true);
            m_chargeAttackValue = 0f;
            m_isCharging = true;
            m_chargeMeter.SetActive(true);
        }
    }

    public void OnSwordSliceAttack_CancelPreparation(InputAction.CallbackContext value)
    {
        if (!PauseMenu.m_gameIsPaused)
        {
            m_armAnimator.SetBool(AnimationConstants.SwordSliceAttack_PrepareAttack, false);
            m_chargeAttackValue = 0f;
            m_isCharging = false;
            m_chargeMeter.SetActive(false);
        }
    }

    public void OnSwordSliceAttack(InputAction.CallbackContext value)
    {
        if (!ArmAnimatorHelper.m_isActionInProgress && m_isCharging)
        {
            m_armAnimator.SetBool(AnimationConstants.SwordSliceAttack_PrepareAttack, false);
            m_armAnimator.SetTrigger(AnimationConstants.SwordSliceAttackTrigger);
            m_isCharging = false;
            m_chargeMeter.SetActive(false);
            ArmAnimatorHelper.m_isActionInProgress = true;
        }
    }
}
