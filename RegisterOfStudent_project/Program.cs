using Register;

public class StudentsRegister
{
    public static void Main(string[] args)
    {
        bool TurnOff = false;
        List<Student> RegisterOfStudent = new();

        while (!TurnOff)
        {
            int choice = ReadChoice("===== Student Register =====\n1. Add Student\n2. Show Students\n3. Add grade\n4. Show student grades\n5. Calculate student average");
            
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the Student's Name: ");
                    Student student = new Student();
                    student.Name = Console.ReadLine() ?? "";
                    Console.WriteLine("Enter the Student's Surname: ");
                    student.Surname = Console.ReadLine() ?? "";
                    RegisterOfStudent.Add(student);
                    break;

                case 2:
                    int i = 0;
                    if(RegisterOfStudent.Count == 0)
                    {
                        Console.WriteLine("The Register is empty.");
                    }
                    else
                    {
                        foreach (Student s in RegisterOfStudent)
                        {
                            Console.WriteLine($"{i+1}. {s.Name} {s.Surname} ");
                            i++;
                        }
                    }
                    break;

                case 3:
                    if(RegisterOfStudent.Count == 0)
                    {
                        Console.WriteLine("The Register is Empty");
                    } else
                    {
                        int c = 0;
                        foreach (Student s in RegisterOfStudent)
                        {
                            Console.WriteLine($"{c + 1}. {s.Name} {s.Surname}");
                            c++;
                        }

                        while (true)
                        {
                            choice = ReadChoice("Select the student:");
                            if (choice > RegisterOfStudent.Count || choice < 1)
                            {
                                Console.WriteLine("Invalid input. Please retry");
                            }
                            else
                            {
                                break;
                            }
                        }
                        Console.WriteLine($"You choosed the student: {RegisterOfStudent[choice - 1].Name} {RegisterOfStudent[choice - 1].Surname}");

                        while (true)
                        {
                            double Grades = ReadChoice("Enter the Grades:");
                            if (Grades < 1 || Grades > 10)
                            {
                                Console.WriteLine("Invalid Grades number.");
                            }
                            else
                            {
                                RegisterOfStudent[choice - 1].Grades.Add(Grades);
                                break;
                            }
                        }
                        
                    }
                    break;

                case 4:
                    if (RegisterOfStudent.Count == 0)
                    {
                        Console.WriteLine("The Register is empty");
                    }
                    else
                    {
                        int g = 0;
                        foreach (Student s in RegisterOfStudent)
                        {
                            Console.WriteLine($"{g + 1}. {s.Name} {s.Surname} ");
                            g++;
                        }
                        int schoice;
                        while (true)
                        {
                            schoice = ReadChoice("Select the student:");
                            if (schoice > RegisterOfStudent.Count || schoice < 1)
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (RegisterOfStudent[schoice-1].Grades.Count == 0)
                                {
                                    Console.WriteLine($"The Student {RegisterOfStudent[schoice - 1].Name} {RegisterOfStudent[schoice - 1].Surname} has no grades to show");
                                    break;
                                }
                                else
                                {
                            Console.WriteLine($"The Student {RegisterOfStudent[schoice - 1].Name} {RegisterOfStudent[schoice - 1].Surname}'s grades are:");
                                    foreach (int grades in RegisterOfStudent[schoice-1].Grades){
                                        Console.WriteLine($"{grades}");
                                        }
                                    break;
                                }
                    }
                    break;

                case 5:
                    if (RegisterOfStudent.Count == 0)
                    {
                        Console.WriteLine("The Register is Empty");
                    }
                    else
                    {
                        int e = 0;
                        int f;
                        foreach (Student s in RegisterOfStudent)
                        {
                            Console.WriteLine($"{e + 1}. {s.Name} {s.Surname}");
                            e++;
                        }

                        while (true)
                        {
                            f = ReadChoice("Select a Student that u want the grade's avg");

                            if (f > RegisterOfStudent.Count || f < 1)
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            else break;
                        }

                        if (RegisterOfStudent[f - 1].Grades.Count == 0)
                        {
                            Console.WriteLine("The Selected Student has no grades.");
                        }
                        else
                        {
                            Console.WriteLine($"The Grade's Average of the Student:\n {RegisterOfStudent[f - 1].Name} {RegisterOfStudent[f - 1].Surname} is ");
                            double avg = 0;

                            foreach (double grades in RegisterOfStudent[f - 1].Grades)
                            {
                                avg = avg + grades;
                            }
                            avg = avg / RegisterOfStudent[f - 1].Grades.Count;
                            Console.WriteLine($"{avg}");
                        }
                    }
                    break;

                case 0:
                    TurnOff = true;
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                break;
            }
        }
    }

    public static int ReadChoice(string message)
    {
        while (true)
        {
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number. ");
            }
        }
    }
}