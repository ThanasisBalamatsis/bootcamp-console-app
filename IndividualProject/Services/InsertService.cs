using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProject.Entities;

namespace IndividualProject.Services
{
    class InsertService : IInsertService
    {
        public void InsertData()
        {
            throw new NotImplementedException();
        }
        public void InsertData(Student student)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.students.Add(student);
                databaseContext.SaveChanges();
                Console.WriteLine("Student successfully inserted");
            }
        }
        public void InsertData(Trainer trainer)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.trainers.Add(trainer);
                databaseContext.SaveChanges();
                Console.WriteLine("Trainer successfully inserted");
            }
        }
        public void InsertData(Assignment assignment)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.assignments.Add(assignment);
                databaseContext.SaveChanges();
                Console.WriteLine("Assignment successfully inserted");
            }
        }
        public void InsertData(Course course)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.courses.Add(course);
                databaseContext.SaveChanges();
                Console.WriteLine("Course successfully inserted");
            }
        }
        public void InsertData(Student student, int courseId)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.students.Add(student);
                
                student.courses.Add(databaseContext.courses.Single(c => c.course_id == courseId));
                databaseContext.SaveChanges();
                Console.WriteLine("Student successfully inserted and registered for course");
            }
        }
        public void InsertData(Trainer trainer, int courseId)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.trainers.Add(trainer);

                trainer.courses.Add(databaseContext.courses.Single(c => c.course_id == courseId));
                databaseContext.SaveChanges();
                Console.WriteLine("Trainer successfully inserted and registered for course");
            }
        }
        public void InsertData(Assignment assignment, int courseId)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.assignments.Add(assignment);

                databaseContext.courses.Single(c => c.course_id == courseId).assignments.Add(assignment);
                databaseContext.SaveChanges();
                Console.WriteLine("Assignment successfully inserted and added to the list of assignments of the course");
            }
        }


    }
}
