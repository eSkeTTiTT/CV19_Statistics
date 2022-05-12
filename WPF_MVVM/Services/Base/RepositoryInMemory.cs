using System;
using System.Collections.Generic;
using System.Text;
using WPF_MVVM.Models.Interfaces;
using WPF_MVVM.Services.Interfaces;

namespace WPF_MVVM.Services.Base
{
    public abstract class RepositoryInMemory<T> : IRepository<T> where T : IEntity
    {
        private List<T> _items = new List<T>();
        private int _lastId = 1;

        protected RepositoryInMemory()
        {

        }

        protected RepositoryInMemory(IEnumerable<T> items)
        {
            foreach (var item in items)
                Add(item);
        }

        public void Add(T item)
        {
            if (item is null) throw new ArgumentException(nameof(item));

            if (_items.Contains(item)) return;

            item.Id = ++_lastId;
            _items.Add(item);
        }

        public IEnumerable<T> GetAll() => _items;

        public void Remove(T item) => _items.Remove(item);

        public void Update(int id, T item)
        {
            if (item is null) throw new ArgumentException(nameof(item));

            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            if (_items.Contains(item)) return;

            var db_item = ((IRepository<T>)this).Get(id);
            if (db_item is null) throw new InvalidOperationException(nameof(db_item));

            Update(item, db_item);
        }

        protected abstract void Update(T source, T destination);
    }
}
