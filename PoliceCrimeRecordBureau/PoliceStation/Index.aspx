<%@ Page Title="" Language="C#" MasterPageFile="~/PoliceStation/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PoliceCrimeRecordBureau.PoliceStation.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <form runat="server">
         <div class="row" >
            <div class="col-lg-12" style="border-radius:8px;text-align:center;background-color:lightcyan;box-shadow:4px 4px 8px inset;">
                <h4 style="color:blue">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h4>

            </div>
        </div>
        <br /> <br />
        <div class="row">
            <div class="col-lg-6">

                <table class="table table-hoverable">
                    <tr>
                        <td style="text-align:center">

                            <asp:Image ID="Image1" runat="server"  CssClass="img img-circle img-thumbnail"/>
                        </td>
                    </tr>
                      <tr>
                        <td style="text-align:center;color:blue;font-weight:bolder">

                            <asp:Label ID="Label2" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        </td>
                    </tr>
                      <tr>
                        <td style="text-align:center">
                        <asp:Label ID="Label3" runat="server" Text="Label" CssClass="form-control"></asp:Label>


                        </td>
                    </tr>
                </table>

           


            </div>
             <div class="col-lg-6">
                 <h3>Available Case Categories</h3>
                 <asp:DataList ID="DataList1" runat="server" class="table table-hoverable" OnDeleteCommand="DataList1_DeleteCommand" OnUpdateCommand="DataList1_UpdateCommand">
                     <ItemTemplate>
                         <table class="table table-hoverable">
                             <tr>
                                 <td style="text-align:center">
                                     <asp:Label ID="Label4" runat="server" Text='<%# Eval("Category") %>' Font-Bold="true"></asp:Label>
                                 </td>
                                 <td>
                                     <asp:Label ID="Label5" runat="server" Text='<%# Eval("c_id") %>' Visible="false"></asp:Label>
                                     <asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete"><span class=" glyphicon glyphicon-chevron-down" style="color:blue" ></span></asp:LinkButton>
                               <asp:LinkButton ID="LinkButton2" runat="server" CommandName="update" Visible="false"><span class=" glyphicon glyphicon-chevron-up" style="color:blue" ></span></asp:LinkButton>
                                     </td>
                             </tr>
                             <tr>
                                 <td colspan="2" style="text-align:center">
                                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Visible="false" GridLines="None" CssClass="table table-responsive" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle">
                                         <Columns>
                                             <asp:BoundField DataField="des" ShowHeader="False" ItemStyle-ForeColor="Blue" />
                                         </Columns>
                                     </asp:GridView>

                                 </td>
                             </tr>
                         </table>
                     </ItemTemplate>
                 </asp:DataList>




             </div>
        </div>







</form>
</asp:Content>
