<%@ Page Title="" Language="C#" MasterPageFile="~/PoliceStation/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="SearchFile.aspx.cs" Inherits="PoliceCrimeRecordBureau.PoliceStation.SearchFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <!-- Option 1: Include in HTML -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
     <link href="../Content/bootstrap.min.css" rel="stylesheet" />
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    
<script type="text/javascript">
    function getSuggestions(input) {
        if (input.length == 0) {
            $('#suggestions').html("");
            return;
        }

        $.ajax({
            type: "POST",
            url: "SearchFile.aspx/GetKeywordSuggestions",
            data: JSON.stringify({ prefix: input }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var suggestions = response.d;
                var html = "<ul style='list-style-type: none'>";
                $.each(suggestions, function (i, suggestion) {
                    html += "<li class='suggestion-item' style='padding:8px;margin-bottom:4px;margin-top:4px;background-color:cornflowerblue;color:white;width:150px;border-radius:20px'><span class='glyphicon glyphicon-tags'>  " +  suggestion + "</span></li>";
                });
                html += "</ul>";
                $('#suggestions').html(html);



                // Add click event handler to each suggestion
                $('.suggestion-item').click(function () {
                   
                    var selectedSuggestion = $(this).text().trim();
                  

                    // Use the correct client-side ID for the TextBox
                    $('#<%=TextBox1.ClientID %>').val(selectedSuggestion);

                    $('#suggestions').html(''); // Clear the suggestions list
                });


            },
            failure: function (response) {
                $('#suggestions').html("Error fetching suggestions.");
            }
        });
    }

    function getSuggestions1(input) {
        if (input.length == 0) {
            $('#suggestions1').html("");
            return;
        }

        $.ajax({
            type: "POST",
            url: "SearchFile.aspx/GetKeywordSuggestions",
            data: JSON.stringify({ prefix: input }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var suggestions = response.d;
                var html = "<ul style='list-style-type: none'>";
                $.each(suggestions, function (i, suggestion) {
                    html += "<li class='suggestion-item'  style='padding:8px;margin-bottom:4px;margin-top:4px;background-color:cornflowerblue;color:white;width:150px;border-radius:20px'><span class='glyphicon glyphicon-tags'>  " + suggestion + "</span></li>";
                });
                html += "</ul>";
                $('#suggestions1').html(html);

                // Add click event handler to each suggestion
                $('.suggestion-item').click(function () {

                    var selectedSuggestion = $(this).text().trim();


                    // Use the correct client-side ID for the TextBox
                    $('#<%=TextBox2.ClientID %>').val(selectedSuggestion);

                    $('#suggestions1').html(''); // Clear the suggestions list
                });
            },
            failure: function (response) {
                $('#suggestions1').html("Error fetching suggestions.");
            }
        });
    }

    function getSuggestions2(input) {
        if (input.length == 0) {
            $('#suggestions2').html("");
            return;
        }

        $.ajax({
            type: "POST",
            url: "SearchFile.aspx/GetKeywordSuggestions",
            data: JSON.stringify({ prefix: input }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var suggestions = response.d;
                var html = "<ul style='list-style-type: none'>";
                $.each(suggestions, function (i, suggestion) {
                    html += "<li class='suggestion-item'  style='padding:8px;margin-bottom:4px;margin-top:4px;background-color:cornflowerblue;color:white;width:150px;border-radius:20px'><span class='glyphicon glyphicon-tags'>  " + suggestion + "</span></li>";
                });
                html += "</ul>";
                $('#suggestions2').html(html);

                // Add click event handler to each suggestion
                $('.suggestion-item').click(function () {

                    var selectedSuggestion = $(this).text().trim();


                    // Use the correct client-side ID for the TextBox
                    $('#<%=TextBox3.ClientID %>').val(selectedSuggestion);

                    $('#suggestions2').html(''); // Clear the suggestions list
                });
            },
            failure: function (response) {
                $('#suggestions2').html("Error fetching suggestions.");
            }
        });
    }


 
</script>
     <form runat="server">
         <div class="row" >
            <div class="col-lg-12" style="border-radius:8px;text-align:center;background-color:lightcyan;box-shadow:4px 4px 8px inset;">
                <h4 style="color:blue">SEARCH MY CASES</h4>
                <asp:HiddenField ID="username" runat="server" />

            </div>
        </div>
        <br /> <br />

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex ="0">

            <asp:View ID="View1" runat="server">
                 <div class="row" >
            <div class="col-lg-3">

                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Search With Keyword1" onkeyup="getSuggestions(this.value)" ></asp:TextBox>

                <div id="suggestions"></div>
            </div>
           <div class="col-lg-3">

                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Search With Keyword2" onkeyup="getSuggestions1(this.value)" ></asp:TextBox>
                           <div id="suggestions1"></div>

            </div>
           <div class="col-lg-3">

                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Search With Keyword3"  onkeyup="getSuggestions2(this.value)"></asp:TextBox>

               <div id="suggestions2"></div>
            </div>
            <div class="col-lg-3">
                <asp:Button ID="Button1" runat="server" Text="Search"  CssClass="form-control btn btn-primary" OnClick="Button1_Click"  />
                </div>
            </div>
          <br /> <br />
        <div class="row">
                <div class="col-lg-2"></div>
                <div class="col-lg-8">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="False" Width="800px" ForeColor="#333333" GridLines="None" CellPadding="4" OnRowUpdating="GridView1_RowUpdating" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="searchfileid" HeaderText="   file Id" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="fname" HeaderText="   File Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                         <asp:BoundField DataField="p_code" HeaderText="File Owner" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="des" HeaderText="Description" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="tcount" HeaderText="Count" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="More">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="update" CssClass="btn btn-sm btn-danger btn-outline-dark">View</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  HorizontalAlign="Center"/>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                </div>

                <div class="col-lg-2"></div>


                
            </div>

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
                                                       <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="Large" ForeColor="Blue" OnClick="LinkButton3_Click"><i class="bi bi-download"></i></asp:LinkButton>
                                 
                               
                                 
                                  
                               </thead>
                                <tr>
                                   <td colspan="2" style="text-align:center">
                                       <asp:Label ID="Label1" runat="server" Text="Label" CssClass="form-control" Font-Bold="true"></asp:Label>
                               </tr>
                               <tr>
                                   <td colspan="2" style="text-align:center;">
                                       <asp:Image ID="Image2" runat="server" CssClass="form-control" Height="150" Width="150" ImageAlign="Middle"/>

                                       <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton2_Click" ><i >Download Image</i></asp:LinkButton>
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
