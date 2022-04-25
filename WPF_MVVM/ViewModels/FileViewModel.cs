using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    public sealed class FileViewModel : ViewModel
    {
        private readonly FileInfo _fileInfo;

        public string Name => _fileInfo.Name;
        public string Path => _fileInfo.FullName;
        public DateTime CreationTime => _fileInfo.CreationTime;

        public FileViewModel(string path)
        {
            _fileInfo = new FileInfo(path);
        }
    }
}
