using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iVans
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if ((LoginCliente.Text.Trim() == "Adm") && (SenhaCliente.Text.Trim() == "ADM"))
            {
                await Navigation.PushModalAsync(new PrinResp());
            }
            else
            {
                await DisplayAlert("Login ou Senha incorretos","Verifique-os","ok");
            }
        }

        private async void Button_OnClickedII(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CadSelect());
        }

    }
}
