using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public AudioSource audio;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio.Play();
        }
    }
}
