using UnityEngine;

namespace GameLogic
{
    public class TimeManager : MonoBehaviour
    {
        public void Pause() =>
            Time.timeScale = 0f;

        public void Unpause() =>
            Time.timeScale = 1f;
    }
}