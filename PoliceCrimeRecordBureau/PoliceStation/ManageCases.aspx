<%@ Page Title="" Language="C#" MasterPageFile="~/PoliceStation/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageCases.aspx.cs" Inherits="PoliceCrimeRecordBureau.PoliceStation.ManageCases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../Content/bootstrap.min.css" rel="stylesheet" />
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <form runat="server">
         <div class="row" >
            <div class="col-lg-12" style="border-radius:8px;text-align:center;background-color:lightcyan;box-shadow:4px 4px 8px inset;">
                <h4 style="color:blue">MANAGE CASES</h4>

            </div>
        </div>
        <br /> <br />


        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

            <asp:View ID="View1" runat="server">
                <div class="row" style="width:100%">
        <div class="col-lg-6">
            <table class="table table-hoverable">
                 <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>

                    </td>
                       <td >
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>

                    </td>
                </tr>
              
                 <tr>
                    <td colspan="2">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>

                    </td>
                </tr>
                 <tr>
                    <td colspan="2">
                     
                          <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"  placeholder="File Name" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
                    </td>
                </tr>
               
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"  placeholder="Description" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                 <tr>
                    <td colspan="2">
                     
                          <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"  placeholder="Culprit Name" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Keywords For searching</td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" placeholder="KeyWord1"> </asp:TextBox>
                        <asp:TextBox ID="TextBox7" runat="server" placeholder="KeyWord2"> </asp:TextBox>
                        <asp:TextBox ID="TextBox8" runat="server" placeholder="KeyWord3"></asp:TextBox>


                    </td>
                </tr>
                <tr>
                    <td>Case Status</td>
                    <td>
                        <asp:RadioButtonList ID="radioactive" runat="server"   RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Active</asp:ListItem>
                            <asp:ListItem Value="0">Inactive</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>Upload Your CaseFile</td>
                                        <td>
                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control"/></td>
                </tr>
                  <tr>
                    <td>Image of Culprit</td>
                                        <td>
                                            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control"/></td>
                </tr>
                <tr>
                    <td colspan="2">

                        <asp:Button ID="Button1" runat="server" Text="Upload" CssClass="btn btn-primary form-control" OnClick="Button1_Click"/>
                    </td>
                </tr>
                </table>



        </div>
                <div class="col-lg-6">
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" >
                        <asp:ListItem Value="1">Active</asp:ListItem>
                        <asp:ListItem Value="0">Inactive</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                    
                    <asp:DataList ID="DataList1" runat="server" CssClass="table table-responsive" RepeatDirection="Vertical" RepeatColumns="3" OnDeleteCommand="DataList1_DeleteCommand">
                        <ItemTemplate>
                            <table class="table table-responsive">
                                <tr>
                                    <td style="text-align: center">
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="76px" ImageUrl="~/PoliceStation/images/caseicon.png" Width="86px" CssClass="img img-thumbnail" CommandName="delete" CausesValidation="false" />
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("fid") %>' Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                <td style="text-align: center">
                                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Bind("fname") %>' Font-Bold="true"></asp:Label>
                                </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>



                    <asp:DataList ID="DataList2" runat="server" CssClass="table table-responsive" RepeatDirection="Vertical" RepeatColumns="3"  Visible="false" OnDeleteCommand="DataList2_DeleteCommand" >
                        <ItemTemplate>
                            <table class="table table-responsive">
                                <tr>
                                    <td style="text-align: center">
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="76px" ImageUrl="~/PoliceStation/images/caseicon.png" Width="86px" CssClass="img img-thumbnail" CommandName="delete"  CausesValidation="false"/>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("fid") %>' Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                <td style="text-align: center">
                                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text='<%# Bind("fname") %>' Font-Bold="true"></asp:Label>
                                </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>




                </div>
                </div>
            </asp:View>






            <asp:View ID="View2" runat="server">
                  <div class="row" style="width:100%">
                        <div class="col-lg-3"></div>
                       <div class="col-lg-6">


                           <div style="height:500px;width:500px;box-shadow:2px 2px 8px inset">

                           <table class="table table-hoverable">
                               <thead style="text-align:end;font-size:large;">
                                   <span style="padding-left:400px"><asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue" Font-Size="Large" OnClick="LinkButton1_Click" ><i class="glyphicon glyphicon-home"></i></asp:LinkButton></span>
                                          
                                               &nbsp;&nbsp;&nbsp;
                                               <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="Large" ForeColor="Blue" OnClick="LinkButton2_Click"><i class="glyphicon glyphicon-download"></i></asp:LinkButton>
                                   
                                 
                                  
                               </thead>
                                <tr>
                                   <td colspan="2" style="text-align:center">
                                       <asp:Label ID="Label1" runat="server" Text="Label" CssClass="form-control"></asp:Label>
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

            


    </form>
</asp:Content>
