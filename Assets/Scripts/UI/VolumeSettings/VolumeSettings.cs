using UnityEngine;

public class VolumeSettings : MonoBehaviour
{
    private const int MinVolumeValue = -80;
    private const int Multiplier = 20;

    [SerializeField] private AudioSetup _music;
    [SerializeField] private AudioSetup _sounds;
    [SerializeField] private AudioSaveSystem _saveSystem;

    public AudioSetup Music => _music;
    public AudioSetup Sounds => _sounds;

    private void OnDisable() => 
        _saveSystem.Save();

    public void Load() => 
        _saveSystem.Load();

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
}