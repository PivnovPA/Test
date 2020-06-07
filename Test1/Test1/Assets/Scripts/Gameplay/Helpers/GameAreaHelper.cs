using UnityEngine;

namespace Gameplay.Helpers
{
    public class GameAreaHelper : Singleton<GameAreaHelper>
    {

        private Camera _camera;
        float camHalfHeight;
        float camHalfWidth;
        Vector3 camPos;
        float topBound;
        float bottomBound;
        float leftBound;
        float rightBound;


        private void Start()
        {
            _camera = Camera.main;
            camHalfHeight = _camera.orthographicSize;
            camHalfWidth = camHalfHeight * _camera.aspect;
            camPos = _camera.transform.position;
            topBound = camPos.y + camHalfHeight;
            bottomBound = camPos.y - camHalfHeight;
            leftBound = camPos.x - camHalfWidth;
            rightBound = camPos.x + camHalfWidth;
        }


        public bool IsInGameplayArea(Transform objectTransform, Bounds objectBounds)
        {
            var objectPos = objectTransform.position;

            return (objectPos.x - objectBounds.extents.x < rightBound)
                && (objectPos.x + objectBounds.extents.x > leftBound)
                && (objectPos.y - objectBounds.extents.y < topBound)
                && (objectPos.y + objectBounds.extents.y > bottomBound);

        }

        public bool LeftBoundsCollisiton (Transform objectTransform, Bounds objectBounds)
        {   
            var objectPos = objectTransform.position;

            return (objectPos.x - objectBounds.extents.x < leftBound);
        }

        public bool RightBoundCollision(Transform objectTransform, Bounds objectBounds)
        {
            var objectPos = objectTransform.position;

            return (objectPos.x + objectBounds.extents.x > rightBound);
        }
        
    }
}