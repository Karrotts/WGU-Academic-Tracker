﻿using AcademicTracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AcademicTracker.Model;

namespace AcademicTracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermView : ContentPage
    {
        public TermView()
        {
            InitializeComponent();
            DataHelper.Initalize();
            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new TermViewModel();
            collectionPanel.ItemsSource = DataHelper.DataStore;
        }

        public void CancelSelection(Object sender, EventArgs e)
        {
            collectionPanel.SelectedItem = null;
        }
    }
}