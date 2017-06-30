using System;

namespace Maticsoft.Common
{
    /// <summary>
    /// Summary description for AppConst.
    /// </summary>
    public class AppConst
    {
        #region ϵͳ���ж�δ��ֵ���жϣ�ֻ�������ڱȽ��жϣ��������ڸ�ֵ

        public const int ShoppingCartLastVersion = 5;
        public const int ShoppingCartVersion = 6;
        public const string SOSplitChar = "_|_";
        public const string SOSplitCharRegex = "_\\|_";
        public const string SOSpecSplitChar = "_:_";
        public const short ShortNull = -9999;
        public const string StringNull = "";
        public const int IntNull = -999999;
        public const decimal DecimalNull = -999999m;
        public static readonly DateTime DateTimeNull = DateTime.Parse("1900-01-01");
        public const Byte[] ByteNull = null;
        public static readonly Guid GuidNull = Guid.Empty;
        #endregion

        public const string AllSelectString = "����";

        public const string TrimZero = "#########0.##";
        public const string DecimalToInt = "#########0"; //����point����ʾ��һ����˵currentpriceӦ��û�з֡�
        public const string DecimalFormat = "#########0.00";
        public const string DecimalFormatThree = "#########0.000";
        public const string DecimalFormatFour = "#########0.0000";
        public const string DecimalFormatWithGroup = "#,###,###,##0.00";
        public const string IntFormatWithGroup = "#,###,###,##0";
        public const string DecimalToIntWithCurrency = "$#########0";
        public const string DecimalFormatWithCurrency = "$#########0.00";
        public const string DecimalFormatWithCurrencyThree = "$#########0.000";
        public const string DecimalFormatWithCurrencyFour = "$#########0.0000";
        public const string DateFormatShort = "MM/dd";
        public const string DateFormat = "MM/dd/yyyy";
        public const string DateFormatLong = "MM/dd/yyyy HH:mm:ss";
        public const string DateFormatPRC = "yyyy-MM-dd";
        public const string DateFormatPRCLong = "yyyy-MM-dd HH:mm:ss";
        //����DataGrid��ÿҳ�ļ�¼��
        public const int PageSize = 50;

        public const int WebPageSize = 12;

        //����DataGrid��ÿҳ��ť����Ŀ
        public const int PageButtonCount = 5;

        /// <summary>
        /// ���ֺ��ֽ�RMBת������ Point = Cash*ExchangeRate
        /// </summary>
        public const decimal ExchangeRate = 1000m;

        //����С����ѵĽ��Ҫ��
        public const decimal PettyFeeLimit = 100m;

        //С����ѽ��
        public const decimal PettyFeeAmt = 10m;

        // ÿ�ŷ�Ʊ���������
        public const int PageMaxLine = 14;

        // ÿ�����Ƶ���󳤶�
        public const int NameMaxLength = 30;

        // ��ַ����󳤶ȣ����������ᱻ��ȥһ����
        public const int AddressMaxLength = 100;

        // ��Ʒ�۸��ȱʡֵ
        public const decimal DefaultPrice = 999999m;

        //��Ʒ�����Ʊ���
        public const decimal InvoiceMaxAmt = 11699.98m;

        // ϵͳ����Log��Ĭ��ip��ַ
        public const string SysIP = "127.0.0.1";

        // ϵͳ����Log��Ĭ��User
        public const int SysUser = 0;

        public const string ErrorTemplet = @"
          <table width='100%' border='0' cellpadding='1' cellspacing='1'>
            <tr>
                <td bgcolor='#AA0605'>
                    <table width='100%' border='0' cellspacing='0' cellpadding='4' bgcolor='#FFFFD5'>
                        <tr>
                            <td width='17' bgcolor='#FFFFD5'>
                                <img src='../images/error2.png' width='17'
                                    height='17' /></td>
                            <td align='left' bgcolor='#FFFFD5'>
                                <span class='font-error'>Error Msg</span></td>
                        </tr>
                        <tr>
                            <td bgcolor='#FFFFD5'>
                                &nbsp;</td>
                            <td align='left' bgcolor='#FFFFD5' class='ays_font_error_2'>
                                @errorMsg</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>";
        public const string SuccTemplet = @"
          <table bgcolor='#ffffd5' border='0' cellpadding='2' cellspacing='0' width='100%'>
            <tr>
                <td bgcolor='#ffffd5' width='17'>
                    &nbsp;</td>
                <td>
                    <span class='ays_font_success'>Success Msg</span></td>
            </tr>
            <tr>
                <td bgcolor='#ffffd5'>
                    &nbsp;</td>
                <td class='ays_font_success2' bgcolor='#ffffd5'>
                    @succMsg</td>
            </tr>
        </table>";
        public const string md5pal = "pwmksex6u50onh3xsuvepmzlk5tw03sk";

        public const string CanDeliverySunday = "CanDeliverySunday";

        public const string UnableDeliveryHoliday = "UnableDeliveryHoliday";

        public const string ListTaxItem = "0509";

        public const string DefaultLocalSetting = "en-US";

        public const string EntityCategory = "Category";

        public const int DefaultSkinID = 1;

        public const string DefaultImageFilenameOverride = "";

        public const int NewProductIDStartPoint = 600000;

        public const string NonePassword = "none";

        public const string AnonymUserNotes = "Quick checkout unfinished";


        public const int MinDiscount = 5;

        public const int AnypromoSiteSysNo = 1;

        //����˰��
        public const decimal CATax =8m;
        
        public const int MinProductId = 600000;
        public const int MaxProductId = 999999;
        public const int MaxPurchaseQty = 999999;
        public const int MinPurchaseQty = 1;

        public const string MayApply = "Additional Shipping Charge Will Apply";

        public const decimal ListPriceToWebPriceRatio = 0.77m;
    }
}
