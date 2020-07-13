using AcademicTracker.Model;
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
    public partial class AssessmentView : ContentPage
    {
        public AssessmentView()
        {
            InitializeComponent();

            List<Term> terms = new List<Term> { new Term("test", DateTime.Now, DateTime.Now), new Term("test", DateTime.Now, DateTime.Now) };

            collectionView.ItemsSource = terms;
        }
    }
}