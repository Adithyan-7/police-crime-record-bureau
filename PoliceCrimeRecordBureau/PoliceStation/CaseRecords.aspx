<%@ Page Title="" Language="C#" MasterPageFile="~/PoliceStation/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="CaseRecords.aspx.cs" Inherits="PoliceCrimeRecordBureau.PoliceStation.CaseRecords" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <!-- Option 1: Include in HTML -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <form runat="server">
    <div class="row">
        <div class="col-lg-3"></div>
         <div class="col-lg-6">

             <table style="width:100%" class="table">
                 <tr>
                     <td>  <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                         
                           </asp:DropDownList></td>
                      <td>   <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList></td>
                 </tr>
             </table> 
             <asp:DataList ID="DataList1" runat="server" CssClass="table table-responsive" RepeatDirection="Vertical" RepeatColumns="3" OnDeleteCommand="DataList1_DeleteCommand" >
                        <ItemTemplate>
                            <table class="table table-responsive">
                                <tr>
                                    <td style="text-align: center">
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="76px" ImageUrl="~/PoliceStation/images/caseicon.png" Width="86px" CssClass="img img-thumbnail" CommandName="delete" CausesValidation="false" />
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("fid") %>' Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                <td style="text-align: center">
                                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Eval("fname") %>' Font-Bold="true"></asp:Label>
                                </td>
                                </tr>
                                 <tr>
                                <td style="text-align: center">
                                    <asp:Button ID="Button1" runat="server" Text="Request File" CommandName="delete" />
                                    <asp:Label ID="Label3" runat="server" Visible="false" ForeColor="Green"></asp:Label>
                                  
                                </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList><asp:Panel ID="Panel1" runat="server" class="jumbotron" Visible="false"> No Cases Registered!!</asp:Panel>
         


         </div>
         <div class="col-lg-3"></div>
    </div>

    </form>

</asp:Content>
