using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int _width = 5, _height = 5;
    [SerializeField] private Cell _prefab;

    private List<Cell> _cells = new();
    public Transform Transform { get; private set; }
    public int Width => _width;
    public int Height => _height;
    public IReadOnlyList<Cell> Cells => _cells;

    private void Awake() => Transform = transform;

    public void Create()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Vector3Int coordinate = new Vector3Int(x, y);

                Cell spawnedCell = Instantiate(_prefab, coordinate, Quaternion.identity, Transform);

                spawnedCell.name = $"{x}:{y}";

                _cells.Add(spawnedCell);
            }
        }
    }
}
