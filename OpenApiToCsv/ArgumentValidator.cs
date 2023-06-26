using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenApiToCsv
{
    public interface IArgumentValidator
    {
        (bool,string[]?) IsValid(string[] arguments);
    }
    public class ArgumentValidator : IArgumentValidator
    {
        public (bool, string[]?) IsValid(string[] arguments)
        {
            throw new NotImplementedException();
        }
    }
}
