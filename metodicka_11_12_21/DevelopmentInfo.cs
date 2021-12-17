using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodicka_11_12_21
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal sealed class DevelopementInfoAttribute : Attribute
    {
        public string Name { get; private set; }
        public string Organisation { get; private set; }

        public DevelopementInfoAttribute(string developer, string organisation)
        {
            Name = developer;
            Organisation = organisation;
        }
    }
}
