using TMPro;
using UnityEngine;

public class PowerUpView : MonoBehaviour
{
    [SerializeField] private PowerUp _powerUp;
    [SerializeField] private TextMeshProUGUI _costView;
    [SerializeField] private TextMeshProUGUI _descriptionView;

    private void Start() => 
        Show();

    private void OnEnable() => 
        _powerUp.Upgraded += Show;

    private void OnDisable() => 
        _powerUp.Upgraded -= Show;

    private void Show()
    {
        _descriptionView.text = _powerUp.Description;
        _costView.text = _powerUp.Price.ToString();
    }
}
