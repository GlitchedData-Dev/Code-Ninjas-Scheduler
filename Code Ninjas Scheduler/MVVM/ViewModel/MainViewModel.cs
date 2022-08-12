using Code_Ninjas_Scheduler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Ninjas_Scheduler.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand SchduleVMCommand { get; set; }
        public RelayCommand SettingsVMCommand { get; set; }
        public RelayCommand MenuToggleCommand { get; set; }

        public ScheduleViewModel ScheduleVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            ScheduleVM = new ScheduleViewModel();
            SettingsVM = new SettingsViewModel();
            CurrentView = ScheduleVM;

            SchduleVMCommand = new RelayCommand(o =>
            {
                CurrentView = ScheduleVM;
            });

            SettingsVMCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });

            MenuToggleCommand = new RelayCommand(o =>
            {
                if (CurrentView == SettingsVM)
                {
                    CurrentView = ScheduleVM;
                }
                else
                {
                    CurrentView = SettingsVM;
                }
            });
        }
    }
}
