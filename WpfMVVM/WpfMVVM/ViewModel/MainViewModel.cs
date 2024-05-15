using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfMVVM.Command;
using WpfMVVM.View;

namespace WpfMVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
		private object currentView;

		public object CurrentView
		{
			get { return currentView; }
			set { currentView = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentView"));
			}
		}

		private GreenView greenView;
		private YellowView yellowView;
		private PinkView pinkView;

        public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged()
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentView"));
		}

        public RelayCommand YellowViewCommand { get; }
        public RelayCommand GreenViewCommand { get; }

		public RelayCommand PinkViewCommand { get; }

        public MainViewModel() 
		{ 
			greenView = new GreenView();
			yellowView = new YellowView();
			pinkView = new PinkView();
			CurrentView = greenView;

			YellowViewCommand = new RelayCommand(setYellow);
			GreenViewCommand = new RelayCommand(x=>CurrentView=greenView);
			PinkViewCommand = new RelayCommand(x => CurrentView = pinkView);
		}

		private void setYellow(object y)
		{
			CurrentView = yellowView;
		}
	}
}
