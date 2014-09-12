using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO.Constates;
using TO;
using BO;
using System.Drawing;
using BO.Constantes;
using AjaxControlToolkit;


namespace Web.Projetos.Testador
{
    public partial class ExecutarCasoDeTestes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;

            if (Session["Usuario"] == null)
            {
                Session["PaginaAnterior"] = "~/Home.aspx";
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                string[] usuario = Session["Usuario"].ToString().Split('|');
                int codigo = Convert.ToInt32(usuario[0]);
                if (usuario[2] != TipoUsuario.TESTADOR.ToString())
                {
                    Response.Redirect("~/AcessoNegado.aspx");
                }
            }
            lblMsg.Text = string.Empty;
        }

        private void MostrarCamposCadastro()
        {
            fvwCaso.Visible = true;
            gvwCaso.Visible = false;
            lblFiltro.Visible = false;
            txtFiltro.Visible = false;
            BtnFiltrar.Visible = false;
            pnlVlTotal.Visible = false;


        }

        private void MostrarCamposConsulta()
        {
            gvwCaso.SelectedIndex = -1;
            gvwCaso.Visible = true;
            fvwCaso.Visible = false;
            lblFiltro.Visible = true;
            txtFiltro.Visible = true;
            BtnFiltrar.Visible = true;
            pnlVlTotal.Visible = true;

        }

        protected void gvwCaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarCamposCadastro();
            fvwCaso.ChangeMode(FormViewMode.Edit);
        }

        protected void gvwCaso_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPrioridade = ((Label)e.Row.FindControl("lblPrioridade"));
                lblPrioridade.Text = Prioridades.ObterPrioridade(Convert.ToInt32(lblPrioridade.Text));

                Label lblComplexidade = ((Label)e.Row.FindControl("lblComplexidade"));
                lblComplexidade.Text = TipoComplexidade.ObterComplexidade(Convert.ToInt32(lblComplexidade.Text));

                Label lblStatus = ((Label)e.Row.FindControl("lblStatus"));
                lblStatus.Text = StatusCasoTeste.ObterStatus(Convert.ToInt32(lblStatus.Text));

            }
        }

        protected void odsFvwCaso_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            //CasoDeTesteTO caso = e.InputParameters[0] as CasoDeTesteTO;
            //if (((CheckBox)fvwCaso.FindControl("cbxCasoAutomatico")).Checked)
            //{
            //    caso.CasoAutomatico = 'S';
            //}
            //else
            //{
            //    caso.CasoAutomatico = 'N';
            //}
            //caso.DtCadastro = Convert.ToDateTime(((TextBox)fvwCaso.FindControl("txtDataCadastro")).Text);
            //caso.Status = StatusCasoTeste.CADASTRADO;
            //string[] usuario = Session["Usuario"].ToString().Split('|');
            //caso.IdAnalista = Convert.ToInt32(usuario[0]);
            //caso.Observacao = "";
        }

        protected void fvwCaso_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            if (e.Exception != null && e.Exception.InnerException is ApplicationException)
            {
                e.ExceptionHandled = true;
                e.KeepInEditMode = true;
                lblMsg.Text = e.Exception.InnerException.Message;
                lblMsg.ForeColor = Color.Red;
            }

        }

        protected void odsFvwCaso_Updated(object sender, ObjectDataSourceStatusEventArgs e)
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
                    //lblMsg.Text = "Caso de teste removido por outro usuário";
                    //lblMsg.ForeColor = Color.Red;
                }
                else
                {
                    //lblMsg.Text = "Caso de teste atualizado com sucesso";
                    //lblMsg.ForeColor = Color.Green;
                }
                MostrarCamposConsulta();
                gvwCaso.DataBind();
            }
        }

        protected void odsFvwCaso_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            int index = gvwCaso.SelectedIndex;
            if (index >= 0)
            {
                e.InputParameters["pId"] = gvwCaso.DataKeys[index][0];
                e.InputParameters["pIdSubModulo"] = gvwCaso.DataKeys[index][1];
                e.InputParameters["pIdProjeto"] = gvwCaso.DataKeys[index][2];
            }
        }

        protected void OdsConsulta_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            string[] usuario = Session["Usuario"].ToString().Split('|');
            e.InputParameters["pIdTestador"] = usuario[0];
        }

        protected void OdsConsulta_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                lblVlTotal.Text = ((List<CasoDeTesteTO>)e.ReturnValue).Count.ToString();
            }
        }

        protected void odsFvwCaso_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            CasoDeTesteTO caso = e.ReturnValue as CasoDeTesteTO;
            if (caso.Prioridade == 0)
            {
                caso.Prioridade = null;
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            fvwCaso.ChangeMode(FormViewMode.ReadOnly);
            MostrarCamposConsulta();
        }

        protected void ddlSubModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
        }

        protected void flpDocumento_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            AsyncFileUpload flp = (AsyncFileUpload)sender;
            Session["ArquivoScript"] = flp.FileBytes;
            Session["NomeArquivoScript"] = flp.FileName;
            ((Label)fvwCaso.FindControl("lblNomeArquivo")).Text = flp.FileName;
        }

        protected void fvwCaso_ModeChanged(object sender, EventArgs e)
        {
            if (fvwCaso.CurrentMode == FormViewMode.Edit)
            {
                Label lbl = ((Label)fvwCaso.FindControl("lblVlProjeto"));
                lbl.Text = lbl.Text + " - " + ProjetoBO.ObterDescricao(Convert.ToInt32(lbl.Text));
            }
        }

        protected void ddlResultado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DropDownList)sender).SelectedValue == "C")
            {
                ((Panel)fvwCaso.FindControl("pnlArquivo")).Visible = true;
                ((Panel)fvwCaso.FindControl("pnlIncidente")).Visible = false;
                ((Panel)fvwCaso.FindControl("pnlRetorno")).Visible = false;
            }
            else if (((DropDownList)sender).SelectedValue == "I")
            {
                ((Panel)fvwCaso.FindControl("pnlArquivo")).Visible = true;
                ((Panel)fvwCaso.FindControl("pnlIncidente")).Visible = true;
                ((Panel)fvwCaso.FindControl("pnlRetorno")).Visible = false;
            }
            else if (((DropDownList)sender).SelectedValue == "R")
            {
                ((Panel)fvwCaso.FindControl("pnlArquivo")).Visible = false;
                ((Panel)fvwCaso.FindControl("pnlIncidente")).Visible = false;
                ((Panel)fvwCaso.FindControl("pnlRetorno")).Visible = true;
            }

        }

         
  
    }
}