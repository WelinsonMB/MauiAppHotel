using MauiAppHotel.Models;
using System.Data;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;
	public ContratacaoHospedagem()
	{
		InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        if (PropriedadesApp.lista_quartos.Any())
        {
            pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;
        }
        else
        {
            DisplayAlert("Erro", "Nenhuma acomodação disponível.", "OK");
        }

        dtcpk_chekin.MinimumDate = DateTime.Now;
        dtcpk_chekin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtcpk_chekout.MinimumDate = dtcpk_chekin.Date.AddDays(1);
        dtcpk_chekout.MaximumDate = dtcpk_chekin.Date.AddMonths(6);

    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Sobre());

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        { 
            //Recuperar informações selecionadas

            var quartoSelecionado = (Quarto)pck_quarto.SelectedItem;
            if (quartoSelecionado == null)
            {
                await DisplayAlert("Erro", "Por favor, selecione uma acomodação.", "OK");
                return;
            }

            int adultos =(int)stp_adultos.Value;
            int criancas = (int)stp_criancas.Value;

            DateTime checkin = dtcpk_chekin.Date;
            DateTime checkout = dtcpk_chekout.Date;

            //Calcular valor total
            int diasEstadia = (checkout - checkin).Days; 
            double valorTotal = (quartoSelecionado.ValorDiariaAdulto * adultos + quartoSelecionado.ValorDiariaCriaca * criancas) * diasEstadia;

            //Criar objeto hospedagem

            var hospedagem = new Hospedagem
            {
                Quarto = quartoSelecionado.Descricao,
                Adultos = adultos,
                Criancas = criancas,
                Checkin = checkin,
                Checkout = checkout,
                ValorTotal = valorTotal
            };

            await Navigation.PushAsync(new HospedagemContratada(hospedagem));

        } catch (Exception ex) 
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void dtcpk_chekin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date;

        dtcpk_chekout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtcpk_chekout.MaximumDate = data_selecionada_checkin.AddMonths(6);


    }
}