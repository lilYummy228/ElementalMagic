using DG.Tweening;
using UnityEngine;

public class Element : MonoBehaviour
{
    private float _duration = 100;
    private float _strength = 0.025f;
    private float _randomness = 90;
    private float _popUpDuration = 0.4f;
    private int _vibrato = 16;
    private bool _snapping = false;
    private bool _fadeOut = false;

    private Vector3 _position;
    private Tweener _tween;

    private void OnEnable() =>
        PopUp(_popUpDuration);

    private void Start() =>
        _position = transform.position;

    public void Shake(bool isSelected)
    {
        if (isSelected)
        {
            _tween = transform.DOShakePosition(_duration, _strength, _vibrato, _randomness, _snapping, _fadeOut);
        }
        else
        {
            _tween.Kill();
            transform.position = _position;
        }
    }

    private void PopUp(float duration)
    {
        var scale = transform.localScale;

        transform.localScale = Vector3.zero;
        transform.DOScale(scale, duration);
    }
}
