using AcademicTracker.Model;
using AcademicTracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcademicTracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentView : ContentPage
    {
        public AssessmentView(AssessmentViewModel assessmentViewModel)
        {
            InitializeComponent();

            BindingContext = assessmentViewModel;
            collectionView.ItemsSource = assessmentViewModel.CurrentCourse.Assessments;
        }

        public void CancelSelection(Object sender, EventArgs e)
        {
            collectionView.SelectedItem = null;
        }
    }
}