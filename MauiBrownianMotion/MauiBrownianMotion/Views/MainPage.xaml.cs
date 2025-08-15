using MauiBrownianMotion.ViewModels;
using MauiBrownianMotion.Views.Controls;

namespace MauiBrownianMotion
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            // Configuração do Drawable
            var drawable = new BrownianMotionDrawable();
            GraphicsView.Drawable = drawable;

            viewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(MainViewModel.SimulationResults))
                {
                    drawable.SimulationResults = viewModel.SimulationResults.ToList();
                    GraphicsView.Invalidate();
                }
            };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
