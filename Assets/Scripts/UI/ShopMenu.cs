using UnityEngine;

public class ShopMenu : MonoBehaviour, IMenu
{
    [SerializeField] private Transform _shopMenuPanel;    

    public Transform MenuPanel => _shopMenuPanel;

    public void Open(Transform panel)
    {
        _shopMenuPanel.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);        
    }    
}
