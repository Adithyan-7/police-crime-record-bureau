<%@ Page Title="" Language="C#" MasterPageFile="~/PoliceStation/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="RequestStatus.aspx.cs" Inherits="PoliceCrimeRecordBureau.PoliceStation.RequestStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <!-- Option 1: Include in HTML -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
     <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <form runat="server">
        <div class="row" >
            <div class="col-lg-12" style="border-radius:8px;text-align:center;background-color:lightcyan;box-shadow:4px 4px 8px inset;">
                <h4 style="color:blue">Request Status</h4>

            </div>
        </div>
        <br />
        <br />
    <div class="row">
        <div class="col-lg-3"></div>
         <div class="col-lg-6">

             <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                 <asp:View ID="View1" runat="server">


                     <asp:DataList ID="DataList1" runat="server" CssClass="table table-responsive" RepeatDirection="Vertical" RepeatColumns="3" OnDeleteCommand="DataList1_DeleteCommand"  >
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
                                       <asp:Label ID="Label7" runat="server" Visible="False" ForeColor="Green" Text='<%# Eval("req_id") %>'></asp:Label>
                                      <asp:Label ID="Label4" runat="server" Visible="False" ForeColor="Green" Text='<%# Eval("st") %>'></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Visible="false" ForeColor="red"></asp:Label>
                                    <asp:Button ID="Button2" runat="server" Text="Download File" Visible="false"  CommandName="delete"/>
                                </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                 </asp:View>





                 <asp:View ID="View2" runat="server">

                     <div class="row" style="width:100%">
                        <div class="col-lg-3"></div>
                       <div class="col-lg-6">


                           <div style="height:500px;width:500px;box-shadow:2px 2px 8px inset">

                           <table class="table table-hoverable">
                               <thead style="text-align:end;font-size:large;">
                                   <span style="padding-left:400px"><asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue" Font-Size="Large" OnClick="LinkButton1_Click"  ><i class="bi bi-home"></i></asp:LinkButton></span>
                                          
                                               
                                                   &nbsp;&nbsp;&nbsp;
                                                   <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="Large" ForeColor="Blue" OnClick="LinkButton2_Click"><i class="bi bi-download"></i></asp:LinkButton>
                               
                                 
                                  
                               </thead>
                                <tr>
                                   <td colspan="2" style="text-align:center">
                                       <asp:Label ID="Label1" runat="server" Text="Label" CssClass="form-control" Font-Bold="true"></asp:Label>
                               </tr>
                               <tr>
                                   <td colspan="2" style="text-align:center;">
                                       <asp:Image ID="Image2" runat="server" CssClass="form-control" Height="150" Width="150" ImageAlign="Middle"/>

                                       <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"><i >Download Image</i></asp:LinkButton>
                                   </td>
                               </tr>
                               <tr>
                                   <td style="text-align:center">Culprit Name</td>
                                   <td style="text-align:center">  <asp:Label ID="Label3" runat="server" Text="Label" CssClass="form-control"></asp:Label></td>
                               </tr>
                                <tr>
                                   <td style="text-align:center">Case Name</td>
                                   <td style="text-align:center">  <asp:Label ID="Label4" runat="server" Text="Label" CssClass="form-control"></asp:Label></td>
                               </tr>
                                <tr>
                                   <td style="text-align:center">Description</td>
                                   <td style="text-align:center">  <asp:Label ID="Label5" runat="server" Text="Label" CssClass="form-control"></asp:Label></td>
                               </tr>
                               <tr>
                                   <td style="text-align:center">Upload Date</td>
                                   <td style="text-align:center">  <asp:Label ID="Label6" runat="server" Text="Label" CssClass="form-control"></asp:Label></td>
                               </tr>
                           </table>
                               </div>


                            </div>
                       <div class="col-lg-3"></div>
                   </div>

                 </asp:View>

             </asp:MultiView>
             


         </div>
         <div class="col-lg-3"></div>
    </div>

    </form>
</asp:Content>
