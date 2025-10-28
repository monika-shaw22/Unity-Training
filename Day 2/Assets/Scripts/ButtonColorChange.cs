using UnityEngine;

using static UnityEngine.GraphicsBuffer;

public class ButtonColorChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject target;
    public void ChangeColor()
    {
        target.GetComponent<Renderer>().material.color = Color.red;
    }
}
