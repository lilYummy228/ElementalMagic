using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHurtVisualization : MonoBehaviour
    {
        private const float FullAlpha = 1f;
        private const float ZeroAlpha = 0f;

        [SerializeField] private Health.Health _health;
        [SerializeField] private Image _hurtOverlay;
        [SerializeField] private float _changeSpeed;

        private float _currentHealthValue;
        private WaitForFixedUpdate _waitForFixedUpdate;

        private void Awake() =>
            _waitForFixedUpdate = new WaitForFixedUpdate();

        private void OnEnable() =>
            _health.HealthValueChanged += StartBlink;

        private void OnDisable() =>
            _health.HealthValueChanged -= StartBlink;

        private void StartBlink()
        {
            if (_health.CurrentHealthValue < _health.MaxHealthValue)
                if (_health.CurrentHealthValue < _currentHealthValue)
                    StartCoroutine(Blink(_hurtOverlay));

            _currentHealthValue = _health.CurrentHealthValue;
        }

        private IEnumerator Blink(Image overlay)
        {
            while (overlay.color.a < FullAlpha)
            {
                ChangeAlpha(FullAlpha, overlay);

                yield return _waitForFixedUpdate;
            }

            while (overlay.color.a > ZeroAlpha)
            {
                ChangeAlpha(ZeroAlpha, overlay);

                yield return _waitForFixedUpdate;
            }
        }

        private void ChangeAlpha(float alpha, Image overlay) =>
            overlay.color = new Color(1f, 1f, 1f, Mathf.MoveTowards(overlay.color.a, alpha, _changeSpeed * Time.deltaTime));
    }
}