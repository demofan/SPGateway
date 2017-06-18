# SPGateway
台灣第三方金流服務智富通API串接小幫手

* 智付通第三方金流網址：[https://www.spgateway.com](https://www.spgateway.com)
* 智付通 API 位置：[https://web.spgateway.com/api/download_api](https://web.spgateway.com/api/download_api)
 
此小幫手只處理 智付通 交易所需的 AES 加解密與 雜湊(SHA)字串檢查


```cs
public class HomeController : Controller
{
    private readonly string _key;
    private readonly string _Vi;

    public HomeController()
    {
        _key = "xbEznJ0PExvWzd5ct72dLPCMPIBUw8K3";
        _Vi = "kpDI8DxNb2JKgOXK";
    }

    public ActionResult Index()
    {
        var tradeInfo = new TradeInfo()
        {
            MerchantID = "MS12345678",
            RespondType = "JSON",
            TimeStamp = DateTime.Now.ToUnixTimeStamp(),
            Version = "1.4",
            Amt = 100,
            ItemDesc = "TTEESSTT",
            //InstFlag="3,6",
            //CreditRed = 0,
            Email = "demo@demo.demo",
            EmailModify = 0,
            LoginType = 0,
            MerchantOrderNo = DateTime.Now.Ticks.ToString(),
            TradeLimit = 180,
            //CVS=1,
            //ExpireDate=DateTime.Now.ToString("yyyyMMdd"),
            ReturnURL = "http://localhost:51639/home/index",
        };
        var postData = tradeInfo.ToDictionary();
        var cryptoHelper = new CryptoHelper(_key, _Vi);
        var aesString = cryptoHelper.GetAesString(postData);
        ViewData["TradeInfo"] = aesString;
        ViewData["TradeSha"] = cryptoHelper.GetSha256String(aesString);
        return PartialView();
    }

    [HttpPost]
    public ActionResult Index(SpGatewayResponse response)
    {
        response.Key = _key;
        response.Vi = _Vi;
        var success = response.Validate("MS31756909");
        if (success)
        {
            var tradInfoModel=response.GetResponseModel<TradeInfoModel>();
        }
        return View();
    }
}
```

