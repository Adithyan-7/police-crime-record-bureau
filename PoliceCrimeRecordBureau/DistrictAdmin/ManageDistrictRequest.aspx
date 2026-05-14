<%@ Page Title="" Language="C#" MasterPageFile="~/DistrictAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageDistrictRequest.aspx.cs" Inherits="PoliceCrimeRecordBureau.DistrictAdmin.ManageDistrictRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../Content/bootstrap.min.css" rel="stylesheet" />
       <!-- Option 1: Include in HTML -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
    <form runat="server">
        <div class="row" >
            <div class="col-lg-12" style="border-radius:8px;text-align:center;background-color:lightcyan;box-shadow:4px 4px 8px inset;">
                <h4 style="color:blue">MANAGE FILE REQUEST</h4>

            </div>
        </div>
        <br /> <br />

    <div class="row">
        <div class="col-lg-1"></div>
         <div class="col-lg-10">


             <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" GridLines="None" CellPadding="5" CellSpacing="5" ForeColor="Blue" HeaderStyle-HorizontalAlign="Center" HorizontalAlign="Center" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
                 <Columns>
                     <asp:BoundField HeaderText="Request From" DataField="StationName" ItemStyle-HorizontalAlign="Center" >
                      
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                     </asp:BoundField>
                      
                     <asp:TemplateField HeaderText="Requested District" ItemStyle-HorizontalAlign="Center">
                         <ItemTemplate>
                          <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

                         </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                     </asp:TemplateField>
                     <asp:BoundField HeaderText="FileName" DataField="fname" />
                      <asp:BoundField HeaderText="Requested Date" DataField="rdate" />

                     <asp:TemplateField>
                         <ItemTemplate>

                             <asp:Button ID="Button1" runat="server" Text="Accept" CssClass="btn btn-block " BackColor="Green" CommandName="update"/>
                         </ItemTemplate>

                     </asp:TemplateField>

                      <asp:TemplateField>
                         <ItemTemplate>
                          
                             <asp:Label ID="Label2" runat="server" Text='<%# Eval("req_from_dis") %>'  Visible="false"></asp:Label>
                               <asp:Label ID="Label1" runat="server" Text='<%# Eval("req_id") %>'  Visible="false"></asp:Label>
                             <asp:Button ID="Button2" runat="server" Text="Reject"  CssClass="btn btn-block " BackColor="Red" CommandName="delete"/>
                         </ItemTemplate>

                     </asp:TemplateField>
                 </Columns>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
             </asp:GridView>



         </div>
         <div class="col-lg-1"></div>
    </div>
        </form>
</asp:Content>
