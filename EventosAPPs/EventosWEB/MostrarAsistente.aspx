﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MostrarAsistente.aspx.cs" Inherits="EventosWEB.MostrarAsistente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
            <div class="col-lg-6 mx-auto">
                <asp:DropDownList ID="estadoDDL" runat="server" Enabled="false" AutoPostBack="true" >
                    <asp:ListItem Text="Pagada" Value="Pagada"></asp:ListItem>
                    <asp:ListItem Text="Con Deuda" Value="conDeuda"></asp:ListItem>
                </asp:DropDownList>
               <asp:CheckBox runat="server" ID="todosChk" Text="Todos" Checked="true" 
                   AutoPostBack="true" />
 
            </div>
               <div class="row mt-5">
                    <asp:GridView 
                        CssClass="table table-hover table-bordered"
                        ID="grillaAsistente"
                        AutoGenerateColumns="false"
                        ShowHeaderWhenEmpty="true"
                        EmptyDataText="No hay registros"
                        runat="server">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                            <asp:BoundField HeaderText="Empresa" DataField="Empresa" />
                            <asp:BoundField HeaderText="Region" DataField="Region.Nombre" />
                            <asp:BoundField HeaderText="Estado" DataField="Estado" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button CssClass="btn btn-danger" runat="server"
                                        CommandName="eliminar" Text="Eliminar"
                                        CommandArgument='<%#Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
          
        </div>
</asp:Content>