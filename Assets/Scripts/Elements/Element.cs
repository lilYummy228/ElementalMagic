using UnityEngine;

[RequireComponent(typeof(ElementAnimator))]
public class Element : MonoBehaviour
{
    [SerializeField] private AudioClip _selectionSound;
    [SerializeField] private AudioClip _attackSound;
    [SerializeField] private ElementProjectile _projectile;
    [SerializeField] private ElementAnimator _animator;
    [SerializeField] private PowerUp _powerUp;
    [SerializeField] private float _damage;

    public AudioClip SelectionSound => _selectionSound;
    public AudioClip AttackSound => _attackSound;
    public ElementProjectile Projectile => _projectile;
    public ElementAnimator Animator => _animator;
    public Vector3 InitialPosition => transform.position;
    public float Damage => _damage + _powerUp.UpgradeValue * _powerUp.FilledCages;

    private void OnEnable()
    {
        _powerUp.Setup();

        Animator.PopUp(transform);
    }

    private void OnDisable() => 
        _powerUp.Save();

    public void ProjectileLaunch()
    {
        ElementProjectile projectile = Instantiate(_projectile, transform.position, Quaternion.identity);
        projectile.StartLaunching();
    }
}
