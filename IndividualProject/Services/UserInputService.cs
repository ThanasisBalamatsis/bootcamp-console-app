using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProject.Entities;

namespace IndividualProject.Services
{
    class UserInputService : IUserInputService
    {
        public void AskPrintOrInsert()
        {
            bool repeatProcess = true;
            while (repeatProcess)
            {
                Console.WriteLine("Would you like to print all available data (1) or insert data (2) ? Please press 1 for print or 2 for insertion.");
                string userInput = Console.ReadLine();
                while (userInput != "1" && userInput != "2")
                {
                    Console.WriteLine("Invalid input. Please press 1 for print or 2 for insertion.");
                    userInput = Console.ReadLine();
                }

                ProcessUserInput(userInput);
                repeatProcess = AskYesOrNo("Would you like to go back to Home Page? Please press 'Y' for yes or 'N' for no.");
            }
            
        }

        public void ProcessUserInput(string userInput)
        {
            
            switch (userInput)
            {
               case "1": //Print Data
                    PrintService myPrintService = new PrintService();
                    myPrintService.PrintData();
                    break;
                default: //Insert Data
                    InsertService myInsertService = new InsertService();
                    CreateService myCreateService = new CreateService();

                    string whatToInsert = AskWhatToInsert();
                    switch (whatToInsert)
                    {
                        case "1": //insert student
                            Student student = myCreateService.CreateStudent();
                            myInsertService.InsertData(student);
                            break;
                        case "2": //insert trainer
                            Trainer trainer = myCreateService.CreateTrainer();
                            myInsertService.InsertData(trainer);
                            break;
                        case "3": //insert assignment
                            Assignment assignment = myCreateService.CreateAssignment();
                            myInsertService.InsertData(assignment);
                            break;
                        case "4": //insert course
                            Course course = myCreateService.CreateCourse();
                            myInsertService.InsertData(course);
                            break;
                        case "5": //insert a student to a course
                            Student studentToCourse = myCreateService.CreateStudent();
                            myInsertService.InsertData(studentToCourse, AskToWhichCourseToAdd("student")); //inserts the new student to the database and to the course
                            break;
                        case "6": //insert a trainer to a course
                            Trainer trainerToCourse = myCreateService.CreateTrainer();
                            myInsertService.InsertData(trainerToCourse, AskToWhichCourseToAdd("trainer")); //inserts the new trainer to the database and to the course
                            break;
                        case "7": //insert an assignment to a course that belongs to a student
                            Assignment assignmentToCourse = myCreateService.CreateAssignment();
                            myInsertService.InsertData(assignmentToCourse, AskToWhichCourseToAdd("assignment"));
                            break;
                    }
                    break;
            }
        }

        public string AskWhatToInsert()
        {
            string message = "What would you like to insert?" +
                "\n\tto insert student press 1" +
                "\n\tto insert trainer press 2" +
                "\n\tto insert assignment press 3" +
                "\n\tto insert course press 4" +
                "\n\tto insert a new student to a course press 5" +
                "\n\tto insert a new trainer to a course press 6" +
                "\n\tto insert an new assignment to a course press 7";
            Console.WriteLine(message);

            string userInput = Console.ReadLine();
            List<string> validInputs = new List<string> { "1", "2", "3", "4", "5", "6","7"};

            while (!validInputs.Contains(userInput))
            {
                Console.WriteLine($"Invalid input. {message}");
                userInput = Console.ReadLine();
            }
           
            return userInput;
        }

        public int AskToWhichCourseToAdd(string entityType)
        {
            using(DatabaseContext database = new DatabaseContext())
            {
                string message = $"Select to which course the {entityType} should be added. Enter the course id of your choice"
                             + string.Join("\n\t", database.courses.Select(c => "\n\t" + c.course_id + 
                                                                         "\t" + c.title +
                                                                         "\t" + c.stream +
                                                                         "\t" + c.type));

                Console.WriteLine(message);
                List<int> validIDs = database.courses.Select(c => c.course_id).ToList();
                bool isInteger = int.TryParse(Console.ReadLine(), out int userInput);

                while (!isInteger || !(validIDs.Contains(userInput)))
                {
                    Console.WriteLine($"Invalid input. {message}");
                    isInteger = int.TryParse(Console.ReadLine(), out userInput);
                }
                return userInput;
            }
            
            
        }

        public static bool AskYesOrNo(string question)
        {
            Console.WriteLine($"{question}");
            string userResponse = (Console.ReadLine()).ToUpper();
            while (userResponse != "N" && userResponse != "Y")
            {
                Console.WriteLine($"Invalid input. {question}");
                userResponse = (Console.ReadLine()).ToUpper();
            }
            bool loopControlVariable = (userResponse == "N") ? false : true;

            return loopControlVariable;
        }


    }
}
