using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProject.Services;
using IndividualProject.Entities;

namespace IndividualProject
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInputService myUserInputService = new UserInputService();
            myUserInputService.AskPrintOrInsert();
        }


    }
}
