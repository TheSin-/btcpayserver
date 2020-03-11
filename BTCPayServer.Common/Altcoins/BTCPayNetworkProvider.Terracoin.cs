using NBitcoin;

namespace BTCPayServer
{
    public partial class BTCPayNetworkProvider
    {
        public void InitTerracoin()
        {
            //not needed: NBitcoin.Altcoins.Terracoin.Instance.EnsureRegistered();
            var nbxplorerNetwork = NBXplorerNetworkProvider.GetFromCryptoCode("TRC");
            Add(new BTCPayNetwork()
            {
                CryptoCode = nbxplorerNetwork.CryptoCode,
                DisplayName = "Terracoin",
                BlockExplorerLink = NetworkType == NetworkType.Mainnet
                    ? "https://insight.terracoin.io/tx/{0}"
                    : "https://test-insight.terracoin.io/tx/{0}",
                NBitcoinNetwork = nbxplorerNetwork.NBitcoinNetwork,
                NBXplorerNetwork = nbxplorerNetwork,
                UriScheme = "terracoin",
                DefaultRateRules = new[]
                    {
                        "TRC_X = TRC_BTC * BTC_X",
                        "TRC_BTC = coingecko(TRC_BTC)"
                    },
                CryptoImagePath = "imlegacy/terracoin.png",
                DefaultSettings = BTCPayDefaultSettings.GetDefaultSettings(NetworkType),
                //https://github.com/satoshilabs/slips/blob/master/slip-0044.md
                CoinType = NetworkType == NetworkType.Mainnet ? new KeyPath("83'") : new KeyPath("1'"),
                MinFee = Money.Satoshis(0.0001m)
            });
        }
    }
}
