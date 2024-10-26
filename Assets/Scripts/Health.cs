using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthValue;

    public int HealthValue => _healthValue;

    public event Action<int> HealthChanged;
    public event Action Dead;

    private void Awake() => 
        StartCoroutine(nameof(CheckDeath));

    public void TakeDamage(int damage)
    {
        _healthValue -= damage;

        HealthChanged?.Invoke(_healthValue);
    }

    public void SetHealth(int healthValue)
    {
        if (healthValue > 0)
            _healthValue = healthValue;
        else
            _healthValue = 0;

        HealthChanged?.Invoke(_healthValue);
    }

    private IEnumerator CheckDeath()
    {
        yield return new WaitUntil(() => _healthValue <= 0);
         
        Dead?.Invoke();
    }
}
