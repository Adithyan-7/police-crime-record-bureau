<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="otpverification.aspx.cs" Inherits="PoliceCrimeRecordBureau.Login.otpverification" %>

<!DOCTYPE html>

<html>
<head>
<title>Gaming Login Form Responsive Widget Template  :: w3layouts</title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Gaming Login Form Widget Tab Form,Login Forms,Sign up Forms,Registration Forms,News letter Forms,Elements"/>
<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
	<div class="padding-all">
		<div class="header">
            <img src="images/National_Crime_Records_Bureau_Logo.png" alt=" "  height="100px" width="150px">
            <br />
			<h1> PCR Bureau</h1>
		</div>
		<div class="design-w3l"  >
			<div class="mail-form-agile" > 
				<form  runat="server">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder=" Verify OTP send to your Registered Email" required=""></asp:TextBox>
					<br />					<br />					<br />
					 
					<%--<input type="text" name="name" placeholder="User Name  or  email..." required="" runat="server" id="name"/>
					<input type="password"  name="password" class="padding" placeholder="Password" required="" runat="server" id="password"/>--%>
                    <asp:Button ID="Button1" runat="server" Text="Submit" BackColor="Brown" OnClick="Button1_Click"     />
				</form>
			</div>
		  <div class="clear"> </div>
		</div>
		
	
	</div>
</body>
</html>