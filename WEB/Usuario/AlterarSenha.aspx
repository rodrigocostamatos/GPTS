<%@ Page Title="Alterar_Senha" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AlterarSenha.aspx.cs" Inherits="Web.Cadastros.Usuario.AlterarSenha" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .table
        {
            width: 100%;
            margin-left: 30px;
        }
        .fv
        {
            width: 450px;
        }
        .BackgroundCssClassPopUp
        {
            background-color: #333333;
            filter: alpha(opacity=70);
            opacity: 0.7;
            -moz-opacity: 0.7;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <table class="table">
                <tr>
                    <td align="center">
                        <br />
                        <br />
                        <asp:Label ID="LblTitulo" runat="server" Font-Size="Large" Font-Bold="True" Text="Alterar Senha"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" Width="110px"></asp:Label>
                        <asp:TextBox ID="txtUsuario" runat="server" Enabled="false" Columns="50"></asp:TextBox>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblSenhaAtual" runat="server" Text="Senha Atual:" Width="110px"></asp:Label>
                        <asp:TextBox ID="txtSenhaAtual" runat="server" TextMode="Password" Columns="50" MaxLength="50"></asp:TextBox>
                        &nbsp;*
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ControlToValidate="txtSenhaAtual"
                            Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblSenhaNova" runat="server" Text="Senha Nova:" Width="110px"></asp:Label>
                        <asp:TextBox ID="txtSenhaNova" runat="server" TextMode="Password" Columns="50" MaxLength="50"></asp:TextBox>
                        &nbsp;*
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="rfvSenhaNova" runat="server" ControlToValidate="txtSenhaNova"
                            Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvSenha2" runat="server" ControlToValidate="txtSenhaNova"
                            Text="Escolha uma senha que ainda não tenha sido usada com esta conta" ErrorMessage="Escolha uma senha que ainda não tenha sido usada com esta conta"
                            ForeColor="Red" ToolTip="Escolha uma senha que ainda não tenha sido usada com esta conta"
                            OnServerValidate="cvSenha2_ServerValidate"></asp:CustomValidator>
                        <br />
                    </td>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblSenhaConfirmar" runat="server" Text="Confirmar Senha:" Width="110px"></asp:Label>
                            <asp:TextBox ID="txtSenhaConfirmar" runat="server" TextMode="Password" Columns="50"
                                MaxLength="50"></asp:TextBox>
                            &nbsp;*
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="rfvConfirmarSenha" runat="server" ControlToValidate="txtSenhaConfirmar"
                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvSenha" runat="server" ControlToValidate="txtSenhaConfirmar"
                                ErrorMessage="Senhas não correspondem" ForeColor="Red" ToolTip="Senhas não correspondem"
                                OnServerValidate="cvSenha_ServerValidate"></asp:CustomValidator>
                            <br />
                        </td>
                    </tr>
                </tr>
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="BtnInsert" runat="server" ImageUrl="~/Images_btn/Btn_Confirmar.png"
                            ToolTip="Salvar" OnClick="BtnInsert_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="BtnCancelar" runat="server" ImageUrl="~/Images_btn/Btn_Cancelar.png"
                            CausesValidation="False" OnClick="BtnCancelar_Click" ToolTip="Cancelar" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;&nbsp;
                        <asp:Label ID="lblSalvar" runat="server" Text="Salvar"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblCancelar" runat="server" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lbtGatilho" runat="server"></asp:LinkButton>
                        <asp:ModalPopupExtender ID="mpePopUp" runat="server" TargetControlID="lbtGatilho"
                            BackgroundCssClass="BackgroundCssClassPopUp" PopupControlID="pnlPopUP">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlPopUP" runat="server" BackColor="White" BorderColor="#1B4861" BorderStyle="Solid">
                            <asp:Panel ID="pnlMensagem" runat="server" Width="300px" Height="90px">
                                <table class="style5">
                                    <tr>
                                        <td align="center">
                                            <br />
                                            <asp:Label ID="lblMsgPopUp" runat="server" ForeColor="Green"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="BtnOk" runat="server" OnClick="BtnOk_Click" OnPreRender="BtnOk_PreRender"
                                                Text="Ok" CausesValidation="False" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
