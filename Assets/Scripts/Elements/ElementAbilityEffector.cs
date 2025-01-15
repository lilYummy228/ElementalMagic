using UnityEngine;

public class ElementAbilityEffector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireEffect;
    [SerializeField] private ParticleSystem _waterEffect;
    [SerializeField] private ParticleSystem _windEffect;
    [SerializeField] private ParticleSystem _earthEffect;

    public ParticleSystem FireEffect => _fireEffect;
    public ParticleSystem WaterEffect => _waterEffect;
    public ParticleSystem WindEffect => _windEffect;
    public ParticleSystem EarthEffect => _earthEffect;

    public void PlayEffect(ParticleSystem particleSystem)
    {
        if (particleSystem.isPlaying == false)
            particleSystem.Play();
    }

    public void StopAllEffects()
    {
        _fireEffect.Stop();
        _waterEffect.Stop();
        _windEffect.Stop();
        _earthEffect.Stop();
    }
}
