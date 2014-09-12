<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Cliente.aspx.cs" Inherits="Web.Cadastros.Cliente.Cliente" %>

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
                        <asp:Label ID="LblTitulo" runat="server" Font-Size="Large" Font-Bold="True" Text="Clientes"></asp:Label>
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblFiltro" runat="server" Text="Nome: "></asp:Label>
                        <asp:TextBox ID="txtFiltro" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                        <asp:ImageButton ID="BtnFiltrar" runat="server" Height="20px" ImageUrl="~/Images_btn/Btn_Visualizar.png"
                            Width="20px" ToolTip="Pesquisar" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvwCliente" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CellPadding="4" DataKeyNames="cnpj" ForeColor="#4B6C9E" GridLines="None" ShowHeaderWhenEmpty="True"
                            Width="90%" OnSelectedIndexChanged="gvwCliente_SelectedIndexChanged" 
                            DataSourceID="OdsConsulta">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:ImageButton ID="btnCadastrar" runat="server" ImageUrl="~/Images_btn/Btn_Add.png"
                                            OnClick="BtnCadastrar_Click" ToolTip="Adicionar Cliente" CausesValidation="False" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/Images_btn/Btn_Edit.ico"
                                            ToolTip="Alterar Cliente" CausesValidation="False" CommandName="select" />
                                        &nbsp;
                                        <asp:ImageButton ID="btnExcluir" runat="server" CommandName="Delete" ImageUrl="~/Images_btn/Btn_Delete.png"
                                            OnClientClick="return confirm('Deseja realmente excluir o cliente?')" ToolTip="Excluir Cliente"
                                            CausesValidation="False" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CNPJ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcnpj" runat="server" Text='<%# Eval("cnpj") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120px" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Razão Social">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRazaoSocial" runat="server" Text='<%# Eval("razaoSocial") %>'></asp:Label>
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
                                <asp:TemplateField HeaderText="Telefone">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTelefone" runat="server" Text='<%# Eval("telefone") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150px" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <EmptyDataTemplate>
                                <div style="text-align: center;">
                                    <asp:Label ID="lblEmpty" runat="server" Text="Nenhum Cliente Cadastrado" Font-Bold="true"
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
                            SelectMethod="ObterTodos" TypeName="BO.ClienteBO" OnDeleted="OdsConsulta_Deleted"
                            DataObjectTypeName="TO.ClienteTO">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtFiltro" Name="pNome" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:FormView ID="fvwCliente" runat="server" CellPadding="4" ForeColor="#333333"
                            Width="90%" DataKeyNames="cnpj" Visible="False" DataSourceID="odsFvwCliente"
                            OnItemInserted="fvwCliente_ItemInserted" OnItemUpdated="fvwCliente_ItemUpdated">
                            <EditItemTemplate>
                                <table class="table">
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblDadosEmpresa" runat="server" Text="Dados Da Empresa" Font-Bold="true"
                                                Font-Italic="true" Font-Size="Medium"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblContatoContrato" runat="server" Text="Dados do Contato do Contrato"
                                                Font-Bold="true" Font-Italic="true" Font-Size="Medium"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblCNPJ" runat="server" Text="CNPJ:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCnpj" runat="server" Width="300px" MaxLength="18" Text='<%# Eval("cnpj") %>'
                                                Enabled="false" TabIndex="1" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvCnpj" runat="server" ControlToValidate="txtCnpj"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblNomeContrato" runat="server" Text="Nome:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtNomeContrato" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("contatoPrime") %>'
                                                TabIndex="13" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvNomeContato" runat="server" ControlToValidate="txtNomeContrato"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblRazaoSocial" runat="server" Text="Razão Social:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtRazaoSocial" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("razaoSocial") %>'
                                                TabIndex="2" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvRazaoSocial" runat="server" ControlToValidate="txtRazaoSocial"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblCargoContrato" runat="server" Text="Cargo:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCargoContrato" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("cargoPrime") %>'
                                                TabIndex="14" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvCargoContrato" runat="server" ControlToValidate="txtCargoContrato"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblNome" runat="server" Text="Nome Fantasia:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtNome" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("nome") %>'
                                                TabIndex="3" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblTelefoneContrato" runat="server" Text="Telefone:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtTelefoneContrato" runat="server" Width="300px" MaxLength="13"
                                                Text='<%# Bind("telefonePrime") %>' onkeyup="maskIt(this,event,'(##)####-####')"
                                                onBlur="ValidarTelefone(this);" TabIndex="15" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvTelefoneContrato" runat="server" ControlToValidate="txtTelefoneContrato"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblIscMunicipal" runat="server" Text="Inscrição Municipal:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtIscMunicipal" runat="server" Width="300px" MaxLength="20" Text='<%# Bind("inscricaoMunicipal") %>'
                                                TabIndex="4" />
                                            <br />
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblCelularContrato" runat="server" Text="Celular:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCelularContrato" runat="server" Width="300px" MaxLength="13"
                                                Text='<%# Bind("celularPrime") %>' onkeyup="maskIt(this,event,'(##)####-####')"
                                                onBlur="ValidarTelefone(this);" TabIndex="16" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblIscEstadual" runat="server" Text="Inscrição Estadual:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtIscEstadual" runat="server" Width="300px" MaxLength="20" Text='<%# Bind("inscricaoEstadual") %>'
                                                TabIndex="5" />
                                            <br />
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblEmailContrato" runat="server" Text="E-mail:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtEmailContrato" runat="server" Width="300px" MaxLength="100" Text='<%# Bind("emailPrime") %>'
                                                TabIndex="17" />
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RegularExpressionValidator ID="relEmailContrato" runat="server" ErrorMessage="E-mail inválido"
                                                ToolTip="E-mail inválido" ForeColor="Red" Display="Dynamic" ControlToValidate="txtEmailContrato"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblEndereco" runat="server" Text="Endereço:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtEndereco" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("endereco") %>'
                                                TabIndex="6" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvEndereco" runat="server" ControlToValidate="txtEndereco"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblDadosDoContatodaGestao" runat="server" Text="Dados do Contato da Gestão"
                                                Font-Bold="true" Font-Italic="true" Font-Size="Medium"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblBairro" runat="server" Text="Bairro:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtBairro" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("bairro") %>'
                                                TabIndex="7" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvBairro" runat="server" ControlToValidate="txtBairro"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblNomeContato" runat="server" Text="Nome:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtNomeContato" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("contato") %>'
                                                TabIndex="18" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rvftxtNomeContato" runat="server" ControlToValidate="txtNomeContato"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblCidade" runat="server" Text="Cidade:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCidade" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("cidade") %>'
                                                TabIndex="8" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvCidade" runat="server" ControlToValidate="txtCidade"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblCargoContato" runat="server" Text="Cargo:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCargoContato" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("cargoContato") %>'
                                                TabIndex="19" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rvftxtCargoContato" runat="server" ControlToValidate="txtCargoContato"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblEstado" runat="server" Text="Estado:" Width="121px"></asp:Label>
                                            <asp:DropDownList ID="DdlEstado" runat="server" SelectedValue='<%# Bind("estado") %>'
                                                Width="305px" TabIndex="9">
                                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                                <asp:ListItem Value="AC">Acre</asp:ListItem>
                                                <asp:ListItem Value="AL">Alagoas</asp:ListItem>
                                                <asp:ListItem Value="AP">Amapá</asp:ListItem>
                                                <asp:ListItem Value="AM">Amazonas</asp:ListItem>
                                                <asp:ListItem Value="BA">Bahia</asp:ListItem>
                                                <asp:ListItem Value="CE">Ceará</asp:ListItem>
                                                <asp:ListItem Value="DF">Distrito Federal (Brasília)</asp:ListItem>
                                                <asp:ListItem Value="ES">Espírito Santo</asp:ListItem>
                                                <asp:ListItem Value="GO">Goiás</asp:ListItem>
                                                <asp:ListItem Value="MA">Maranhão</asp:ListItem>
                                                <asp:ListItem Value="MT">Mato Grosso</asp:ListItem>
                                                <asp:ListItem Value="MS">Mato Grosso do Sul</asp:ListItem>
                                                <asp:ListItem Value="MG">Minas Gerais</asp:ListItem>
                                                <asp:ListItem Value="PA">Pará</asp:ListItem>
                                                <asp:ListItem Value="PB">Paraíba</asp:ListItem>
                                                <asp:ListItem Value="PR">Paraná</asp:ListItem>
                                                <asp:ListItem Value="PE">Pernambunco</asp:ListItem>
                                                <asp:ListItem Value="PI">Piauí</asp:ListItem>
                                                <asp:ListItem Value="RN">Rio Grande do Norte</asp:ListItem>
                                                <asp:ListItem Value="RS">Rio Grande do Sul</asp:ListItem>
                                                <asp:ListItem Value="RJ">Rio de Janeiro</asp:ListItem>
                                                <asp:ListItem Value="RO">Rondônia</asp:ListItem>
                                                <asp:ListItem Value="RR">Roraima</asp:ListItem>
                                                <asp:ListItem Value="SC">Santa Catarina</asp:ListItem>
                                                <asp:ListItem Value="SP">São Paulo</asp:ListItem>
                                                <asp:ListItem Value="SE">Sergipe</asp:ListItem>
                                                <asp:ListItem Value="TO">Tocantins</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="DdlEstado"
                                                ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblTelefoneContato" runat="server" Text="Telefone:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtTelefoneContato" runat="server" Width="300px" MaxLength="13"
                                                Text='<%# Bind("telefoneContato") %>' onkeyup="maskIt(this,event,'(##)####-####')"
                                                onBlur="ValidarTelefone(this);" TabIndex="20" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rvftxtTelefoneContato" runat="server" ControlToValidate="txtTelefoneContato"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblCEP" runat="server" Text="CEP:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCEP" runat="server" Width="300px" MaxLength="10" Text='<%# Bind("cep") %>'
                                                onkeyup="maskIt(this,event,'##.###-###')" onBlur="ValidarCep(this);" TabIndex="10" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvCEP" runat="server" ControlToValidate="txtCEP"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblCelularContato" runat="server" Text="Celular:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCelularContato" runat="server" Width="300px" MaxLength="13" Text='<%# Bind("celularContato") %>'
                                                onkeyup="maskIt(this,event,'(##)####-####')" onBlur="ValidarTelefone(this);"
                                                TabIndex="21" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblTelefone" runat="server" Text="Telefone:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtTelefone" runat="server" Width="300px" MaxLength="13" Text='<%# Bind("telefone") %>'
                                                onkeyup="maskIt(this,event,'(##)####-####')" onBlur="ValidarTelefone(this);"
                                                TabIndex="11" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvTelefone" runat="server" ControlToValidate="txtTelefone"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblEmailContato" runat="server" Text="E-mail:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtEmailContato" runat="server" Width="300px" MaxLength="100" Text='<%# Bind("emailContato") %>'
                                                TabIndex="22" />
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RegularExpressionValidator ID="relEmailContato" runat="server" ErrorMessage="E-mail inválido"
                                                ToolTip="E-mail inválido" ForeColor="Red" Display="Dynamic" ControlToValidate="txtEmailContato"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblSite" runat="server" Text="Site:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtSite" runat="server" Width="300px" MaxLength="100" Text='<%# Bind("site") %>'
                                                TabIndex="12" />
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RegularExpressionValidator ID="revSite" runat="server" ControlToValidate="txtSite"
                                                Display="Dynamic" ErrorMessage="Site inválido" ToolTip="Site inválido" ForeColor="Red"
                                                ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <table class="table">
                                    <tr>
                                        <td align="center">
                                            <br />
                                            <br />
                                            <asp:ImageButton ID="BtnInsert" runat="server" ImageUrl="~/Images_btn/Btn_Confirmar.png"
                                                CommandName="Update" ToolTip="Salvar" TabIndex="23" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:ImageButton ID="BtnCancelar" runat="server" ImageUrl="~/Images_btn/Btn_Cancelar.png"
                                                CausesValidation="False" OnClick="BtnCancelar_Click" ToolTip="Cancelar" TabIndex="24" />
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
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <table class="table">
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblDadosEmpresa" runat="server" Text="Dados Da Empresa" Font-Bold="true"
                                                Font-Italic="true" Font-Size="Medium"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblContatoContrato" runat="server" Text="Dados do Contato do Contrato"
                                                Font-Bold="true" Font-Italic="true" Font-Size="Medium"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblCNPJ" runat="server" Text="CNPJ:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCnpj" runat="server" Width="300px" MaxLength="18" Text='<%# Bind("cnpj") %>'
                                                onkeyup="maskIt(this,event,'##.###.###/####-##')" onBlur="ValidarCNPJ(this);"
                                                TabIndex="1" AutoPostBack="True" OnTextChanged="txtCnpj_TextChanged" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvCnpj" runat="server" ControlToValidate="txtCnpj"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="cvCNPJ" runat="server" ErrorMessage="CNPJ já cadastrado"
                                                ControlToValidate="txtCnpj" Display="Dynamic" ToolTip="CNPJ já cadastrado" ForeColor="Red"
                                                OnServerValidate="cvCNPJ_ServerValidate"></asp:CustomValidator>
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblNomeContrato" runat="server" Text="Nome:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtNomeContrato" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("contatoPrime") %>'
                                                TabIndex="13" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvNomeContato" runat="server" ControlToValidate="txtNomeContrato"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblRazaoSocial" runat="server" Text="Razão Social:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtRazaoSocial" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("razaoSocial") %>'
                                                TabIndex="2" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRazaoSocial"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblCargoContrato" runat="server" Text="Cargo:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCargoContrato" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("cargoPrime") %>'
                                                TabIndex="14" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvCargoContrato" runat="server" ControlToValidate="txtCargoContrato"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblNome" runat="server" Text="Nome Fantasia:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtNome" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("nome") %>'
                                                TabIndex="3" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblTelefoneContrato" runat="server" Text="Telefone:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtTelefoneContrato" runat="server" Width="300px" MaxLength="13"
                                                Text='<%# Bind("telefonePrime") %>' onkeyup="maskIt(this,event,'(##)####-####')"
                                                onBlur="ValidarTelefone(this);" TabIndex="15" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvTelefoneContrato" runat="server" ControlToValidate="txtTelefoneContrato"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblIscMunicipal" runat="server" Text="Inscrição Municipal:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtIscMunicipal" runat="server" Width="300px" MaxLength="20" Text='<%# Bind("inscricaoMunicipal") %>'
                                                TabIndex="4" />
                                            <br />
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblCelularContrato" runat="server" Text="Celular:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCelularContrato" runat="server" Width="300px" MaxLength="13"
                                                Text='<%# Bind("celularPrime") %>' onkeyup="maskIt(this,event,'(##)####-####')"
                                                onBlur="ValidarTelefone(this);" TabIndex="16" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblIscEstadual" runat="server" Text="Inscrição Estadual:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtIscEstadual" runat="server" Width="300px" MaxLength="20" Text='<%# Bind("inscricaoEstadual") %>'
                                                TabIndex="5" />
                                            <br />
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblEmailContrato" runat="server" Text="E-mail:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtEmailContrato" runat="server" Width="300px" MaxLength="100" Text='<%# Bind("emailPrime") %>'
                                                TabIndex="17" />
                                            <asp:RegularExpressionValidator ID="relEmailContrato" runat="server" ErrorMessage="*"
                                                ToolTip="E-mail inválido" ForeColor="Red" Display="Dynamic" ControlToValidate="txtEmailContrato"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblEndereco" runat="server" Text="Endereço:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtEndereco" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("endereco") %>'
                                                TabIndex="6" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvEndereco" runat="server" ControlToValidate="txtEndereco"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblDadosDoContatodaGestao" runat="server" Text="Dados do Contato da Gestão"
                                                Font-Bold="true" Font-Italic="true" Font-Size="Medium"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblBairro" runat="server" Text="Bairro:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtBairro" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("bairro") %>'
                                                TabIndex="7" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvBairro" runat="server" ControlToValidate="txtBairro"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblNomeContato" runat="server" Text="Nome:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtNomeContato" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("contato") %>'
                                                TabIndex="18" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rvftxtNomeContato" runat="server" ControlToValidate="txtNomeContato"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblCidade" runat="server" Text="Cidade:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCidade" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("cidade") %>'
                                                TabIndex="8" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvCidade" runat="server" ControlToValidate="txtCidade"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblCargoContato" runat="server" Text="Cargo:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCargoContato" runat="server" Width="300px" MaxLength="50" Text='<%# Bind("cargoContato") %>'
                                                TabIndex="19" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rvftxtCargoContato" runat="server" ControlToValidate="txtCargoContato"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblEstado" runat="server" Text="Estado:" Width="121px"></asp:Label>
                                            <asp:DropDownList ID="DdlEstado" runat="server" SelectedValue='<%# Bind("estado") %>'
                                                Width="305px" TabIndex="9">
                                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                                <asp:ListItem Value="AC">Acre</asp:ListItem>
                                                <asp:ListItem Value="AL">Alagoas</asp:ListItem>
                                                <asp:ListItem Value="AP">Amapá</asp:ListItem>
                                                <asp:ListItem Value="AM">Amazonas</asp:ListItem>
                                                <asp:ListItem Value="BA">Bahia</asp:ListItem>
                                                <asp:ListItem Value="CE">Ceará</asp:ListItem>
                                                <asp:ListItem Value="DF">Distrito Federal (Brasília)</asp:ListItem>
                                                <asp:ListItem Value="ES">Espírito Santo</asp:ListItem>
                                                <asp:ListItem Value="GO">Goiás</asp:ListItem>
                                                <asp:ListItem Value="MA">Maranhão</asp:ListItem>
                                                <asp:ListItem Value="MT">Mato Grosso</asp:ListItem>
                                                <asp:ListItem Value="MS">Mato Grosso do Sul</asp:ListItem>
                                                <asp:ListItem Value="MG">Minas Gerais</asp:ListItem>
                                                <asp:ListItem Value="PA">Pará</asp:ListItem>
                                                <asp:ListItem Value="PB">Paraíba</asp:ListItem>
                                                <asp:ListItem Value="PR">Paraná</asp:ListItem>
                                                <asp:ListItem Value="PE">Pernambunco</asp:ListItem>
                                                <asp:ListItem Value="PI">Piauí</asp:ListItem>
                                                <asp:ListItem Value="RN">Rio Grande do Norte</asp:ListItem>
                                                <asp:ListItem Value="RS">Rio Grande do Sul</asp:ListItem>
                                                <asp:ListItem Value="RJ">Rio de Janeiro</asp:ListItem>
                                                <asp:ListItem Value="RO">Rondônia</asp:ListItem>
                                                <asp:ListItem Value="RR">Roraima</asp:ListItem>
                                                <asp:ListItem Value="SC">Santa Catarina</asp:ListItem>
                                                <asp:ListItem Value="SP">São Paulo</asp:ListItem>
                                                <asp:ListItem Value="SE">Sergipe</asp:ListItem>
                                                <asp:ListItem Value="TO">Tocantins</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="DdlEstado"
                                                ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblTelefoneContato" runat="server" Text="Telefone:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtTelefoneContato" runat="server" Width="300px" MaxLength="13"
                                                Text='<%# Bind("telefoneContato") %>' onkeyup="maskIt(this,event,'(##)####-####')"
                                                onBlur="ValidarTelefone(this);" TabIndex="20" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rvftxtTelefoneContato" runat="server" ControlToValidate="txtTelefoneContato"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblCEP" runat="server" Text="CEP:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCEP" runat="server" Width="300px" MaxLength="10" Text='<%# Bind("cep") %>'
                                                onkeyup="maskIt(this,event,'##.###-###')" onBlur="ValidarCep(this);" TabIndex="10" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvCEP" runat="server" ControlToValidate="txtCEP"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblCelularContato" runat="server" Text="Celular:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtCelularContato" runat="server" Width="300px" MaxLength="13" Text='<%# Bind("celularContato") %>'
                                                onkeyup="maskIt(this,event,'(##)####-####')" onBlur="ValidarTelefone(this);"
                                                TabIndex="21" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblTelefone" runat="server" Text="Telefone:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtTelefone" runat="server" Width="300px" MaxLength="13" Text='<%# Bind("telefone") %>'
                                                onkeyup="maskIt(this,event,'(##)####-####')" onBlur="ValidarTelefone(this);"
                                                TabIndex="11" />
                                            &nbsp;*
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvTelefone" runat="server" ControlToValidate="txtTelefone"
                                                Display="Dynamic" ErrorMessage="Campo Obrigatorio" ToolTip="Campo Obrigatorio"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />
                                            <br />
                                        </td>
                                        <td class="fv">
                                            <asp:Label ID="lblEmailContato" runat="server" Text="E-mail:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtEmailContato" runat="server" Width="300px" MaxLength="100" Text='<%# Bind("emailContato") %>'
                                                TabIndex="22" />
                                            <asp:RegularExpressionValidator ID="relEmailContato" runat="server" ErrorMessage="*"
                                                ToolTip="E-mail inválido" ForeColor="Red" Display="Dynamic" ControlToValidate="txtEmailContato"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fv">
                                            <asp:Label ID="lblSite" runat="server" Text="Site:" Width="120px"></asp:Label>
                                            <asp:TextBox ID="txtSite" runat="server" Width="300px" MaxLength="100" Text='<%# Bind("site") %>'
                                                TabIndex="12" />
                                            &nbsp;
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            <asp:RegularExpressionValidator ID="revSite" runat="server" ControlToValidate="txtSite"
                                                Display="Dynamic" ToolTip="Site inválido" ForeColor="Red" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                                                ErrorMessage="Site inválido"></asp:RegularExpressionValidator>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <table class="table">
                                    <tr>
                                        <td align="center">
                                            <br />
                                            <br />
                                            <asp:ImageButton ID="BtnInsert" runat="server" ImageUrl="~/Images_btn/Btn_Confirmar.png"
                                                CommandName="Insert" ToolTip="Salvar" TabIndex="23" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:ImageButton ID="BtnCancelar" runat="server" ImageUrl="~/Images_btn/Btn_Cancelar.png"
                                                CausesValidation="False" OnClick="BtnCancelar_Click" ToolTip="Cancelar" TabIndex="24" />
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
                        <asp:ObjectDataSource ID="odsFvwCliente" runat="server" DataObjectTypeName="TO.ClienteTO"
                            InsertMethod="Cadastrar" OldValuesParameterFormatString="original_{0}" SelectMethod="Obter"
                            TypeName="BO.ClienteBO" UpdateMethod="Alterar" 
                            onupdated="odsFvwCliente_Updated">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="gvwCliente" Name="cnpj" PropertyName="SelectedValue"
                                    Type="String" />
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

        //valida o CNPJ digitado
        function ValidarCNPJ(ObjCnpj) {
            if (ObjCnpj.value.length > 0) {
                var cnpj = ObjCnpj.value;
                var valida = new Array(6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2);
                var dig1 = new Number;
                var dig2 = new Number;

                exp = /\.|\-|\//g
                cnpj = cnpj.toString().replace(exp, "");
                var digito = new Number(eval(cnpj.charAt(12) + cnpj.charAt(13)));

                for (i = 0; i < valida.length; i++) {
                    dig1 += (i > 0 ? (cnpj.charAt(i - 1) * valida[i]) : 0);
                    dig2 += cnpj.charAt(i) * valida[i];
                }
                dig1 = (((dig1 % 11) < 2) ? 0 : (11 - (dig1 % 11)));
                dig2 = (((dig2 % 11) < 2) ? 0 : (11 - (dig2 % 11)));

                if (((dig1 * 10) + dig2) != digito) {
                    alert('CNPJ Invalido!');
                    ObjCnpj.value = "";
                    ObjCnpj.focus();
                }

                if (cnpj == '00000000000000') {
                    alert('CNPJ Invalido!');
                    ObjCnpj.value = "";
                    ObjCnpj.focus();
                }

                maskIt(ObjCnpj, event, '##.###.###/####-##');
            }
        }
        //valida telefone
        function ValidarTelefone(tel) {
            if (tel.value.length > 0) {
                exp = /\(\d{2}\)\d{4}\-\d{4}/
                if (!exp.test(tel.value)) {
                    alert('Numero de Telefone inválido');
                    tel.value = "";
                    tel.focus();
                }
            }
        }
        function ValidarCep(cep) {
            if (cep.value.length > 0) {
                exp = /\d{2}\.\d{3}\-\d{3}/
                if (!exp.test(cep.value)) {
                    alert('Numero de Cep inválido');
                    cep.value = "";
                    cep.focus();
                }
            }
        }

    </script>
</asp:Content>
