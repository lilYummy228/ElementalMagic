using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable() => 
        _wallet.CountChanged += Show;

    private void OnDisable() => 
        _wallet.CountChanged -= Show;

    private void Start() => 
        Show(_wallet.Count);

    public void Show(int count) => 
        _text.text = count.ToString();
}
