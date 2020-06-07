using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.ShipSystems;
public abstract class Bonus : MonoBehaviour
{
    [SerializeField]
    private MovementSystem _movementSystem;

    protected virtual void Update()
    {
        _movementSystem.LongitudinalMovement(Time.deltaTime);
    }
}
