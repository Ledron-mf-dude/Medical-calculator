﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Medical_calculator.MVVM.View
{
    /// <summary>
    /// Interaction logic for GFRCalcView.xaml
    /// </summary>
    public partial class GFRCalcView : UserControl
    {
        public List<string> Items { get; set; }

        public GFRCalcView()
        {
            InitializeComponent();

            Items = new List<string> { "Варіант 1", "Варіант 2", "Варіант 3" };
        }
    }
}