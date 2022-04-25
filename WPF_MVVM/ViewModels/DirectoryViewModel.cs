using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    public sealed class DirectoryViewModel : ViewModel
    {
        private readonly DirectoryInfo _directoryInfo;

        public IEnumerable<DirectoryViewModel> SubDirectories
        {
            get
            {
                try
                {
                    var directories = _directoryInfo
                        .EnumerateDirectories()
                        .Select(d => new DirectoryViewModel(d.FullName));

                    return directories;
                }
                catch (UnauthorizedAccessException e)
                {
                    Debug.WriteLine(e.ToString());
                }

                return Enumerable.Empty<DirectoryViewModel>();
            }
        }

        public IEnumerable<FileViewModel> Files
        {
            get
            {
                try
                {
                    var files = _directoryInfo
                        .EnumerateFiles()
                        .Select(file => new FileViewModel(file.FullName));

                    return files;
                }
                catch (UnauthorizedAccessException e)
                {
                    Debug.WriteLine(e.ToString());
                }

                return Enumerable.Empty<FileViewModel>();
            }
        }

        public IEnumerable<object> DirectoryItems
        {
            get
            {
                try
                {
                    return SubDirectories.Cast<object>().Concat(Files);
                }
                catch (UnauthorizedAccessException e)
                {
                    Debug.WriteLine(e.ToString());
                }

                return Enumerable.Empty<object>();
            }
        }

        public string Name => _directoryInfo.Name;
        public string Path => _directoryInfo.FullName;
        public DateTime CreationTime => _directoryInfo.CreationTime;

        public DirectoryViewModel(string path)
        {
            _directoryInfo = new DirectoryInfo(path);
        }
    }
}
