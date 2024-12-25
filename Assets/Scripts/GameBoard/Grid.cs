using System.Collections.Generic;
using UnityEngine;
using YG;

public class Grid : MonoBehaviour
{
    [SerializeField] private int _width = 5, _height = 5;
    [SerializeField] private Cell _prefab;
    [SerializeField] private PowerUp _powerUp;

    private List<Cell> _cells = new();

    public IReadOnlyList<Cell> Cells => _cells;
    public Transform Transform => transform;
    public int Width => _width + _powerUp.UpgradeValue * YandexGame.savesData.GridPowerUps;
    public int Height => _height + _powerUp.UpgradeValue * YandexGame.savesData.GridPowerUps;

    public void Create()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Vector3Int coordinate = new(x, y);

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
