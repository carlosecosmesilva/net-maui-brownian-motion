using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBrownianMotion.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiBrownianMotion.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        #region Variables
        private readonly BrownianMotionModel _brownianMotionModel;
        #endregion

        #region Observable
        [ObservableProperty]
        private double _initialPrice = 100;
        [ObservableProperty]
        private double _volatility = 0.2;
        [ObservableProperty]
        private double _mean = 0.01;
        [ObservableProperty]
        private int _timeDays = 252;
        [ObservableProperty]
        private int _simulationCount = 1;
        [ObservableProperty]
        private ObservableCollection<double[]> _simulationResults = new();
        [ObservableProperty]
        private bool _isBusy;
        #endregion

        #region Constructor
        public MainViewModel() : this(new BrownianMotionModel())
        {
        }

        public MainViewModel(BrownianMotionModel model)
        {
            _brownianMotionModel = model;
        }
        #endregion

        #region Methods
        [RelayCommand]
        private async Task GenerateSimulation()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            SimulationResults.Clear();

            try
            {
                for (int i = 0; i < SimulationCount; i++)
                {
                    var result = BrownianMotionModel.GenerateBrownianMotion(
                        Volatility, Mean, InitialPrice, TimeDays);

                    SimulationResults.Add(result);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
