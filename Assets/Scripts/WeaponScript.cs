using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] protected Animator m_armAnimator;
    [SerializeField] float m_damageDeal;

    [SerializeField] protected InputActionMap m_weaponActionMap;

    protected virtual float GetDamageDeal()
    {
        return m_damageDeal;
    }

    protected virtual void OnEnable()
    {
        m_weaponActionMap.Enable();
    }

    protected virtual void OnDisable()
    {
        m_weaponActionMap.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Enemy))
        {
            other.gameObject.GetComponent<HealthComponent>().ReceiveDamage(GetDamageDeal());
        }
    }
}
