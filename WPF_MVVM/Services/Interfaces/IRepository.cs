using System;
using System.Collections.Generic;
using System.Text;
using WPF_MVVM.Models.Interfaces;
using System.Linq;

namespace WPF_MVVM.Services.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        T Get(int id) => GetAll().FirstOrDefault(item => item.Id == id);
        IEnumerable<T> GetAll();
        void Add(T item);
        void Remove(T item);
        void Update(int id, T item);
    }
}
