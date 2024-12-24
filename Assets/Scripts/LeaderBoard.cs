using UnityEngine;
using YG;

public class LeaderBoard : MonoBehaviour
{
    private const string YandexLeaderBoardName = "Score";

    [SerializeField] private Wallet _wallet;

    private int _score;

    private void OnEnable() => 
        _wallet.CountChanged += SaveScore;

    private void OnDisable() => 
        _wallet.CountChanged -= SaveScore;

    public void SaveScore(int score)
    {
        _score += score;

        YandexGame.NewLeaderboardScores(YandexLeaderBoardName, _score);
    }
}
