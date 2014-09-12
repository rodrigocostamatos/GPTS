<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ExecutarCasoDeTestes.aspx.cs" Inherits="Web.Projetos.Testador.ExecutarCasoDeTestes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .table
        {
            width: 100%;
            margin-left: 30px;
        }
        .table popUp
        {
            width: 500px;
        }
        .fv
        {
            width: 700px;
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
    <asp:UpdatePanel ID="Upn" runat="server">
        <ContentTemplate>
            <table class="table">
                <tr>
                    <td align="center">
                        <br />
                        <br />
                        <asp:Label ID="LblTitulo" runat="server" Font-Size="Large" Font-Bold="True" Text="Executar Casos de Teste"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <asp:Panel ID="pnlVlTotal" runat="server">
                    <tr>
                        <td align="left">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label ID="lblFiltro" runat="server" Font-Bold="true" Text="Descrição: " Width="70px"></asp:Label>
                            <asp:TextBox ID="txtFiltro" runat="server" MaxLength="200" Width="196px" onkeyPress="btn_Filtrar_Enter(this, event)"></asp:TextBox>
                            <asp:ImageButton ID="BtnFiltrar" runat="server" Height="20px" ImageUrl="~/Images_btn/Btn_Visualizar.png"
                                Width="20px" ToolTip="Pesquisar" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="fv">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvwCaso" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                CellPadding="4" DataKeyNames="id,idSubModulo,idProjeto" ForeColor="#4B6C9E" GridLines="None"
                                ShowHeaderWhenEmpty="True" Width="90%" OnSelectedIndexChanged="gvwCaso_SelectedIndexChanged"
                                DataSourceID="OdsConsulta" OnRowDataBound="gvwCaso_RowDataBound">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/Images_btn/Btn_Executar.png"
                                                ToolTip="Executar Caso de Teste" Width="16px" Height="16px" CausesValidation="False"
                                                CommandName="select" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# string.Format("{0} - {1}", Eval("letra"),Eval("id")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70px" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Objetivo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblObjetivo" runat="server" Text='<%# Eval("objetivo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prioridade">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrioridade" runat="server" Text='<%# Eval("prioridade") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Complexidade">
                                        <ItemTemplate>
                                            <asp:Label ID="lblComplexidade" runat="server" Text='<%# Eval("complexidade") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Distribuição">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDataDistribuicao" runat="server" Text='<%# Eval("dtDistribuicao",  "{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <EmptyDataTemplate>
                                    <div style="text-align: center;">
                                        <asp:Label ID="lblEmpty" runat="server" Text="Nenhum Caso de Teste Encontrado" Font-Bold="true"
                                            ForeColor="Black"></asp:Label>
                                    </div>
                                </EmptyDataTemplate>
                                <FooterStyle BackColor="#1B4861" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1B4861" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#1B4861" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="OdsConsulta" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="ObterCasosPorTestador" TypeName="BO.CasoDeTesteBO" DataObjectTypeName="TO.CasoDeTesteTO"
                                DeleteMethod="Excluir" OnSelected="OdsConsulta_Selected" OnSelecting="OdsConsulta_Selecting">
                                <SelectParameters>
                                    <asp:Parameter Name="pIdTestador" Type="Int32" />
                                    <asp:ControlParameter ControlID="txtFiltro" Name="pObjetivo" PropertyName="Text"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 80px;">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Text="Total: " Width="50px"></asp:Label>
                            <asp:Label ID="lblVlTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td align="left">
                        <asp:FormView ID="fvwCaso" runat="server" CellPadding="4" ForeColor="#333333" Width="90%"
                            DataKeyNames="id,idSubModulo,idProjeto" Visible="False" OnItemUpdated="fvwCaso_ItemUpdated"
                            DataSourceID="odsFvwCaso" OnModeChanged="fvwCaso_ModeChanged">
                            <EditItemTemplate>
                                <tr>
                                    <td class="fv">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="lblProjeto" runat="server" Text="Projeto:" Font-Bold="true" Width="120px"></asp:Label>
                                        <asp:Label ID="lblVlProjeto" runat="server" Text='<%# Bind("idProjeto") %>'></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="lblCasoDeTeste" runat="server" Text="Nr. Caso de Teste:" Font-Bold="true"
                                            Width="120px"></asp:Label>
                                        <asp:Label ID="lblIdCasoDeTeste" runat="server" Text='<%# string.Format("{0} - {1}", Eval("letra"),Eval("id")) %>'></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="lblObjetivo" runat="server" Text="Objetivo:" Width="120px" Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblVlObjetivo" runat="server" Width="522px" Text='<%# Bind("objetivo") %>'></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="lblCondicao" runat="server" Text="Condição:" Width="120px" Style="vertical-align: top;"
                                            Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblVlCondicao" runat="server" Width="522px" Text='<%# Bind("condicao") %>'
                                            Style="vertical-align: top;"></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv" valign="top">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="lblEntrada" runat="server" Text="Entradas:" Width="120px" Style="vertical-align: top;"
                                            Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblVlEntrada" runat="server" Style="vertical-align: top;" Width="522px"
                                            Text='<%# Bind("entrada") %>'></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv" valign="top">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="lblProcedimento" runat="server" Text="Procedimentos:" Width="120px"
                                            Font-Bold="true" Style="vertical-align: top;"></asp:Label>
                                        <asp:Label ID="lblVlProcedimento" runat="server" Text='<%# Bind("procedimento") %>'
                                            Width="522px" Style="vertical-align: top;"></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv" valign="top">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="lblSaida" runat="server" Text="Saídas:" Width="120px" Style="vertical-align: top;"
                                            Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblVlSaida" runat="server" Text='<%# Bind("saida") %>' Width="522px"
                                            Style="vertical-align: top;"></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv" valign="top">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="lblResultado" runat="server" Text="Resultado:" Width="120px" Style="vertical-align: top;"
                                            Font-Bold="true"></asp:Label>
                                        <asp:DropDownList ID="ddlResultado" runat="server" AutoPostBack="True" Width="150px"
                                            OnSelectedIndexChanged="ddlResultado_SelectedIndexChanged">
                                            <asp:ListItem Value="C" Selected="True">Correto</asp:ListItem>
                                            <asp:ListItem Value="I">Incidente</asp:ListItem>
                                            <asp:ListItem Value="R">Retorno</asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <table class="table">
                                    <asp:Panel ID="pnlArquivo" runat="server">
                                        <tr style="clear: none;">
                                            <td style="clear: none; width: 120px; float: left; margin-left: 25px;">
                                                <asp:Label ID="lblScript" runat="server" Text="Script:" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td style="clear: none; width: 500px; float: left;">
                                                <asp:AsyncFileUpload ID="flpDocumento" runat="server" Width="300px" UploadingBackColor="#CCFFFF"
                                                    OnUploadedComplete="flpDocumento_UploadedComplete" OnClientUploadComplete="UploadComplete"
                                                    ClientIDMode="AutoID" CompleteBackColor="White" />
                                            </td>
                                        </tr>
                                        <asp:Button ID="UP_Btn" runat="server" Text="Updatepanel_Trigger" Style="display: none" />
                                        <tr>
                                            <td style="clear: none; width: 120px; float: left; margin-left: 25px;">
                                            </td>
                                            <td style="clear: none; width: 500px; float: left;">
                                                <asp:Label ID="lblNomeArquivo" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                </table>
                                <asp:Panel ID="pnlIncidente" runat="server" Visible="false">
                                    <tr>
                                        <td class="fv" valign="top">
                                            <br />
                                            <br />
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                            <asp:Label ID="lblIncidente" runat="server" Text="Incidente:" Width="120px" Style="vertical-align: top;"
                                                Font-Bold="true"></asp:Label>
                                            <asp:TextBox ID="txtIncidente" runat="server" Width="522px" Height="120px" TextMode="MultiLine"
                                                Style="resize: none;" onkeyPress="maxlength(this)" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <asp:Panel ID="pnlRetorno" runat="server" Visible="false">
                                    <tr>
                                        <td class="fv" valign="top">
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                            <asp:Label ID="lblRetorno" runat="server" Text="Retorno:" Width="120px" Style="vertical-align: top;"
                                                Font-Bold="true"></asp:Label>
                                            <asp:TextBox ID="txtRetorno" runat="server" Width="522px" Height="120px" TextMode="MultiLine"
                                                Style="resize: none;" onkeyPress="maxlength(this)" />
                                            <br />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </asp:Panel>
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
                                        &nbsp;&nbsp;
                                        <asp:Label ID="lblSalvarEdit" runat="server" Text="Salvar"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblCancelarEdit" runat="server" Text="Cancelar"></asp:Label>
                                    </td>
                                </tr>
                            </EditItemTemplate>
                        </asp:FormView>
                        <asp:ObjectDataSource ID="odsFvwCaso" runat="server" OldValuesParameterFormatString="original_{0}"
                            OnSelected="odsFvwCaso_Selected" OnSelecting="odsFvwCaso_Selecting" SelectMethod="Obter"
                            TypeName="BO.CasoDeTesteBO">
                            <SelectParameters>
                                <asp:Parameter Name="pId" Type="Int32" />
                                <asp:Parameter Name="pIdSubModulo" Type="Int32" />
                                <asp:Parameter Name="pIdProjeto" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <tr>
        <td align="center">
            &nbsp;
            <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" Style="display: none;" />
        </td>
    </tr>
    <script type="text/javascript" language="javascript">
        function maxlength(txt) {
            if (txt.value.length > 1000) {
                txt.value = txt.value.substring(0, 1000)
            }
        }

        function btn_Filtrar_Enter(objTextBox, e) {
            var keyCode;
            //IE ou FIREFOX
            if (!e) var e = window.event
            if (e.keyCode) keyCode = e.keyCode;
            else if (e.which) keyCode = e.which;

            if (keyCode == 13) {
                document.getElementById('<%=this.BtnFiltrar.ClientID%>').focus();
                document.getElementById('<%=this.BtnFiltrar.ClientID%>').click();
            }
        }

        function UploadComplete(sender, args) {
            __doPostBack('UP_Btn', '');
        }
    </script>
</asp:Content>
