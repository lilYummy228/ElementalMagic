using System;
using UnityEngine;
using YG;

public class GameContinuation : MonoBehaviour
{
    private const int RewardId = 2;

    [SerializeField] private AdsProvider _adsProvider;

    public event Action GameContinued;

    private void OnEnable() => 
        YandexGame.RewardVideoEvent += Continue;

    private void OnDisable() => 
        YandexGame.RewardVideoEvent -= Continue;

    public void Continue(int id)
    {
        if (id != RewardId)
            return;

        GameContinued?.Invoke();
    }
}
