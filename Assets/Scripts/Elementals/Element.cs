using UnityEngine;

[RequireComponent(typeof(ElementAnimator))]
public class Element : MonoBehaviour
{   
    public Vector3 InitialPosition {  get; private set; }
    public ElementAnimator Animator {  get; private set; }

    private void Awake() => 
        Animator = GetComponent<ElementAnimator>();

    private void OnEnable() =>
        Animator.PopUp(transform);

    private void Start() => 
        InitialPosition = transform.position;
}
