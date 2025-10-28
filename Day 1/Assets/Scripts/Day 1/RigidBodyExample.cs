using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = new Vector3(5f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
