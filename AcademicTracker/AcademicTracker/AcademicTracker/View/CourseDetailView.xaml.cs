﻿using AcademicTracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcademicTracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetailView : ContentPage
    {
        public CourseDetailView(CourseDetailViewModel courseDetailViewModel)
        {
            InitializeComponent();
            BindingContext = courseDetailViewModel;

            BindableLayout.SetItemsSource(assessmentPanel, courseDetailViewModel.CurrentCourse.Assessments);
        }
    }
}