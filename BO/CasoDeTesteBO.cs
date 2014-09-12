using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;
using DAL;
using System.ComponentModel;
using System.Transactions;
using BO.Constates;

namespace BO
{
    [DataObject]
    public class CasoDeTesteBO
    {
        public static CasoDeTesteTO Obter(int pId, int pIdSubModulo, int pIdProjeto)
        {
            try
            {
                return CasoDeTesteDAL.Obter(pId, pIdSubModulo, pIdProjeto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter o caso de teste");
            }
        }

        public static List<CasoDeTesteTO> ObterPorSubModulo(int pIdProjeto, int pIdModulo, int pIdSubModulo, string pObjetivo)
        {
            try
            {
                if (string.IsNullOrEmpty(pObjetivo))
                {
                    pObjetivo = "";
                }
                if (pIdModulo == 0)
                {
                    return new List<CasoDeTesteTO>();
                }
                if (pIdModulo == -1)
                {
                    return CasoDeTesteDAL.ObterTodosPorProjeto(pIdProjeto, pObjetivo);
                }
                else
                {
                    if (pIdSubModulo == -1)
                    {
                        return CasoDeTesteDAL.ObterTodosPorModuloProjeto(pIdProjeto, pIdModulo, pObjetivo);
                    }
                    else
                    {
                        return CasoDeTesteDAL.ObterPorSubModuloProjeto(pIdProjeto, pIdSubModulo, pObjetivo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter os casos de teste");
            }
        }

        public static List<CasoDeTesteTO> ObterCasosPorStatusSubModulo(int pIdProjeto, int pIdModulo, int pIdSubModulo, int pStatus, string pObjetivo)
        {
            try
            {
                if (string.IsNullOrEmpty(pObjetivo))
                {
                    pObjetivo = "";
                }
                if (pIdModulo == 0)
                {
                    return new List<CasoDeTesteTO>();
                }
                if (pStatus == 0)
                {
                    return new List<CasoDeTesteTO>();
                }
                else
                {
                    if (pIdModulo == -1)
                    {
                        return CasoDeTesteDAL.ObterTodosPorProjetoStatus(pIdProjeto, pStatus, pObjetivo);
                    }
                    else
                    {
                        if (pIdSubModulo == -1)
                        {
                            return CasoDeTesteDAL.ObterTodosPorModuloProjetoStatus(pIdProjeto, pIdModulo, pStatus, pObjetivo);
                        }
                        else
                        {
                            return CasoDeTesteDAL.ObterPorSubModuloProjetoStatus(pIdProjeto, pIdSubModulo, pStatus, pObjetivo);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter os casos de teste");
            }
        }

        public static List<CasoDeTesteTO> ObterCasosPorStatusComplexidadePrioridadeSubModulo(int pIdProjeto, int pIdModulo, int pIdSubModulo, int pStatus, int pComplexidade, int pPrioridade, string pObjetivo)
        {
            try
            {
                if (string.IsNullOrEmpty(pObjetivo))
                {
                    pObjetivo = "";
                }
                if (pIdModulo == 0)
                {
                    return new List<CasoDeTesteTO>();
                }
                if (pStatus == 0)
                {
                    return new List<CasoDeTesteTO>();
                }
                else
                {
                    if (pIdModulo == -1)
                    {
                        if (pComplexidade == 0)
                        {
                            if (pPrioridade == 0)
                            {
                                return CasoDeTesteDAL.ObterTodosPorProjetoStatus(pIdProjeto, pStatus, pObjetivo);
                            }
                            else
                            {
                                return CasoDeTesteDAL.ObterTodosPorProjetoStatusPrioridade(pIdProjeto, pStatus, pPrioridade, pObjetivo);
                            }
                        }
                        else
                        {
                            if (pPrioridade == 0)
                            {
                                return CasoDeTesteDAL.ObterTodosPorProjetoStatusComplexidade(pIdProjeto, pStatus, pComplexidade, pObjetivo);
                            }
                            else
                            {
                                return CasoDeTesteDAL.ObterTodosPorProjetoStatusComplexidadePrioridade(pIdProjeto, pStatus, pComplexidade, pPrioridade, pObjetivo);
                            }
                        }
                    }
                    else
                    {
                        if (pIdSubModulo == -1)
                        {
                            if (pComplexidade == 0)
                            {
                                if (pPrioridade == 0)
                                {
                                    return CasoDeTesteDAL.ObterTodosPorModuloProjetoStatus(pIdProjeto, pIdModulo, pStatus, pObjetivo);
                                }
                                else
                                {
                                    return CasoDeTesteDAL.ObterTodosPorModuloProjetoStatusPrioridade(pIdProjeto, pIdModulo, pStatus, pPrioridade, pObjetivo);
                                }
                            }
                            else
                            {
                                if (pPrioridade == 0)
                                {
                                    return CasoDeTesteDAL.ObterTodosPorModuloProjetoStatusComplexidade(pIdProjeto, pIdModulo, pStatus, pComplexidade, pObjetivo);
                                }
                                else
                                {
                                    return CasoDeTesteDAL.ObterTodosPorModuloProjetoStatusComplexidadePrioridade(pIdProjeto, pIdModulo, pStatus, pComplexidade, pPrioridade, pObjetivo);
                                }
                            }
                        }
                        else
                        {

                            if (pComplexidade == 0)
                            {
                                if (pPrioridade == 0)
                                {
                                    return CasoDeTesteDAL.ObterPorSubModuloProjetoStatus(pIdProjeto, pIdSubModulo, pStatus, pObjetivo);
                                }
                                else
                                {
                                    return CasoDeTesteDAL.ObterPorSubModuloProjetoStatusPrioridade(pIdProjeto, pIdSubModulo, pStatus, pPrioridade, pObjetivo);
                                }
                            }
                            else
                            {
                                if (pPrioridade == 0)
                                {
                                    return CasoDeTesteDAL.ObterPorSubModuloProjetoStatusComplexidade(pIdProjeto, pIdSubModulo, pStatus, pComplexidade, pObjetivo);
                                }
                                else
                                {
                                    return CasoDeTesteDAL.ObterPorSubModuloProjetoStatusComplexidadePrioridade(pIdProjeto, pIdSubModulo, pStatus, pComplexidade, pPrioridade, pObjetivo);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter os casos de teste");
            }
        }

        public static List<CasoDeTesteTO> ObterCasosPorTestador(int pIdTestador, string pObjetivo)
        {
            try
            {
                if (string.IsNullOrEmpty(pObjetivo))
                {
                    pObjetivo = "";
                }
                return CasoDeTesteDAL.ObterTodosPorTestador(pIdTestador, StatusCasoTeste.DISTRIBUIDO , pObjetivo);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter os casos de teste");
            }
        }

        public static void Cadastrar(CasoDeTesteTO pCaso)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    //Calcular Complexidade
                    List<ComplexidadeContratoTO> listComplexidade = ComplexidadeContratoBO.ObterPorProjeto(pCaso.IdProjeto);
                    int nrEntradas = pCaso.Entrada.ToString().Split('\n').Count(i => !string.IsNullOrWhiteSpace(i));
                    int nrProcedimentos = pCaso.Procedimento.ToString().Split('\n').Count(i => !string.IsNullOrWhiteSpace(i));
                    int nrSaidas = pCaso.Saida.ToString().Split('\n').Count(i => !string.IsNullOrWhiteSpace(i));
                    foreach (ComplexidadeContratoTO complexidade in listComplexidade)
                    {
                        pCaso.Complexidade = complexidade.NrTipo;
                        if (nrEntradas <= complexidade.Entradas && nrProcedimentos <= complexidade.Procedimentos && nrSaidas <= complexidade.Saidas)
                        {
                            break;
                        }
                    }

                    pCaso.Id = ObterIdCasoDeTeste(pCaso.IdSubModulo, pCaso.IdProjeto);
                    pCaso.Letra = ModulosProjetoBO.ObterLetraModulo(pCaso.IdSubModulo);
                    CasoDeTesteDAL.Cadastrar(pCaso);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao cadastrar o caso de teste");
            }
        }

        public static void CadastrarImportacao(CasoDeTesteTO pCaso)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    pCaso.Entrada = string.Empty;
                    pCaso.Procedimento = string.Empty;
                    pCaso.Saida = string.Empty;
                    pCaso.Prioridade = 0;

                    pCaso.Id = ObterIdCasoDeTeste(pCaso.IdSubModulo, pCaso.IdProjeto);

                    CasoDeTesteDAL.Cadastrar(pCaso);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao cadastrar o caso de teste");
            }
        }

        private static int ObterIdCasoDeTeste(int pIdSubModulo, int pIdProjeto)
        {
            try
            {
                return CasoDeTesteDAL.ObterProximoID(pIdSubModulo, pIdProjeto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter o identificador do caso de teste");
            }
        }

        public static int Alterar(CasoDeTesteTO pCaso)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    //Calcular Complexidade
                    List<ComplexidadeContratoTO> listComplexidade = ComplexidadeContratoBO.ObterPorProjeto(pCaso.IdProjeto);
                    int nrEntradas = pCaso.Entrada.ToString().Split('\n').Count(i => !string.IsNullOrWhiteSpace(i));
                    int nrProcedimentos = pCaso.Procedimento.ToString().Split('\n').Count(i => !string.IsNullOrWhiteSpace(i));
                    int nrSaidas = pCaso.Saida.ToString().Split('\n').Count(i => !string.IsNullOrWhiteSpace(i));
                    foreach (ComplexidadeContratoTO complexidade in listComplexidade)
                    {
                        pCaso.Complexidade = complexidade.NrTipo;
                        if (nrEntradas <= complexidade.Entradas && nrProcedimentos <= complexidade.Procedimentos && nrSaidas <= complexidade.Saidas)
                        {
                            break;
                        }
                    }
                    int retorno = CasoDeTesteDAL.Alterar(pCaso);
                    scope.Complete();
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao alterar o caso de teste");
            }
        }

        public static int Excluir(CasoDeTesteTO pCaso)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int retorno = CasoDeTesteDAL.Excluir(pCaso.Id, pCaso.IdSubModulo, pCaso.IdProjeto);
                    scope.Complete();
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao remover o caso de teste");
            }
        }

        public static void ImportarCasosDeTeste(List<CasoDeTesteTO> pListCasos, int pIdProjetoDestino, int pIdSubModuloDestino, int pIdAnalista)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    CasoDeTesteTO caso;
                    CasoDeTesteTO novoCaso;
                    foreach (CasoDeTesteTO pCaso in pListCasos)
                    {
                        caso = new CasoDeTesteTO();
                        caso = Obter(pCaso.Id, pCaso.IdSubModulo, pCaso.IdProjeto);
                        novoCaso = new CasoDeTesteTO();
                        novoCaso.Id = ObterIdCasoDeTeste(pIdSubModuloDestino, pIdProjetoDestino);
                        novoCaso.IdSubModulo = pIdSubModuloDestino;
                        novoCaso.Letra = pCaso.Letra;
                        novoCaso.IdProjeto = pIdProjetoDestino;
                        novoCaso.IdAnalista = pIdAnalista;
                        novoCaso.Prioridade = caso.Prioridade;
                        novoCaso.Complexidade = caso.Complexidade;
                        novoCaso.Condicao = caso.Condicao;
                        novoCaso.Objetivo = caso.Objetivo;
                        novoCaso.CasoAutomatico = caso.CasoAutomatico;
                        novoCaso.Status = StatusCasoTeste.CADASTRADO;
                        novoCaso.Entrada = caso.Entrada;
                        novoCaso.Procedimento = caso.Procedimento;
                        novoCaso.Saida = caso.Saida;
                        novoCaso.Observacao = "";
                        CasoDeTesteDAL.Cadastrar(novoCaso);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao importar os casos de teste");
            }
        }

        public static void LiberacaoCasosDeTeste(List<CasoDeTesteTO> pListCasos)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (CasoDeTesteTO pCaso in pListCasos)
                    {
                        pCaso.Status = StatusCasoTeste.LIBERADO;
                        pCaso.DtLiberacao = DateTime.Now;
                        CasoDeTesteDAL.LiberarCasoDeTeste(pCaso);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao liberar os casos de teste");
            }
        }

        public static void DistribuicaoCasosDeTeste(List<CasoDeTesteTO> pListCasos)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (CasoDeTesteTO pCaso in pListCasos)
                    {
                        pCaso.Status = StatusCasoTeste.DISTRIBUIDO;
                        pCaso.DtDistribuicao = DateTime.Now;
                        CasoDeTesteDAL.DistribuirCasoDeTeste(pCaso);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao distribuir os casos de teste");
            }
        }

        public static void AlterarTestador(int pIdCaso, int pIdSubModulo, int pIdProjeto, int pIdTestador)
        {
            try
            {
                CasoDeTesteDAL.AlterarTestador(pIdCaso, pIdSubModulo, pIdProjeto, pIdTestador);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao alterar o testadord do caso de teste");
            }
        }
    }
}
