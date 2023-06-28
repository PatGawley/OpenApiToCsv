using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OpenApiToCsv
{
    public interface IArgumentValidator
    {
        (bool,string[]?) IsValid(string[] arguments);
    }
    public class ArgumentValidator : IArgumentValidator
    {
        private const string filenameRegex = "^[a-z0-9A-Z]{1,10}.json$";

        public (bool, string[]?) IsValid(string[] arguments)
        {
            
            if(arguments.Length != 1) {
                return (false, new string[] { "No arguments passed - 1 required" });
            }

            if (!Regex.IsMatch(arguments[0], filenameRegex))
            {
                return (false, new string[] { $"Argument must be 10 digit json filename conforming to Regex - {filenameRegex}" });
            }
            
            return (true,null);
        }
    }
}
