using System;
using System.Collections.Generic;
using System.Text;
using WPF_MVVM.Models.Decanat;
using WPF_MVVM.Services.Students;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    public class StudentsManagementViewModel : ViewModel
    {
        #region Properties

        private readonly StudentManager _studentManager;

        public string Title { get; private set; } = "Управление студентами";

        public IEnumerable<Student> Students => _studentManager.Students;

        public IEnumerable<Group> Groups => _studentManager.Groups;

        private Group _selectedGroup;
        public Group SelectedGroup
        {
            get => _selectedGroup;
            set => Set(ref _selectedGroup, value);
        }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set => Set(ref _selectedStudent, value);
        }

        #endregion

        public StudentsManagementViewModel(StudentManager studentManager)
        {
            _studentManager = studentManager;
        }
    }
}
