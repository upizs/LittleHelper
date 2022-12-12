using LittleHelper.Bases;
using LittleHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LittleHelper
{
    public class MainWindowViewModel : BindableBase
    {
        private DateTime _currentTime;
        private Timer _timer = new Timer(1000);
        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }


        public DateTime CurrentTime
        {
            get { return _currentTime; }
            set { SetProperty(ref _currentTime, value); }
        }
        public MainWindowViewModel()
        {
            CurrentTime = DateTime.Now;
            _timer.Elapsed += (s, e) => CurrentTime = DateTime.Now.ToLocalTime();
            _timer.Start();
            CurrentViewModel = new TextCompareViewModel();
        }



    }
}
