using UnityEngine;

public class ElementAbilityEffector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireEffect;
    [SerializeField] private ParticleSystem _waterEffect;

    public ParticleSystem FireEffect => _fireEffect;
    public ParticleSystem WaterEffect => _waterEffect;

    public void PlayEffect(ParticleSystem particleSystem)
    {
        if (particleSystem.isPlaying == false)
            particleSystem.Play();
    }
}
