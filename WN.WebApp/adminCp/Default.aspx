<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WN.WebApp.adminCp.Default" %>
<%@ Import Namespace="WN.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
   <%-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css" />--%>
    <link href="css/custom-sidebar.css" rel="stylesheet" type="text/css" />
    <link href="css/custom-style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server" id="back_End">
        <%if (Session["admin-login-status"] != null && Session["admin-login-status"].Equals("success"))
          { %>
        <div id="wrapper">
            <div id="sidebar-wrapper">
                <ul class="sidebar-nav">
                    <li class="sidebar-brand">
                        <h3 style="color: White">Admin</h3>
                    </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucHomePage"%>">Quản Lý Trang Chủ</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucBanner"%>">Quản Lý Banner</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucShopInfo"%>">Thông tin SHOP</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucCategoryLevel1"%>">Danh Mục Cấp 1</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucCategoryLevel2"%>">Danh Mục Cấp 2</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucProduct"%>">Quản Lý Sản Phẩm</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucTagSEO"%>">Quản Lý Tag</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucUserAcount"%>">Quản Lý User</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucChangePassword"%>">Đôi mật khẩu</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin"%>">Đăng Xuất</a> </li>


                 <%--   <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucHomePage"%>">Trang Chủ</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucBanner"%>">Banner</a> </li>
                   
                    
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucContact"%>">Contact</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucCompany"%>">Thông Tin Shop</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucTagSEO"%>">Tag Seo</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucUserAcount"%>">QL User</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucChangePassword"%>">Đôi mật khẩu</a> </li>
                    <li><a href="<%=Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin"%>">Logout</a> </li>--%>
                </ul>
            </div>
            <a href="#menu-toggle" id="menu-toggle" rel="nofollow" style="display: block;"></a>
            <%} %>
            <div id="page-content-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:PlaceHolder ID="placeHolderMain" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
            <%if (Session["admin-login-status"] != null &&  Session["admin-login-status"].Equals("success"))
              { %>
        </div>
        <%} %>
        
        <script src="js/jquery-1.11.0.min.js"></script>
        <script src="js/bootstrap.min.js"></script>

        <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js" type="text/javascript"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js" type="text/javascript"></script>--%>
        <script src="js/custom-script.js" type="text/javascript"></script>
    </form>
</body>
</html>
