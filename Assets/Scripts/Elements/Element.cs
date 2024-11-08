using System;
using UnityEngine;

[RequireComponent(typeof(ElementAnimator))]
public class Element : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private AudioClip _selectionSound;
    [SerializeField] private AudioClip _attackSound;

    public int Damage => _damage;
    public AudioClip SelectionSound => _selectionSound;
    public AudioClip AttackSound => _attackSound;
    public Vector3 InitialPosition {  get; private set; }
    public ElementAnimator Animator {  get; private set; }

    private void Awake() => 
        Animator = GetComponent<ElementAnimator>();

    private void OnEnable() =>
        Animator.PopUp(transform);

    private void Start() => 
        InitialPosition = transform.position;
}
