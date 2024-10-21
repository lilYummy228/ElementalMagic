using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private ElementsPool _elementsPool;

    private float _offsetZ = -0.5f;

    public void CreateElements(IReadOnlyList<Cell> cells)
    {
        foreach (Cell cell in cells)
        {
            if (cell.IsFilled == false)
            {
                Element element = _elementsPool.GetElement();

                element.gameObject.SetActive(true);
                element.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, _offsetZ);
            }

            cell.UpdateState();
        }
    }
}
