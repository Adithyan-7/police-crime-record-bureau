<%@ Page Title="" Language="C#" MasterPageFile="~/DistrictAdmin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageStation.aspx.cs" Inherits="PoliceCrimeRecordBureau.DistrictAdmin.ManageStation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- Option 1: Include in HTML -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <form runat="server">

        <div class="row" >
            <div class="col-lg-12" style="border-radius:8px;text-align:center;background-color:lightcyan;box-shadow:4px 4px 8px inset;">
                <h4 style="color:blue">MANAGE POLICE STATIONS</h4>

            </div>
        </div>
        <br /> <br />


        <div class="row" style="width:100%">
        <div class="col-lg-6">
            <table class="table table-hoverable">
                 <tr>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Station Code" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Station Name..." ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                 <tr>
                    <td colspan="2">  
                      <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Station Location"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">  
                      <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Station Admin"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">  
                      <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="Email "></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="**invalid " ForeColor="red" ControlToValidate="TextBox5" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                 <tr>
                    <td>  
                      <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" placeholder="UserName"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox6"></asp:RequiredFieldValidator>

                    </td>
                      <td>  
                      <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="Password" OnTextChanged="TextBox7_TextChanged"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox7"></asp:RequiredFieldValidator>
                     <asp:Label ID="Label6" runat="server" Text="Please include (8-10) characters which contains Capital Letter,small lettres,numbers and special characters" ForeColor="red" Visible="false"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">  
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
                     
                    </td>
                </tr>
                 <tr>
                    <td colspan="2">
                       
                        <asp:Button ID="Button1" runat="server" Text="ADD" CssClass="btn btn-primary form-control" OnClick="Button1_Click"  />

                    </td>
                </tr>
            </table>

        </div>
        <div class="col-lg-6">

            <h4>
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></h4>

            <div style="height:500px;overflow-y:scroll">
            <asp:DataList ID="DataList1" runat="server" CssClass="table table-responsive" RepeatDirection="Vertical" RepeatColumns="2" HorizontalAlign="Center" OnDeleteCommand="DataList1_DeleteCommand"  >
                <ItemTemplate>
                    <table class="table table-hover" style="text-align: center">
                        <tr>
                            <td style="vertical-align: middle; text-align: center">


                                <asp:Image ID="Image1" runat="server" Height="62px" Width="94px" ImageUrl='<%# Eval("Image") %>' />
                            </td>
                          
                        </tr>
                         <tr>
                            <td style="vertical-align: middle; text-align: center">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("stationAdmin") %>' Font-Bold="True" ForeColor="#0033CC"></asp:Label>
                                </td>
                             </tr>

                         <tr>
                            <td style="text-align: center; vertical-align: middle">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("StationName") %>'></asp:Label>
                                 <asp:Label ID="Label4" runat="server"  Text='<%# Eval("station_id") %>' Visible="false"></asp:Label>
                                </td>
                             </tr>
                       
                        <tr>
                            <td style="text-align: center; vertical-align: middle">
                            <asp:Label ID="Label5" runat="server"  Text='<%# Eval("Username") %>' Visible="false"></asp:Label>

                                <asp:Button ID="Button2" runat="server" Text="Delete"  CssClass="btn btn-primary" CausesValidation="false" CommandName="delete"/>
                                </td>
                             </tr>
                    </table>
                </ItemTemplate>

            </asp:DataList>
         </div>


        </div>
    </div>

        </form>


</asp:Content>
