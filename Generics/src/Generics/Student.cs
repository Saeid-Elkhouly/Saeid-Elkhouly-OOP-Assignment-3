namespace Generics;
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class StudentStore
{
    private readonly List<Student> _students = [];

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }
    // GetById(int id) (returns null if not found),
    public Student? GetById(int id)
    {
        foreach (var student in _students)
        {
            if (student.Id == id)
            {
                return student;
            }
        }
        return null;
    }
    //Remove(int id)
    public bool Remove(int id)
    {
        var student = GetById(id);
        if (student != null)
        {
            _students.Remove(student);
            return true;
        }
        return false;
    }
}
