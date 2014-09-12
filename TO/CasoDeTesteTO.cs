using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TO
{
    public class CasoDeTesteTO
    {
        private int id;
        private string letra;
        private int idSubModulo;
        private int idProjeto;
        private int? prioridade;
        private int complexidade;
        private char situacao;
        private int status;
        private int idAnalista;
        private int idTestador;

        private string objetivo;
        private string condicao;
        private string observacao;
        private string entrada;
        private string procedimento;
        private string saida;
        private char casoAutomatico;
        private DateTime dtCadastro;
        private DateTime? dtLiberacao;
        private DateTime? dtDistribuicao;
        private DateTime? dtExecucao;
        private DateTime? dtRetorno;
        private DateTime? dtFatura;
        private DateTime? dtFaturaExecucao;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Letra
        {
            get { return letra; }
            set { letra = value; }
        }

        public int IdSubModulo
        {
            get { return idSubModulo; }
            set { idSubModulo = value; }
        }

        public int IdProjeto
        {
            get { return idProjeto; }
            set { idProjeto = value; }
        }

        public int? Prioridade
        {
            get { return prioridade; }
            set { prioridade = value; }
        }

        public int Complexidade
        {
            get { return complexidade; }
            set { complexidade = value; }
        }

        public char Situacao
        {
            get { return situacao; }
            set { situacao = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public int IdAnalista
        {
            get { return idAnalista; }
            set { idAnalista = value; }
        }

        public int IdTestador
        {
            get { return idTestador; }
            set { idTestador = value; }
        }

        public string Objetivo
        {
            get { return objetivo; }
            set { objetivo = value; }
        }

        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; }
        }

        public string Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }

        public string Entrada
        {
            get { return entrada; }
            set { entrada = value; }
        }

        public string Procedimento
        {
            get { return procedimento; }
            set { procedimento = value; }
        }

        public string Saida
        {
            get { return saida; }
            set { saida = value; }
        }

        public char CasoAutomatico
        {
            get { return casoAutomatico; }
            set { casoAutomatico = value; }
        }

        public DateTime DtCadastro
        {
            get { return dtCadastro; }
            set { dtCadastro = value; }
        }

        public DateTime? DtLiberacao
        {
            get { return dtLiberacao; }
            set { dtLiberacao = value; }
        }

        public DateTime? DtDistribuicao
        {
            get { return dtDistribuicao; }
            set { dtDistribuicao = value; }
        }

        public DateTime? DtExecucao
        {
            get { return dtExecucao; }
            set { dtExecucao = value; }
        }

        public DateTime? DtRetorno
        {
            get { return dtRetorno; }
            set { dtRetorno = value; }
        }

        public DateTime? DtFatura
        {
            get { return dtFatura; }
            set { dtFatura = value; }
        }

        public DateTime? DtFaturaExecucao
        {
            get { return dtFaturaExecucao; }
            set { dtFaturaExecucao = value; }
        }

    }
}
