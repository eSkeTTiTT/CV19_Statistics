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

        #endregion

        public StudentsManagementViewModel(StudentManager studentManager)
        {
            _studentManager = studentManager;
        }
    }
}
