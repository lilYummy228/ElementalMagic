using UnityEngine;

public class VolumeSettings : MonoBehaviour
{
    private const int MinVolumeValue = -80;
    private const int Multiplier = 20;

    [SerializeField] private AudioSaver[] _audios;

    public void Setup()
    {
        foreach (AudioSaver audio in _audios)
        {
            audio.Setup();

            SwitchToggle(audio);
        }
    }

    public void SwitchToggle(AudioSaver audio)
    {
        if (audio.Toggle.isOn)
            audio.AudioMixerGroup.audioMixer.SetFloat(audio.AudioMixerGroup.name, Mathf.Log10(audio.Slider.value) * Multiplier);
        else
            audio.AudioMixerGroup.audioMixer.SetFloat(audio.AudioMixerGroup.name, MinVolumeValue);
    }

    public void ChangeVolume(AudioSaver audio)
    {
        if (audio.Toggle.isOn)
            audio.AudioMixerGroup.audioMixer.SetFloat(audio.AudioMixerGroup.name, Mathf.Log10(audio.Slider.value) * Multiplier);
    }

    private void OnDisable()
    {
        foreach (AudioSaver audio in _audios)
            audio.Save();
    }
}