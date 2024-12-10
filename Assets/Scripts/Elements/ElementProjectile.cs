using System.Collections;
using UnityEngine;

public class ElementProjectile : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _explosion;

    public WaitForFixedUpdate WaitForFixedUpdate => new();
    public WaitUntil WaitUntil => new(() => _explosion.isStopped);

    public void StartLaunching() =>
        StartCoroutine(Launch());

    public void Init(Transform target) =>
        _target = target;

    private IEnumerator Launch()
    {
        while (transform.position != _target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

            yield return WaitForFixedUpdate;
        }

        _explosion.Play();

        yield return WaitUntil;

        Destroy(gameObject);
    }
}
