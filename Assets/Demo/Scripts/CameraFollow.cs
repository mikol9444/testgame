using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    public Vector3 offset;
    private void Start()
    {
        target = Player.Instance.tr;
        offset = transform.position;
    }
    private void LateUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
