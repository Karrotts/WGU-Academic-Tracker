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
    public partial class CourseAddView : ContentPage
    {
        public CourseAddView(CourseAddViewModel courseAddViewModel)
        {
            InitializeComponent();

            BindingContext = courseAddViewModel;
        }
    }
}