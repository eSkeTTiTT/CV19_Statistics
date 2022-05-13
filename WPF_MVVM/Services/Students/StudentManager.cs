using System;
using System.Collections.Generic;
using System.Text;
using WPF_MVVM.Models.Decanat;

namespace WPF_MVVM.Services.Students
{
    // так как не собираемся переопределять, зарегаем как обычный класс, без интерфейса
    public class StudentManager
    {
        private readonly StudentsRepository _students;
        private readonly GroupRepository _groups;

        public IEnumerable<Student> Students => _students.GetAll();
        public IEnumerable<Group> Groups => _groups.GetAll();

        public StudentManager(GroupRepository groups, StudentsRepository students)
        {
            _students = students;
            _groups = groups;
        }
    }
}
