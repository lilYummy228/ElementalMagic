using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private float _affectSpeed = 45;
    [SerializeField] private Slider _slider;

    public WaitForFixedUpdate _waitForFixedUpdate;

    private void Awake() => 
        _waitForFixedUpdate = new();

    private void OnEnable() =>
        _health.HealthValueChanged += RefreshHealthValue;

    private void OnDisable() =>
        _health.HealthValueChanged -= RefreshHealthValue;

    private void RefreshHealthValue() =>
        StartCoroutine(RefreshHealthValueSmoothly());

    private IEnumerator RefreshHealthValueSmoothly()
    {
        SliderRefresh();

        while (Mathf.Round(_slider.value) != Mathf.Round(_health.CurrentHealthValue))
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.CurrentHealthValue, _affectSpeed * Time.deltaTime);
            _valueText.text = $"{_slider.value}/{_health.MaxHealthValue}";

            yield return _waitForFixedUpdate;
        }
    }

    private void SliderRefresh()
    {
        if (Mathf.Round(_slider.maxValue) != Mathf.Round(_health.MaxHealthValue))
        {
            _slider.maxValue = _health.MaxHealthValue;
            _slider.value = _health.MaxHealthValue;
            _valueText.text = $"{_slider.value}/{_health.MaxHealthValue}";
        }
    }
}
