using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TO
{
    public class UsuarioTO
    {
        private int id;
        private int tipo;
        private int totProducao;

        private char flagSenha;
        private String login;
        private String nome;
        private String email;
        private String status;


        public String Login
        {
            get { return login; }
            set { login = value; }
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public int TotProducao
        {
            get { return totProducao; }
            set { totProducao = value; }
        }

        public char FlagSenha
        {
            get { return flagSenha; }
            set { flagSenha = value; }
        }

    }
}

