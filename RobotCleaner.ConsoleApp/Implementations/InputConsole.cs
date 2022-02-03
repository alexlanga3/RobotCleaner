using RobotCleaner.ConsoleApp.Helpers.Interfaces;
using RobotCleaner.ServiceLibrary.Interfaces;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobotCleaner.ConsoleApp.Implementations
{
    public class InputConsole
    {
        private static readonly Regex regexNumber = new Regex(@"^\d*$");
        private static readonly Regex regexNegativeNumber = new Regex(@"^-?\d*\.{0,1}\d+$");
        private static readonly Regex regexLetter = new Regex(@"\b[E,W,S,N]\w*\b");
        private int setRobotCleanerInstructionsNumber = 2;
        private int robotCleanerLiveInstructions;

        /// <summary>
        /// The User Library service.
        /// </summary>
        private readonly IUserLibrary _userLibrary;
        private readonly IRobotLibrary _robotLibrary;
        private readonly IConsole _wrapperConsole;

        public InputConsole(IUserLibrary userLibrary, IRobotLibrary robotLibrary, IConsole wrapperConsole)
        {
            _userLibrary = userLibrary;
            _robotLibrary = robotLibrary;
            _wrapperConsole = wrapperConsole;
        }

        public async Task StartRobotCleanerAppAsync()
        {
            while (ValidateInstructions())
            {
                Console.WriteLine("=>");

                if (robotCleanerLiveInstructions == 0)
                {
                    string input = _wrapperConsole.ReadLine();
                    if (regexNumber.IsMatch(input))
                    {
                        var inputNumber = Int32.Parse(input);
                        ValidateInstructionsNumber(inputNumber);
                        setRobotCleanerInstructionsNumber += inputNumber;
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                else if (robotCleanerLiveInstructions == 1)
                {
                    var coordinates = ValidateCoordinates(_wrapperConsole.ReadLine());
                    _userLibrary.SetStartParameters(coordinates);
                }
                else
                {
                    var movements = ValidateMovements(_wrapperConsole.ReadLine());
                    _userLibrary.SetMovements(movements);

                }
                robotCleanerLiveInstructions++;
            }

            var placesCleanned = await _robotLibrary.RunningThePlayAsync(_userLibrary.GetInstructions());

            Console.WriteLine("\n => Cleaned: {0}", placesCleanned);
        }


        #region Validations

        private string[] ValidateMovements(string movements)
        {
            string[] movementsStrings = movements.Split(null);

            if (movementsStrings.Length == 2)
            {
                if (!regexLetter.IsMatch(movementsStrings[0].ToUpper()))
                    Environment.Exit(0);

                if (regexNumber.IsMatch(movementsStrings[1]))
                {
                    var movement = Int32.Parse(movementsStrings[1]);
                    if (movement < 0 || movement > 100000)
                        Environment.Exit(0);
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Environment.Exit(0);
            }

            return movementsStrings;
        }

        private string[] ValidateCoordinates(string inputCoordinates)
        {
            string[] coordinateStrings = inputCoordinates.Split(null);

            if (coordinateStrings.Length == 2)
            {
                foreach (string i in coordinateStrings)
                {
                    if (regexNegativeNumber.IsMatch(i))
                    {
                        var coordinate = Int32.Parse(i);
                        if (coordinate < -100000 || coordinate > 100000)
                            Environment.Exit(0);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                Environment.Exit(0);
            }       

            return coordinateStrings;
        }

        private void ValidateInstructionsNumber(int inputNumber)
        {
            if (inputNumber > 10000)
                Environment.Exit(0);
        }

        private bool ValidateInstructions()
        {
            return robotCleanerLiveInstructions < setRobotCleanerInstructionsNumber;
        }

        #endregion
    }
}
