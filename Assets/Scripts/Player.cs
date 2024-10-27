using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private Health _enemyHealth;
    [SerializeField] private ElementConnector _elementConnector;

    private Health _health;

    private void Awake() => 
        _health = GetComponent<Health>();

    private void Start()
    {
        _health.SetHealth(_health.HealthValue, _health.HealthValue);
    }

    private void OnEnable() => 
        _elementConnector.ElementCountPopped += Hit;

    private void OnDisable() => 
        _elementConnector.ElementCountPopped -= Hit;

    public void Hit(int damage) => 
        _enemyHealth.TakeDamage(damage);
}
