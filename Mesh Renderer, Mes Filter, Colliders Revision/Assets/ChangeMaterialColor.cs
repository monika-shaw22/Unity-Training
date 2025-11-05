using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Material[] materials;
    private Renderer rend;
    private int index = 0;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = materials[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index = (index + 1) % materials.Length;
            rend.material = materials[index];
        }
        
    }
}
