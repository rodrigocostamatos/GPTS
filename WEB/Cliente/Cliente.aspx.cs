using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO.Constates;
using System.Drawing;
using BO;
using BO.Auxiliar;
using System.Text;

namespace Web.Cadastros.Cliente
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Session["PaginaAnterior"] = "~/Cadastros/Cliente/Cliente.aspx";
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                string[] usuario = Session["Usuario"].ToString().Split('|');
                int codigo = Convert.ToInt32(usuario[0]);
                if (usuario[2] != TipoUsuario.ADMINISTRADOR.ToString())
                {
                    Response.Redirect("~/AcessoNegado.aspx");
                }
            }
            lblMsg.Text = string.Empty;
        }

        private void MostrarCamposCadastro()
        {
            fvwCliente.Visible = true;
            LblTitulo.Text = "Cadastro de Cliente";
            gvwCliente.Visible = false;
            txtFiltro.Visible = false;
            BtnFiltrar.Visible = false;
            lblFiltro.Visible = false;
        }

        private void MostrarCamposConsulta()
        {
            gvwCliente.SelectedIndex = -1;
            gvwCliente.Visible = true;
            txtFiltro.Visible = true;
            BtnFiltrar.Visible = true;
            lblFiltro.Visible = true;
            LblTitulo.Text = "Cliente";
            fvwCliente.Visible = false;
        }

        protected void gvwCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarCamposCadastro();
            LblTitulo.Text = "Atualizar Cliente";
            fvwCliente.ChangeMode(FormViewMode.Edit);
        }

        protected void BtnCadastrar_Click(object sender, ImageClickEventArgs e)
        {
            MostrarCamposCadastro();
            fvwCliente.ChangeMode(FormViewMode.Insert);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            fvwCliente.ChangeMode(FormViewMode.ReadOnly);
            MostrarCamposConsulta();

        }

        protected void fvwCliente_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            if (e.Exception != null && e.Exception.InnerException is ApplicationException)
            {
                e.ExceptionHandled = true;
                e.KeepInInsertMode = true;
                lblMsg.Text = e.Exception.InnerException.Message;
                lblMsg.ForeColor = Color.Red;
            }
            else
            {
                lblMsg.Text = "Cliente cadastrado com sucesso";
                lblMsg.ForeColor = Color.Green;
                MostrarCamposConsulta();
                gvwCliente.DataBind();
            }
        }

        protected void odsFvwCliente_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null && e.Exception.InnerException is ApplicationException)
            {
                e.ExceptionHandled = true;
                lblMsg.Text = e.Exception.InnerException.Message;
                lblMsg.ForeColor = Color.Red;
            }
            else
            {
                if (Convert.ToInt32(e.ReturnValue) < 1)
                {
                    lblMsg.Text = "Cliente removido por outro usuário";
                    lblMsg.ForeColor = Color.Red;
                }
                else
                {
                    lblMsg.Text = "Cliente atualizado com sucesso";
                    lblMsg.ForeColor = Color.Green;
                }
                MostrarCamposConsulta();
                gvwCliente.DataBind();
            }
        }

        protected void fvwCliente_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            if (e.Exception != null && e.Exception.InnerException is ApplicationException)
            {
                e.ExceptionHandled = true;
                e.KeepInEditMode = true;
            }

        }

        protected void OdsConsulta_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null && e.Exception.InnerException is ApplicationException)
            {
                e.ExceptionHandled = true;

                lblMsg.Text = e.Exception.InnerException.Message;
                lblMsg.ForeColor = Color.Red;
            }
            else
            {
                if (Convert.ToInt32(e.ReturnValue) < 1)
                {
                    lblMsg.Text = "Cliente removido por outro usuário";
                    lblMsg.ForeColor = Color.Red;
                }
                else
                {
                    lblMsg.Text = "Cliente removido com sucesso";
                    lblMsg.ForeColor = Color.Green;
                }
                MostrarCamposConsulta();
                gvwCliente.DataBind();
            }
        }

        protected void cvCNPJ_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string cnpj = ((TextBox)fvwCliente.FindControl("txtCnpj")).Text;
            if (ClienteBO.VerificarCNPJ(cnpj))
            {
                lblMsg.Text = "* CNPJ já cadastrado *";
                lblMsg.ForeColor = Color.Red;
                args.IsValid = false;
            }
        }

        protected void txtCnpj_TextChanged(object sender, EventArgs e)
        {
            string cnpj = ((TextBox)sender).Text.ToString();
            if (cnpj.Length < 18)
            {
                cnpj = cnpj.Replace(".", "").Replace(".", " ").Replace("/", "").Replace("-", "");
                ((TextBox)sender).Text = String.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToInt64(cnpj));
            }
        }



    }
}