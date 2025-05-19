using Player;
using UnityEngine;
using YG;

namespace Saves
{
    public class WalletSaveSystem : MonoBehaviour, ISaveSystem
    {
        [SerializeField] private Wallet _wallet;

        public void Load() =>
            _wallet.SetCount(YandexGame.savesData.coinsCount);

        public void Save()
        {
            YandexGame.savesData.coinsCount = _wallet.Count;

            YandexGame.SaveProgress();
        }

        [ContextMenu("Refresh")]
        public void Refresh()
        {
            _wallet.SetCount(default);

            Save();
        }
    }
}