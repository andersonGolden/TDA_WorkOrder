using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDAWorkOrderAPI.ViewModel
{
    public class StaticMessages
    {
        public static string ErrorMessage => "Could not process your request, please try again.";
        public static string RecordSaved => "Record Created Successfully.";
        public static string RecordExists => "Record Already Exists!.";
        public static string RecordRetreived => "Record Retreived.";
        public static string RecordNotFound => "Record Not Found!.";
        public static string RecordUpdate => "Record Updated Successfully.";
        public static string RecordDeleted => "Record Deleted Successfully.";
        public static string InvalidCredentials => "Incorrect username/password.";
        public static string DefaultSuccess => "Successful.";
    }
}
