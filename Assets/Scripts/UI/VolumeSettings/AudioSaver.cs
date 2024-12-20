using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSaver : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private Slider _slider;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private string _fileName;

    private SaveData _saveData = new();
    private string _path;

    public AudioMixerGroup AudioMixerGroup => _audioMixerGroup;
    public Slider Slider => _slider;
    public Toggle Toggle => _toggle;

    public void Setup()
    {
        _path = Path.Combine(Application.dataPath, _fileName);

        if (File.Exists(_path))
            _saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(_path));

        _slider.value = _saveData.value;
        _toggle.isOn = _saveData.flag;        
    }

    public void Save()
    {
        _saveData.value = _slider.value;
        _saveData.flag = _toggle.isOn;

        File.WriteAllText(_path, JsonUtility.ToJson(_saveData));
    }    
}