using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ElementSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips = new AudioClip[4];

    private AudioSource _audioSource;

    private void Awake() => 
        _audioSource = GetComponent<AudioSource>();

    public void PlaySound(Element element)
    {
        if (_audioSource.isPlaying == false)
        {
            if (element is WaterElement)
                _audioSource.clip = _audioClips[0];
            if (element is FireElement)
                _audioSource.clip = _audioClips[1]; 
            if (element is EarthElement)
                _audioSource.clip = _audioClips[2];
            if (element is WindElement)
                _audioSource.clip = _audioClips[3];

            _audioSource.Play();
        }
    }

    public void StopSound() => 
        _audioSource?.Stop();
}
