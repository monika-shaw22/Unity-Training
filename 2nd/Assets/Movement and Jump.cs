using UnityEngine;

public class MovementandJump : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 10f;
    public float rotateSpeed = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up* move * moveSpeed*Time.deltaTime);
        transform.Rotate(Vector3.up * rotate * rotateSpeed * Time.deltaTime);
    }
}
