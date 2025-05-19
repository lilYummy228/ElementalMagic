using UnityEngine;
using YG;

namespace Saves
{
    public class LevelProgressChecker : MonoBehaviour
    {
        [SerializeField] private Transform[] _reachIcons;

        public void Load()
        {
            for (int i = 0; i < _reachIcons.Length; i++)
                _reachIcons[i].gameObject.SetActive(YandexGame.savesData.isLevelPassed[i]);
        }

        [ContextMenu("Refresh level count")]
        public void RefreshLevelCount()
        {
            YandexGame.savesData.isLevelPassed = new bool[_reachIcons.Length];

            YandexGame.SaveProgress();
        }
    }
}