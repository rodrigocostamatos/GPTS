<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Usuarios.aspx.cs" Inherits="Web.Cadastros.Usuarios" %>

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
        .txtFiltro
        {
            margin-left: 4px;
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
                        <asp:Label ID="LblTitulo" runat="server" Font-Size="Large" Font-Bold="True" Text="Usuários"></asp:Label>
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo:" Width="55px"></asp:Label>
                        <asp:DropDownList ID="ddlTipoUsuario" runat="server" Width="155px" AutoPostBack="True">
                            <asp:ListItem Value="0">Selecione</asp:ListItem>
                            <asp:ListItem Value="1">Administrador</asp:ListItem>
                            <asp:ListItem Value="2">Gerente de Projeto</asp:ListItem>
                            <asp:ListItem Value="3">Analista de Teste</asp:ListItem>
                            <asp:ListItem Value="4">Líder de Teste</asp:ListItem>
                            <asp:ListItem Value="5">Cliente</asp:ListItem>
                            <asp:ListItem Value="6">Desenvolvedor</asp:ListItem>
                            <asp:ListItem Value="7">Testador</asp:ListItem>
                            <asp:ListItem Value="8">Gerente de Desenvolvimento</asp:ListItem>
                            <asp:ListItem Value="9">Gerente do Contrato</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblstatus" runat="server" Text="Status:" Width="55px"></asp:Label>
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="155px" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="">Selecione</asp:ListItem>
                            <asp:ListItem Value="A">Ativo</asp:ListItem>
                            <asp:ListItem Value="I">Inativo</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblFiltro" runat="server" Text="Nome:" Width="50px"></asp:Label>
                        <asp:TextBox ID="txtFiltro" runat="server" Width="153px" MaxLength="20" ToolTip="Pesquisar"
                            CssClass="txtFiltro"></asp:TextBox>
                        <asp:ImageButton ID="BtnFiltrar" runat="server" Height="20px" ImageUrl="~/Images_btn/Btn_Visualizar.png"
                            Width="20px" ToolTip="Pesquisar" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvwUsuarios" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CellPadding="4" DataKeyNames="id" ForeColor="#4B6C9E" GridLines="None" ShowHeaderWhenEmpty="True"
                            Width="90%" DataSourceID="OdsConsulta" OnRowDataBound="gvwUsuarios_RowDataBound"
                            OnRowCommand="gvwUsuarios_RowCommand" OnSelectedIndexChanged="gvwUsuarios_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:ImageButton ID="BtnCadastrar" runat="server" ImageUrl="~/Images_btn/Btn_Add.png"
                                            OnClick="BtnCadastrar_Click" ToolTip="Adicionar Usuário" CausesValidation="False" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="BtnAlterar" runat="server" ImageUrl="~/Images_btn/Btn_Edit.ico"
                                            ToolTip="Alterar Usuário" CausesValidation="False" CommandName="select" />
                                        &nbsp;
                                        <asp:ImageButton ID="BtnExcluir" runat="server" CommandName="Delete" ImageUrl="~/Images_btn/Btn_Delete.png"
                                            OnClientClick="return confirm('Deseja realmente excluir o usuário?')" ToolTip="Excluir Usuário"
                                            CausesValidation="False" />
                                        &nbsp;
                                        <asp:ImageButton ID="BtnReinicarSenha" runat="server" ImageUrl="~/Images_btn/Btn_Senha.ico"
                                            OnClientClick="return confirm('Deseja realmente resetar a senha?')" ToolTip="Resetar Senha"
                                            CausesValidation="False" CommandName="ReiniciarSenha" CommandArgument='<%# Eval("id") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Login">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLogin" runat="server" Text='<%# Eval("Login") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nome">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNome" runat="server" Text='<%# Eval("nome") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTipo" runat="server" Text='<%# Eval("tipo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <EmptyDataTemplate>
                                <div style="text-align: center;">
                                    <asp:Label ID="lblEmpty" runat="server" Text="Nenhum Usuário Encontrado" Font-Bold="true"
                                        ForeColor="Black"></asp:Label>
                                </div>
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#1B4861" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1B4861" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#1B4861" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="OdsConsulta" runat="server" DeleteMethod="Excluir" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="ObterPorLoginTipoStatus" TypeName="BO.UsuarioBO" OnDeleted="OdsConsulta_Deleted"
                            DataObjectTypeName="TO.UsuarioTO">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtFiltro" Name="pNome" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="ddlTipoUsuario" Name="pTipo" PropertyName="SelectedValue"
                                    Type="Int32" />
                                <asp:ControlParameter ControlID="ddlStatus" Name="pStatus" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:FormView ID="fvwUsuarios" runat="server" CellPadding="4" ForeColor="#333333"
                            Width="90%" DataKeyNames="id" Visible="False" DataSourceID="OdsFvwUsuario" OnItemInserted="fvwUsuarios_ItemInserted"
                            OnItemUpdated="fvwUsuarios_ItemUpdated" OnPreRender="fvwUsuarios_PreRender">
                            <EditItemTemplate>
                                <table class="table">
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblLogin" runat="server" Text="Login:" Width="55px"></asp:Label>
                                            <asp:TextBox ID="txtLogin" runat="server" Width="300px" MaxLength="20" Text='<%# Bind("Login") %>'
                                                Enabled="false" />
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ControlToValidate="txtLogin"
                                                Display="Dynamic" ErrorMessage="*" ToolTip="Campo Obrigatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblNome" runat="server" Text="Nome:" Width="55px"></asp:Label>
                                            <asp:TextBox ID="txtNome" runat="server" Width="300px" MaxLength="100" Text='<%# Bind("Nome") %>' />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblEmail" runat="server" Text="E-mail:" Width="55px"></asp:Label>
                                            <asp:TextBox ID="txtEmail" runat="server" Width="300px" MaxLength="100" Text='<%# Bind("Email") %>' />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="relEmail" runat="server" ErrorMessage="E-mail inválido"
                                                ToolTip="E-mail inválido" ForeColor="Red" Display="Dynamic" ControlToValidate="txtEmail"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlProducao" runat="server">
                                        <tr>
                                            <td class="fv">
                                                <asp:Label ID="lblTotProducao" runat="server" Text="Produção:" Width="55px"></asp:Label>
                                                <asp:TextBox ID="txtProducao" runat="server" Width="300px" MaxLength="100" Text='<%# Bind("totProducao") %>'
                                                    onkeyup="maskIt(this,event,'#####',true)" />
                                                &nbsp;*
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                                <asp:RequiredFieldValidator ID="rfvProducao" runat="server" ControlToValidate="txtProducao"
                                                    Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                                <br />
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo:" Width="55px"></asp:Label>
                                            <asp:DropDownList ID="ddlTipoUsuario" runat="server" SelectedValue='<%# Bind("tipo") %>'
                                                Width="305px">
                                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                                <asp:ListItem Value="1">Administrador</asp:ListItem>
                                                <asp:ListItem Value="2">Gerente de Projeto</asp:ListItem>
                                                <asp:ListItem Value="3">Analista de Teste</asp:ListItem>
                                                <asp:ListItem Value="4">Líder de Teste</asp:ListItem>
                                                <asp:ListItem Value="5">Cliente</asp:ListItem>
                                                <asp:ListItem Value="5">Desenvolvedor</asp:ListItem>
                                                <asp:ListItem Value="7">Testador</asp:ListItem>
                                                <asp:ListItem Value="8">Gerente de Desenvolvimento</asp:ListItem>
                                                <asp:ListItem Value="9">Gerente do Contrato</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvTipoUsuario" runat="server" ControlToValidate="ddlTipoUsuario"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblStatus" runat="server" Text="Status:" Width="55px"></asp:Label>
                                            <asp:DropDownList ID="ddlStatus" runat="server" SelectedValue='<%# Bind("status") %>'
                                                Width="305px">
                                                <asp:ListItem>Selecione</asp:ListItem>
                                                <asp:ListItem Value="A">Ativo</asp:ListItem>
                                                <asp:ListItem Value="I">Inativo</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlTipoUsuario"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:ImageButton ID="BtnUpdate" runat="server" ImageUrl="~/Images_btn/Btn_Confirmar.png"
                                                CommandName="Update" ToolTip="Salvar" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:ImageButton ID="BtnCancelar" runat="server" ImageUrl="~/Images_btn/Btn_Cancelar.png"
                                                CausesValidation="False" OnClick="BtnCancelar_Click" ToolTip="Cancelar" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            &nbsp;&nbsp
                                            <asp:Label ID="lblSalvarEdit" runat="server" Text="Salvar"></asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblCancelarEdit" runat="server" Text="Cancelar"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <table class="table">
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblLogin" runat="server" Text="Login:" Width="45px"></asp:Label>
                                            <asp:TextBox ID="txtLogin" runat="server" Width="300px" MaxLength="20" Text='<%# Bind("Login") %>' />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ControlToValidate="txtLogin"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="cvLogin" runat="server" ErrorMessage="Login já cadastrado"
                                                ControlToValidate="txtLogin" OnServerValidate="cvLogin_ServerValidate" Display="Dynamic"
                                                ToolTip="Login já cadastrado" ForeColor="Red"></asp:CustomValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblNome" runat="server" Text="Nome:" Width="45px"></asp:Label>
                                            <asp:TextBox ID="txtNome" runat="server" Width="300px" MaxLength="100" Text='<%# Bind("Nome") %>' />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblEmail" runat="server" Text="E-mail:" Width="45px"></asp:Label>
                                            <asp:TextBox ID="txtEmail" runat="server" Width="300px" MaxLength="100" Text='<%# Bind("Email") %>'
                                                ControlToValidate="txtEmail" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="relEmail" runat="server" ErrorMessage="E-mail inválido"
                                                ToolTip="E-mail inválido" ForeColor="Red" Display="Dynamic" ControlToValidate="txtEmail"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo:" Width="45px"></asp:Label>
                                            <asp:DropDownList ID="ddlTipoUsuario" runat="server" SelectedValue='<%# Bind("tipo") %>'
                                                Width="305px">
                                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                                <asp:ListItem Value="1">Administrador</asp:ListItem>
                                                <asp:ListItem Value="2">Gerente de Projeto</asp:ListItem>
                                                <asp:ListItem Value="3">Analista de Teste</asp:ListItem>
                                                <asp:ListItem Value="4">Líder de Teste</asp:ListItem>
                                                <asp:ListItem Value="5">Cliente</asp:ListItem>
                                                <asp:ListItem Value="5">Desenvolvedor</asp:ListItem>
                                                <asp:ListItem Value="7">Testador</asp:ListItem>
                                                <asp:ListItem Value="8">Gerente de Desenvolvimento</asp:ListItem>
                                                <asp:ListItem Value="9">Gerente do Contrato</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvTipoUsuario" runat="server" ControlToValidate="ddlTipoUsuario"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:ImageButton ID="BtnInsert" runat="server" ImageUrl="~/Images_btn/Btn_Confirmar.png"
                                                CommandName="Insert" ToolTip="Salvar" />
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
                                </table>
                            </InsertItemTemplate>
                        </asp:FormView>
                        <asp:ObjectDataSource ID="OdsFvwUsuario" runat="server" DataObjectTypeName="TO.UsuarioTO"
                            InsertMethod="Cadastrar" OldValuesParameterFormatString="original_{0}" SelectMethod="ObterPorID"
                            TypeName="BO.UsuarioBO" UpdateMethod="Alterar" OnUpdated="OdsFvwUsuario_Updated">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="gvwUsuarios" Name="pId" PropertyName="SelectedValue"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript" language="javascript">
        function maskIt(w, e, m, r, a, tipo) {
            // Cancela se o evento for Backspace
            if (!e) var e = window.event
            if (e.keyCode) code = e.keyCode;
            else if (e.which) code = e.which;

            // Variáveis da função
            var txt = (!r) ? w.value.replace(/[^\d]+/gi, '') : w.value.replace(/[^\d]+/gi, '').reverse();
            var mask = (!r) ? m : m.reverse();
            var pre = (a) ? a.pre : "";
            var pos = (a) ? a.pos : "";
            var ret = "";

            if (code == 9 || code == 8 || txt.length == mask.replace(/[^#]+/g, '').length) return false;

            // Loop na máscara para aplicar os caracteres
            for (var x = 0, y = 0, z = mask.length; x < z && y < txt.length; ) {
                if (mask.charAt(x) != '#') {
                    ret += mask.charAt(x); x++;
                } else {
                    ret += txt.charAt(y); y++; x++;
                }
            }

            // Retorno da função
            ret = (!r) ? ret : ret.reverse()
            w.value = pre + ret + pos;
        }
        // Novo método para o objeto 'String'
        String.prototype.reverse = function () {
            return this.split('').reverse().join('');
        };
    </script>
</asp:Content>
