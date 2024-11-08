using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ElementConnector _elementConnector;
    [SerializeField] private int _damage = 1;

    public Health Health { get; private set; }

    private void Awake() => 
        Health = GetComponent<Health>();

    private void Start() => 
        Health.SetHealth(Health.CurrentHealthValue);

    private void OnEnable() => 
        _elementConnector.ElementCountPopped += Hit;

    private void OnDisable() => 
        _elementConnector.ElementCountPopped -= Hit;

    public void Hit(int count)
    {
        _enemy.EnemyRenderer.StartBlink();
        _enemy.Health.TakeDamage(count * _damage);
    }
}
