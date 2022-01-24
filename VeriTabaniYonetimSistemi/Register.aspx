<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="VeriTabaniYonetimSistemi.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="css/bootstrap-responsive.css"  type="text/css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css"  type="text/css" rel="stylesheet" />
    <link href="css/bootstrap.css"  type="text/css" rel="stylesheet" />
    <link href="css/bootstrap.min.css"  type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
     <link href="css/register.css" rel="stylesheet" /> 
    <link href="css/register.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />


    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/duotone.css" integrity="sha384-R3QzTxyukP03CMqKFe0ssp5wUvBPEyy9ZspCB+Y01fEjhMwcXixTyeot+S40+AjZ" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/fontawesome.css" integrity="sha384-eHoocPgXsiuZh+Yy6+7DsKAerLXyJmu2Hadh4QYyt+8v86geixVYwFqUvMU8X90l" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/duotone.css" integrity="sha384-R3QzTxyukP03CMqKFe0ssp5wUvBPEyy9ZspCB+Y01fEjhMwcXixTyeot+S40+AjZ" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/fontawesome.css" integrity="sha384-eHoocPgXsiuZh+Yy6+7DsKAerLXyJmu2Hadh4QYyt+8v86geixVYwFqUvMU8X90l" crossorigin="anonymous" />


    <script src="js/bootstrap.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.js"
        integrity="sha256-QWo7LDvxbWT2tbbQ97B53yJnYU3WhH/C8ycbRAkjPDc="
        crossorigin="anonymous"></script>
    <script src="//code.jquery.com/jquery-1.12.4.js"></script>
    <script src="//code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <meta name="theme-color" content="#7952b3">
  
</head>
<body>
    <form id="form1" runat="server">
            <div class="my-main">
        <div class="bg-layer">
            <h1>VTYS</h1>
            <div class="header-main">
                <div class="main-icon">
                    <span class="fa fa-database"></span>
                </div>
                <div class="header-left-bottom">
                    <form action="#" method="post">


                        <div class="icon1">
                            <span class="fa fa-user"></span>
                            <%--    <input type="text" id="ad" placeholder="Name" required="" />--%>
                            <asp:TextBox ID="txtAd" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvfAd" runat="server" ErrorMessage="Lütfen Adınızı Girin" Display="Dynamic" ForeColor="#FF3300" SetFocusOnError="true" ControlToValidate="txtAd"></asp:RequiredFieldValidator>
                        </div>

                        <div class="icon1">
                            <span class="fa fa-user"></span>
                            <asp:TextBox ID="txtSoyad" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvfSoyad" runat="server" ErrorMessage="Lütfen Soyadınızı Girin" Display="Dynamic" ForeColor="#FF3300" SetFocusOnError="true" ControlToValidate="txtSoyad"></asp:RequiredFieldValidator>

                        </div>


                        <div class="icon1">
                            <span class="fa fa-envelope"></span>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvfEmail" runat="server" ErrorMessage="Lütfen Email Adresinizi Girin" Display="Dynamic" ForeColor="#FF3300" SetFocusOnError="true" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rgeEmail" ControlToValidate="txtEmail" runat="server" Display="Dynamic" ForeColor="#FF3300" SetFocusOnError="true" ErrorMessage="Lütfen Geçerli bir Email Formatı Girin" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="icon1">
                            <span class="fa fa-user"></span>
                            <asp:TextBox ID="txtKullaniciAd" runat="server"></asp:TextBox>

                        </div>
                        <div class="icon1">
                            <span class="fa fa-lock"></span>
                            <asp:TextBox ID="txtSifre" runat="server"></asp:TextBox>
                        </div>


                        <div class="" style=" background:#007cc0; height: 30px;"; >
  
                            <asp:Button ID="btnRegister"   runat="server" Text="Register"  OnClick="btnRegister_Click"  BorderStyle="None" ForeColor="White" BackColor="#007CC0" Font-Bold="True" Font-Size="Medium" Width="400px" Height="30px" />
             
                        
             
                       </div>
                    
                    </form>
                </div>

                <div class="social">
                    <ul>
                        <li>Or Login Using</li>
                        <li><a href="#" class="facebook"><span class="fab fa-facebook-f"></span></a></li>
                        <li><a href="#" class="twitter"><span class="fab fa-twitter"></span></a></li>
                        <li><a href="#" class="linkedin"><span class="fab fa-linkedin"></span></a></li>


                    </ul>
                </div>

            </div>
        </div>
    </div>
    </form>
</body>
</html>
