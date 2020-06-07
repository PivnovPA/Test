using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : Bonus, ISpeedDealer
{   
    [SerializeField]
    private float _speedUpdate;
    public float SpeedUpdate => _speedUpdate;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var objectSpeedUpdate = other.gameObject.GetComponent<ISpeed>();

        if (objectSpeedUpdate != null)
        {
            objectSpeedUpdate.SpeedUpdate(_speedUpdate);
            Destroy(this.gameObject);
        }

    }
}
