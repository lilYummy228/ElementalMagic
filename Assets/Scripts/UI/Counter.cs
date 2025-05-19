using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Counter : MonoBehaviour
    {
        private const int SecondsPerMinute = 60;
        private const int Second = 1;
        private const float Delay = 0.5f;

        [SerializeField] private TextMeshProUGUI _startGameCounter;
        [SerializeField] private TextMeshProUGUI _startGameText;
        [SerializeField] private int _startGameCount = 3;
        [SerializeField] private Image _cooldown;

        private WaitForSeconds _counter;
        private WaitForSeconds _stopwatch;
        private Coroutine _timeCoroutine;
        private Coroutine _cooldownCoroutine;
        private int _minutes;
        private int _seconds;

        public event Action Counted;
        public event Action<int, int> TimerStopped;

        private void Awake()
        {
            _counter = new WaitForSeconds(Delay);
            _stopwatch = new WaitForSeconds(Second);
        }

        public void StartCountDown() =>
            StartCoroutine(nameof(CountDown));

        public void StartCountTime() =>
            _timeCoroutine = StartCoroutine(nameof(CountTime));

        public void StartCooldown(float delay)
        {
            if (_cooldownCoroutine != null)
                StopCoroutine(_cooldownCoroutine);

            _cooldownCoroutine = StartCoroutine(nameof(Cooldown), delay);
        }

        public void StopCountTime()
        {
            if (_timeCoroutine != null)
                StopCoroutine(_timeCoroutine);

            TimerStopped?.Invoke(_minutes, _seconds);
        }

        private IEnumerator CountDown()
        {
            for (int i = _startGameCount; i > 0; i--)
            {
                _startGameCounter.text = i.ToString();

                yield return _counter;
            }

            _startGameCounter.text = _startGameText.text;

            yield return _counter;

            _startGameCounter.text = null;

            Counted?.Invoke();
        }

        private IEnumerator CountTime()
        {
            while (enabled)
            {
                if (_seconds == SecondsPerMinute)
                {
                    _minutes++;
                    _seconds = default;
                }
                else
                {
                    _seconds++;
                }

                yield return _stopwatch;
            }
        }

        private IEnumerator Cooldown(float delay)
        {
            _cooldown.fillAmount = 1;
            float step = _cooldown.fillAmount / delay;

            while (enabled)
            {
                _cooldown.fillAmount = Mathf.MoveTowards(_cooldown.fillAmount, 0, step * Time.deltaTime);

                yield return new WaitForFixedUpdate();

                if (_cooldown.fillAmount == 0)
                    _cooldown.fillAmount = 1;
            }
        }
    }
}