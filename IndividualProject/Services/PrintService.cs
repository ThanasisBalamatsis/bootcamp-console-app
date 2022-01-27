using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProject.Entities;

namespace IndividualProject.Services
{
    class PrintService : IPrintService
    {
       

        public void PrintData()
        {
            DatabaseContext databaseContext = new DatabaseContext();
            using(databaseContext)
            {
                // All the students
                Console.WriteLine("ALL STUDENTS\n\t\n");
                Console.WriteLine(string.Join("\n", databaseContext.students.Select(s => "\tStudent ID: " + s.student_id + 
                                                                                         "\tfirst name: " + s.first_name +
                                                                                         "\tlast name: " + s.last_name +
                                                                                         "\tbirth date: " + s.date_birth +
                                                                                         "\ttuition fees: " + s.tuition_fees)));
                Console.WriteLine("\n---------------------------------------------------------------------------------");




                // All the trainers
                Console.WriteLine("ALL TRAINERS\n\t\n");
                Console.WriteLine(string.Join("\n", databaseContext.trainers.Select(t => "\tTrainer ID: " + t.trainer_id +
                                                                                         "\tfirst name: " + t.first_name +
                                                                                         "\tlast name: " + t.last_name +
                                                                                         "\tsubject: " + t.subject)));
                Console.WriteLine("\n---------------------------------------------------------------------------------");




                // All the assignments
                Console.WriteLine("ALL ASSIGNMENTS\n\t\n");
                Console.WriteLine(string.Join("\n", databaseContext.assignments.Select(a => "\tAssignment ID: " + a.assignment_id +
                                                                                            "\ttitle: " + a.title +
                                                                                            "\tdescription: " + a.description +
                                                                                            "\tsubmission date: " + a.sub_date +
                                                                                            "\toral mark: " + a.oral_mark +
                                                                                            "\ttotal mark: " + a.total_mark)));
                Console.WriteLine("\n---------------------------------------------------------------------------------");



                // All the courses
                Console.WriteLine("ALL COURSES\n\t\n");
                Console.WriteLine(string.Join("\n", databaseContext.courses.Select(c => "\tCourse ID: " + c.course_id +
                                                                                        "\ttitle: " + c.title +
                                                                                        "\tstream: " + c.stream +
                                                                                        "\ttype: " + c.type +
                                                                                        "\tstart date: " + c.start_date +
                                                                                        "\tend date: " + c.end_date)));
                Console.WriteLine("\n---------------------------------------------------------------------------------");



                // All the students per course
                Console.WriteLine("STUDENTS PER COURSE\n\t\n");
                foreach (Course course in databaseContext.courses)
                {
                    if (course.students.Count() == 0)
                    {
                        Console.WriteLine($"The course {course.title} {course.stream} {course.type} has no registered students");
                        Console.WriteLine("\n---------------------------------------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine(course.title + " " + course.stream + " " + course.type + "\n\n" + string.Join("\n", course.students.Select(s => "\t" + s.student_id + "\t " + s.first_name + "\t " + s.last_name)));
                        Console.WriteLine("\n---------------------------------------------------------------------------------");
                    }
                }
                Console.WriteLine("\n---------------------------------------------------------------------------------");


                // All trainers per course
                Console.WriteLine("TRAINERS PER COURSE\n\t\n");
                foreach (Course course in databaseContext.courses)
                {
                    if (course.trainers.Count() == 0)
                    {
                        Console.WriteLine($"The course {course.title} {course.stream} {course.type} has no registered trainers");
                        Console.WriteLine("\n---------------------------------------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine(course.title + " " + course.stream + " " + course.type + "\n\n" + string.Join("\n", course.trainers.Select(t => "\t" + t.trainer_id + "\t" + t.first_name + "\t" + t.last_name)));
                        Console.WriteLine("\n---------------------------------------------------------------------------------");
                    }
                }
                Console.WriteLine("\n---------------------------------------------------------------------------------");


                // All assignments per course
                Console.WriteLine("ASSIGNMENTS PER COURSE\n\t\n");
                foreach (Course course in databaseContext.courses)
                {
                    if (course.assignments.Count() == 0)
                    {
                        Console.WriteLine($"The course {course.title} {course.stream} {course.type} has no registered assignments");
                        Console.WriteLine("\n---------------------------------------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine(course.title + " " + course.stream + " " + course.type + "\n\n" + string.Join("\n", course.assignments.Select(a => "\t" + a.assignment_id + "\t" + a.title + "\t" + a.description)));
                        Console.WriteLine("\n---------------------------------------------------------------------------------");
                    }
                }
                Console.WriteLine("\n---------------------------------------------------------------------------------");


                // All the assignments per course per student
                Console.WriteLine("ASSIGNMENTS PER COURSE PER STUDENT\n\t\n");
                foreach (Student student in databaseContext.students)
                {
                    Console.WriteLine(student.student_id + "\t" + student.first_name + "\t" + student.last_name + "\t");
                    if (student.courses.Count() == 0)
                    {
                        Console.WriteLine("\n\tThis student hasn't registered for any courses");
                        Console.WriteLine("\n---------------------------------------------------------------------------------");
                    }
                    else
                    {
                        foreach (Course course in student.courses)
                        {
                            if (course.assignments.Count() == 0)
                            {
                                Console.WriteLine($"\t{course.course_id}\t{course.title}\t{course.stream}\t\n\n\tThis course hasn't registered assignments");
                                Console.WriteLine("\n---------------------------------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("\t" + course.course_id + "\t" + course.title + "\t" + course.stream + "\t\n\n" + string.Join("\n", course.assignments.Select(a => "\t" + a.assignment_id + "\t" + a.title + "\t" + a.description + "\t" + a.sub_date)));
                                Console.WriteLine("\n---------------------------------------------------------------------------------");
                            }

                        }
                    }
                }
                Console.WriteLine("\n---------------------------------------------------------------------------------");


                // Students that belong to more than one courses
                Console.WriteLine("STUDENTS THAT BELONG TO MORE THAN ONE COURSES\n\t\n" + string.Join("\n\t", databaseContext.students.Where(s => s.courses.Count() > 1)));
                Console.WriteLine("\n---------------------------------------------------------------------------------");
            }
            
        }



       
    }
}
