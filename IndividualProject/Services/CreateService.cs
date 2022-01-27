using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProject.Entities;

namespace IndividualProject.Services
{
    class CreateService : ICreateService
    {
        public Assignment CreateAssignment()
        {
            ValidationService myValidationService = new ValidationService();
            Assignment assignment = new Assignment() 
            {
                title = myValidationService.CheckTexLength("title"),
                description = myValidationService.CheckTexLength("description"),
                sub_date = myValidationService.CheckDate("submission date")
            };
            return assignment;
        }

        public Course CreateCourse()
        {
            ValidationService myValidationService = new ValidationService();
            Course course = new Course()
            {
                title = myValidationService.CheckTexLength("title"),
                stream = myValidationService.CheckStream(),
                type = myValidationService.CheckType(),
                start_date = myValidationService.CheckDate("start date"),
            };
            return course;
        }

        public Student CreateStudent()
        {
            ValidationService myValidationService = new ValidationService();
            Student student = new Student()
            {
                first_name = myValidationService.CheckName("first"),
                last_name = myValidationService.CheckName("last"),
                date_birth = myValidationService.CheckDate("birth date"),
                tuition_fees = myValidationService.CheckTuitionFees()
            };
            return student;
        }

        public Trainer CreateTrainer()
        {
            ValidationService myValidationService = new ValidationService();
            Trainer trainer = new Trainer() 
            {
                first_name = myValidationService.CheckName("first"),
                last_name = myValidationService.CheckName("last"),
                subject = "This is the subject"
            };
            return trainer;
        }
    }
}
