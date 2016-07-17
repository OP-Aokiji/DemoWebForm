<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogin.ascx.cs" Inherits="WN.WebApp.adminCp.uc.ucLogin" %>
<div class="page-container-style4">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b> Đăng nhập</b>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label for="inputUsername">
                     Tên đăng nhập
                    <asp:RequiredFieldValidator ID="requiredFieldValidatorUsername" runat="server" ControlToValidate="textboxUsername"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxUsername" runat="server" class="form-control" placeholder="Tên đăng nhập"></asp:TextBox>

            </div>
            <div class="form-group">
                <label for="inputPassword">
                    Mật khẩu 
                    <asp:RequiredFieldValidator ID="requiredFieldValidatorPassword" runat="server" ControlToValidate="textboxPassword"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxPassword" runat="server" TextMode="Password" class="form-control" placeholder="Mật khẩu"></asp:TextBox>

            </div>
            <div class="centered">
                <asp:Button ID="buttonLogin" runat="server" class="btn btn-primary active" Text=" Đăng nhập "
                    Width="100px" OnClick="buttonLogin_Click" />
            </div>
        </div>
    </div>
</div>
