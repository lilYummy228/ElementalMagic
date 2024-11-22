using UnityEngine;

public class ElementAbilityEffector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireEffect;

    public ParticleSystem FireEffect => _fireEffect;

    public void PlayEffect(ParticleSystem particleSystem)
    {
        if (particleSystem.isPlaying == false)
            particleSystem.Play();
    }
}
