<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCategoryLevel1CU.ascx.cs"
    Inherits="WN.WebApp.adminCp.uc.ucCategoryLevel1CU" %>
<%@ Import Namespace="WN.Common" %>
<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>DM Cấp 1</b> / <a href="<%=Constants.NAVIGATE_DEFAULT_PAGE  + "ucCategoryLevel1"%>">
                <b>Quay Lại</b></a>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label for="inputCatL1Name">
                    Tên danh mục
                    <asp:RequiredFieldValidator ID="requiredFieldValidatorCatL1Description" runat="server"
                        ControlToValidate="textboxCatL1Name" ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxCatL1Name" runat="server" class="form-control-uppercase"
                    placeholder="Tên danh mục"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="inputCatL1Description">
                    Mô tả</label>
                <asp:TextBox ID="textboxCatL1Description" runat="server" TextMode="MultiLine" Rows="6"
                    class="form-control" placeholder="Mô tả"></asp:TextBox>
            </div>
            <div class="centered">
                <asp:Button ID="buttonSaveData" runat="server" class="btn btn-primary active" Text=" Lưu dữ liệu "
                    Width="150px" OnClick="buttonSaveData_Click" />
            </div>
        </div>
    </div>
</div>
