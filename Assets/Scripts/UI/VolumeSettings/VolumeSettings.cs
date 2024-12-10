using UnityEngine;

public class VolumeSettings : MonoBehaviour
{
    private const int MinVolumeValue = -80;
    private const int Multiplier = 20;

    [SerializeField] private AudioSetup[] _audios;

    public void Setup()
    {
        foreach (AudioSetup audio in _audios)
            audio.Setup();
    }

    public void SwitchToggle(AudioSetup audio)
    {
        if (audio.Toggle.isOn)
            audio.AudioMixerGroup.audioMixer.SetFloat(audio.AudioMixerGroup.name, Mathf.Log10(audio.Slider.value) * Multiplier);
        else
            audio.AudioMixerGroup.audioMixer.SetFloat(audio.AudioMixerGroup.name, MinVolumeValue);
    }

    public void ChangeVolume(AudioSetup audio)
    {
        if (audio.Toggle.isOn)
            audio.AudioMixerGroup.audioMixer.SetFloat(audio.AudioMixerGroup.name, Mathf.Log10(audio.Slider.value) * Multiplier);
    }

    private void OnDisable()
    {
        foreach (AudioSetup audio in _audios)
            audio.Save();
    }
}