using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            meshRenderer.enabled = !meshRenderer.enabled;
        }
    }
}
