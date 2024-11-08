using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    [SerializeField] private Camera _camera;
    [SerializeField] private ElementGenerator _sphereGenerator;
    [SerializeField] private ElementConnector _elementConnector;

    private float _cameraPositionX, _cameraPositionY;
    private float _offsetY = 1.5f;
    private float _borderOffset = 0.5f;

    private void Awake() => 
        CameraToGrid();

    private void CameraToGrid()
    {
        _cameraPositionX = (float)_grid.Width / 2 - _borderOffset;
        _cameraPositionY = (float)_grid.Height / 2 - _borderOffset + _offsetY;
        _camera.orthographicSize = _grid.Width;

        _camera.transform.position = new Vector3(_cameraPositionX, _cameraPositionY, _camera.transform.position.z);
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