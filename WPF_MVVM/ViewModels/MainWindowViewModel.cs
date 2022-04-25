using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using WPF_MVVM.Infrastructure.Commands;
using WPF_MVVM.Models.Decanat;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    public sealed class MainWindowViewModel : ViewModel
    {
        #region Constructors

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            int student_index = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {student_index}",
                Surname = $"Surname {student_index}",
                Patronymic = $"Patronymic {student_index++}",
                Birthday = DateTime.Now,
                Rating = 0
            });
            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            });

            Groups = new ObservableCollection<Group>(groups);

            _selectedGroupStudents.Filter += OnStudentFiltred;
        }

        #endregion

        #region Properties

        #region View Models

        public DirectoryViewModel DiskRootDir { get; } = new DirectoryViewModel("c:\\");

        #endregion

        public ObservableCollection<Group> Groups { get; }

        private Group _selectedGroup;
        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                if (!Set(ref _selectedGroup, value)) return;
                _selectedGroupStudents.Source = value?.Students;
                OnPropertyChanged(nameof(SelectedGroupStudents));
            }
        }

        private DirectoryViewModel _selectedDirectory;
        public DirectoryViewModel SelectedDirectory
        {
            get => _selectedDirectory;
            set => Set(ref _selectedDirectory, value);
        }

        private readonly CollectionViewSource _selectedGroupStudents = new CollectionViewSource();
        public ICollectionView SelectedGroupStudents => _selectedGroupStudents?.View;

        private string _title;
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private string _studentFilterText;
        public string StudentFilterText
        {
            get => _studentFilterText;
            set
            {
                if (!Set(ref _studentFilterText, value)) return;
                _selectedGroupStudents.View.Refresh();
            }
        }

        #endregion

        #region Commands

        #region Close Application Command

        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        #endregion

        #endregion

        #region Methods

        private void OnStudentFiltred(object sender, FilterEventArgs e)
        {
            string filterText = _studentFilterText;

            if (string.IsNullOrWhiteSpace(filterText)) return;

            if (!(e.Item is Student student) || student.Name is null || student.Surname is null || student.Patronymic is null)
            {
                e.Accepted = false;
                return;
            }

            if (student.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (student.Surname.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (student.Patronymic.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;


            e.Accepted = false;
        }

        #endregion
    }
}
