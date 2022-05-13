using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPF_MVVM.Models.Decanat;

namespace WPF_MVVM.Services.Students
{
    public static class TestData
    {
        private static Group[] _groups;
        private static Student[] _students;

        public static Group[] Groups => _groups ??= Enumerable
            .Range(1, 10)
            .Select(i => new Group { Name = $"Группа {i}" })
            .ToArray();

        public static Student[] Students => _students ??= CreateStudents(_groups);

        private static Student[] CreateStudents(IEnumerable<Group> groups)
        {
            var rnd = new Random();

            int index = 1;
            foreach (var group in groups)
            {
                for (int i = 0; i < 10; ++i)
                {
                    group.Students.Add(new Student
                    {
                        Name = $"Имя {index}",
                        Surname = $"Фамилия {index}",
                        Patronymic = $"Отчество {index++}",
                        Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(300 * rnd.Next(19, 30))),
                        Rating = rnd.NextDouble() * 100
                    });
                }
            }

            return groups.SelectMany(g => g.Students).ToArray();
        }
    }
}
