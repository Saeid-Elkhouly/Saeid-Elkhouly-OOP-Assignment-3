/*
• Put 5 students in a Store<Student> and 3 courses in a Store<Course>; get one of each by id.
• Add a student with an id that already exists — catch the exception and print its message.
• Print page 2 (size 2) of the students, and call FindById on a plain List<Course>.
• Leave new Store<string>() as a commented-out line marked “must NOT compile”, and explain why in
Answers.md.
*/

using Generics;

Store<Student> studentStore = new Store<Student>();
studentStore.Add(new Student { Id = 1, Name = "Saeid" });
studentStore.Add(new Student { Id = 2, Name = "Mohamed" });
studentStore.Add(new Student { Id = 3, Name = "Ali" });
studentStore.GetById(1);
studentStore.GetById(2);
studentStore.GetById(3);
//• Print page 2 (size 2) of the students, and call FindById on a plain List<Course>.
studentStore.Items.Page(2, 2);
studentStore.GetById(1);
//Store<string> stringStore = new Store<string>(); // must NOT compile because string does not implement IHasId interface

