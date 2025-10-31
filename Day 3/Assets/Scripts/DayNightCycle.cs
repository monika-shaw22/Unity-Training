using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight;
    public float rotationSpeed = 1f;

    void Update()
    {
        directionalLight.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}