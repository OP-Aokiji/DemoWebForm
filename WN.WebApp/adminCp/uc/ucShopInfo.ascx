<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucShopInfo.ascx.cs" Inherits="WN.WebApp.adminCp.uc.ucShopInfo" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>Thông tin SHOP</b>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label for="inputShopName">
                    Tên SHOP
                    <asp:RequiredFieldValidator ID="requiredFieldValidatorShopName" runat="server" ControlToValidate="textboxShopName"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="textboxShopName" runat="server" class="form-control" placeholder="Tên SHOP"
                    MaxLength="50"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="inputShopAddress">
                    Địa chỉ
                    <asp:RequiredFieldValidator ID="requiredFieldValidatorShopAddress" runat="server"
                        ControlToValidate="textboxShopAddress" ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxShopAddress" runat="server" TextMode="MultiLine" class="form-control"
                    placeholder="Địa Chỉ"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="inputShopPhone">
                    Số điện thoại
                    <asp:RequiredFieldValidator ID="requiredFieldValidatorShopPhone" runat="server" ControlToValidate="textboxShopPhone"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxShopPhone" runat="server" class="form-control" MaxLength="50"
                    placeholder="Số Điện Thoại"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="inputShopEmail">
                    Email
                    <asp:RequiredFieldValidator ID="requiredFieldValidatorShopEmail" runat="server" ControlToValidate="textboxShopEmail"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxShopEmail" runat="server" MaxLength="50" class="form-control"
                    placeholder="Email"></asp:TextBox>
            </div>
             <div class="form-group">
                <label for="inputEmailPass">
                   Mật khẩu
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmailPass" runat="server" ControlToValidate="textboxEmailPass"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator>--%></label>
                <asp:TextBox ID="textboxEmailPass" runat="server" TextMode = "Password" class="form-control"
                    placeholder="Mật khẩu Email"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="inputShopSkype">
                    Skype
                    <asp:RequiredFieldValidator ID="requiredFieldValidatorShopSkype" runat="server" ControlToValidate="textboxShopSkype"
                        ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxShopSkype" runat="server" class="form-control" MaxLength="50"
                    placeholder="Skype"></asp:TextBox>
            </div>
           
            <div class="centered">
                <asp:Button ID="buttonSaveData" runat="server" class="btn btn-primary active" Text=" Lưu dữ liệu "
                    Width="150px" OnClick="buttonSaveData_Click" />
            </div>
        </div>
    </div>
</div>
