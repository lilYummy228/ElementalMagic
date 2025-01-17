using UnityEngine;
using YG;

public class LevelProgressChecker : MonoBehaviour
{
    [SerializeField] private Transform[] _reachIcons;

    public void Load()
    {
        for (int i = 0; i < _reachIcons.Length; i++)
            _reachIcons[i].gameObject.SetActive(YandexGame.savesData.IsLevelPassed[i]);
    }

    [ContextMenu("Refresh level count")]
    public void RefreshLevelCount()
    {
        YandexGame.savesData.IsLevelPassed = new bool[_reachIcons.Length];

        YandexGame.SaveProgress();
    }
}
