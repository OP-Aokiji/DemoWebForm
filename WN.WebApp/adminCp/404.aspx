<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="WN.WebApp.adminCp._404" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page Not Found</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
        .pageNotFound{
	        position: fixed;
	        top: 40%;
	        left: 50%;
	        transform: translate(-50%, -50%);
	}
    </style>
</head>
<body>
    <form runat="server" id="formAdminMain">
    <div class="pageNotFound">
        <h3>Sorry, page not found !</h3>
    </div>
    </form>
</body>
</html>
