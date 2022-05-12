using System;
using System.Collections.Generic;
using System.Text;
using WPF_MVVM.Models.Decanat;
using WPF_MVVM.Services.Base;

namespace WPF_MVVM.Services
{
    public class StudentsRepository : RepositoryInMemory<Student>
    {
        protected override void Update(Student source, Student destination)
        {
            destination.Name = source.Name;
            destination.Surname = source.Surname;
            destination.Patronymic = source.Patronymic;
            destination.Rating = source.Rating;
            destination.Birthday = source.Birthday;
        }
    }
}
