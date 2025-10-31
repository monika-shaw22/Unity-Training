using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DamageEffect : MonoBehaviour
{
    public Volume volume;
    private Vignette vignette;
    private ChromaticAberration chromatic;

    void Start()
    {
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out chromatic);
    }

    public void TriggerDamage()
    {
        if (vignette != null) vignette.intensity.value = 0.5f;
        if (chromatic != null) chromatic.intensity.value = 1f;
    }
}