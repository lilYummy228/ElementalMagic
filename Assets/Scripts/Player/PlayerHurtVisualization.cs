using System.Collections;
using UnityEngine;

public class PlayerHurtVisualization : MonoBehaviour
{
    private const float FullAlpha = 1f;
    private const float ZeroAlpha = 0f;

    [SerializeField] private Health _health;
    [SerializeField] private SpriteRenderer _hurtOverlay;
    [SerializeField] private float _changeSpeed;

    private float _currentHealthValue;

    public WaitForFixedUpdate WaitForFixedUpdate => new();

    private void OnEnable() =>
        _health.HealthValueChanged += StartBlink;

    private void OnDisable() =>
        _health.HealthValueChanged -= StartBlink;

    private void StartBlink()
    {
        if (Mathf.Round(_health.CurrentHealthValue) != Mathf.Round(_health.MaxHealthValue))
            if (Mathf.Round(_health.CurrentHealthValue) < Mathf.Round(_currentHealthValue))
                StartCoroutine(Blink(_hurtOverlay));

        _currentHealthValue = _health.CurrentHealthValue;
    }

    private IEnumerator Blink(SpriteRenderer overlay)
    {
        while (Mathf.Round(overlay.color.a) != Mathf.Round(FullAlpha))
        {
            ChangeAlpha(FullAlpha, overlay);

            yield return WaitForFixedUpdate;
        }

        while (Mathf.Round(overlay.color.a) != Mathf.Round(ZeroAlpha))
        {
            ChangeAlpha(ZeroAlpha, overlay);

            yield return WaitForFixedUpdate;
        }
    }

    private void ChangeAlpha(float alpha, SpriteRenderer overlay) => 
        overlay.color = new Color(1f, 1f, 1f, Mathf.MoveTowards(overlay.color.a, alpha, _changeSpeed * Time.deltaTime));
}
