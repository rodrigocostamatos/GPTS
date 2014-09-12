using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TO;
using System.Data.SqlClient;

namespace DAL
{
    public class ClienteDAL
    {
        private static List<ClienteTO> PreencherLista(DataTable dt)
        {
            List<ClienteTO> result = new List<ClienteTO>();
            ClienteTO cliente;
            foreach (DataRow dr in dt.Rows)
            {
                cliente = new ClienteTO();
                cliente.Cnpj = dr["CD_CNPJ"].ToString();
                cliente.Nome = dr["VC_NOME_FANTASIA"].ToString();
                cliente.InscricaoMunicipal = dr["VC_INSCRICAO_MUNICIPAL"].ToString();
                cliente.InscricaoEstadual = dr["VC_INSCRICAO_ESTADUAL"].ToString();
                cliente.RazaoSocial = dr["VC_RAZAO_SOCIAL"].ToString();
                cliente.Site = dr["VC_SITE"].ToString();
                cliente.Telefone = dr["VC_TELEFONE"].ToString();
                cliente.Endereco = dr["VC_ENDERECO"].ToString();
                cliente.Bairro = dr["VC_BAIRRO"].ToString();
                cliente.Cidade = dr["VC_CIDADE"].ToString();
                cliente.Estado = dr["VC_ESTADO"].ToString();
                cliente.Cep = dr["NR_CEP"].ToString();
                cliente.ContatoPrime = dr["VC_CONTATO_PRIME"].ToString();
                cliente.CargoPrime = dr["VC_CARGO_PRIME"].ToString();
                cliente.CargoContato = dr["VC_CARGO_CONTATO"].ToString();
                cliente.TelefonePrime = dr["VC_TELEFONE_PRIME"].ToString();
                cliente.CelularPrime = dr["VC_CELULAR_PRIME"].ToString();
                cliente.EmailPrime = dr["VC_EMAIL_PRIME"].ToString();
                cliente.Contato = dr["VC_CONTATO"].ToString();
                cliente.TelefoneContato = dr["VC_TELEFONE_CONTATO"].ToString();
                cliente.CelularContato = dr["VC_CELULAR_CONTATO"].ToString();
                cliente.EmailContato = dr["VC_EMAIL_CONTATO"].ToString();
                result.Add(cliente);
            }
            return result;
        }

        private static ClienteTO Preencher(DataTable dt)
        {
            ClienteTO cliente = new ClienteTO();
            foreach (DataRow dr in dt.Rows)
            {
                cliente.Cnpj = dr["CD_CNPJ"].ToString();
                cliente.Nome = dr["VC_NOME_FANTASIA"].ToString();
                cliente.InscricaoMunicipal = dr["VC_INSCRICAO_MUNICIPAL"].ToString();
                cliente.InscricaoEstadual = dr["VC_INSCRICAO_ESTADUAL"].ToString();
                cliente.RazaoSocial = dr["VC_RAZAO_SOCIAL"].ToString();
                cliente.Site = dr["VC_SITE"].ToString();
                cliente.Telefone = dr["VC_TELEFONE"].ToString();
                cliente.Endereco = dr["VC_ENDERECO"].ToString();
                cliente.Bairro = dr["VC_BAIRRO"].ToString();
                cliente.Cidade = dr["VC_CIDADE"].ToString();
                cliente.Estado = dr["VC_ESTADO"].ToString();
                cliente.Cep = dr["NR_CEP"].ToString();
                cliente.ContatoPrime = dr["VC_CONTATO_PRIME"].ToString();
                cliente.CargoPrime = dr["VC_CARGO_PRIME"].ToString();
                cliente.CargoContato = dr["VC_CARGO_CONTATO"].ToString();
                cliente.TelefonePrime = dr["VC_TELEFONE_PRIME"].ToString();
                cliente.CelularPrime = dr["VC_CELULAR_PRIME"].ToString();
                cliente.EmailPrime = dr["VC_EMAIL_PRIME"].ToString();
                cliente.Contato = dr["VC_CONTATO"].ToString();
                cliente.TelefoneContato = dr["VC_TELEFONE_CONTATO"].ToString();
                cliente.CelularContato = dr["VC_CELULAR_CONTATO"].ToString();
                cliente.EmailContato = dr["VC_EMAIL_CONTATO"].ToString();
            }
            return cliente;
        }

        public static ClienteTO Obter(String pCnpj)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TB_CLIENTE where CD_CNPJ = @cnpj";
                comando.Parameters.Add(new SqlParameter("cnpj", pCnpj));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return Preencher(resultado);
            }
            finally
            {
                conn.Close();
            }
        }

        public static Boolean VerificarCNPJ(String pCNPJ)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select COUNT(*)  from TB_CLIENTE where CD_CNPJ = @cnpj";
                comando.Parameters.Add(new SqlParameter("cnpj", pCNPJ));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                int qtd = 0;
                foreach (DataRow dr in resultado.Rows)
                {
                    qtd = Convert.ToInt32(dr[0].ToString());
                }
                return qtd > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter o usuário");
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool verifcarClienteContrato(string pCNPJ)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select COUNT(*) from TB_CONTRATO where CD_CNPJ = @cnpj";
                comando.Parameters.Add(new SqlParameter("cnpj", pCNPJ));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                int qtd = 0;
                foreach (DataRow dr in resultado.Rows)
                {
                    qtd = Convert.ToInt32(dr[0].ToString());
                }
                return qtd == 0 ? true : false;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<ClienteTO> ObterTodos()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TB_CLIENTE";
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return PreencherLista(resultado);
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<ClienteTO> ObterTodos(string pNome)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TB_CLIENTE where VC_NOME_FANTASIA like @nome ";
                comando.Parameters.Add(new SqlParameter("nome", "%" + pNome + "%"));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return PreencherLista(resultado);
            }
            finally
            {
                conn.Close();
            }
        }

        public static int Cadastrar(ClienteTO pCliente)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "insert into TB_CLIENTE (CD_CNPJ, VC_RAZAO_SOCIAL, VC_NOME_FANTASIA, VC_INSCRICAO_MUNICIPAL, VC_INSCRICAO_ESTADUAL, VC_ENDERECO, VC_BAIRRO, VC_CIDADE, VC_ESTADO, NR_CEP, VC_TELEFONE, VC_SITE, VC_CONTATO_PRIME, VC_CARGO_PRIME, VC_TELEFONE_PRIME, VC_CELULAR_PRIME, VC_EMAIL_PRIME, VC_CONTATO, VC_CARGO_CONTATO, VC_TELEFONE_CONTATO, VC_CELULAR_CONTATO, VC_EMAIL_CONTATO) values (@cnpj, @razaoSocial, @nomeFantasia, @inscMunicipal, @inscEstadual, @endereco, @bairro, @cidade, @estado, @cep, @telefone, @site, @contatoPrime, @cargoPrime, @telefonePrime, @celularPrime, @eMailPrime, @contato, @cargo, @telefoneContado, @celular, @eMail)";
                comando.Parameters.Add(new SqlParameter("cnpj", pCliente.Cnpj));
                comando.Parameters.Add(new SqlParameter("razaoSocial", pCliente.RazaoSocial));
                comando.Parameters.Add(new SqlParameter("nomeFantasia", pCliente.Nome));
                comando.Parameters.Add(new SqlParameter("inscMunicipal", pCliente.InscricaoMunicipal));
                comando.Parameters.Add(new SqlParameter("inscEstadual", pCliente.InscricaoEstadual));
                comando.Parameters.Add(new SqlParameter("endereco", pCliente.Endereco));
                comando.Parameters.Add(new SqlParameter("bairro", pCliente.Bairro));
                comando.Parameters.Add(new SqlParameter("cidade", pCliente.Cidade));
                comando.Parameters.Add(new SqlParameter("estado", pCliente.Estado));
                comando.Parameters.Add(new SqlParameter("cep", pCliente.Cep));
                comando.Parameters.Add(new SqlParameter("telefone", pCliente.Telefone));
                comando.Parameters.Add(new SqlParameter("site", pCliente.Site));

                comando.Parameters.Add(new SqlParameter("contatoPrime", pCliente.ContatoPrime));
                comando.Parameters.Add(new SqlParameter("cargoPrime", pCliente.CargoPrime));
                comando.Parameters.Add(new SqlParameter("telefonePrime", pCliente.TelefonePrime));
                comando.Parameters.Add(new SqlParameter("celularPrime", pCliente.CelularPrime));
                comando.Parameters.Add(new SqlParameter("eMailPrime", pCliente.EmailPrime));

                comando.Parameters.Add(new SqlParameter("contato", pCliente.Contato));
                comando.Parameters.Add(new SqlParameter("cargo", pCliente.CargoContato));
                comando.Parameters.Add(new SqlParameter("telefoneContado", pCliente.TelefoneContato));
                comando.Parameters.Add(new SqlParameter("celular", pCliente.CelularContato));
                comando.Parameters.Add(new SqlParameter("eMail", pCliente.EmailContato));
                comando.Connection = conn;
                conn.Open();
                return comando.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public static int Alterar(ClienteTO pCliente)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "update TB_CLIENTE set VC_RAZAO_SOCIAL=@razaoSocial, VC_NOME_FANTASIA=@nomeFantasia, VC_INSCRICAO_MUNICIPAL=@inscMunicipal, VC_INSCRICAO_ESTADUAL=@inscEstadual, VC_ENDERECO=@endereco, VC_BAIRRO=@bairro, VC_CIDADE=@cidade, VC_ESTADO=@estado, NR_CEP=@cep, VC_TELEFONE=@telefone, VC_SITE=@site, VC_CONTATO_PRIME=@contatoPrime, VC_CARGO_PRIME=@cargoPrime, VC_TELEFONE_PRIME=@telefonePrime, VC_CELULAR_PRIME=@celularPrime, VC_EMAIL_PRIME=@eMailPrime, VC_CONTATO=@contato, VC_CARGO_CONTATO=@cargo, VC_TELEFONE_CONTATO=@telefoneContado, VC_CELULAR_CONTATO=@celular, VC_EMAIL_CONTATO=@eMail where CD_CNPJ=@cnpj";
                comando.Parameters.Add(new SqlParameter("cnpj", pCliente.Cnpj));
                comando.Parameters.Add(new SqlParameter("razaoSocial", pCliente.RazaoSocial));
                comando.Parameters.Add(new SqlParameter("nomeFantasia", pCliente.Nome));
                comando.Parameters.Add(new SqlParameter("inscMunicipal", pCliente.InscricaoMunicipal));
                comando.Parameters.Add(new SqlParameter("inscEstadual", pCliente.InscricaoEstadual));
                comando.Parameters.Add(new SqlParameter("endereco", pCliente.Endereco));
                comando.Parameters.Add(new SqlParameter("bairro", pCliente.Bairro));
                comando.Parameters.Add(new SqlParameter("cidade", pCliente.Cidade));
                comando.Parameters.Add(new SqlParameter("estado", pCliente.Estado));
                comando.Parameters.Add(new SqlParameter("cep", pCliente.Cep));
                comando.Parameters.Add(new SqlParameter("telefone", pCliente.Telefone));
                comando.Parameters.Add(new SqlParameter("site", pCliente.Site));

                comando.Parameters.Add(new SqlParameter("contatoPrime", pCliente.ContatoPrime));
                comando.Parameters.Add(new SqlParameter("cargoPrime", pCliente.CargoPrime));
                comando.Parameters.Add(new SqlParameter("telefonePrime", pCliente.TelefonePrime));
                comando.Parameters.Add(new SqlParameter("celularPrime", pCliente.CelularPrime));
                comando.Parameters.Add(new SqlParameter("eMailPrime", pCliente.EmailPrime));

                comando.Parameters.Add(new SqlParameter("contato", pCliente.Contato));
                comando.Parameters.Add(new SqlParameter("cargo", pCliente.CargoContato));
                comando.Parameters.Add(new SqlParameter("telefoneContado", pCliente.TelefoneContato));
                comando.Parameters.Add(new SqlParameter("celular", pCliente.CelularContato));
                comando.Parameters.Add(new SqlParameter("eMail", pCliente.EmailContato));
                comando.Connection = conn;
                conn.Open();
                return comando.ExecuteNonQuery();

            }
            finally
            {
                conn.Close();
            }
        }

        public static int Excluir(ClienteTO pCliente)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "delete from TB_CLIENTE where CD_CNPJ = @cnpj";
                comando.Parameters.Add(new SqlParameter("cnpj", pCliente.Cnpj));
                comando.Connection = conn;
                conn.Open();
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao excluir o cliente");
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
