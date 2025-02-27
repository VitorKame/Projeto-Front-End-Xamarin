﻿using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iVans.Models
{
    class Empresa : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }

        public string email { get; set; }

        public string nome { get; set; }

        public string senha { get; set; }

        public string telefone { get; set; }

        public string endereco { get; set; }

        public string cnpj { get; set; }

    }
}
