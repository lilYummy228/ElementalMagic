using Elements;
using UnityEngine;

namespace GameBoard
{
    public class GameBoard : MonoBehaviour
    {
        [SerializeField] private Grid _grid;
        [SerializeField] private Camera _camera;
        [SerializeField] private ElementGenerator _elementGenerator;
        [SerializeField] private ElementConnector _elementConnector;

        private float _deepOffset = 0.35f;
        private float _offsetY = 1f;
        private float _borderOffset = 0.5f;
        private float _cameraPositionX;
        private float _cameraPositionY;

        private void Awake() =>
            CameraToGrid();

        private void OnEnable() =>
            _elementConnector.Popped += FillBoard;

        private void OnDisable() =>
            _elementConnector.Popped -= FillBoard;

        private void Start() =>
            _grid.Create();

        public void FillBoard() =>
            _elementGenerator.Fill(_grid.Cells);

        public void RefreshBoard() =>
            _grid.Clear();

        private void CameraToGrid()
        {
            _cameraPositionX = (float)_grid.Width / 2 - _borderOffset;
            _cameraPositionY = (float)_grid.Height / 2 - _borderOffset + _offsetY;
            _camera.orthographicSize = _grid.Width - _deepOffset;

            _camera.transform.position = new Vector3(_cameraPositionX, _cameraPositionY, _camera.transform.position.z);
        }
    }
}