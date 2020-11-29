using iVans.Models;
using Realms;
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
    public partial class Cad_Emp : ContentPage
    {
        private bool edit;
        private Realm _realm;
        private int _idEmpresa;

        public int idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;
                current = _realm.All<Empresa>().FirstOrDefault(it => it.id == idEmpresa);
                edit = true;
            }
        }

        private Empresa _current;

        private Empresa current
        {
            get { return _current; }
            set
            {
                _current = value;
                this.BindingContext = current;
            }
        }
        public Cad_Emp()
        {
            InitializeComponent();

            _realm = Helpers.Util.GetInstanceRealm();
            current = new Empresa();
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            _realm.Write(() =>
            {
                if (edit)
                {
                    _realm.Add<Empresa>(_current, true);
                }
                else
                {
                    var oo = _realm.All<Empresa>().OrderByDescending(it => it.id).FirstOrDefault();

                    if (oo == null)
                    {
                        _realm.Add<Empresa>(_current);
                    }
                    else
                    {
                        _current.id = oo.id + 1;
                        _realm.Add<Empresa>(_current);
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
            //  Navigation.PopAsync();
        }
    }
}