using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(0)] private int _currentHealthValue;

    public int MaxHealthValue { get; private set; }
    public int CurrentHealthValue => _currentHealthValue;

    public event Action HealthValueChanged;
    public event Action Dead;

    private void Start() =>
        StartDeathControl();

    public void TakeDamage(int damageValue)
    {
        _currentHealthValue -= damageValue;

        if (_currentHealthValue < 0)
            _currentHealthValue = 0;

        HealthValueChanged?.Invoke();
    }

    public void SetHealth(int healthValue)
    {
        if (healthValue > 0)
        {
            _currentHealthValue = healthValue;
            MaxHealthValue = healthValue;

            HealthValueChanged?.Invoke();
        }
    }

    public void StartDeathControl() =>
        StartCoroutine(nameof(ControlDeath));

    private IEnumerator ControlDeath()
    {
        yield return new WaitUntil(() => _currentHealthValue <= 0);

        Dead?.Invoke();
    }
}
