using iVans.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iVans
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cad_Resp : ContentPage
    {
        private bool edit;
        private Realm _realm;
        private int _idPessoa;
       

        public int idPessoa
        {
            get { return _idPessoa; }
            set { _idPessoa = value;
               current = _realm.All<Pessoa>().FirstOrDefault(it => it.id == idPessoa);
                edit = true;
            }
        }

        private Pessoa _current;

        private Pessoa current
        {
            get { return _current; }
            set
            {
                _current = value;
                this.BindingContext = current;
            }
        }


        public Cad_Resp()
        {
            InitializeComponent();
            _realm = Helpers.Util.GetInstanceRealm();
            current = new Pessoa();

            
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            _realm.Write(() =>
            {
                if (edit)
                {
                    _realm.Add<Pessoa>(_current, true);
                }
                else
                {
                    var oo = _realm.All<Pessoa>().OrderByDescending(it => it.id).FirstOrDefault();

                    if (oo == null)
                    {
                        _realm.Add<Pessoa>(_current);
                    }
                    else
                    {
                        _current.id = oo.id + 1;
                        _realm.Add<Pessoa>(_current);
                    }
                }
            });
        }

        private void btnDel_Clicked(object sender, EventArgs e)
        {
            _realm.Write(() =>
            {
                _realm.Remove(_current);
            }
            );
            // Navigation.PopAsync();
        }

    }
}