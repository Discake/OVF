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

namespace OVFProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task1.FindULPfloat();
            var ULPfloat = Task1.ULPfloat;
            var Nfloat = Task1.Nfloat;

            Task1.FindULPdouble();
            var ULPdouble = Task1.ULPdouble;
            var Ndouble = Task1.Ndouble;
        }
    }
}
