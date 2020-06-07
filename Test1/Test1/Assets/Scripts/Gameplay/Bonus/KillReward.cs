using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillReward : MonoBehaviour
{
    [SerializeField]
    private GameObject bonus;
    public void InstanceBonus()
    {
        if (Probability() > 70)
        {
            Instantiate(bonus, transform.position, transform.rotation);
        }
    }

    int Probability()
    {
        return Random.Range(0, 100);
    }
}
