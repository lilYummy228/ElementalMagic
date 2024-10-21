using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Cell _prefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _camera;
    [SerializeField] private SphereGenerator _sphereGenerator;
    [SerializeField] private ElementConnector _elementConnector;

    private float _cameraPositionX, _cameraPositionY;
    private float _offset = 1f;
    private List<Cell> _cells = new();

    private void Awake()
    {
        _cameraPositionX = _width / 2;
        _cameraPositionY = _height / 2 + _offset;        
    }

    private void OnEnable()
    {
        _elementConnector.ElementsGone += FillBoard;        
    }

    private void OnDisable()
    {
        _elementConnector.ElementsGone -= FillBoard;
    }

    private void Start()
    {
        CreateGrid();
    }

    private void FillBoard()
    {
        _sphereGenerator.CreateElements(_cells);
    }

    private void CreateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Cell spawnedCell = Instantiate(_prefab, new Vector3(x, y), Quaternion.identity, _parent);   

                spawnedCell.name = $"{x}:{y}";

                _cells.Add(spawnedCell);
            }
        }

        _camera.position = new Vector3(_cameraPositionX, _cameraPositionY, _camera.position.z);        
    }   
}
