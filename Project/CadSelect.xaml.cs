using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iVans
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadSelect : ContentPage
    {
        public CadSelect()
        {
            InitializeComponent();
        }

        private async void btn_resp_Click(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Cad_Resp());
        }

        private async void btn_emp_Click(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Cad_Emp());
            
        }
    }
}