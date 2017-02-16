using System;
using System.Collections.Generic;

namespace CSharp.Console.Menu
{
    public class Menu
    {
        private readonly string _startOfMenu;
        private readonly string _endOfMenu;
        private readonly int _minSpaceAfterMenuTitle;
        private readonly string _inputPrompt;
        private readonly IList<MenuItem> _menuItems;
        private readonly MenuItem _exitMenu;
        private int _maxLength;
        private int _exitIndex;

        public Menu(string title, string details)
        {
            Title = title;
            Details = details;
            _startOfMenu = "*****************************Main menu********************************";
            _endOfMenu   = "****************************End of menu*******************************";
            _minSpaceAfterMenuTitle = 10;
            _maxLength = 5;
            _inputPrompt = "$> ";
            _exitIndex = 0;
            _menuItems = new List<MenuItem>();
            _exitMenu = new ExitMenuItem();
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            _menuItems.Add(menuItem);
            if (menuItem.Title.Length > _maxLength)
            {
                _maxLength = menuItem.Title.Length;
            }
        }

        public void Start()
        {
            while (true)
            {
                var doExit = false;
                try
                {
                    doExit = ShowMenu();
                }
                catch (Exception)
                {
                    // we don't care about develpers' exceptions occurred during execution of menu items
                }

                if (doExit)
                {
                    break;
                }
            }
        }

        private bool ShowMenu()
        {
            PrintHeader();
            PrintMenuItems();
            PrintFooter();
            PrintInputPrompt();
            var cmd = System.Console.ReadLine();

            if (cmd == null)
            {
                PrintInvalidInputWarning();
                return false;
            }

            var args = cmd.Split(' ');

            int cmdId;

            if (!int.TryParse(args[0], out cmdId))
            {
                PrintInvalidInputWarning();
                return false;
            }

            if (cmdId == _exitIndex)
            {
                return true;
            }

            return ProcessCommandLineArguments(cmdId, args);
        }

        private bool ProcessCommandLineArguments(int cmdId, IReadOnlyList<string> args)
        {
            var index = cmdId - 1;

            if (index < 0 || index > _menuItems.Count - 1) {
                PrintInvalidInputWarning();
                return false;
            }

            var menuItem = _menuItems[index];
            var options = menuItem.Options;

            index = 1;
            var values = new MenuCallValues();

            if (options.Count != args.Count - 1) {
                PrintInvalidInputWarning();
                return false;
            }

            foreach (var option in options) {
                try {
                    var value = option.AsObject(args[index++]);
                    values.AddValue(option.ShortForm, value);
                } catch (InvalidMenuOptionValueException) {
                    PrintInvalidInputWarning();
                    return false;
                }
            }

            try {
                menuItem.Handler(values);
            } catch (Exception e) {
                PrintErrorDuringExecution(e);
                PressEnterToContinue();
                return false;
            }

            PressEnterToContinue();
            return false;
        }

        private void PrintErrorDuringExecution(Exception exception)
        {
            OutputToConsole($"Error during execution: {exception.Message}");
            Eol();
        }

        private void PrintMenuItems()
        {
            var itemNo = 0;
            foreach (var menuItem in _menuItems)
            {
                PrintMenuItem(menuItem, ++itemNo);
            }
            PrintMenuItem(_exitMenu, ++itemNo);
            _exitIndex = itemNo;
        }

        private void PrintMenuItem(MenuItem menuItem, int itemNo)
        {
            string title = $"{itemNo}. {menuItem.Title}";
            OutputToConsole(title);
            PrintSpaces(_maxLength - title.Length + _minSpaceAfterMenuTitle);
            PrintOptions(menuItem.Options, itemNo);
            Eol();
        }

        private void PrintInvalidInputWarning()
        {
            OutputToConsole("Invalid input");
            Eol();
            PressEnterToContinue();
        }

        private void PressEnterToContinue()
        {
            OutputToConsole("Press Enter to continue...");
            System.Console.ReadLine();
        }

        private void PrintHeader()
        {
            OutputToConsole(Title);
            Eol();
            if (Details != null)
            {
                OutputToConsole(Details);
                Eol();
            }
            OutputToConsole(_startOfMenu);
            Eol();
            const string title = "Title";
            OutputToConsole(title);
            PrintSpaces(_maxLength - title.Length + _minSpaceAfterMenuTitle);
            OutputToConsole("Command");
            Eol();
        }

        private void PrintInputPrompt()
        {
            OutputToConsole(_inputPrompt);
        }

        private void PrintFooter()
        {
            OutputToConsole(_endOfMenu);
            Eol();
        }

        public string Title { get; }

        public string Details { get; }

        private static void PrintOptions(IEnumerable<MenuOption> menuItemOptions, int itemNo)
        {
            OutputToConsole(itemNo);

            foreach (var option in menuItemOptions)
            {
                OutputToConsole($" [{option.Title}]");
            }
        }

        private static void Eol()
        {
            System.Console.WriteLine();
        }

        private static void PrintSpaces(int count)
        {
            OutputToConsole(new string('\0', count));
        }

        private static void OutputToConsole(string s)
        {
            System.Console.Write(s);
        }

        private static void OutputToConsole(int num)
        {
            System.Console.Write(num.ToString());
        }
    }
}