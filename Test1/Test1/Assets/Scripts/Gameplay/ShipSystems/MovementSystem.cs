using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class MovementSystem : MonoBehaviour
    {

        [SerializeField]
        private float _lateralMovementSpeed;
        
        [SerializeField]
        private float _longitudinalMovementSpeed;

        [SerializeField]
        private float _pointerMovementSpeed;
        

        public void LateralMovement(float amount)
        {
            Move(amount * _lateralMovementSpeed, Vector3.right);
        }

        public void LongitudinalMovement(float amount)
        {
            Move(amount * _longitudinalMovementSpeed, Vector3.up);
        }

        
        private void Move(float amount, Vector3 axis)
        {
            transform.Translate(amount * axis.normalized);  
        }

        public void PointerMovement(GameObject currentPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, _pointerMovementSpeed * Time.deltaTime);
        }
    }
}
