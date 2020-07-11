using AcademicTracker.ViewModel;
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
    public partial class CourseView : ContentPage
    {
        public CourseView(CourseViewModel courseViewModel)
        {
            InitializeComponent();
            BindingContext = courseViewModel;
            collectionPanel.ItemsSource = courseViewModel.CurrentTerm.Courses;
        }

        public void CancelSelection(Object sender, EventArgs e)
        {
            collectionPanel.SelectedItem = null;
        }
    }
}