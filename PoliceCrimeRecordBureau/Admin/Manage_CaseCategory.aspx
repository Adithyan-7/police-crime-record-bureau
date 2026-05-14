<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Manage_CaseCategory.aspx.cs" Inherits="PoliceCrimeRecordBureau.Admin.Manage_CaseCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Option 1: Include in HTML -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
    
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <form  runat="server">
      <div class="row">
            <div class="col-lg-12" style="border-radius:8px;text-align:center;background-color:lightcyan;box-shadow:4px 4px 8px inset;">
                <h4 style="color:blue">MANAGE CASE CATEGORY</h4>


            </div>
        </div>
        <br /> <br />
    <div class="row" style="width:100%">
        <div class="col-lg-6">
            <table class="table table-hoverable">
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Category" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                 <tr>
                    <td>  
                      <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Description"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="ADD" CssClass="btn btn-primary form-control" OnClick="Button1_Click"  />

                    </td>
                </tr>
            </table>

        </div>
        <div class="col-lg-6">

            <h4>Categories</h4>

             <table class="table table-hover">
            <asp:DataList ID="DataList1" runat="server" CssClass="table table-responsive" RepeatDirection="Vertical" RepeatColumns="1" OnDeleteCommand="DataList1_DeleteCommand" OnUpdateCommand="DataList1_UpdateCommand" >
                <ItemTemplate>
                   
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" ForeColor="#0000CC" Text='<%# Eval("c_id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#0000CC" Text='<%# Eval("Category") %>'></asp:Label>
                            </td>
                            <td style="text-align:right">
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="update" CausesValidation="false"><span class="bi bi-trash-fill" > </span></asp:LinkButton>
                            </td>
                            <td>
                         <asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete" CausesValidation="false"><span class="bi bi-chevron-down" style="color:blue"></span></asp:LinkButton>
                            </td>
                            
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:DataList ID="DataList2" runat="server" CssClass="table table-responsive" Visible="false">

                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("des") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:DataList>
                            </td>
                        </tr>
                    
                </ItemTemplate>

            </asp:DataList>
                 </table>
           <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" BackColor="White" BorderColor="White" BorderStyle="None" BorderWidth="0px" CellPadding="3" ForeColor="Black" GridLines="None" ShowHeader="false" RowStyle-BorderColor="White" FooterStyle-BorderStyle="None" HorizontalAlign="Center">
             <AlternatingRowStyle BackColor="AliceBlue" />
             <Columns>
                 <asp:BoundField DataField="Category" HeaderText="Category"  ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Blue"/>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete" CausesValidation="false"><span class="glyphicon glyphicon-chevron-down" style="color:blue"></span></asp:LinkButton>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#CCCCCC" />
             <HeaderStyle BackColor="DarkBlue" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#808080" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#383838" />
         </asp:GridView>--%>


        </div>
    </div>
        </form>
</asp:Content>
