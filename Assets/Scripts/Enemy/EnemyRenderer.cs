using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyRenderer : MonoBehaviour
{
    [Header("Render")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private float _drawDuration = 1f;
    [Header("Blink")]
    [SerializeField] private Color _blinkColor;
    [SerializeField] private float _blinkDuration = 0.3f;
    [SerializeField] private int _blinkTimes = 3;

    private Color _defaultColor;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _defaultColor = _spriteRenderer.color;
        _wait = new WaitForSeconds(_blinkDuration);
    }

    public void DrawEnemy(Sprite sprite, string name)
    {
        _spriteRenderer.sprite = sprite;

        _spriteRenderer.transform.localScale = Vector3.zero;
        _spriteRenderer.transform.DOScale(Vector3.one, _drawDuration);

        _nameText.text = name;
    }

    public void StartBlink() => 
        StartCoroutine(nameof(Blink));

    public void Clear() =>
        _spriteRenderer.sprite = null;

    private IEnumerator Blink()
    {
        for (int i = 0; i < _blinkTimes; i++)
        {
            _spriteRenderer.color = _blinkColor;

            yield return _wait;

            _spriteRenderer.color = _defaultColor;

            yield return _wait;
        }
    }
}
