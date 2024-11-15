namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada(Hospedagem hospedagem)
    {
        InitializeComponent();

        // Atualiza os dados na interface
        lblQuarto.Text = hospedagem.Quarto;
        lblAdultos.Text = hospedagem.Adultos.ToString();
        lblCriancas.Text = hospedagem.Criancas.ToString();
        lblCheckin.Text = hospedagem.Checkin.ToString("dd/MM/yyyy");
        lblCheckout.Text = hospedagem.Checkout.ToString("dd/MM/yyyy");
        lblValorTotal.Text = $"R$ {hospedagem.ValorTotal:F2}";
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // Retorna para a tela de contratação de hospedagem
        await Navigation.PopToRootAsync();
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConfirmacaoPage());
    }
}