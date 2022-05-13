using System;
using System.Collections.Generic;
using System.Text;
using WPF_MVVM.Models.Decanat;
using WPF_MVVM.Services.Base;

namespace WPF_MVVM.Services.Students
{
    public class GroupRepository : RepositoryInMemory<Group>
    {
        public GroupRepository() : base(TestData.Groups) { }

        protected override void Update(Group source, Group destination)
        {
            destination.Name = source.Name;
            destination.Description = source.Description;
        }
    }
}
