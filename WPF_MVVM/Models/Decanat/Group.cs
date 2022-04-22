using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_MVVM.Models.Decanat
{
    public class Group
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
