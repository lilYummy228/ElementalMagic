using DG.Tweening;
using TMPro;
using UnityEngine;

public class EnemyRenderer : MonoBehaviour
{
    private const int CameraSize = 5;
    private const float Offset = 3;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private float _drawDuration = 1f;
    [SerializeField] private Camera _camera;

    private Transform _enemy;
    private Vector3 _cameraPosition;
    private float _sideSize;

    public Transform EnemyTransform => transform;

    private void Awake()
    {
        _sideSize = _camera.orthographicSize / CameraSize;
        _cameraPosition = new Vector3(_camera.transform.position.x, _camera.transform.position.y, 0);
        transform.position = _cameraPosition + Vector3.up * Offset * _sideSize;
    }

    public void DrawEnemy(Transform prefab, string name)
    {
        _enemy = Instantiate(prefab, new Vector3(_camera.transform.position.x, _camera.transform.position.y, 0), Quaternion.identity);

        _enemy.localScale = Vector3.zero;
        _enemy.DOScale(Vector3.one * _sideSize, _drawDuration);

        _nameText.text = name;
    }

    public void Clear()
    {
        if (_enemy != null)
            Destroy(_enemy.gameObject);
    }
}