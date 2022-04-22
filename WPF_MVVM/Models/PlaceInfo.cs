﻿using System.Collections.Generic;
using System.Windows;

namespace WPF_MVVM.Models
{
    public class PlaceInfo
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public IEnumerable<ConfirmedCount> Counts { get; set; }
    }
}