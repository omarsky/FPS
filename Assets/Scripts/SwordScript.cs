using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Enemy))
        {
            other.gameObject.GetComponent<HealthComponent>().ReceiveDamage(GameplayConstants.SwordAttackDamage);
        }
    }
}
