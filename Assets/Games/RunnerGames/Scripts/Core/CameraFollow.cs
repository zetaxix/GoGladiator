using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;
    public Vector3 offset = new Vector3(0,5,-10); // Kameranýn oyuncuya göre konumu
    [SerializeField] float smoothTime = 0.4f; // Takip yumuþaklýðý ayarý

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 targetPosition = targetPlayer.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
