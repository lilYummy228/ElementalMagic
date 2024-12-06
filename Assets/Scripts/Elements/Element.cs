using UnityEngine;

[RequireComponent(typeof(ElementAnimator))]
public class Element : MonoBehaviour
{
    [SerializeField] private AudioClip _selectionSound;
    [SerializeField] private AudioClip _attackSound;
    [SerializeField] private ElementProjectile _projectile;
    [SerializeField] private float _damage;

    public AudioClip SelectionSound => _selectionSound;
    public AudioClip AttackSound => _attackSound;
    public ElementProjectile Projectile => _projectile;
    public ElementAnimator Animator { get; private set; }
    public float Damage => _damage + PlayerPrefs.GetFloat(nameof(UpgradeDamage));
    public Vector3 InitialPosition { get; private set; }

    private void Awake() =>
        Animator = GetComponent<ElementAnimator>();

    private void OnEnable() => 
        Animator.PopUp(transform);

    private void Start() =>
        InitialPosition = transform.position;

    public void ProjectileLaunch()
    {
        ElementProjectile projectile = Instantiate(_projectile, transform.position, Quaternion.identity);
        projectile.StartLaunching();
    }
}
