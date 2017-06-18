using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SpGatewayHelper.Helper;

namespace SpGatewayHelper
{
    public class SpGatewayResponse
    {
        public string Status { get; set; }
        public string MerchantId { get; set; }
        public string TradeInfo { get; set; }
        public string TradeSha { get; set; }
        public string Version { get; set; }
        public string Key { get; set; }
        public string Vi { get; set; }
        /// <summary>
        /// 驗證資料正確性
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <returns></returns>
        public bool Validate(string merchantId)
        {
            if (merchantId != MerchantId)
            {
                return false;
            }
            var cryptoHelper = new CryptoHelper(Key, Vi);
            var sha = cryptoHelper.GetSha256String(TradeInfo);
            return sha == TradeSha;
        }

        /// <summary>
        /// Gets the response model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetResponseModel<T>()
        {
            var cryptoHelper = new CryptoHelper(Key, Vi);
            var jsonString = cryptoHelper.DecryptAesString(TradeInfo);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

    }
}