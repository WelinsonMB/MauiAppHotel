namespace MauiAppHotel.Views
{
    public partial class ConfirmacaoPage : ContentPage
    {
        public ConfirmacaoPage()
        {
            InitializeComponent();
        }

        // Evento do botão Fechar
        private async void FecharButton_Clicked(object sender, EventArgs e)
        {
            // Navegar de volta para a página anterior
            await Navigation.PopAsync();
        }
    }
}