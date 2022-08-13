using CodeNinjasScheduler.Core;
using System;

namespace CodeNinjasScheduler.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand SchduleVMCommand { get; set; }
        public RelayCommand SettingsVMCommand { get; set; }
        public RelayCommand MenuToggleCommand { get; set; }

        public ScheduleViewModel ScheduleVM { get; set; }
        public ScheduleViewModel28 ScheduleVM28 { get; set; }
        public ScheduleViewModel30 ScheduleVM30 { get; set; }
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
            ScheduleVM28 = new ScheduleViewModel28();
            ScheduleVM30 = new ScheduleViewModel30();
            SettingsVM = new SettingsViewModel();
            
            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            if (daysInMonth == 31) { CurrentView = ScheduleVM; }
            else if(daysInMonth == 30) { CurrentView = ScheduleVM30; }
            else { CurrentView = ScheduleVM28; }


            SchduleVMCommand = new RelayCommand(o =>
            {
                if (daysInMonth == 31) { CurrentView = ScheduleVM; }
                else if (daysInMonth == 30) { CurrentView = ScheduleVM30; }
                else { CurrentView = ScheduleVM28; }
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
