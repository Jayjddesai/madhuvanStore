namespace Madhuvan.Commonlayer
{
    public static class RegularExpression
    {
        public const string RegexNumber = @"^[0-9]*$";

        /// <summary>
        /// The regular expression for telephone.
        /// </summary>
        public const string RegExpTelephone = @"^[0-9 (,),-]{0,15}$";

        /// <summary>
        /// The regular expression email.
        /// </summary>
        public const string RegExpEmail = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}";

        /// <summary>
        /// The regular expression url.
        /// </summary>
        public const string RegExpURl = @"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";

        /// <summary>
        /// The regular expression up to 2 decimal place.
        /// </summary>
        public const string RegExpUpTo2Decimal = @"^\d{1,14}(\.\d{1,2})?$";

        /// <summary>
        /// Regular expression for email
        /// </summary>
        public const string RegexEmail = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}";

        /// <summary>
        /// Regular expression for I.P Address
        /// </summary>
        public const string RegexIp = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
    }
}
