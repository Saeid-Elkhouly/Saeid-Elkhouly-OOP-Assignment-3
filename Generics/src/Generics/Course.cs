/*
Step 2 — A store for courses
Create a class Course (Id, Title, Price) and a class CourseStore with the same four methods. In
Answers.md: what is the same between the two stores, and what is different? the same is that they both have a list of objects (students or courses) and methods to add, get by id, and remove. The difference is that the Course class has a Price property, while the Student class does not.

*/

namespace Generics;

public class Course: IHasId
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
}
  
