using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProject.Entities;
using System.Globalization;

namespace IndividualProject.Services
{
    class ValidationService : IValidationService
    {
        public DateTime CheckDate(string dateType)
        {
            Console.WriteLine($"Enter your {dateType}. Valid format is dd/mm/yyyy");
            string userInput = Console.ReadLine();
            CultureInfo culture = new CultureInfo("el-EL");

            while (!(DateTime.TryParse(userInput, out _)))
            {
                Console.WriteLine($"Invalid input. Enter your {dateType}. Valid format is dd/mm/yyyy");
                userInput = Console.ReadLine();
            }
            DateTime result = DateTime.Parse(userInput, culture);
            return result;
        }

        public string CheckName(string firstOrLast)
        {
            Console.WriteLine($"Please enter a valid {firstOrLast} name");
            string name = Console.ReadLine();
            bool containsInt = name.Any(char.IsDigit);

            while (containsInt || name.Length > 20 || name.Length < 3)
            {
                Console.WriteLine($"Invalid input. Please enter a valid {firstOrLast} name");
                name = Console.ReadLine();
                containsInt = name.Any(char.IsDigit);
            }

            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            return name;
        }

        public string CheckStream()
        {
            Console.WriteLine("Please enter a valid Course Stream. Valid inputs: Java, CSharp, Python, JavaScript");
            string userInput = Console.ReadLine();

            List<string> validStreams = new List<string> {"JAVA", "CSHARP", "PYTHON", "JAVASCRIPT"};

            while (!(validStreams.Contains(userInput.ToUpper())))
            {
                Console.WriteLine("Invalid input. Please enter a valid Course Stream. Valid inputs: Java, CSharp, Python, JavaScript");
                userInput = Console.ReadLine();
            }

            if (userInput.ToUpper() == "CSHARP")
            {
                return userInput.Substring(0, 2).ToUpper() + userInput.Substring(2).ToLower();
            }
            else
            {
                return userInput.Substring(0, 1).ToUpper() + userInput.Substring(1).ToLower();
            }
        }

        public string CheckTexLength(string textType)
        {
            Console.WriteLine($"Please enter a valid {textType}. Maximum number of characters: 50");
            string text = Console.ReadLine();

            while (text.Length > 50)
            {
                Console.WriteLine($"Invalid input. Please enter a valid {textType}. Maximum number of characters: 50");
                text = Console.ReadLine();
            };
            return text;
        }

        public int CheckTuitionFees()
        {
            Console.WriteLine("Please enter Tuition Fees");
            bool isInteger = int.TryParse(Console.ReadLine(), out int tuitionFees);
            while (!isInteger)
            {
                Console.WriteLine("Invalid input. Please enter valid Tuition Fees");
                isInteger = int.TryParse(Console.ReadLine(), out tuitionFees);
            }

            return tuitionFees; 
        }

        public string CheckType()
        {
            Console.WriteLine("Please enter a valid Course Type. Enter FT for Full-time or PT for Part-time");
            string userInput = Console.ReadLine();

            List<string> validTypes = new List<string> { "FT", "PT" };

            while (!(validTypes.Contains(userInput.ToUpper())))
            {
                Console.WriteLine("Invalid input. Please enter a valid Course Type. Enter FT for Full-time or PT for Part-time");
                userInput = Console.ReadLine();
            }

            if (userInput.ToUpper() == "FT")
            {
                return "Full-time";
            }
            else
            {
                return "Part-time";
            }
        }
    }
}
