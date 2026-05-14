<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="PoliceCrimeRecordBureau.Admin.Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <!-- Option 1: Include in HTML -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
      <div class="container">
          <form runat="server">

        <div class="row" style="padding:3px">
            <div class="col-lg-12" style="border-radius:8px;text-align:center;background-color:lightcyan;box-shadow:4px 4px 8px inset;">
                <h4 style="color:blue">MANAGE DISTRICT ADMINS</h4>


            </div>
        </div>
        <br /> <br />
        <div class="row">
               <div class="col-lg-2"></div>
               <div class="col-lg-8">

                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hoverable" HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"   RowStyle-VerticalAlign="Middle">
                       <Columns>
                           <asp:TemplateField HeaderText="Request Receiver" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                               <ItemTemplate> 
                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("req_to") %>'></asp:Label>
                                   <asp:Label ID="Label2" runat="server" Text=""></asp:Label> 

                               </ItemTemplate>
                           </asp:TemplateField>

                           <asp:TemplateField HeaderText="Request Sender" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">


                                <ItemTemplate>

                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("req_from") %>'></asp:Label>
                                   <asp:Label ID="Label4" runat="server" Text=""></asp:Label> 
                                </ItemTemplate>
                           </asp:TemplateField>
                           <asp:BoundField HeaderText="Requested Date"  DataField="rdate"/>
                       </Columns>
                   </asp:GridView>
              
               </div>
               <div class="col-lg-2"></div>
        </div>
               </form>
         </div>
   
</asp:Content>
