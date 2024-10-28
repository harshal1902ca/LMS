using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Abstraction.Enums
{
    public enum TransactionStatuses
    {
        [Description("Aquired")]
        Aquired = 1,

        [Description("Release")]
        Release = 2,
    }
}
