using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int _width = 5, _height = 5;
    [SerializeField] private Cell _prefab;

    private List<Cell> _cells = new();

    public IReadOnlyList<Cell> Cells => _cells;
    public Transform Transform => transform;
    public int Width => _width + PlayerPrefs.GetInt(nameof(UpgradeGrid));
    public int Height => _height + PlayerPrefs.GetInt(nameof(UpgradeGrid));

    public void Create()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Vector3Int coordinate = new Vector3Int(x, y);

                Cell spawnedCell = Instantiate(_prefab, coordinate, Quaternion.identity, Transform);

                spawnedCell.name = $"{x}:{y}";

                _cells.Add(spawnedCell);
            }
        }
    }

    public void Clear()
    {
        foreach (Cell cell in _cells)
            Destroy(cell.Element.gameObject);
    }
}
