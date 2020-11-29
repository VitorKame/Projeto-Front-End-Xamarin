using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iVans.Models
{
    class Pessoa : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }

        public string email { get; set; }

        public string nome { get; set; }

        public string senha { get; set; }

        public string celular { get; set; }

        public string endereco { get; set; }

        public string cpf { get; set; }

        public string nomec { get; set; }

        public string escola { get; set; }

        public string transporte { get; set; }

    }
}
