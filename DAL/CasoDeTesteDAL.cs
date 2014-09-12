using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DAL
{
    public class CasoDeTesteDAL
    {
        private static List<CasoDeTesteTO> PreencherLista(DataTable dt)
        {
            List<CasoDeTesteTO> result = new List<CasoDeTesteTO>();
            CasoDeTesteTO caso;
            foreach (DataRow dr in dt.Rows)
            {
                caso = new CasoDeTesteTO();
                caso.Id = Convert.ToInt32(dr["ID"].ToString());
                caso.IdSubModulo = Convert.ToInt32(dr["ID_SUB_MODULO"].ToString());
                caso.IdProjeto = Convert.ToInt32(dr["ID_PROJETO"].ToString());
                caso.Letra = dr["VC_LETRA_MODULO"].ToString();
                caso.Complexidade = Convert.ToInt32(dr["NR_COMPLEXIDADE"].ToString());
                caso.Status = Convert.ToInt32(dr["NR_STATUS"].ToString());
                caso.CasoAutomatico = Convert.ToChar(dr["ST_CASO_AUTOMATICO"].ToString());
                caso.Situacao = Convert.ToChar(dr["ST_SITUACAO"].ToString());
                caso.Prioridade = Convert.ToInt32(dr["NR_PRIORIDADE"].ToString());
                caso.IdAnalista = Convert.ToInt32(dr["ID_ANALISTA"].ToString());
                caso.IdTestador = Convert.ToInt32(dr["ID_TESTADOR"].ToString());
                caso.Objetivo = dr["VC_OBJETIVO"].ToString();
                caso.Condicao = dr["VC_CONDICAO"].ToString();
                caso.Entrada = dr["VC_ENTRADA"].ToString();
                caso.Procedimento = dr["VC_PROCEDIMENTO"].ToString();
                caso.Saida = dr["VC_SAIDA"].ToString();
                caso.Observacao = dr["VC_OBSERVACAO"].ToString();
                caso.DtCadastro = Convert.ToDateTime(dr["DT_CADASTRO"].ToString());
                caso.DtLiberacao = string.IsNullOrEmpty(dr["DT_LIBERACAO"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_LIBERACAO"].ToString());
                caso.DtDistribuicao = string.IsNullOrEmpty(dr["DT_DISTRIBUICAO"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_DISTRIBUICAO"].ToString());
                caso.DtExecucao = string.IsNullOrEmpty(dr["DT_EXECUCAO"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_EXECUCAO"].ToString()); ;
                caso.DtRetorno = string.IsNullOrEmpty(dr["DT_RETORNO"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_RETORNO"].ToString());
                caso.DtFatura = string.IsNullOrEmpty(dr["DT_FATURA"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_FATURA"].ToString());
                caso.DtFaturaExecucao = string.IsNullOrEmpty(dr["DT_FATURA_EXECUCAO"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_FATURA_EXECUCAO"].ToString());
                result.Add(caso);
            }
            return result;
        }

        private static CasoDeTesteTO Preencher(DataTable dt)
        {
            CasoDeTesteTO caso = new CasoDeTesteTO();
            foreach (DataRow dr in dt.Rows)
            {
                caso.Id = Convert.ToInt32(dr["ID"].ToString());
                caso.IdSubModulo = Convert.ToInt32(dr["ID_SUB_MODULO"].ToString());
                caso.IdProjeto = Convert.ToInt32(dr["ID_PROJETO"].ToString());
                caso.Letra = dr["VC_LETRA_MODULO"].ToString();
                caso.Complexidade = Convert.ToInt32(dr["NR_COMPLEXIDADE"].ToString());
                caso.Status = Convert.ToInt32(dr["NR_STATUS"].ToString());
                caso.CasoAutomatico = Convert.ToChar(dr["ST_CASO_AUTOMATICO"].ToString());
                caso.Situacao = Convert.ToChar(dr["ST_SITUACAO"].ToString());
                caso.Prioridade = Convert.ToInt32(dr["NR_PRIORIDADE"].ToString());
                caso.IdAnalista = Convert.ToInt32(dr["ID_ANALISTA"].ToString());
                caso.IdTestador = Convert.ToInt32(dr["ID_TESTADOR"].ToString());
                caso.Objetivo = dr["VC_OBJETIVO"].ToString();
                caso.Condicao = dr["VC_CONDICAO"].ToString();
                caso.Entrada = dr["VC_ENTRADA"].ToString();
                caso.Procedimento = dr["VC_PROCEDIMENTO"].ToString();
                caso.Saida = dr["VC_SAIDA"].ToString();
                caso.Observacao = dr["VC_OBSERVACAO"].ToString();
                caso.DtCadastro = Convert.ToDateTime(dr["DT_CADASTRO"].ToString());
                caso.DtLiberacao = string.IsNullOrEmpty(dr["DT_LIBERACAO"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_LIBERACAO"].ToString());
                caso.DtDistribuicao = string.IsNullOrEmpty(dr["DT_DISTRIBUICAO"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_DISTRIBUICAO"].ToString());
                caso.DtExecucao = string.IsNullOrEmpty(dr["DT_EXECUCAO"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_EXECUCAO"].ToString()); ;
                caso.DtRetorno = string.IsNullOrEmpty(dr["DT_RETORNO"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_RETORNO"].ToString());
                caso.DtFatura = string.IsNullOrEmpty(dr["DT_FATURA"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_FATURA"].ToString());
                caso.DtFaturaExecucao = string.IsNullOrEmpty(dr["DT_FATURA_EXECUCAO"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_FATURA_EXECUCAO"].ToString());

            }
            return caso;
        }

        public static CasoDeTesteTO Obter(int pId, int pIdSubModulo, int pIdProjeto)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT * FROM TB_CASO_DE_TESTE  WHERE ID = @id and ID_SUB_MODULO = @idSubModulo and ID_PROJETO=@idProjeto";
                comando.Parameters.Add(new SqlParameter("id", pId));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pIdSubModulo));
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
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

        public static List<CasoDeTesteTO> ObterPorSubModuloProjeto(int pIdProjeto, int pIdSubModulo, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT * FROM TB_CASO_DE_TESTE where ID_PROJETO =@idProjeto and ID_SUB_MODULO=@idSubModulo and VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pIdSubModulo));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
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

        public static List<CasoDeTesteTO> ObterTodosPorModuloProjeto(int pIdProjeto, int pIdModulo, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT caso.ID,caso.ID_SUB_MODULO,caso.ID_PROJETO,caso.VC_LETRA_MODULO,caso.NR_PRIORIDADE,caso.NR_COMPLEXIDADE,caso.ST_SITUACAO,caso.NR_STATUS,caso.ID_TESTADOR,caso.ID_ANALISTA,caso.VC_OBJETIVO,caso.VC_CONDICAO,caso.VC_OBSERVACAO,caso.ST_CASO_AUTOMATICO,caso.VC_ENTRADA,caso.VC_PROCEDIMENTO,caso.VC_SAIDA,caso.ID_ESTRATEGIA,caso.DT_CADASTRO,caso.DT_LIBERACAO,caso.DT_DISTRIBUICAO,caso.DT_EXECUCAO,caso.DT_RETORNO,caso.DT_FATURA ,caso.DT_FATURA_EXECUCAO ,caso.VC_ARQUIVO FROM TB_CASO_DE_TESTE caso, TB_MODULO modulo where caso.ID_PROJETO =@idProjeto and caso.ID_SUB_MODULO = modulo.ID and  modulo.ID_MODULO_PAI=@idModulo and caso.VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("idModulo", pIdModulo));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return PreencherLista(resultado);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<CasoDeTesteTO> ObterTodosPorProjeto(int pIdProjeto, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT *  FROM TB_CASO_DE_TESTE where ID_PROJETO =@idProjeto and VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return PreencherLista(resultado);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<CasoDeTesteTO> ObterTodosPorTestador(int pIdTestador, int pStatus, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT * FROM TB_CASO_DE_TESTE where ID_TESTADOR =@idTestador and NR_STATUS=@nrStatus and VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idTestador", pIdTestador));
                comando.Parameters.Add(new SqlParameter("nrStatus", pStatus));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return PreencherLista(resultado);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //Status
        public static List<CasoDeTesteTO> ObterTodosPorProjetoStatus(int pIdProjeto, int pStatus, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT * FROM TB_CASO_DE_TESTE  where ID_PROJETO =@idProjeto and NR_STATUS=@status and NR_COMPLEXIDADE<>0 and NR_PRIORIDADE<>0 and VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return PreencherLista(resultado);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<CasoDeTesteTO> ObterTodosPorProjetoStatusPrioridade(int pIdProjeto, int pStatus, int pPrioridade, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT * FROM TB_CASO_DE_TESTE  where ID_PROJETO =@idProjeto and NR_STATUS=@status and NR_COMPLEXIDADE<>0 and NR_PRIORIDADE=@prioridade and VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("prioridade", pPrioridade));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return PreencherLista(resultado);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<CasoDeTesteTO> ObterTodosPorProjetoStatusComplexidade(int pIdProjeto, int pStatus, int pComplexidade, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT * FROM TB_CASO_DE_TESTE  where ID_PROJETO =@idProjeto and NR_STATUS=@status and NR_COMPLEXIDADE=@complexidade and NR_PRIORIDADE<>0 and VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("complexidade", pComplexidade));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return PreencherLista(resultado);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<CasoDeTesteTO> ObterTodosPorProjetoStatusComplexidadePrioridade(int pIdProjeto, int pStatus, int pComplexidade, int pPrioridade, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT * FROM TB_CASO_DE_TESTE  where ID_PROJETO =@idProjeto and NR_STATUS=@status and NR_COMPLEXIDADE=@complexidade and NR_PRIORIDADE=@prioridade and VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("prioridade", pPrioridade));
                comando.Parameters.Add(new SqlParameter("complexidade", pComplexidade));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                return PreencherLista(resultado);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //---------------------------------------------
        public static List<CasoDeTesteTO> ObterTodosPorModuloProjetoStatus(int pIdProjeto, int pIdModulo, int pStatus, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT caso.ID,caso.ID_SUB_MODULO,caso.VC_LETRA_MODULO,caso.ID_PROJETO ,caso.NR_PRIORIDADE ,caso.NR_COMPLEXIDADE,caso.ST_SITUACAO,caso.NR_STATUS,caso.ID_ANALISTA ,caso.ID_TESTADOR ,caso.VC_OBJETIVO,caso.VC_CONDICAO,caso.VC_OBSERVACAO, caso.VC_OBJETIVO,caso.VC_ENTRADA ,caso.VC_PROCEDIMENTO, caso.VC_SAIDA ,caso.ST_CASO_AUTOMATICO ,caso.DT_CADASTRO,caso.DT_LIBERACAO ,caso.DT_DISTRIBUICAO ,caso.DT_EXECUCAO,caso.DT_RETORNO ,caso.DT_FATURA ,caso.DT_FATURA_EXECUCAO FROM TB_CASO_DE_TESTE caso, TB_MODULO modulo where caso.ID_PROJETO =@idProjeto and caso.ID_SUB_MODULO = modulo.ID and  modulo.ID_MODULO_PAI=@idModulo and caso.NR_STATUS=@status and caso.NR_COMPLEXIDADE<>0 and caso.NR_PRIORIDADE<>0  and  caso.VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("idModulo", pIdModulo));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
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

        public static List<CasoDeTesteTO> ObterTodosPorModuloProjetoStatusPrioridade(int pIdProjeto, int pIdModulo, int pStatus, int pPrioridade, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT caso.ID,caso.ID_SUB_MODULO,caso.VC_LETRA_MODULO,caso.ID_PROJETO ,caso.NR_PRIORIDADE ,caso.NR_COMPLEXIDADE,caso.ST_SITUACAO,caso.NR_STATUS,caso.ID_ANALISTA ,caso.ID_TESTADOR ,caso.VC_OBJETIVO,caso.VC_CONDICAO,caso.VC_OBSERVACAO, caso.VC_OBJETIVO,caso.VC_ENTRADA ,caso.VC_PROCEDIMENTO, caso.VC_SAIDA ,caso.ST_CASO_AUTOMATICO ,caso.DT_CADASTRO,caso.DT_LIBERACAO ,caso.DT_DISTRIBUICAO ,caso.DT_EXECUCAO,caso.DT_RETORNO ,caso.DT_FATURA ,caso.DT_FATURA_EXECUCAO FROM TB_CASO_DE_TESTE caso, TB_MODULO modulo where caso.ID_PROJETO =@idProjeto and caso.ID_SUB_MODULO = modulo.ID and  modulo.ID_MODULO_PAI=@idModulo and caso.NR_STATUS=@status and caso.NR_COMPLEXIDADE<>0 and caso.NR_PRIORIDADE=@prioridade and caso.VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("idModulo", pIdModulo));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("prioridade", pPrioridade));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
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

        public static List<CasoDeTesteTO> ObterTodosPorModuloProjetoStatusComplexidade(int pIdProjeto, int pIdModulo, int pStatus, int pComplexidade, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT caso.ID,caso.ID_SUB_MODULO,caso.ID_PROJETO,caso.VC_LETRA_MODULO,caso.NR_PRIORIDADE ,caso.NR_COMPLEXIDADE,caso.ST_SITUACAO,caso.NR_STATUS,caso.ID_ANALISTA ,caso.ID_TESTADOR ,caso.VC_OBJETIVO,caso.VC_CONDICAO,caso.VC_OBSERVACAO, caso.VC_OBJETIVO,caso.VC_ENTRADA ,caso.VC_PROCEDIMENTO, caso.VC_SAIDA ,caso.ST_CASO_AUTOMATICO ,caso.DT_CADASTRO,caso.DT_LIBERACAO ,caso.DT_DISTRIBUICAO ,caso.DT_EXECUCAO,caso.DT_RETORNO ,caso.DT_FATURA ,caso.DT_FATURA_EXECUCAO FROM TB_CASO_DE_TESTE caso, TB_MODULO modulo where caso.ID_PROJETO =@idProjeto and caso.ID_SUB_MODULO = modulo.ID and  modulo.ID_MODULO_PAI=@idModulo and caso.NR_STATUS=@status and caso.NR_COMPLEXIDADE=@complexidade and  caso.NR_PRIORIDADE<>0  and caso.VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("idModulo", pIdModulo));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("complexidade", pComplexidade));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
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

        public static List<CasoDeTesteTO> ObterTodosPorModuloProjetoStatusComplexidadePrioridade(int pIdProjeto, int pIdModulo, int pStatus, int pComplexidade, int pPrioridade, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT caso.ID,caso.ID_SUB_MODULO,caso.ID_PROJETO,caso.VC_LETRA_MODULO,caso.NR_PRIORIDADE ,caso.NR_COMPLEXIDADE,caso.ST_SITUACAO,caso.NR_STATUS,caso.ID_ANALISTA ,caso.ID_TESTADOR ,caso.VC_OBJETIVO,caso.VC_CONDICAO,caso.VC_OBSERVACAO, caso.VC_OBJETIVO,caso.VC_ENTRADA ,caso.VC_PROCEDIMENTO, caso.VC_SAIDA ,caso.ST_CASO_AUTOMATICO ,caso.DT_CADASTRO,caso.DT_LIBERACAO ,caso.DT_DISTRIBUICAO ,caso.DT_EXECUCAO,caso.DT_RETORNO ,caso.DT_FATURA ,caso.DT_FATURA_EXECUCAO FROM TB_CASO_DE_TESTE caso, TB_MODULO modulo where caso.ID_PROJETO =@idProjeto and caso.ID_SUB_MODULO = modulo.ID and  modulo.ID_MODULO_PAI=@idModulo and caso.NR_STATUS=@status and caso.NR_COMPLEXIDADE=@complexidade and caso.NR_PRIORIDADE=@prioridade and caso.VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("idModulo", pIdModulo));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("prioridade", pPrioridade));
                comando.Parameters.Add(new SqlParameter("complexidade", pComplexidade));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
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

        //---------------------------------------------
        public static List<CasoDeTesteTO> ObterPorSubModuloProjetoStatus(int pIdProjeto, int pIdSubModulo, int pStatus, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = " SELECT  * FROM TB_CASO_DE_TESTE where ID_PROJETO =@idProjeto and ID_SUB_MODULO=@idSubModulo and NR_STATUS=@status and NR_COMPLEXIDADE<>0 and NR_PRIORIDADE<>0 and VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pIdSubModulo));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
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

        public static List<CasoDeTesteTO> ObterPorSubModuloProjetoStatusPrioridade(int pIdProjeto, int pIdSubModulo, int pStatus, int pPrioridade, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = " SELECT  * FROM TB_CASO_DE_TESTE where ID_PROJETO =@idProjeto and ID_SUB_MODULO=@idSubModulo and NR_STATUS=@status and NR_PRIORIDADE=@prioridade and NR_COMPLEXIDADE<>0 and  VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pIdSubModulo));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("prioridade", pPrioridade));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
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

        public static List<CasoDeTesteTO> ObterPorSubModuloProjetoStatusComplexidade(int pIdProjeto, int pIdSubModulo, int pStatus, int pComplexidade, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = " SELECT  * FROM TB_CASO_DE_TESTE where ID_PROJETO =@idProjeto and ID_SUB_MODULO=@idSubModulo and NR_STATUS=@status and NR_COMPLEXIDADE=@complexidade and NR_PRIORIDADE<>0 and VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pIdSubModulo));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("complexidade", pComplexidade));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
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

        public static List<CasoDeTesteTO> ObterPorSubModuloProjetoStatusComplexidadePrioridade(int pIdProjeto, int pIdSubModulo, int pStatus, int pComplexidade, int pPrioridade, string pObjetivo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = " SELECT  * FROM TB_CASO_DE_TESTE where ID_PROJETO =@idProjeto and ID_SUB_MODULO=@idSubModulo and NR_STATUS=@status and NR_COMPLEXIDADE=@complexidade and NR_PRIORIDADE=@prioridade and VC_OBJETIVO like @objetivo";
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pIdSubModulo));
                comando.Parameters.Add(new SqlParameter("status", pStatus));
                comando.Parameters.Add(new SqlParameter("prioridade", pPrioridade));
                comando.Parameters.Add(new SqlParameter("complexidade", pComplexidade));
                comando.Parameters.Add(new SqlParameter("objetivo", "%" + pObjetivo + "%"));
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


        public static void Cadastrar(CasoDeTesteTO pCaso)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "insert into TB_CASO_DE_TESTE (ID ,ID_SUB_MODULO,ID_PROJETO,VC_LETRA_MODULO,NR_PRIORIDADE,NR_COMPLEXIDADE,ST_SITUACAO,NR_STATUS,ID_ANALISTA,VC_OBJETIVO,VC_CONDICAO,VC_OBSERVACAO,ST_CASO_AUTOMATICO,DT_CADASTRO, VC_ENTRADA, VC_PROCEDIMENTO, VC_SAIDA,ID_TESTADOR) values (@id, @idSubModulo,@idProjeto,@letra,@nrPrioridade,@complexidade,@situacao,@status,@idAnalista,@objetivo,@condicao,@observacao,@casoAutomatico,@dtCadastro, @entrada, @procedimento ,@saida,@idTestador)";
                comando.Parameters.Add(new SqlParameter("id", pCaso.Id));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pCaso.IdSubModulo));
                comando.Parameters.Add(new SqlParameter("idProjeto", pCaso.IdProjeto));
                comando.Parameters.Add(new SqlParameter("letra", pCaso.Letra));
                comando.Parameters.Add(new SqlParameter("nrPrioridade", pCaso.Prioridade));
                comando.Parameters.Add(new SqlParameter("complexidade", pCaso.Complexidade));
                comando.Parameters.Add(new SqlParameter("situacao", pCaso.Situacao));
                comando.Parameters.Add(new SqlParameter("status", pCaso.Status));
                comando.Parameters.Add(new SqlParameter("idAnalista", pCaso.IdAnalista));
                comando.Parameters.Add(new SqlParameter("idTestador", pCaso.IdTestador));
                comando.Parameters.Add(new SqlParameter("objetivo", pCaso.Objetivo));
                comando.Parameters.Add(new SqlParameter("condicao", pCaso.Condicao));
                comando.Parameters.Add(new SqlParameter("observacao", pCaso.Observacao));
                comando.Parameters.Add(new SqlParameter("casoAutomatico", pCaso.CasoAutomatico));
                comando.Parameters.Add(new SqlParameter("dtCadastro", DateTime.Now));
                comando.Parameters.Add(new SqlParameter("entrada", pCaso.Entrada));
                comando.Parameters.Add(new SqlParameter("procedimento", pCaso.Procedimento));
                comando.Parameters.Add(new SqlParameter("saida", pCaso.Saida));

                comando.Connection = conn;
                conn.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao cadastrar o caso de teste");
            }
            finally
            {
                conn.Close();
            }
        }

        public static int Alterar(CasoDeTesteTO pCaso)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                SqlDateTime sqldatenull = SqlDateTime.Null;
                comando.CommandText = "update TB_CASO_DE_TESTE set NR_PRIORIDADE=@nrPrioridade,NR_COMPLEXIDADE=@complexidade,ST_SITUACAO=@situacao,NR_STATUS=@status,ID_ANALISTA=@idAnalista,ID_TESTADOR=@idTestador,VC_OBJETIVO=@objetivo,VC_CONDICAO=@condicao,VC_OBSERVACAO=@observacao,ST_CASO_AUTOMATICO=@casoAutomatico,DT_LIBERACAO=@dtLiberacao,DT_DISTRIBUICAO=@dtDistribuicao,DT_EXECUCAO=@dtExecucao,DT_RETORNO=@dtRetorno,DT_FATURA=@dtFatura,DT_FATURA_EXECUCAO=@dtFaturaExecucao, VC_ENTRADA=@entrada, VC_PROCEDIMENTO=@procedimento, VC_SAIDA=@saida where ID=@id and ID_SUB_MODULO=@idSubModulo and ID_PROJETO=@idProjeto ";
                comando.Parameters.Add(new SqlParameter("id", pCaso.Id));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pCaso.IdSubModulo));
                comando.Parameters.Add(new SqlParameter("idProjeto", pCaso.IdProjeto));
                comando.Parameters.Add(new SqlParameter("nrPrioridade", pCaso.Prioridade));
                comando.Parameters.Add(new SqlParameter("complexidade", pCaso.Complexidade));
                comando.Parameters.Add(new SqlParameter("situacao", pCaso.Situacao));
                comando.Parameters.Add(new SqlParameter("status", pCaso.Status));
                comando.Parameters.Add(new SqlParameter("idAnalista", pCaso.IdAnalista));
                comando.Parameters.Add(new SqlParameter("idTestador", pCaso.IdTestador));
                comando.Parameters.Add(new SqlParameter("objetivo", pCaso.Objetivo));
                comando.Parameters.Add(new SqlParameter("condicao", pCaso.Condicao));
                comando.Parameters.Add(new SqlParameter("observacao", pCaso.Observacao));
                comando.Parameters.Add(new SqlParameter("dtCadastro", pCaso.DtCadastro));
                comando.Parameters.Add(new SqlParameter("casoAutomatico", pCaso.CasoAutomatico));
                comando.Parameters.Add(new SqlParameter("entrada", pCaso.Entrada));
                comando.Parameters.Add(new SqlParameter("procedimento", pCaso.Procedimento));
                comando.Parameters.Add(new SqlParameter("saida", pCaso.Saida));
                // Estava dando erro nas datas nulas 
                if (string.IsNullOrEmpty(pCaso.DtLiberacao.ToString()))
                {
                    comando.Parameters.Add(new SqlParameter("dtLiberacao", sqldatenull));
                }
                else
                {
                    comando.Parameters.Add(new SqlParameter("dtLiberacao", pCaso.DtLiberacao));
                }

                if (string.IsNullOrEmpty(pCaso.DtDistribuicao.ToString()))
                {
                    comando.Parameters.Add(new SqlParameter("dtDistribuicao", sqldatenull));
                }
                else
                {
                    comando.Parameters.Add(new SqlParameter("dtDistribuicao", pCaso.DtDistribuicao));
                }

                if (string.IsNullOrEmpty(pCaso.DtExecucao.ToString()))
                {
                    comando.Parameters.Add(new SqlParameter("dtExecucao", sqldatenull));
                }
                else
                {
                    comando.Parameters.Add(new SqlParameter("dtExecucao", pCaso.DtExecucao));
                }

                if (string.IsNullOrEmpty(pCaso.DtRetorno.ToString()))
                {
                    comando.Parameters.Add(new SqlParameter("dtRetorno", sqldatenull));
                }
                else
                {
                    comando.Parameters.Add(new SqlParameter("dtRetorno", pCaso.DtRetorno));
                }

                if (string.IsNullOrEmpty(pCaso.DtFatura.ToString()))
                {
                    comando.Parameters.Add(new SqlParameter("dtFatura", sqldatenull));
                }
                else
                {
                    comando.Parameters.Add(new SqlParameter("dtFatura", pCaso.DtFatura));
                }

                if (string.IsNullOrEmpty(pCaso.DtFaturaExecucao.ToString()))
                {
                    comando.Parameters.Add(new SqlParameter("dtFaturaExecucao", sqldatenull));
                }
                else
                {
                    comando.Parameters.Add(new SqlParameter("dtFaturaExecucao", pCaso.DtFaturaExecucao));
                }



                comando.Connection = conn;
                conn.Open();
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao alterar o caso de teste");
            }
            finally
            {
                conn.Close();
            }
        }

        public static int AlterarStatus(CasoDeTesteTO pCaso, int pStatus)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                SqlDateTime sqldatenull = SqlDateTime.Null;
                comando.CommandText = "update TB_CASO_DE_TESTE set  NR_STATUS=@status where ID=@id and ID_SUB_MODULO=@idSubModulo and ID_PROJETO=@idProjeto ";
                comando.Parameters.Add(new SqlParameter("id", pCaso.Id));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pCaso.IdSubModulo));
                comando.Parameters.Add(new SqlParameter("idProjeto", pCaso.IdProjeto));
                comando.Parameters.Add(new SqlParameter("status", pStatus));

                comando.Connection = conn;
                conn.Open();
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao alterar o status do caso de teste");
            }
            finally
            {
                conn.Close();
            }
        }

        public static int LiberarCasoDeTeste(CasoDeTesteTO pCaso)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                SqlDateTime sqldatenull = SqlDateTime.Null;
                comando.CommandText = "update TB_CASO_DE_TESTE set NR_STATUS=@status, DT_LIBERACAO=@dtLiberacao where ID=@id and ID_SUB_MODULO=@idSubModulo and ID_PROJETO=@idProjeto ";
                comando.Parameters.Add(new SqlParameter("id", pCaso.Id));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pCaso.IdSubModulo));
                comando.Parameters.Add(new SqlParameter("idProjeto", pCaso.IdProjeto));
                comando.Parameters.Add(new SqlParameter("status", pCaso.Status));
                comando.Parameters.Add(new SqlParameter("dtLiberacao", pCaso.DtLiberacao));

                comando.Connection = conn;
                conn.Open();
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao alterar o status do caso de teste");
            }
            finally
            {
                conn.Close();
            }
        }

        public static int DistribuirCasoDeTeste(CasoDeTesteTO pCaso)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                SqlDateTime sqldatenull = SqlDateTime.Null;
                comando.CommandText = "update TB_CASO_DE_TESTE set NR_STATUS=@status, DT_DISTRIBUICAO=@dtDistribuicao, ID_TESTADOR=@idTestador where ID=@id and ID_SUB_MODULO=@idSubModulo and ID_PROJETO=@idProjeto ";
                comando.Parameters.Add(new SqlParameter("id", pCaso.Id));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pCaso.IdSubModulo));
                comando.Parameters.Add(new SqlParameter("idProjeto", pCaso.IdProjeto));
                comando.Parameters.Add(new SqlParameter("status", pCaso.Status));
                comando.Parameters.Add(new SqlParameter("dtDistribuicao", pCaso.DtDistribuicao));
                comando.Parameters.Add(new SqlParameter("idTestador", pCaso.IdTestador));

                comando.Connection = conn;
                conn.Open();
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao alterar o status do caso de teste");
            }
            finally
            {
                conn.Close();
            }
        }

        public static int Excluir(int pID, int pIdSubModulo, int pIdProjeto)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "delete from TB_CASO_DE_TESTE where ID = @id and ID_SUB_MODULO = @idSubModulo and ID_PROJETO = @idProjeto ";
                comando.Parameters.Add(new SqlParameter("id", pID));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pIdSubModulo));
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Connection = conn;
                conn.Open();
                return comando.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Verifica se um sub-modulo possui algum caso de teste cadastrado.
        /// </summary>
        /// <param name="pIdModulo"></param>
        /// <param name="pIdProjeto"></param>
        /// <returns></returns>
        public static bool VerificarCasosPorModulo(int pIdSubModulo, int pIdProjeto)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "select COUNT(*) from TB_CASO_DE_TESTE where ID_SUB_MODULO = @idSubModulo and ID_PROJETO = @idProjeto";
                comando.Parameters.Add(new SqlParameter("idModulo", pIdSubModulo));
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
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
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao excluir o módulo");
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obter proximo id da lista de casos do submodulo projeto
        /// </summary>
        /// <param name="pIdProjeto"></param>
        /// <param name="pIdSubModulo"></param>
        /// <returns></returns>
        public static int ObterProximoID(int pIdSubModulo, int pIdProjeto)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT MAX(ID) FROM TB_CASO_DE_TESTE  WHERE  ID_SUB_MODULO = @idSubModulo and ID_PROJETO=@idProjeto";
                comando.Parameters.Add(new SqlParameter("idSubModulo", pIdSubModulo));
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Connection = conn;
                conn.Open();
                DataTable resultado = new DataTable();
                resultado.Load(comando.ExecuteReader());
                int max = 0;
                foreach (DataRow dr in resultado.Rows)
                {
                    if (string.IsNullOrEmpty(dr[0].ToString()))
                    {
                        max = 1;
                    }
                    else
                    {
                        max = Convert.ToInt32(dr[0].ToString()) + 1;
                    }
                }
                return max;
            }
            finally
            {
                conn.Close();
            }
        }

        public static int AlterarTestador(int pIdCaso, int pIdSubModulo, int pIdProjeto, int pIdTestador)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Conexao.ConnectionString;
            try
            {
                SqlCommand comando = new SqlCommand();
                SqlDateTime sqldatenull = SqlDateTime.Null;
                comando.CommandText = "update TB_CASO_DE_TESTE set  ID_TESTADOR=@testador where ID=@id and ID_SUB_MODULO=@idSubModulo and ID_PROJETO=@idProjeto ";
                comando.Parameters.Add(new SqlParameter("id", pIdCaso));
                comando.Parameters.Add(new SqlParameter("idSubModulo", pIdSubModulo));
                comando.Parameters.Add(new SqlParameter("idProjeto", pIdProjeto));
                comando.Parameters.Add(new SqlParameter("testador", pIdTestador));

                comando.Connection = conn;
                conn.Open();
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao alterar o testador do caso de teste");
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
