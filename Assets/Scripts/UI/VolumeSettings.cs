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

    private void OnEnable()
    {
        _musicSlider.onValueChanged.AddListener(delegate { ChangeVolume(_music, _musicToggle, _musicSlider); });
        _soundsSlider.onValueChanged.AddListener(delegate { ChangeVolume(_sounds, _soundsToggle, _soundsSlider); });

        _musicToggle.onValueChanged.AddListener(delegate { SwitchToggle(_music, _musicToggle, _musicSlider); });
        _soundsToggle.onValueChanged.AddListener(delegate { SwitchToggle(_sounds, _soundsToggle, _soundsSlider); });
    }

    private void OnDisable()
    {
        _musicSlider.onValueChanged.RemoveListener(delegate { ChangeVolume(_music, _musicToggle, _musicSlider); });
        _soundsSlider.onValueChanged.RemoveListener(delegate { ChangeVolume(_sounds, _soundsToggle, _soundsSlider); });

        _musicToggle.onValueChanged.RemoveListener(delegate { SwitchToggle(_music, _musicToggle, _musicSlider); });
        _soundsToggle.onValueChanged.RemoveListener(delegate { SwitchToggle(_sounds, _soundsToggle, _soundsSlider); });
    }

    public void Setup()
    {
        _musicToggle.isOn = PlayerPrefs.GetInt(_musicToggle.name) == 1;
        _soundsToggle.isOn = PlayerPrefs.GetInt(_soundsToggle.name) == 1;

        _musicSlider.value = PlayerPrefs.GetFloat(_musicSlider.name);
        _soundsSlider.value = PlayerPrefs.GetFloat(_soundsSlider.name);

        ChangeVolume(_music, _musicToggle, _musicSlider);
        ChangeVolume(_sounds, _soundsToggle, _soundsSlider);

        SwitchToggle(_music, _musicToggle, _musicSlider);
        SwitchToggle(_sounds, _soundsToggle, _soundsSlider);
    }

    public void SwitchToggle(AudioMixerGroup audioMixer, Toggle toggle, Slider slider)
    {
        if (toggle.isOn)
            audioMixer.audioMixer.SetFloat(audioMixer.name, Mathf.Log10(slider.value) * Multiplier);
        else
            audioMixer.audioMixer.SetFloat(audioMixer.name, MinVolumeValue);

        PlayerPrefs.SetInt($"{toggle.name}", toggle.isOn ? 1 : 0);
    }

    public void ChangeVolume(AudioMixerGroup audioMixer, Toggle toggle, Slider slider)
    {
        if (toggle.isOn)
            audioMixer.audioMixer.SetFloat(audioMixer.name, Mathf.Log10(slider.value) * Multiplier);

        PlayerPrefs.SetFloat($"{slider.name}", slider.value);
    }
}