namespace Utility
{
    public enum Message
    {
        SubmitSuccess,
        RemoveSuccess,
        RemoveFailed,
        NotBlank,
        NoFound,
        PermissionDenied,
        DateFormatError,
        WriteError,
        ParsingProblem,
        UnderMaintenance,
        Unapproved,
        AlreadyApproved,
        AlreadyAdded,
        SomethingError,
        SessionOut
        
        

    }

    public static class MessageExtensions
    {
         
        public static string ToFriendlyString(this Message msg)
        {
            switch (msg)
            {
                case Message.SubmitSuccess:
                    return "Submit Successfully";
                case Message.NotBlank:
                    return "Cannot be Blank";
                case Message.RemoveSuccess:
                    return "Remove Successfully";
                case Message.RemoveFailed:
                    return "Remove Failed";
                case Message.NoFound:
                    return "No Data Found";
                case Message.PermissionDenied:
                    return "Permission Denined";
                case Message.DateFormatError:
                    return "Date Format Error";
                case Message.WriteError:
                    return "Write Properly";
                case Message.ParsingProblem:
                    return "Parsing Problem";
                case Message.UnderMaintenance:
                    return "Under Maintenance";
                case Message.Unapproved:
                    return "This is Unapproved";
                case Message.AlreadyApproved:
                    return "This is Already Approved";
                case Message.AlreadyAdded:
                    return "This is Already Added";
                case Message.SomethingError:
                    return "Somethings Error";
                case Message.SessionOut:
                    return "Session timeout. please try again.";
                
                default:
                    return "UnKnown Message";
            }
        }
    }

}
