using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathInput.Resources
{
    public class LocalizedStrings
    {
        private static Language _localizedResources = new Language();

        public Language LocalizedResources { get { return _localizedResources; } }
    }
}
