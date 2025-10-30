using UnityEngine;

public class SideScrollerCamera : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.3f;

    void LateUpdate()
    {
        Vector3 newPos = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed);
    }
}
