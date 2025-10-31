using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public Material dissolveMaterial;
    public float dissolveSpeed = 1f;
    private float dissolveAmount = 0f;

    void Update()
    {
        dissolveAmount += Time.deltaTime * dissolveSpeed;
        dissolveMaterial.SetFloat("_DissolveAmount", dissolveAmount);
    }
}

