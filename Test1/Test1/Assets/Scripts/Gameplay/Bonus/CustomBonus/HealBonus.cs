using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBonus : Bonus, IHealDealer
{
    [SerializeField]
    private float _healAmount;
    public float HealAmount => _healAmount;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var objectHeal = other.gameObject.GetComponent<IHealth>();

        if (objectHeal != null)
        {
            objectHeal.ApplyHealth(_healAmount);
            Destroy(this.gameObject);
        }

    }

}
