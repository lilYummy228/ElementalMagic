using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    private const int MinVolumeValue = -80;
    private const int Multiplier = 20;

    [Header("AudioMixers")]
    [SerializeField] private AudioMixerGroup _music;
    [SerializeField] private AudioMixerGroup _sounds;
    [Header("Sliders")]
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundsSlider;
    [Header("Toggles")]
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _soundsToggle;

    private void Awake()
    {
        _musicSlider.onValueChanged.AddListener(delegate { ChangeVolume(_music, _musicToggle, _musicSlider.value); });
        _soundsSlider.onValueChanged.AddListener(delegate { ChangeVolume(_sounds, _soundsToggle, _soundsSlider.value); });

        _musicToggle.onValueChanged.AddListener(delegate { SwitchToggle(_music, _musicToggle, _musicSlider.value); });
        _soundsToggle.onValueChanged.AddListener(delegate { SwitchToggle(_sounds, _soundsToggle, _soundsSlider.value); });
    }

    public void SwitchToggle(AudioMixerGroup audioMixer, Toggle toggle, float volume)
    {
        if (toggle.isOn)
            audioMixer.audioMixer.SetFloat(audioMixer.name, Mathf.Log10(volume) * 20);
        else
            audioMixer.audioMixer.SetFloat(audioMixer.name, MinVolumeValue);
    }

    public void ChangeVolume(AudioMixerGroup audioMixer, Toggle toggle, float volume)
    {
        if (toggle.isOn)
            audioMixer.audioMixer.SetFloat(audioMixer.name, Mathf.Log10(volume) * Multiplier);
    }
}