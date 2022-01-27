using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProject.Entities;

namespace IndividualProject.Services
{
    interface ICreateService
    {
        Student CreateStudent();
        Trainer CreateTrainer();
        Assignment CreateAssignment();
        Course CreateCourse();
    }
}
