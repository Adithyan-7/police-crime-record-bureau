<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="manage_DistrictAdmin.aspx.cs" Inherits="PoliceCrimeRecordBureau.Admin.manage_DistrictAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <!-- Option 1: Include in HTML -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <form runat="server">

        <div class="row">
            <div class="col-lg-12" style="border-radius:8px;text-align:center;background-color:lightcyan;box-shadow:4px 4px 8px inset;">
                <h4 style="color:blue">MANAGE DISTRICT ADMINS</h4>


            </div>
        </div>
        <br /> <br />
     <div class="row" style="width:100%">



         <div class="col-lg-6">


             <table class="table table-hover" style="width:100%">
             <tr>
                 <td colspan="2"> <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True"  >
                                        </asp:DropDownList>  </td>
             </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="District Admin Name" ></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ForeColor="Red" ControlToValidate="TextBox6"></asp:RequiredFieldValidator>
                     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
                 <td>

                      <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" required="" placeholder="Email"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ForeColor="Red" ControlToValidate="TextBox7"></asp:RequiredFieldValidator>

                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox7" ErrorMessage="*Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                 </td>
            </tr>

             <tr>
                 <td>
                      <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" required="" placeholder="Contact"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ForeColor="Red" ControlToValidate="TextBox8"></asp:RequiredFieldValidator>
                
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox8" ErrorMessage="*Invalid Phone Number" ForeColor="Red" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                


                 </td>
                 <td>
                     <asp:TextBox ID="TextBox4" runat="server" placeholder="Create username for this District admin" CssClass="form-control" required=""></asp:TextBox>     
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>

                 </td>
             </tr>
             <tr>
                 <td>
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" AutoPostBack="true"  placeholder="Password" required="" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>  
                     <asp:Label ID="Label3" runat="server" Text="Please include (8-10) characters which contains Capital Letter,small lettres,numbers and special characters" ForeColor="red" Visible="false"></asp:Label>

                     
                 </td>
                 <td>  <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"  placeholder="Confirm Password" required=""></asp:TextBox>   
                     <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="****check your password" ForeColor="Red" ControlToCompare="TextBox5" ControlToValidate="TextBox1"></asp:CompareValidator>
                     </td>
             </tr>
                 <tr>
                     <td colspan="2">
                         <asp:Button ID="Button1" runat="server" Text="Register" CssClass="btn btn-primary form-control" OnClick="Button1_Click"/>
                       <asp:Button ID="Button2" runat="server" Text="Update" CssClass="btn btn-primary form-control" Visible="false" OnClick="Button2_Click"  />

                         </td>
                 </tr>
         </table>
         </div>
         
				
        
     <div class="col-lg-6">


         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowUpdating="GridView1_RowUpdating">
             <AlternatingRowStyle BackColor="AliceBlue" />
             <Columns>
                 <asp:BoundField DataField="DistrictName" HeaderText="District" ItemStyle-Font-Bold="true" >
<ItemStyle Font-Bold="True"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Name" HeaderText="Admin Name" />
                 <asp:BoundField DataField="email" HeaderText="Email Id " />
                 <asp:BoundField DataField="Phn" HeaderText="Contact" />
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete"><span class="bi bi-trash" style="color:blue"></span></asp:LinkButton>
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField>
                     <ItemTemplate>
                          
                         <asp:Label ID="Label2" runat="server"   Visible="False" Text='<%# Bind("Da_id") %>'  ></asp:Label>
                         <asp:LinkButton ID="LinkButton2" runat="server" CommandName="update" CausesValidation="false"><span class="bi bi-pencil" style="color:blue"></span></asp:LinkButton>
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
         </asp:GridView>





     </div>
      
			
                        </div> 
            
        </form>
</asp:Content>
