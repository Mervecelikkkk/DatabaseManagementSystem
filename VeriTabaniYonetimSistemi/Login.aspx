<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VeriTabaniYonetimSistemi.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
    <link href="css/bootstrap-responsive.css"  type="text/css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css"  type="text/css" rel="stylesheet" />
    <link href="css/bootstrap.css"  type="text/css" rel="stylesheet" />
    <link href="css/bootstrap.min.css"  type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link href="css/login.css" rel="stylesheet" />
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
                            <asp:TextBox ID="txtKullaniciAd" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvKullaniciAd" placeholder="Username" runat="server" Display="Dynamic" ForeColor="#FF3300" SetFocusOnError="true" ControlToValidate="txtKullaniciAd" ErrorMessage="Lütfen Giriş Yapabilmek için Bir Kullanıcı Adı Girin"></asp:RequiredFieldValidator>
                        </div>

                        <div class="icon1">
                            <span class="fa fa-lock"></span>
                            <asp:TextBox ID="txtSifre" placeholder="Password" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSifre" runat="server" Display="Dynamic" ForeColor="#FF3300" SetFocusOnError="true" ControlToValidate="txtSifre" ErrorMessage="Lütfen Giriş Yapabilmek için Şifrenizi Girin"></asp:RequiredFieldValidator>
                        </div>
                      <div class="" style=" background:#007cc0; height: 30px;"; >
  
                            <asp:Button ID="btnLogin"   runat="server" Text="Log In"  OnClick="btnLogin_Click"  BorderStyle="None" ForeColor="White" BackColor="#007CC0" Font-Bold="True" Font-Size="Medium" Width="400px" Height="30px" />
             
                            <br />
             
                       </div>
                       
                  
                              <asp:Label ID="lblMsj" runat="server" ></asp:Label>
                           <div>
                            <asp:CheckBox ID="chkRemember" ForeColor="White" runat="server" BorderColor="White" Checked="True"  AutoPostBack="True" />
              
                              <asp:Label ID="Label1" runat="server" Text="Remember Me!" Font-Italic="False" ForeColor="White"></asp:Label>
                           </div>
                  
           
                        <div class="links">
                            <p><a href="#">Forgot Password ?</a></p>
                            <p class="right"><a href="Register.aspx">New User Register</a></p>
                            <div class="clear"></div>
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
