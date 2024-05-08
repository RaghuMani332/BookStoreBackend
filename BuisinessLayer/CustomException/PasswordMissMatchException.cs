using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.CustomException
{
    internal class PasswordMissMatchException:Exception
    {
        public PasswordMissMatchException(string message) : base(message) { }
    }
}
