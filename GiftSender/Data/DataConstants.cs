namespace GiftSender.Data
{
    public class DataConstants
    {
        public class ApplicationUser
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 300;

            public const int MobileNumberMinLength = 6;
            public const int MobileNumberMaxLength = 10;
        }
        public class Transaction
        {
            public const int MassageMinLength = 5;
            public const int MassageMaxLength = 500;

            public const int CreditsMin = 1;
            public const int CreditsMax = 100000;
        }
    }
}
