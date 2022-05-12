using System;
using System.Collections.Generic;
using System.Text;
using WPF_MVVM.Models.Interfaces;

namespace WPF_MVVM.Models.Decanat
{
    public class Student : IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public double Rating { get; set; }

        public int Id { get; set; }
    }
}
