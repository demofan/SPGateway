using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpGatewayHelper.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpGatewayHelper.Models;

namespace SpGatewayHelper.Helper.Tests
{
    [TestClass()]
    public class MyHelperTests
    {
        [TestMethod()]
        public void ToTimeStampTest()
        {
            var testDateTime = new DateTime(2014, 5, 15, 15, 0, 0);
            //-8 是以 UTC 來算
            var actual = testDateTime.AddHours(-8).ToUnixTimeStamp();

            var expected = "1400137200";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToDictionaryTest()
        {
            var unitTime = DateTime.Now.ToUnixTimeStamp();
            var target = new TradeInfo()
            {
                MerchantID = "MS111",
                RespondType = "JSON",
                TimeStamp = unitTime,
                Version = "1.4",
                Amt = 900,
                ItemDesc = "TTEESSTT",
                ClientBackURL = "",
                CREDIT = 1,
                CreditRed = 1,
                CustomerURL = "",
                Email = "demo@demoshop.tw",
                EmailModify = 1,
                LoginType = 0,
                MerchantOrderNo = "9487",
                NotifyURL = "",
                ReturnURL = "",
                TradeLimit = 180
            };
            var actual = string.Join("", target.ToDictionary().OrderBy(d => d.Key).Select(d => d.Key + d.Value));

            var expectedDictionary = new Dictionary<string, object>
            {
                {"MerchantID", "MS111"},
                {"RespondType", "JSON"},
                {"TimeStamp", unitTime},
                {"Version", "1.4"},
                {"Amt", 900},
                {"ItemDesc", "TTEESSTT"},
                {"CREDIT", 1},
                {"CreditRed", 1},
                {"Email", "demo@demoshop.tw"},
                {"EmailModify", 1},
                {"LoginType", 0},
                {"MerchantOrderNo", "9487"},
                {"TradeLimit", 180},
            };
            var expected = string.Join("", expectedDictionary.OrderBy(d => d.Key).Select(d => d.Key + d.Value));
            Assert.AreEqual(expected, actual);
        }
    }
}