using Shop;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PowerUpView : MonoBehaviour
    {
        [SerializeField] private PowerUp _powerUp;
        [SerializeField] private TextMeshProUGUI _costView;

        private void OnEnable() =>
            _powerUp.Upgraded += Show;

        private void OnDisable() =>
            _powerUp.Upgraded -= Show;

        private void Show(string cost) =>
            _costView.text = cost;
    }
}