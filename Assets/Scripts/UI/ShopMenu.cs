using UnityEngine;

public class ShopMenu : MonoBehaviour, IMenu
{
    [SerializeField] private Transform _shopMenuPanel;    

    public Transform MenuPanel => _shopMenuPanel;

    public void Open(Transform menuPanel)
    {
        _shopMenuPanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(true);        
    }    
}
