<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucChangePassword.ascx.cs"
    Inherits="WN.WebApp.adminCp.uc.ucChangePassword" %>
<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>Đổi mật khẩu</b>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label for="inputUsername">
                    Tên đăng nhập
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ControlToValidate="textboxUsername"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxUsername" runat="server" class="form-control" placeholder="Tên đăng nhập"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="inputOldPassword">
                    Mật khẩu cũ
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorOldPassword" runat="server" ControlToValidate="textboxOldPassword"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxOldPassword" runat="server" TextMode="Password" class="form-control"
                    placeholder="Mật khẩu cũ"></asp:TextBox>
            </div>
             <div class="form-group">
                <label for="inputNewPassword">
                    Mật khẩu mới
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPassword" runat="server" ControlToValidate="textboxNewPassword"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxNewPassword" runat="server" TextMode="Password" class="form-control"
                    placeholder="Mật khẩu mới"></asp:TextBox>
            </div>
             <div class="form-group">
                <label for="inputConfirmPassword">
                    Xác nhận mật khẩu
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textboxConfirmPassword"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxConfirmPassword" runat="server" TextMode="Password" class="form-control"
                    placeholder="Xác nhận mật khẩu"></asp:TextBox>
            </div>
            <div class="centered">
                <asp:Button ID="buttonChangePassword" runat="server" 
                    class="btn btn-primary active" Text=" Đổi mật khẩu "
                    Width="150px" onclick="buttonChangePassword_Click"/>
            </div>
        </div>
    </div>
</div>
