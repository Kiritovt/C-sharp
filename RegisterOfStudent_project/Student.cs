using System.Dynamic;

namespace Register;

public class Student
{
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public List<double> Grades { get; set; } = new();

}