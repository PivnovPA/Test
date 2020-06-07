using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        [HideInInspector]
        public bool goLeft = true;
        [HideInInspector]
        public bool goRight = true;
        private float movement;
        public enum PlayerMoveState
        {
            Left,
            Right

        }
        [HideInInspector]
        public PlayerMoveState _playerMoveState;
        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movement = Input.GetAxis("Horizontal");

            SwitchState();

            if (_playerMoveState == PlayerMoveState.Left)
            {
                Move(movementSystem, goLeft);
            }

            else if (_playerMoveState == PlayerMoveState.Right)
            {
                Move(movementSystem, goRight);
            }
        }

        public void Move(MovementSystem movementSystem, bool directionAction)
        {
            if(directionAction == true)
               movementSystem.LateralMovement(movement * Time.deltaTime);
        }
       
        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fireSystem.TriggerFire();
            }

        }


        void SwitchState()
        {
            if (movement > 0)
            {
                _playerMoveState = PlayerMoveState.Right;
            }
            else if (movement < 0)
            {
                _playerMoveState = PlayerMoveState.Left;
            }
        }
    }
}
