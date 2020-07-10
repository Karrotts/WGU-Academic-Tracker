using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AcademicTracker.View;
using System.Collections.ObjectModel;
using AcademicTracker.Model;

namespace AcademicTracker.ViewModel
{
    public class CourseViewModel : INotifyPropertyChanged
    {
        public CourseViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Term CurrentTerm { get; set; }
    }
}
