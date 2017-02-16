using System.Collections.Generic;

namespace CSharp.Console.Menu
{
    public class StringMenuOption : MenuOption
    {
        private readonly HashSet<string> _availableOptions;

        public StringMenuOption(string title, string shortForm) : base(title, shortForm)
        {
            _availableOptions = null;
        }

        public StringMenuOption(string title, string shortForm, IEnumerable<string> availableOptions) : base(title, shortForm)
        {
            _availableOptions = new HashSet<string>(availableOptions);
        }

        public override object AsObject(string str)
        {
            if (_availableOptions != null && !_availableOptions.Contains(str))
            {
                throw new InvalidMenuOptionValueException($"Not allowed value {str}");
            }

            return str;
        }
    }
}