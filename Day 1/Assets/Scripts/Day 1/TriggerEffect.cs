using UnityEngine;

public class TriggerEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ParticleSystem effect;

    private void OnMouseDown()
    {
        effect.Play();
    }
}
