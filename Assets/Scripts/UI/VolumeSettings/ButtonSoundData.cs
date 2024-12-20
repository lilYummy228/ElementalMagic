using UnityEngine;

public class ButtonSoundData : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _enterClip;
    [SerializeField] private AudioClip _clickClip;

    public AudioSource AudioSource => _audioSource;
    public AudioClip EnterClip => _enterClip;
    public AudioClip ClickClip => _clickClip;
}
