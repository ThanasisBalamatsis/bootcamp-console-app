using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject.Services
{
    interface IValidationService
    {
        string CheckName(string firstOrLast);

        DateTime CheckDate(string dateType);

        int CheckTuitionFees();
        string CheckTexLength(string textType);
        string CheckStream();
        string CheckType();
    }
}
