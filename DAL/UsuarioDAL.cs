using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuarioDAL
    {
        private static List<UsuarioTO> PreencherLista(DataTable dt)
        {
            List<UsuarioTO> result = new List<UsuarioTO>();
            UsuarioTO usuario;
            foreach (DataRow dr in dt.Rows)
            {
                usuario = new UsuarioTO();
                usuario.Id = Convert.ToInt32(dr["ID"].ToString());
                usuario.Nome = dr["VC_NOME"].ToString();
                usuario.Login = dr["VC_LOGIN"].ToString();
                usuario.Status = dr["ST_STATUS"].ToString();
                usuario.Email = dr["VC_EMAIL"].ToString();
                usuario.TotProducao = Convert.ToInt32(dr["NR_PRODUCAO"].ToString());
                usuario.Tipo = Convert.ToInt32(dr["NR_TIPO_USUARIO"].ToString());
                usuario.FlagSenha = Convert.ToChar(dr["ST_FLAG_SENHA"].ToString());
                result.Add(usuario);
            }
            return result;
        }

        private static UsuarioTO Preencher(DataTable dt)
        {
            UsuarioTO usuario = new UsuarioTO();
            foreach (DataRow dr in dt.Rows)
            {
                usuario.Id = Convert.ToInt32(dr["ID"].ToString());
                usuario.Nome = dr["VC_NOME"].ToString();
                usuario.Login = dr["VC_LOGIN"].ToString();
                usuario.Status = dr["ST_STATUS"].ToString();
                usuario.Email = dr["VC_EMAIL"].ToString();
                usuario.TotProducao = Convert.ToInt32(dr["NR_PRODUCAO"].ToString());
                usuario.Tipo = Convert.ToInt32(dr["NR_TIPO_USUARIO"].ToString());
                usuario.FlagSenha = Convert.ToChar(dr["ST_FLAG_SENHA"].ToString());
            }
            return usuario;
        }

        public static UsuarioTO ObterPorId(int pId)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TB_USUARIO where ID = @id";
                comando.Parameters.Add(new SqlParameter("id", pId));
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

        public static Boolean VerificarLogin(String login)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TB_USUARIO where VC_LOGIN = @login";
                comando.Parameters.Add(new SqlParameter("login", login));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                if (resultado.Rows.Count > 0)
                {
                    return true;
                }
                return false;
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

        public static UsuarioTO ObterPorLogin(String login)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TB_USUARIO where VC_LOGIN = @login";
                comando.Parameters.Add(new SqlParameter("login", login));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return Preencher(resultado);
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

        public static UsuarioTO ObterUsuario(String login, String senha)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TB_USUARIO where VC_LOGIN=@login and PWDCOMPARE( @senha ,VC_SENHA, 0) = 1";
                comando.Parameters.Add(new SqlParameter("login", login));
                comando.Parameters.Add(new SqlParameter("senha", senha));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return Preencher(resultado);
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

        public static List<UsuarioTO> ConsultarTodos()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TB_USUARIO"; ;
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

        public static List<UsuarioTO> ConsultarTodos(string pNome)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TB_USUARIO where VC_NOME like @nome ";
                comando.Parameters.Add(new SqlParameter("nome", pNome + "%"));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return PreencherLista(resultado);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter os usuários");
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<UsuarioTO> ConsultarTodosComTipo(string pNome, int pTipo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TB_USUARIO where NR_TIPO_USUARIO = @tipo and  VC_NOME like @nome ";
                comando.Parameters.Add(new SqlParameter("nome", pNome + "%"));
                comando.Parameters.Add(new SqlParameter("tipo", pTipo));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return PreencherLista(resultado);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter os usuários");
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<UsuarioTO> ConsultarTodosComStatus(string pNome, string pStatus)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TB_USUARIO where VC_NOME like @nome and ST_STATUS = @status";
                comando.Parameters.Add(new SqlParameter("nome", pNome + "%"));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
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

        public static List<UsuarioTO> ConsultarTodosComTipoStatus(string pNome, int pTipo, string pStatus)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select * from TB_USUARIO where NR_TIPO_USUARIO = @tipo and ST_STATUS = @status and VC_NOME like @nome";
                comando.Parameters.Add(new SqlParameter("nome", pNome + "%"));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("tipo", pTipo));
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

        public static List<UsuarioTO> ConsultarTodosComStatusNaoEstaNoProjeto(string pNome, string pStatus, int pIdProjeto)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select distinct uso.ID  ,uso.VC_NOME ,uso.VC_LOGIN  ,uso.VC_SENHA ,uso.NR_TIPO_USUARIO ,uso.NR_PRODUCAO  ,uso.VC_EMAIL  ,uso.ST_STATUS ,uso.ST_FLAG_SENHA  from TB_USUARIO uso  where uso.VC_NOME like @nome and uso.ST_STATUS = @status and uso.ID not in (select ID_USUARIO from TBR_USUARIO_PROJETO where ID_PROJETO=@idProjeto)";
                comando.Parameters.Add(new SqlParameter("nome", pNome + "%"));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
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

        public static List<UsuarioTO> ConsultarUsuariosPorProjeto(int pIdProj, int pTipoUsuario)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT usu.ID,usu.VC_NOME,usu.VC_LOGIN,usu.NR_TIPO_USUARIO,usu.NR_PRODUCAO,usu.VC_EMAIL,usu.ST_STATUS,usu.ST_FLAG_SENHA FROM TB_USUARIO usu, TBR_USUARIO_PROJETO projUso WHERE projUso.ID_PROJETO = @idProjeto AND usu.ID = projUso.ID_USUARIO AND  projUso.NR_FUNCAO =@tipoUsuario";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProj));
                comando.Parameters.Add(new SqlParameter("tipoUsuario", pTipoUsuario));
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

        public static void Cadastrar(UsuarioTO usuario)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "insert into TB_USUARIO (VC_LOGIN, VC_SENHA, VC_NOME, NR_TIPO_USUARIO, NR_PRODUCAO, VC_EMAIL, ST_STATUS, ST_FLAG_SENHA) values (@login, PWDENCRYPT(@senha), @nome, @tipo, @totProducao, @email, @status, 'F')";
                comando.Parameters.Add(new SqlParameter("login", usuario.Login));
                comando.Parameters.Add(new SqlParameter("senha", "123456"));
                comando.Parameters.Add(new SqlParameter("nome", usuario.Nome));
                comando.Parameters.Add(new SqlParameter("tipo", usuario.Tipo));
                comando.Parameters.Add(new SqlParameter("totProducao", '0'));
                comando.Parameters.Add(new SqlParameter("email", usuario.Email));
                comando.Parameters.Add(new SqlParameter("status", 'A'));
                comando.Connection = conn;
                conn.Open();
                comando.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public static int Excluir(int pId)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "delete from TB_USUARIO where ID = @id";
                comando.Parameters.Add(new SqlParameter("id", pId));
                comando.Connection = conn;
                conn.Open();
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao excluir o usuário");
            }
            finally
            {
                conn.Close();
            }
        }

        public static int Alterar(UsuarioTO pUsuario)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "update TB_USUARIO set VC_NOME=@nome, NR_TIPO_USUARIO=@tipo, NR_PRODUCAO=@totProducao, VC_EMAIL=@email, ST_STATUS=@status where ID=@id";
                comando.Parameters.Add(new SqlParameter("id", pUsuario.Id));
                comando.Parameters.Add(new SqlParameter("nome", pUsuario.Nome));
                comando.Parameters.Add(new SqlParameter("tipo", pUsuario.Tipo));
                comando.Parameters.Add(new SqlParameter("totProducao", pUsuario.TotProducao));
                comando.Parameters.Add(new SqlParameter("email", pUsuario.Email));
                comando.Parameters.Add(new SqlParameter("status", pUsuario.Status));
                comando.Connection = conn;
                conn.Open();
                return comando.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public static int AlterarSenha(int pId, string pSenha, char pFlagSenha)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "update TB_USUARIO set VC_SENHA = PWDENCRYPT(@senha) , ST_FLAG_SENHA = @flagCadastro where ID=@id";
                comando.Parameters.Add(new SqlParameter("id", pId));
                comando.Parameters.Add(new SqlParameter("senha", pSenha));
                comando.Parameters.Add(new SqlParameter("flagCadastro", pFlagSenha));
                comando.Connection = conn;
                conn.Open();
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao alterar a senha do usuário");
            }
            finally
            {
                conn.Close();
            }
        }











    }
}
