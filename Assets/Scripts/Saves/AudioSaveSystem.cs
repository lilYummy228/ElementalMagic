using UnityEngine;
using YG;

public class AudioSaveSystem : MonoBehaviour, ISaveSystem
{
    [SerializeField] private VolumeSettings _volumeSettings;

    public void Load()
    {
        _volumeSettings.Music.Setup(YandexGame.savesData.MusicVolume, YandexGame.savesData.IsMusicOn);
        _volumeSettings.Sounds.Setup(YandexGame.savesData.SoundsVolume, YandexGame.savesData.IsSoundsOn);

        _volumeSettings.SwitchToggle(_volumeSettings.Music);
        _volumeSettings.SwitchToggle(_volumeSettings.Sounds);
    }

    public void Save()
    {
        YandexGame.savesData.MusicVolume = _volumeSettings.Music.Slider.value;
        YandexGame.savesData.SoundsVolume = _volumeSettings.Sounds.Slider.value;

        YandexGame.savesData.IsMusicOn = _volumeSettings.Music.Toggle.isOn;
        YandexGame.savesData.IsSoundsOn = _volumeSettings.Sounds.Toggle.isOn;        
    }
}
