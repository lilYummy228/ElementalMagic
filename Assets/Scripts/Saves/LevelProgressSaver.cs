using Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace Saves
{
    public class LevelProgressSaver : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;

        private void OnEnable() =>
            _enemySpawner.AllEnemiesDied += Save;

        private void OnDisable() =>
            _enemySpawner.AllEnemiesDied -= Save;

        private void Save()
        {
            YandexGame.savesData.isLevelPassed[SceneManager.GetActiveScene().buildIndex - 1] = true;

            YandexGame.SaveProgress();
        }
    }
}