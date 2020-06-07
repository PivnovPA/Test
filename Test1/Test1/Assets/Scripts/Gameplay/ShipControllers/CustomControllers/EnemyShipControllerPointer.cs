using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

public class EnemyShipControllerPointer : EnemyShipController
{
    [SerializeField]
    private GameObject[] pointsMove;
    [SerializeField]
    private int _currentPoint;
    private void Start()
    {
        _currentPoint = 0;
    }
    protected override void ProcessHandling(MovementSystem movementSystem)
    {
        movementSystem.PointerMovement(pointsMove[_currentPoint]);
        CheckCurrentPointPosition();
    }

    private void CheckCurrentPointPosition()
    {
        if (transform.position == pointsMove[_currentPoint].transform.position)
        {
            _currentPoint++;
        }
    }
}
