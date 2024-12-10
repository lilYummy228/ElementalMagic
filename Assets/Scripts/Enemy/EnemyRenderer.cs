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

    public Vector3 CameraPosition => new Vector3(_camera.transform.position.x, _camera.transform.position.y, 0);
    public float SideSize => _camera.orthographicSize / CameraSize;

    public Transform EnemyTransform => transform;

    private void Awake() => 
        transform.position = CameraPosition + Vector3.up * Offset * SideSize;

    public void DrawEnemy(Transform prefab, string name)
    {
        _enemy = Instantiate(prefab, new Vector3(_camera.transform.position.x, _camera.transform.position.y, 0), Quaternion.identity);

        _enemy.localScale = Vector3.zero;
        _enemy.DOScale(Vector3.one * SideSize, _drawDuration);

        _nameText.text = name;
    }

    public void Clear()
    {
        if (_enemy != null)
            Destroy(_enemy.gameObject);
    }
}