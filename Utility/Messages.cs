using System;
using System.ComponentModel;
using System.Reflection;

namespace Utility
{
    public enum Message
    {
        SubmitSuccess,
        NotBlank,
        NoFound,
        PermissionDenied,
        DateFormatError,
        WriteError,
        ParsingProblem,
        UnderMaintenance

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
                default:
                    return "UnKnown Message";
            }
        }
    }

}
