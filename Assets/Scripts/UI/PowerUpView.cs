using TMPro;
using UnityEngine;

public class PowerUpView : MonoBehaviour
{
    [SerializeField] private PowerUp _powerUp;
    [SerializeField] private TextMeshProUGUI _costView;

    private void OnEnable() =>
        _powerUp.Upgraded += Show;

    private void OnDisable() =>
        _powerUp.Upgraded -= Show;

    private void Show(int cost) => 
        _costView.text = cost.ToString();
}
