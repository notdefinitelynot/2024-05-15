using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfNaruto.Command;
using WpfNaruto.View;

namespace WpfNaruto.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set { currentView = value; OnPropertyChanged(); }
        }

        HomeView homeView;
        UsersView usersView;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string name=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public RelayCommand openHome { get; }
        public RelayCommand openUsers { get; }
        public MainViewModel()
        {
            homeView = new HomeView();
            usersView = new UsersView();

            openHome = new RelayCommand(x=>CurrentView=homeView);
            openUsers = new RelayCommand(x=>CurrentView=usersView);

            CurrentView = homeView;
        }
    }
}
