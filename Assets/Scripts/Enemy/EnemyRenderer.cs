using DG.Tweening;
using System.Collections;
using UnityEngine;

public class EnemyRenderer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _drawDuration = 1f;

    public void DrawEnemy(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;

        _spriteRenderer.transform.localScale = Vector3.zero;
        _spriteRenderer.transform.DOScale(Vector3.one, _drawDuration);
    }

    public void Clear() =>
        _spriteRenderer.sprite = null;
}
