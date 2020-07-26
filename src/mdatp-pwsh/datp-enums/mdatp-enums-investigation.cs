namespace MdatpPwsh
{
    namespace Classes
    {
        namespace Enums
        {
            public enum InvestigationState
            {
                Unknown,
                Terminated,
                SuccessfullyRemediated,
                Benign,
                Failed,
                PartiallyRemediated,
                Running,
                PendingApproval,
                PendingResource,
                PartiallyInvestigated,
                TerminatedByUser,
                TerminatedBySystem,
                Queued,
                InnerFailure,
                PreexistingAlert,
                UnsupportedOs,
                UnsupportedAlertType,
                SuppressedAlert
            }
        }
    }
}