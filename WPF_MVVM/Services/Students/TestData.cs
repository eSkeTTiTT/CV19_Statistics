using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPF_MVVM.Models.Decanat;

namespace WPF_MVVM.Services.Students
{
    public static class TestData
    {
        public static Group[] Groups => Enumerable
            .Range(1, 10)
            .Select(i => new Group { Name = $"Группа {i}" })
            .ToArray();

        public static Student[] Students
        {
            get
            {
                var rnd = new Random();

                int index = 1;
                foreach(var group in Groups)
                {
                    for (int i = 0; i < 10; ++i)
                    {
                        group.Students.Add(new Student
                        {
                            Name = $"Имя {index}",
                            Surname = $"Фамилия {index}",
                            Patronymic = $"Отчество {index++}",
                            Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(300 * rnd.Next(19, 30))),
                            Rating = rnd.Next() * 100
                        });
                    }
                }

                return Groups.SelectMany(g => g.Students).ToArray();
            }
        }
    }
}
