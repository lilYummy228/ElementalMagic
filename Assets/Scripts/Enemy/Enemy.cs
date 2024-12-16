using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyRenderer _renderer;
    [SerializeField] private Health _health;
    [SerializeField] private EnemyResistance _resistance;

    private WaitForSeconds _delay;
    private string _name;
    private int _damage;

    public EnemyRenderer EnemyRenderer => _renderer;
    public Health Health => _health;
    public EnemyResistance Resistance => _resistance;

    private void Start() =>
        StartCoroutine(nameof(Hit));    

    public void Setup(int damage, int attackDelay, int healthValue)
    {
        _delay = new(attackDelay);
        _damage = damage;

        Health.SetHealth(healthValue);
        Health.StartDeathControl();
    }

    public void PayAward(int award) => 
        _player.Wallet.AddCoins(award);

    private IEnumerator Hit()
    {
        yield return _delay;

        while (_player.Health.CurrentHealthValue > 0 && Health.CurrentHealthValue > 0)
        {
            _player.Health.TakeDamage(_damage);

            yield return _delay;
        }
    }
}
