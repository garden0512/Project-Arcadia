using UnityEngine;

namespace Arcadia.Prototype.ComprehensiveEffectPrototypeVer1
{
    public class ParallaxEffect : MonoBehaviour
    {
        public Camera camera;
        public Transform followTarget;

        private Vector2 startingPosition;
        private float startingZPoint;
        private Vector2 camMoveSinceStart => (Vector2)camera.transform.position - startingPosition;
        private float zDistanceFromTarget => transform.position.z - followTarget.position.z;
        float clippingPlane => (camera.transform.position.z + (zDistanceFromTarget)>0?camera.farClipPlane :camera.nearClipPlane);
        float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

        void Start()
        {
            startingPosition = transform.position;
            startingZPoint = transform.localPosition.z;
        }

        void Update()
        {
            Vector2 newPosition = startingPosition + camMoveSinceStart / parallaxFactor;
            transform.position = new Vector3(newPosition.x, newPosition.y, startingZPoint);
        }
    }
}