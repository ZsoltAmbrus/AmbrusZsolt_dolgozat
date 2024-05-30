using schoolPaper.Command;
using schoolPaper.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace schoolPaper.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

		private object currentView;

		public object CurrentView
		{
			get { return currentView; }
			set { currentView = value; OnPropertyChanged(); }
		}

		HomeView homeView;
		TaskOneView taskOneView;
        DataView dataView;

        public event PropertyChangedEventHandler? PropertyChanged;

        public RelayCommand openHOme { get; }
        public RelayCommand TaskOneView { get; }
        public RelayCommand DataView { get; }

        public MainViewModel()
        {
            homeView = new HomeView();
            taskOneView = new TaskOneView();
            dataView = new DataView();

            openHOme = new RelayCommand(X => CurrentView = homeView);
            TaskOneView = new RelayCommand(X=> CurrentView = taskOneView);
            DataView = new RelayCommand(X=> CurrentView = dataView);

			CurrentView = homeView;
        }
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
