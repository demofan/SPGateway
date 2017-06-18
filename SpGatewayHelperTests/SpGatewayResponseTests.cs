using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SpGatewayHelper;
using SpGatewayHelper.Models;

namespace SpGatewayHelperTests
{
    [TestClass()]
    public class SpGatewayResponseTests
    {
        [TestMethod()]
        public void ValidateTest()
        {
            var target = new SpGatewayResponse()
            {
                MerchantId = "AAA",
                Status = "SUCCESS",
                Version = "1.4",
                TradeInfo = "ff91c8aa01379e4de621a44e5f11f72e4d25bdb1a18242db6cef9ef07d80b0165e476fd1d9acaa53170272c82d122961e1a0700a7427cfa1cf90db7f6d6593bbc93102a4d4b9b66d9974c13c31a7ab4bba1d4e0790f0cbbbd7ad64c6d3c8012a601ceaa808bff70f94a8efa5a4f984b9d41304ffd879612177c622f75f4214fa",
                TradeSha = "EA0A6CC37F40C1EA5692E7CBB8AE097653DF3E91365E6A9CD7E91312413C7BB8",
                Key = "12345678901234567890123456789012",
                Vi = "1234567890123456"
            };

            Assert.AreEqual(false, target.Validate("asb"));
            Assert.AreEqual(true, target.Validate("AAA"));
        }

        [TestMethod()]
        public void GetResponseModelTest()
        {
            var target = new SpGatewayResponse()
            {
                MerchantId = "MS31756909",
                Status = "SUCCESS",
                Version = "1.4",
                TradeInfo = "9d9d94de7cdaa5c73ba288bb9fafac953691b4e72d865e4e098d7e96eded1122d4accc05946ccec051dd621b070cad3a7ff98656178bcfebbbd76b6fe11684476a0d4815c67195694106b33f6a922398047291f5775c2202553896d4b6abbdf5df5e0e86af72ae9b41329657b4e23dd9ec287464186928f30ee0fd859ed96c6982ccae7836102e97402699a2c780a08fa564a04bda3e7ca305efba44f535f0dbb4f54bea55fc56512a97910fd13712ea046d7c411ce2385fba959241899dbc60eeb4ebe54fe76a14087e3e979217ecfb111406b1c64c6f4a66186fab9eb0c4566909a128d6743e2bf560ce699eaa97a01b983be4b09dc706e69927d271443a3d3bb23789991893043c5c929d6f2586d82f920eb7c6075efa4d3019b13daca3f456448b4d8da93d6243962a062c70c603dea5c1ef60df97b3185302a83bc512bf43462321eeae92f064b2d33c8d2c434e3fbc83b3cad22f6b48f2b690395a0f08",
                TradeSha = "0F271B65D055B3264D6C6C00FD6FDCC6BC7F653F8DAC38399C158F54AB2375B6",
                Key = "xbEznJ0PExvWzd5ct72dLPCMPIBUw8K3",
                Vi = "kpDI8DxNb2JKgOXK"
            };
            var actual = target.GetResponseModel<TradeInfoModel>();

            var expected = new TradeInfoModel
            {
                Status = "SUCCESS",
                Message = "\u4ed8\u6b3e\u6210\u529f",
                Result = new Result
                {
                    MerchantID = "MS31756909",
                    Amt = 900,
                    TradeNo = "17060802213088297",
                    MerchantOrderNo = "636324851460397211",
                    RespondType = "JSON",
                    IP = "180.217.182.136",
                    EscrowBank = "Esun",
                    PaymentType = "WEBATM",
                    PayTime = "2017-06-08 02:21:30",
                    PayerAccount5Code = "12345",
                    PayBankCode = "808"
                }
            };
            expected.ShouldBeEquivalentTo(actual);
        }
    }
}