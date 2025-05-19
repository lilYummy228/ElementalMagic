using UnityEngine;
using YG;

namespace Statistics
{
    public class Authorization : MonoBehaviour
    {
        [SerializeField] private Transform _authorizationPanel;
        [SerializeField] private Transform _leaderBoard;

        public void CheckAuth()
        {
            _authorizationPanel.gameObject.SetActive(!YandexGame.auth);
            _leaderBoard.gameObject.SetActive(YandexGame.auth);
        }
    }
}