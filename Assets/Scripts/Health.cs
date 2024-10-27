using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(0)] private int _healthValue;

    public int MaxHealth { get; private set; }
    public int HealthValue => _healthValue;

    public event Action HealthChanged;
    public event Action Dead;

    private void Start() => 
        StartDeathControl();

    public void TakeDamage(int damage)
    {
        _healthValue -= damage;

        HealthChanged?.Invoke();
    }

    public void SetHealth(int healthValue, int maxHealthValue)
    {
        if (maxHealthValue > 0 && healthValue > 0)
        {
            _healthValue = healthValue;
            MaxHealth = maxHealthValue;

            HealthChanged?.Invoke();
        }
    }

    public void StartDeathControl() => 
        StartCoroutine(nameof(ControlDeath));

    private IEnumerator ControlDeath()
    {
        yield return new WaitUntil(() => _healthValue <= 0);

        Dead?.Invoke();
    }
}
