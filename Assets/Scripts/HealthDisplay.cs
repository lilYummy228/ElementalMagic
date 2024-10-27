using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speed = 12;

    private Slider _slider;

    private void Awake() =>
        _slider = GetComponent<Slider>();

    private void OnEnable() =>
        _health.HealthChanged += RefreshHealth;

    private void OnDisable() =>
        _health.HealthChanged -= RefreshHealth;

    private void RefreshHealth() =>
        StartCoroutine(RefreshHealthSmoothly());

    private IEnumerator RefreshHealthSmoothly()
    {
        if (_slider.maxValue != _health.MaxHealth)
            _slider.maxValue = _health.MaxHealth;

        while (_slider.value != _health.HealthValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.HealthValue, _speed * Time.deltaTime);

            yield return new WaitForFixedUpdate();
        }
    }
}
