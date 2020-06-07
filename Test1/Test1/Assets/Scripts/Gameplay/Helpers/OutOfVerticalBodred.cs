using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Helpers;
using Gameplay.ShipControllers.CustomControllers;

public class OutOfVerticalBodred : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _representation;
    public PlayerShipController _playerShipController;
    private void Start()
    {
        _playerShipController.GetComponent<PlayerShipController>();
    }
    void Update()
    {
        CheckBorders();
        CheckLeftBodrers();
        CheckRightBorders();
    }

    private void CheckBorders()
    {
       
        if (GameAreaHelper.Instance.IsInGameplayArea(transform, _representation.bounds))
        {
            if (_playerShipController.goRight == false)
            {
                _playerShipController.goRight = true;
            }

            if (_playerShipController.goLeft == false)
            {
                _playerShipController.goLeft = true;
            }
        }
    }

    private void CheckLeftBodrers()
    {
        if (GameAreaHelper.Instance.LeftBoundsCollisiton(transform, _representation.bounds))
        {
            _playerShipController.goLeft = false;
        }
    }

    private void CheckRightBorders()
    {
        if (GameAreaHelper.Instance.RightBoundCollision(transform, _representation.bounds))
        {
            _playerShipController.goRight = false;
        }
    }

}
