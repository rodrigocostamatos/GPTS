using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TO;
using System.Data;
using System.Data.SqlClient;
using DAL;
using System.ComponentModel;

namespace BO
{
    [DataObject]
    public class UsuarioBO
    {
       
        public static UsuarioTO ObterPorID(int pId)
        {
            try
            {
                return UsuarioDAL.ObterPorId(pId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter o usuário");
            }
        }

        public static bool VerificarLogin(String pLogin)
        {
            try
            {
                return UsuarioDAL.VerificarLogin(pLogin);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao validar o login");
            }
        }

        public static UsuarioTO ObterUsuario(String pLogin, String pSenha)
        {
            try
            {
                return UsuarioDAL.ObterUsuario(pLogin, pSenha);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao validar o usuário");
            }
        }

        public static List<UsuarioTO> ObterTodos()
        {
            try
            {
                return UsuarioDAL.ConsultarTodos();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter os usuários");
            }
        }

        public static List<UsuarioTO> ObterPorLoginTipoStatus(string pNome, int pTipo, string pStatus)
        {
            try
            {
                if (pNome == null)
                {
                    pNome = string.Empty;
                }
                if (!string.IsNullOrEmpty(pStatus))
                {
                    if (pTipo == 0)
                    {
                        return UsuarioDAL.ConsultarTodosComStatus(pNome, pStatus);
                    }
                    else
                    {
                        return UsuarioDAL.ConsultarTodosComTipoStatus(pNome, pTipo , pStatus);
                    }
                }
                else
                {
                    if (pTipo == 0)
                    {
                        return UsuarioDAL.ConsultarTodos(pNome);
                    }
                    else
                    {
                        return UsuarioDAL.ConsultarTodosComTipo(pNome , pTipo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter os usuários");
            }
        }

        public static List<UsuarioTO> ConsultarUsuariosPorProjeto(int pIdProj, int pTipoUsuario)
        {
            try
            {
                return UsuarioDAL.ConsultarUsuariosPorProjeto(pIdProj, pTipoUsuario);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter os analistas");
            }
        }

        public static List<UsuarioTO> ConsultarUsuariosComStatusNaoEstaNoProjeto(string pNome, string pStatus, int pIdProjeto)
        {
            try
            {
                if (pNome == null)
                {
                    pNome = string.Empty;
                }
                return UsuarioDAL.ConsultarTodosComStatusNaoEstaNoProjeto(pNome, pStatus,pIdProjeto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter os usuários");
            }
        }

        public static void Cadastrar(UsuarioTO pUsuario)
        {
            try
            {
                UsuarioDAL.Cadastrar(pUsuario);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao cadastrar o usuário");
            }
        }

        public static int Excluir(UsuarioTO pUsuario)
        {
            try
            {
                if (ProjetoBO.VerificarUsuarioPodeExcluir(pUsuario.Id))
                {
                    return UsuarioDAL.Excluir(pUsuario.Id);
                }
                else
                {
                    throw new ApplicationException("O contrato não pode ser excluido pois está associado a um ou mais projetos");
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public static int Alterar(UsuarioTO pUsuario)
        {
            try
            {
               return UsuarioDAL.Alterar(pUsuario);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao alterar o usuário");
            }
        }

        public static int ReiniciarSenha(int pId)
        {
            try
            {
               return UsuarioDAL.AlterarSenha(pId, "123456", 'F');
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao reinicar a senha do usuário");
            }
        }

        public static void AlterarSenha(string pLogin, string pSenhaAtual, string pSenhaNova)
        {
            try
            {
                UsuarioTO usuario = ObterUsuario(pLogin, pSenhaAtual);
                if (usuario.Id != 0)
                {
                    UsuarioDAL.AlterarSenha(usuario.Id, pSenhaNova, 'V');
                }
                else
                {
                    throw new ApplicationException("Senha atual inválida");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}
