using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [SerializeField]
    private int rewardKill;

    
    public KillReward _killReward;
    public int RewardKill => rewardKill;
}
