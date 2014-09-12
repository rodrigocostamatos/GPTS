using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TO
{
    public class ClienteTO
    {
        private string cnpj;
        private string razaoSocial;
        private string nome;
        private string inscricaoMunicipal;
        private string inscricaoEstadual;
        private string endereco;
        private string bairro;
        private string cidade;        
        private string estado;
        private string cep;
        private string telefone;
        private string site;
        private string contatoPrime;
        private string contato;
        private string cargoPrime;
        private string cargoContato;
        private string telefonePrime;
        private string telefoneContato;
        private string celularPrime;
        private string celularContato;
        private string emailPrime;
        private string emailContato;

        public override string ToString()
        {
            return nome;
        }

        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        public string RazaoSocial
        {
            get { return razaoSocial; }
            set { razaoSocial = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string InscricaoMunicipal
        {
            get { return inscricaoMunicipal; }
            set { inscricaoMunicipal = value; }
        }

        public string InscricaoEstadual
        {
            get { return inscricaoEstadual; }
            set { inscricaoEstadual = value; }
        }

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public string Site
        {
            get { return site; }
            set { site = value; }
        }

        public string ContatoPrime
        {
            get { return contatoPrime; }
            set { contatoPrime = value; }
        }

        public string Contato
        {
            get { return contato; }
            set { contato = value; }
        }
        
        public string CargoPrime
        {
            get { return cargoPrime; }
            set { cargoPrime = value; }
        }

        public string CargoContato
        {
            get { return cargoContato; }
            set { cargoContato = value; }
        }

        public string TelefonePrime
        {
            get { return telefonePrime; }
            set { telefonePrime = value; }
        }

        public string TelefoneContato
        {
            get { return telefoneContato; }
            set { telefoneContato = value; }
        }

        public string CelularPrime
        {
            get { return celularPrime; }
            set { celularPrime = value; }
        }

        public string CelularContato
        {
            get { return celularContato; }
            set { celularContato = value; }
        }

        public string EmailPrime
        {
            get { return emailPrime; }
            set { emailPrime = value; }
        }

        public string EmailContato
        {
            get { return emailContato; }
            set { emailContato = value; }
        }

    }
}
