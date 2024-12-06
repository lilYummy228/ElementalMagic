using TMPro;
using UnityEngine;

public class PowerUpView : MonoBehaviour
{
    [SerializeField] private PowerUp _powerUp;
    [SerializeField] private TextMeshProUGUI _costView;
    [SerializeField] private TextMeshProUGUI _descriptionView;

    private void Start()
    {
        _descriptionView.text = _powerUp.Description;
        _costView.text = _powerUp.Price.ToString();
    }
}
