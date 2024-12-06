using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    public void Buy(PowerUp powerUp) => 
        _wallet.CheckTransaction(powerUp);
}
