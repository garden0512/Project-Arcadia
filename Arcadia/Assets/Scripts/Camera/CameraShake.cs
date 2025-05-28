using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _shakeMagnitude = 3f;
    [SerializeField] private float _shakeDuration = 0.25f;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            doShake();
        }
    }

    public void doShake()
    {
        CameraMove.Instance.Shake(_shakeMagnitude, _shakeDuration);
    }
}
