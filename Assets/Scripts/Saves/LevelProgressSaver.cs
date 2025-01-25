using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LevelProgressSaver : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    private void OnEnable() => 
        _enemySpawner.AllEnemiesDied += Save;

    private void OnDisable() => 
        _enemySpawner.AllEnemiesDied -= Save;

    private void Save()
    {
        YandexGame.savesData.IsLevelPassed[SceneManager.GetActiveScene().buildIndex - 1] = true;

        YandexGame.SaveProgress();
    }
}
