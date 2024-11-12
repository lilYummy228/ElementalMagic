using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ElementAnimator : MonoBehaviour
{
    private float _shakeDuration = 100;
    private float _strength = 0.025f;
    private float _randomness = 90;
    private float _popUpDuration = 0.4f;
    private int _vibrato = 16;
    private bool _snapping = false;
    private bool _fadeOut = false;
    private Tweener _tween;
    private WaitForFixedUpdate _waitForFixedUpdate;

    private void Awake() => 
        _waitForFixedUpdate = new WaitForFixedUpdate();

    public void Shake(Element element, bool isSelected)
    {
        if (isSelected)
        {
            _tween = transform.DOShakePosition(_shakeDuration, _strength, _vibrato, _randomness, _snapping, _fadeOut);
        }
        else
        {
            _tween.Kill();
            element.transform.position = element.InitialPosition;
        }
    }

    public void PopUp(Transform element)
    {
        Vector3 initialScale = element.transform.localScale;
        element.localScale = Vector3.zero;
        element.DOScale(initialScale, _popUpDuration);
    }
}
