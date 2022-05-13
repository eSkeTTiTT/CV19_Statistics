using System;
using System.Collections.Generic;
using System.Text;
using WPF_MVVM.Models.Interfaces;

namespace WPF_MVVM.Models.Decanat
{
    public class Group : IEntity
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public string Description { get; set; }

        public int Id { get; set; }
    }
}
