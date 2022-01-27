using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.Services
{
    interface IUserInputService
    {
        void AskPrintOrInsert();
        void ProcessUserInput(string userInput);
    }
}
