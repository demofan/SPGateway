using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpGatewayHelper.Models
{
    public class TradeInfo
    {
        /// <summary>
        /// 商店代號 
        /// </summary>
        /// <value>
        /// The merchant identifier.
        /// </value>
        public string MerchantID { get; set; }
        /// <summary>
        /// 回傳格式 
        /// <para>JSON 或是 String</para>
        /// </summary>
        /// <value>
        /// The type of the respond.
        /// </value>
        public string RespondType { get; set; }
        /// <summary>
        /// TimeStamp
        /// <para>自從 Unix 纪元（格林威治時間 1970 年 1 月 1 日 00:00:00）到當前時間的秒數。</para>
        /// </summary>
        /// <value>
        /// The time stamp.
        /// </value>
        public string TimeStamp { get; set; }
        /// <summary>
        /// 串接程式版本 
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public string Version { get; set; }
        /// <summary>
        /// 商店訂單編號 
        /// <para>限英、數字、_ 格式</para>
        /// </summary>
        /// <value>
        /// The merchant order no.
        /// </value>
        public string MerchantOrderNo { get; set; }
        /// <summary>
        /// 訂單金額 
        /// </summary>
        /// <value>
        /// The amt.
        /// </value>
        public int Amt { get; set; }
        /// <summary>
        /// 商店備註 
        /// </summary>
        /// <value>
        /// The order comment.
        /// </value>
        public string OrderComment { get; set; }
        /// <summary>
        /// 商品資訊 
        /// </summary>
        /// <value>
        /// The item desc.
        /// </value>
        public string ItemDesc { get; set; }
        /// <summary>
        /// 交易限制秒數 
        /// </summary>
        /// <value>
        /// The trade limit.
        /// </value>
        public int TradeLimit { get; set; }
        /// <summary>
        /// 支付完成 返回商店網址 
        /// </summary>
        /// <value>
        /// The return URL.
        /// </value>
        public string ReturnURL { get; set; }
        /// <summary>
        /// 支付通知網址 
        /// </summary>
        /// <value>
        /// The notify URL.
        /// </value>
        public string NotifyURL { get; set; }
        /// <summary>
        /// 商店取號網址 
        /// </summary>
        /// <value>
        /// The customer URL.
        /// </value>
        public string CustomerURL { get; set; }
        /// <summary>
        /// 支付取消 返回商店網址 
        /// </summary>
        /// <value>
        /// The client back URL.
        /// </value>
        public string ClientBackURL { get; set; }
        /// <summary>
        /// 付款人電子信箱 
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// 付款人電子信箱 是否開放修改 
        /// <para>1=可修改 0=不可修改 </para>
        /// </summary>
        /// <value>
        /// The email modify.
        /// </value>
        public int EmailModify { get; set; }
        /// <summary>
        /// 智付通會員 
        /// <para>0=不須登入智付通會員</para>
        /// <para>1=須要登入智付通會員</para>
        /// </summary>
        /// <value>
        /// The type of the login.
        /// </value>
        public int LoginType { get; set; }
        /// <summary>
        /// ATM 轉帳啟用
        /// </summary>
        /// <value>
        /// The webatm.
        /// </value>
        public int? VACC { get; set; }
        /// <summary>
        /// 超商條碼繳費啟用 
        /// </summary>
        /// <value>
        /// The webatm.
        /// </value>
        public int? BARCODE { get; set; }
        /// <summary>
        /// 超商代碼繳費 啟用
        /// </summary>
        /// <value>
        /// The webatm.
        /// </value>
        public int? CVS { get; set; }
        /// <summary>
        /// 繳費有效期限 
        /// <para>格式為 date('Ymd') ，例：20140620</para> 
        /// </summary>
        /// <value>
        /// The credit red.
        /// </value>
        public string ExpireDate { get; set; }
        /// <summary>
        /// 信用卡 一次付清啟用 
        /// </summary>
        /// <value>
        /// The credit.
        /// </value>
        public int? CREDIT { get; set; }
        /// <summary>
        /// 信用卡 紅利啟用 
        /// <para>1=啟用</para> 
        /// </summary>
        /// <value>
        /// The credit red.
        /// </value>
        public int? CreditRed { get; set; }
        /// <summary>
        /// 信用卡 分期付款啟用 
        /// <para>3=分3期功能</para>
        /// <para>6=分6期功能</para>
        /// <para>12=分12期功能</para>  
        /// <para>18=分18期功能</para>  
        /// <para>24=分24期功能</para>   
        /// <para>30=分30期功能</para> 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        public string InstFlag { get; set; }
       

    }
}