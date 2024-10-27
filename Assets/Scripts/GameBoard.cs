using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    [SerializeField] private Transform _camera;
    [SerializeField] private ElementGenerator _sphereGenerator;
    [SerializeField] private ElementConnector _elementConnector;

    private float _cameraPositionX, _cameraPositionY;
    private float _offset = 1.5f;    

    private void Awake()
    {
        _cameraPositionX = _grid.Width / 2;
        _cameraPositionY = _grid.Height / 2 + _offset;

        _camera.position = new Vector3(_cameraPositionX, _cameraPositionY, _camera.position.z);
    }

    private void OnEnable() => 
        _elementConnector.ElementsPopped += FillBoard;

    private void OnDisable() => 
        _elementConnector.ElementsPopped -= FillBoard;

    private void Start()
    {
        _grid.Create();

        FillBoard();
    }

    private void FillBoard() => 
        _sphereGenerator.Fill(_grid.Cells);
}