using MauiBrownianMotion.ViewModels;
using MauiBrownianMotion.Views.Controls;

namespace MauiBrownianMotion
{
    public partial class MainPage : ContentPage
    {
        private readonly BrownianMotionDrawable _drawable;

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            // Configuração do Drawable
            _drawable = new BrownianMotionDrawable();
            GraphicsView.Drawable = _drawable;

            viewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(MainViewModel.SimulationResults))
                {
                    _drawable.SimulationResults = viewModel.SimulationResults.ToList();
                    GraphicsView.Invalidate();
                }
            };
        }
    }
}
