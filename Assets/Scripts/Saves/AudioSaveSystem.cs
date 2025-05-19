using UI.VolumeSettings;
using UnityEngine;
using YG;

namespace Saves
{
    public class AudioSaveSystem : MonoBehaviour, ISaveSystem
    {
        [SerializeField] private VolumeSettings _volumeSettings;

        public void Load()
        {
            _volumeSettings.Music.Setup(YandexGame.savesData.musicVolume, YandexGame.savesData.isMusicOn);
            _volumeSettings.Sounds.Setup(YandexGame.savesData.soundsVolume, YandexGame.savesData.isSoundsOn);

            _volumeSettings.SwitchToggle(_volumeSettings.Music);
            _volumeSettings.SwitchToggle(_volumeSettings.Sounds);
        }

        public void Save()
        {
            YandexGame.savesData.musicVolume = _volumeSettings.Music.Slider.value;
            YandexGame.savesData.soundsVolume = _volumeSettings.Sounds.Slider.value;

            YandexGame.savesData.isMusicOn = _volumeSettings.Music.Toggle.isOn;
            YandexGame.savesData.isSoundsOn = _volumeSettings.Sounds.Toggle.isOn;

            YandexGame.SaveProgress();
        }
    }
}