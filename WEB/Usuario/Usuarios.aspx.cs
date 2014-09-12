using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO.Constates;
using TO;
using System.Drawing;
using BO;

namespace Web.Cadastros
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == null)
            {
                Session["PaginaAnterior"] = "~/Cadastros/Usuario/Usuarios.aspx";
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
            fvwUsuarios.Visible = true;
            LblTitulo.Text = "Cadastro de Usuário";
            gvwUsuarios.Visible = false;
            txtFiltro.Visible = false;
            BtnFiltrar.Visible = false;
            lblFiltro.Visible = false;
            lblstatus.Visible = false;
            ddlStatus.Visible = false;
        }

        private void MostrarCamposConsulta()
        {
            gvwUsuarios.SelectedIndex = -1;
            gvwUsuarios.Visible = true;
            txtFiltro.Visible = true;
            lblstatus.Visible = true;
            ddlStatus.Visible = true;
            BtnFiltrar.Visible = true;
            lblFiltro.Visible = true;
            LblTitulo.Text = "Usuários";
            fvwUsuarios.Visible = false;
        }

        protected void gvwUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ReiniciarSenha")
            {
                try
                {
                    if (UsuarioBO.ReiniciarSenha(Convert.ToInt32(e.CommandArgument)) > 0)
                    {
                        lblMsg.Text = "Senha reiniciada com sucesso";
                        lblMsg.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblMsg.Text = "O usuário foi removido por outro usuário";
                        lblMsg.ForeColor = Color.Red;
                    }
                    gvwUsuarios.DataBind();
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Falha ao reiniciar a Senha do usuário";
                    lblMsg.ForeColor = Color.Red;
                }

            }
        }

        protected void gvwUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblstatus = ((Label)e.Row.FindControl("lblStatus"));
                if (lblstatus.Text == "A")
                {
                    lblstatus.Text = "Ativo";
                }
                else if (lblstatus.Text == "I")
                {
                    lblstatus.Text = "Inativo";
                }

                Label lbltipo = ((Label)e.Row.FindControl("lblTipo"));
                int tipo = Convert.ToInt32(lbltipo.Text);
                if (tipo == BO.Constates.TipoUsuario.ADMINISTRADOR)
                {
                    lbltipo.Text = "Administrador";
                }
                else if (tipo == BO.Constates.TipoUsuario.ADMINISTRADOR)
                {
                    lbltipo.Text = "Administrador";
                }
                else if (tipo == BO.Constates.TipoUsuario.GERENTE_PROJETO)
                {
                    lbltipo.Text = "Gerente";
                }
                else if (tipo == BO.Constates.TipoUsuario.ANALISTA)
                {
                    lbltipo.Text = "Analista";
                }
                else if (tipo == BO.Constates.TipoUsuario.LIDER)
                {
                    lbltipo.Text = "Lider";
                }
                else if (tipo == BO.Constates.TipoUsuario.CLIENTE)
                {
                    lbltipo.Text = "Cliente";
                }
                else if (tipo == BO.Constates.TipoUsuario.DESENVOLVEDOR)
                {
                    lbltipo.Text = "Desenvolvedor";
                }
                else if (tipo == BO.Constates.TipoUsuario.TESTADOR)
                {
                    lbltipo.Text = "Testador";
                }
                else if (tipo == BO.Constates.TipoUsuario.GERENTE_DESENVOLVEDOR)
                {
                    lbltipo.Text = "Gerente de Desenvolvimento";
                }
                else if (tipo == BO.Constates.TipoUsuario.GERENTE_CONTRATO)
                {
                    lbltipo.Text = "Gerente de Contrato";
                }
            }
        }

        protected void gvwUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarCamposCadastro();
            LblTitulo.Text = "Atualizar Usuário";
            fvwUsuarios.ChangeMode(FormViewMode.Edit);
        }

        protected void BtnCadastrar_Click(object sender, ImageClickEventArgs e)
        {
            MostrarCamposCadastro();
            fvwUsuarios.ChangeMode(FormViewMode.Insert);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            fvwUsuarios.ChangeMode(FormViewMode.ReadOnly);
            MostrarCamposConsulta();

        }

        protected void fvwUsuarios_ItemInserted(object sender, FormViewInsertedEventArgs e)
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
                lblMsg.Text = "Usuário cadastrado com sucesso";
                lblMsg.ForeColor = Color.Green;
                MostrarCamposConsulta();
                gvwUsuarios.DataBind();
            }
        }

        protected void fvwUsuarios_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            if (e.Exception != null && e.Exception.InnerException is ApplicationException)
            {
                e.ExceptionHandled = true;
                e.KeepInEditMode = true;
            }
        }

        protected void OdsFvwUsuario_Updated(object sender, ObjectDataSourceStatusEventArgs e)
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
                    lblMsg.Text = "Usuário removido por outro usuário";
                    lblMsg.ForeColor = Color.Red;
                }
                else
                {
                    lblMsg.Text = "Usuário atualizado com sucesso";
                    lblMsg.ForeColor = Color.Green;
                }
                MostrarCamposConsulta();
                gvwUsuarios.DataBind();
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
                lblMsg.Text = "Usuário removido com sucesso";
                lblMsg.ForeColor = Color.Green;
                MostrarCamposConsulta();
                gvwUsuarios.DataBind();
            }
        }

        protected void cvLogin_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string login = ((TextBox)fvwUsuarios.FindControl("txtLogin")).Text;
            if (UsuarioBO.VerificarLogin(login))
            {
                lblMsg.Text = "Login já cadastrado";
                lblMsg.ForeColor = Color.Red;
                args.IsValid = false;
            }
        }

        protected void fvwUsuarios_PreRender(object sender, EventArgs e)
        {
            if (fvwUsuarios.CurrentMode == FormViewMode.Edit)
            {
                DropDownList ddl = ((DropDownList)fvwUsuarios.FindControl("ddlTipoUsuario"));
                if (ddl.SelectedValue == TipoUsuario.ANALISTA.ToString() || ddl.SelectedValue == TipoUsuario.LIDER.ToString() || ddl.SelectedValue == TipoUsuario.TESTADOR.ToString())
                {
                    ((Panel)fvwUsuarios.FindControl("pnlProducao")).Visible = true;
                }
                else
                {
                    ((Panel)fvwUsuarios.FindControl("pnlProducao")).Visible = false;
                }
            }

        }

      



    }
}