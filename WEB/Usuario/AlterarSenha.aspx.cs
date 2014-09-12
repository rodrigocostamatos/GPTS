using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using BO.Constates;
using BO;
using TO;

namespace Web.Cadastros.Usuario
{
    public partial class AlterarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Session["PaginaAnterior"] = "~/Cadastros/Usuario/AlterarSenha.aspx";
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                string[] usuario = Session["Usuario"].ToString().Split('|');
                txtUsuario.Text = usuario[1];
            }
            lblMsg.Text = string.Empty;
        }

        protected void BtnInsert_Click(object sender, ImageClickEventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                try
                {
                    string[] user = Session["Usuario"].ToString().Split('|');
                    UsuarioBO.AlterarSenha(user[1], txtSenhaAtual.Text, txtSenhaNova.Text);
                    lblMsgPopUp.Text = "Senha alterada com sucesso";
                    mpePopUp.Show();
                }
                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message.ToString();
                    lblMsg.ForeColor = Color.Red;
                }
            }
        }

        protected void BtnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            mpePopUp.Hide();
            Response.Redirect("~/Home.aspx");
        }

        protected void BtnOk_PreRender(object sender, EventArgs e)
        {
            BtnOk.Focus();
        }

        protected void cvSenha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtSenhaNova.Text != txtSenhaConfirmar.Text)
            {
                args.IsValid = false;
                lblMsg.Text = "Senhas não correspondem";
                lblMsg.ForeColor = Color.Red;
            }
        }

        protected void cvSenha2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((txtSenhaNova.Text).Length < 6)
            {
                args.IsValid = false;
                lblMsg.Text = "A senha deve conter, no mínimo, 6 caracteres";
                lblMsg.ForeColor = Color.Red;
            }
            if (txtSenhaNova.Text == txtSenhaAtual.Text)
            {
                args.IsValid = false;
                lblMsg.Text = "Escolha uma senha que ainda não tenha sido usada com esta conta";
                lblMsg.ForeColor = Color.Red;
            }
        }
    }
}