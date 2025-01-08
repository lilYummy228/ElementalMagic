using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ElementAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceSelection;
    [SerializeField] private AudioSource _audioSourceAttack;

    public AudioSource AudioSourceSelection => _audioSourceSelection;

    public void PlaySelectionSound(Element element)
    {
        if (_audioSourceSelection.isPlaying == false)
        {
            _audioSourceSelection.clip = element.SelectionSound;

            _audioSourceSelection.Play();
        }
    }

    public void PlayAttackSound(Element element) => 
        _audioSourceAttack.PlayOneShot(element.AttackSound);
}
