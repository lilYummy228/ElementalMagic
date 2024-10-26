using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;

    private void Awake() => 
        _slider = GetComponent<Slider>();

    private void OnEnable() =>
        _health.HealthChanged += ShowInfo;

    private void OnDisable() =>
        _health.HealthChanged -= ShowInfo;

    private void Start()
    {
        _slider.maxValue = _health.HealthValue;
        _slider.value = _slider.maxValue;
    }

    public void ShowInfo(int healthValue) =>
        _slider.value = healthValue;
}
