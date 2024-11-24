using TMPro;
using UnityEngine;

namespace TraderScene.Views.Wallet
{
    public class WalletWindow : MonoBehaviour, IUIView
    {
        [SerializeField] private TextMeshProUGUI _goldAmount;
        
        public void UpdateGoldAmount(int amount)
        {
            _goldAmount.text = amount.ToString();
        }
    }
}