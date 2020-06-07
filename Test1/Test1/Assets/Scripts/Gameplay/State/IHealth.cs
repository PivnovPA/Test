using UnityEngine;

public interface IHealth
{
    float MaxStreinght { get; }
    float CurrentStreinght { get; }

    void TakeDamage(float amount);

    void ApplyHealth(float healthAmount);

}
