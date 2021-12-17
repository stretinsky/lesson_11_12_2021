using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodicka_11_12_21
{
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        internal sealed class DeveloperInfoAttribute : Attribute
        {
            public string Name { get; private set; }
            public DateTime Time { get; private set; }

            public DeveloperInfoAttribute(string developer, DateTime date)
            {
                Name = developer;
                Time = date;
            }

            public DeveloperInfoAttribute(string developer)
            {
                Name = developer;
                Time = DateTime.Now;
            }
    }
}
