using MathInput.Resources;

namespace MathInput
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static Language _localizedResources = new Language();

        public Language LocalizedResources { get { return _localizedResources; } }
    }
}
