using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using TO;
using System.Data;
using DAL;
using System.Transactions;

namespace BO
{
    [DataObject]
    public class ClienteBO
    {
        public static ClienteTO Obter(String cnpj)
        {
            try
            {
                return ClienteDAL.Obter(cnpj);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter o cliente");
            }
        }

        public static Boolean VerificarCNPJ(String cnpj)
        {
            try
            {
                return ClienteDAL.VerificarCNPJ(cnpj);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao verificar CNPJ");
            }
        }

        public static List<ClienteTO> ObterTodos()
        {
            try
            {
                return ClienteDAL.ObterTodos();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter os clientes");
            }
        }

        public static List<ClienteTO> ObterTodos(string pNome)
        {
            try
            {
                if (pNome == null)
                {
                    pNome = string.Empty;
                }
                return ClienteDAL.ObterTodos(pNome);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao obter os clientes");
            }
        }

        public static int Cadastrar(ClienteTO pCliente)
        {
            try
            {
                return ClienteDAL.Cadastrar(pCliente);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao cadastrar o cliente");
            }
        }

        public static int Alterar(ClienteTO pCliente)
        {
            try
            {
                return ClienteDAL.Alterar(pCliente);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao alterar o cliente");
            }
        }

        public static int Excluir(ClienteTO pCliente)
        {
            try
            {
                if (ClienteDAL.verifcarClienteContrato(pCliente.Cnpj))
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                       int afectedRows = ClienteDAL.Excluir(pCliente);
                        scope.Complete();
                        return afectedRows;
                    }
                }
                else
                {
                    throw new ApplicationException("O cliente não pode ser excluido pois está associado a um contrato");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}
