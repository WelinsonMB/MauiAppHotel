namespace MauiAppHotel.Views
{
    public partial class ConfirmacaoPage : ContentPage
    {
        public ConfirmacaoPage()
        {
            InitializeComponent();
        }

        // Evento do bot�o Fechar
        private async void FecharButton_Clicked(object sender, EventArgs e)
        {
            // Navegar de volta para a p�gina anterior
            await Navigation.PopAsync();
        }
    }
}