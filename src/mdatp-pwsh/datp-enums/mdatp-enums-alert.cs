namespace MdatpPwsh
{
    namespace Classes
    {
        namespace Enums
        {
            public enum AlertStatus
            {
                InProgress,
                New,
                Resolved,
                Unknown
            }

            public enum AlertSeverity
            {
                UnSpecified,
                Informational,
                Low,
                Medium,
                High
            }

            public enum AlertClassification
            {
                Unknown,
                FalsePositive,
                TruePositive
            }

            public enum AlertDetermination
            {
                NotAvailable,
                Apt,
                Malware,
                SecurityPersonnel,
                SecurityTesting,
                UnwantedSoftware,
                Other
            }
        }
    }
}