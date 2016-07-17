<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUserAcountCU.ascx.cs"
    Inherits="WN.WebApp.adminCp.uc.ucUserAcountCU" %>
    <%@ Import Namespace="WN.Common" %>
<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>User</b> / <a href="<%=Constants.NAVIGATE_DEFAULT_PAGE  + "ucUserAcount"%>"><b>Quay Lại</b></a>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label for="inputFullName">
                    Họ tên
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorFullName" runat="server" ControlToValidate="textboxFullName"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxFullName" runat="server" class="form-control" placeholder="Họ tên"></asp:TextBox>
            </div>
            <%if (!Request.QueryString.AllKeys.Contains("user_Id") && !Request.QueryString.AllKeys.Contains("crud"))
              { %>
            <div class="form-group">
                <label for="inputImgUserName">
                    Tên đăng nhập
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" ControlToValidate="textboxUserName"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxUserName" runat="server" class="form-control" placeholder="Tên đăng nhập"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label for="inputPassword">
                    Mật khẩu
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="textboxPassword"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxPassword" runat="server" class="form-control" TextMode="Password"
                    placeholder="Mật khẩu"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="inputConfirmPassword">
                    Xác nhận mật khẩu
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" runat="server"
                        ControlToValidate="textboxConfirmPassword" ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxConfirmPassword" runat="server" TextMode="Password" class="form-control"
                    placeholder="Xác nhận mật khẩu"></asp:TextBox>
            </div>
            <%} %>
           <%-- <div class="form-group">
                <label for="inputUserEmail">
                    Email
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserEmail" runat="server" ControlToValidate="textboxUserEmail"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxUserEmail" runat="server" class="form-control" placeholder="User Email"></asp:TextBox>
            </div>--%>
            <div class="centered">
                <asp:Button ID="buttonSaveData" runat="server" class="btn btn-primary active" Text=" Lưu dữ liệu "
                    Width="150px" OnClick="buttonSaveData_Click" />
            </div>
        </div>
    </div>
</div>
