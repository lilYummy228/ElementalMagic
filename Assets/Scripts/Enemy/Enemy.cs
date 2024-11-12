using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(EnemyRenderer), typeof(Resistance))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;

    private WaitForSeconds _delay;
    private string _name;
    private int _damage;

    public EnemyRenderer EnemyRenderer {  get; private set; }
    public Health Health { get; private set; }
    public Resistance Resistance {  get; private set; }

    private void Awake()
    {
        Health = GetComponent<Health>();
        EnemyRenderer = GetComponent<EnemyRenderer>();
        Resistance = GetComponent<Resistance>();
    }

    private void Start() =>
        StartCoroutine(nameof(Hit));

    private IEnumerator Hit()
    {       
        yield return _delay;

        while (_player.Health.CurrentHealthValue > 0 && Health.CurrentHealthValue > 0)
        {
            _player.Health.TakeDamage(_damage);

            yield return _delay;
        }
    }

    public void Setup(int damage, int attackDelay, int healthValue)
    {
        _delay = new WaitForSeconds(attackDelay);
        _damage = damage;

        Health.SetHealth(healthValue);
        Health.StartDeathControl();
    }
}
