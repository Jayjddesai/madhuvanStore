using System;
using System.ComponentModel;

namespace Madhuvan.Commonlayer
{
    #region Enum Extension
    public static class EnumExtension
    {
        /// <summary>
        /// The get description.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetDescription(this Enum element)
        {
            var type = element.GetType();
            var memberInfo = type.GetMember(Convert.ToString(element));
            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return Convert.ToString(element);
        }

        /// <summary>
        /// The get string value
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetStringValuefromEnum(Enum value)
        {
            string output = null;
            var type = value.GetType();
            {
                // Look for our 'StringValueAttribute' in the field's custom attributes
                var fi = type.GetField(Convert.ToString(value));
                var attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
                if (attrs != null && attrs.Length > 0)
                {
                    output = attrs[0].Value;
                }
            }

            return output;
        }
    }

    public sealed class StringValueAttribute : Attribute
    {
        /// <summary>
        /// The _value.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringValueAttribute"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public StringValueAttribute(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value
        {
            get { return _value; }
        }
    }
    #endregion

    public enum MailTemplate
    {
        [Description("ForgotPassword.html")]
        ForgotPassword,

        [Description("Error.html")]
        Error,
    }

    public enum PartyTypeEnum
    {

        Shipper = 1,
        Transporter = 2,
        Vendor = 3
    }

    public class MonthClass
    {
        public String MonthaName { get; set; }
        public Int32? MonthaValue { get; set; }
    }

    public enum MultipleItemStatus
    {
        [Description("Add")]
        Add,
        [Description("Edit")]
        Edit,
        [Description("Delete")]
        Delete,
        [Description("NoChange")]
        NoChange
    }

    public enum BaseTotalAmount
    {
        BaseAmount = 1,
        TotalAmount = 2
    }

    public enum POStatusEnum
    {
        [Description("Ordered")]
        Ordered = 1,
        [Description("PartlyRecieved")]
        PartlyRecieved = 2,
        [Description("Recieved")]
        Recieved = 3,
        [Description("Cancelled")]
        Cancelled = 4,
        [Description("SentForPayment")]
        SentForPayment = 5,
        [Description("Payment Done")]
        PaymentDone = 6,

    }

    public class StationEnum
    {
        public const int Jordan = 1;
        public const int Dubai = 2;
        public const int Shanghai = 3;
        public const int Cochin = 4;
        public const int Halol = 5;
        public const int Morbi = 6;
        public const int Kadi = 7;
        public const int Halvad = 8;
        public const int Rajkot = 9;
        public const int Patna = 10;
        public const int Surat = 11;
    }

    public class StationTypeEnum
    {
        public const int Station = 1;
        public const int Port = 2;
        public const int CFS = 3;
        public const int Yard = 4;
        public const int EmptyPark = 5;
    }

    public enum IntimationStatusEnum
    {
        New = 1
    }
    public enum JobStatusEnum
    {
        [Description("Created")]
        Created = 1,
        [Description("Completed")]
        Completed = 2,
    }

    public class DataTypeEnum
    {
        public const int Int = 1;
        public const int Bool = 4;
        public const int DateTime = 5;
        public const int IPAddress = 6;
        public const int EMailAddress = 7;
        public const int Decimal = 2;
        public const int String = 3;
    }

    public enum ConsignmentTypeEnum
    {
        [Description("Export Consignment")]
        Export = 1,
        [Description("Import Consignment")]
        Import = 2,
        [Description("Domestic Consignment")]
        Domestic = 3,
        [Description("Transportation Consignment")]
        Transportation = 4,
        [Description("Freight Forwarding")]
        FreightForwarding = 5
    }

    public enum ConsignmentJobStatus
    {
        [Description("New")]
        New = 1,
        [Description("Open")]
        Open = 2,
        [Description("Close")]
        Close = 3,
        [Description("DO Generated")]
        DoGenerated = 4



    }
    public enum DOStatusEnum
    {
        [Description("New")]
        New = 1
    }

    public enum VoucherTypes
    {
        Purchase = 1,
        Journal = 2,
        DebitNote = 3,
        Invoice = 4,
        CreditNote = 5,
        Brokerage = 6,
        Freight = 7,
        DieselExpense = 8,
        Receipt = 9,
        Payment = 10,
        Contra = 11,
        LRExpense = 12,
        LRFuel = 13,
        LiftOnOff = 14
    }
    public enum UserTypes
    {
        SuperAdmin = 1,
        Admin= 2
    }

    public enum RefernceTypes
    {
        OnAccount = 1,
        Against = 2
    }

    public enum Rates
    {
        ServiceTax = 1,
        VoucherAttachmentLocation = 3,
        ConsignmentAttachmentLocation = 4,
        SBcess = 2,
        VoucherNumberPrefix = 6,
        JobNumberPrefix = 7,
        DONumberPrefix = 8,
        AccountDepartmentEmails = 10,
        KKC = 4,
        FreightAssumption = 5
    }

    public enum TransactionModes
    {
        //Cash           = 1,
        //Withdraw       = 2,
        //Cheque         = 3,
        //Draft          = 4,
        //NetBanking     = 5,
        //CreditCard     = 6,
        //DebitCard      = 7,
        //VisaCard       = 8,
        //Paypal         = 9


        Cash = 1,
        Cheque = 2,
        DebitCard = 3,
        CreditCard = 4,
        Paypal = 5,
        NetBanking = 6,
        Draft = 7

    }

    public enum AccessRightss
    {
        Add,
        Edit,
        Delete,
        View,
        Report,
        Assign
    }


    //public enum SettingsEnum
    //{
    //        LiftONOFFExpense                 =          62 ,
    //        INPUTServiceTaxOthers             =           57,
    //        INPUTKKCOthers                 =            59   ,
    //        OtherInputServiceTaxLedgerId        =          57 ,
    //        OtherOutputServiceTaxLedgerId       =          56 ,
    //        ServiceTax                          =           14.0,
    //        SBcess                              =          0.5 ,
    //        KKC                                 =           0.5,
    //        DefaultChequeBookRemarks          ="Pradip",
    //    User= 1
    //}


    public enum UserLevels : int
    {

        Administrator = 1,
        Head = 2,
        User = 3
    }

    public enum LRStatus
    {
        Active = 1,
        Close = 2
    }
}
