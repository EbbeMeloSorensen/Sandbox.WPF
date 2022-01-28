using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AsyncAwait
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int _dummy;
        public int Dummy
        {
            get => _dummy;
            private set => Set(ref _dummy, value);
        }

        private bool _isBusyBrewingCoffee;
        public bool IsBusyBrewingCoffee
        {
            get => _isBusyBrewingCoffee;
            private set => Set(ref _isBusyBrewingCoffee, value);
        }

        private bool _isBusyRollingADie;
        public bool IsBusyRollingADie
        {
            get => _isBusyRollingADie;
            private set => Set(ref _isBusyRollingADie, value);
        }

        private bool _isBusyDoingHeavyWork;
        public bool IsBusyDoingHeavyWork
        {
            get => _isBusyDoingHeavyWork;
            private set => Set(ref _isBusyDoingHeavyWork, value);
        }

        private RelayCommand _ordinaryRelayCommand;
        private AsyncCommand _myAsyncCommand1;
        private AsyncCommand _myAsyncCommand2;
        private AsyncCommand _myAsyncCommand3;

        public RelayCommand OrdinaryRelayCommand
        {
            get { return _ordinaryRelayCommand ?? (_ordinaryRelayCommand = new RelayCommand(DoSomethingOrdinary)); }
        }

        public AsyncCommand MyAsyncCommand1
        {
            get { return _myAsyncCommand1 ?? (_myAsyncCommand1 = new AsyncCommand(BrewSomeCoffee, CanBrewSomeCoffee)); }
        }

        public AsyncCommand MyAsyncCommand2
        {
            get { return _myAsyncCommand2 ?? (_myAsyncCommand2 = new AsyncCommand(RollADie, CanRollADie)); }
        }

        public AsyncCommand MyAsyncCommand3
        {
            get { return _myAsyncCommand3 ?? (_myAsyncCommand3 = new AsyncCommand(DoHeavyWork, CanDoHeavyWork)); }
        }

        public MainWindowViewModel()
        {
            Dummy = 7;
        }

        private void DoSomethingOrdinary()
        {
        }

        private async Task BrewSomeCoffee()
        {
            try
            {
                IsBusyBrewingCoffee = true;
                MyAsyncCommand1.RaiseCanExecuteChanged();
                var coffeeService = new CoffeeService();
                await coffeeService.PrepareCoffeeAsync();

                Dummy = 9;
            }
            finally
            {
                IsBusyBrewingCoffee = false;
            }
        }

        private bool CanBrewSomeCoffee()
        {
            return !IsBusyBrewingCoffee;
        }

        private async Task RollADie()
        {
            try
            {
                IsBusyRollingADie = true;
                MyAsyncCommand2.RaiseCanExecuteChanged();
                var rollADieService = new RollADieService();
                Dummy = await rollADieService.RollADieAsync();
            }
            finally
            {
                IsBusyRollingADie = false;
            }
        }

        private bool CanRollADie()
        {
            return !IsBusyRollingADie;
        }

        private async Task DoHeavyWork()
        {
            try
            {
                IsBusyDoingHeavyWork = true;
                MyAsyncCommand3.RaiseCanExecuteChanged();
                var heavyDutyService = new HeavyDutyService();
                Dummy = (int)await heavyDutyService.DoSomeHeavyWork();
            }
            finally
            {
                IsBusyDoingHeavyWork = false;
            }
        }

        private bool CanDoHeavyWork()
        {
            return !IsBusyDoingHeavyWork;
        }
    }
}
