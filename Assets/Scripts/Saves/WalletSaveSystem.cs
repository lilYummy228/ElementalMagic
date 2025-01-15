using UnityEngine;
using YG;

public class WalletSaveSystem : MonoBehaviour, ISaveSystem
{
    [SerializeField] private Wallet _wallet;

    public void Load() => 
        _wallet.SetCount(YandexGame.savesData.CoinsCount);

    public void Save()
    {
        YandexGame.savesData.CoinsCount = _wallet.Count;
    }

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        _wallet.SetCount(default);

        Save();
    }
}
