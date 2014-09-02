using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeenDeen.Core;

namespace HeenDeen
{
    public sealed class HeenDeen<TType> : Compiler<TType> where TType : class
    {
    }
}
