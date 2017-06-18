using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpGatewayHelper.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpGatewayHelper.Helper.Tests
{
    [TestClass()]
    public class CryptoHelperTests
    {
        private const string Key = "12345678901234567890123456789012";
        private const string Vi = "1234567890123456";

        [TestMethod()]
        public void GetAesStringTest()
        {
            var target = new CryptoHelper(Key, Vi);

            var postData = new Dictionary<string, object>
            {
                { "MerchantID", "3430112" },
                { "RespondType", "JSON" },
                { "TimeStamp", "1485232229" },
                { "Version", "1.4" },
                { "MerchantOrderNo", "S_1485232229" },
                { "Amt", "40" },
                { "ItemDesc", "UnitTest" }
            };

            var actual = target.GetAesString(postData);

            var expected =
                "ff91c8aa01379e4de621a44e5f11f72e4d25bdb1a18242db6cef9ef07d80b0165e476fd1d9acaa53170272c82d122961e1a0700a7427cfa1cf90db7f6d6593bbc93102a4d4b9b66d9974c13c31a7ab4bba1d4e0790f0cbbbd7ad64c6d3c8012a601ceaa808bff70f94a8efa5a4f984b9d41304ffd879612177c622f75f4214fa";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetSha256StringTest()
        {
            var target = new CryptoHelper(Key, Vi);
            var aesString = "ff91c8aa01379e4de621a44e5f11f72e4d25bdb1a18242db6cef9ef07d80b0165e476fd1d9acaa53170272c82d122961e1a0700a7427cfa1cf90db7f6d6593bbc93102a4d4b9b66d9974c13c31a7ab4bba1d4e0790f0cbbbd7ad64c6d3c8012a601ceaa808bff70f94a8efa5a4f984b9d41304ffd879612177c622f75f4214fa";

            var actual = target.GetSha256String(aesString);

            var expected = "EA0A6CC37F40C1EA5692E7CBB8AE097653DF3E91365E6A9CD7E91312413C7BB8";

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException), "Key or Iv is required")]
        public void CryptoHelperTest()
        {
            new CryptoHelper(null, null);
        }

        [TestMethod()]
        public void DecryptAesStringTest()
        {
            var aesString =
                "ff91c8aa01379e4de621a44e5f11f72e4d25bdb1a18242db6cef9ef07d80b0165e476fd1d9acaa53170272c82d122961e1a0700a7427cfa1cf90db7f6d6593bbc93102a4d4b9b66d9974c13c31a7ab4bba1d4e0790f0cbbbd7ad64c6d3c8012a601ceaa808bff70f94a8efa5a4f984b9d41304ffd879612177c622f75f4214fa";
            var target = new CryptoHelper(Key, Vi);
            var actual = target.DecryptAesString(aesString);
            var expected = "MerchantID=3430112&RespondType=JSON&TimeStamp=1485232229&Version=1.4&MerchantOrderNo=S_1485232229&Amt=40&ItemDesc=UnitTest";
            Assert.AreEqual(expected, actual);

        }
    }
}