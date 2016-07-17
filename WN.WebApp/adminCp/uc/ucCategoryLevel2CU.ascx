<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCategoryLevel2CU.ascx.cs" Inherits="WN.WebApp.adminCp.uc.ucCategoryLevel2CU" %>

<%@ Import Namespace="WN.Common" %>

<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>DM Cấp 2</b> /  <a href="<%=Constants.NAVIGATE_DEFAULT_PAGE  + "ucCategoryLevel2"%>"><b>Quay Lại</b></a>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label for="inputCategoryL1">
                   DM Cấp 1
                </label> <br />
                <asp:DropDownList runat="server" CssClass="dropdownlist-style" ID="comboboxCategoryL1"
                    Width="200px">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="inputCatL2Name">
                    Tên danh mục
                <asp:RequiredFieldValidator ID="requiredFieldValidatorCatL1Description" runat="server" ControlToValidate="textboxCatL2Name"
                    ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxCatL2Name" runat="server" class="form-control" placeholder="Tên danh mục"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="inputCatL2Description">
                    Mô tả</label>
                <asp:TextBox ID="textboxCatL2Description" runat="server" TextMode="MultiLine" Rows="6" class="form-control"
                    placeholder="Mô tả"></asp:TextBox>
            </div>
            <div class="centered">
                <asp:Button ID="buttonSaveData" runat="server" class="btn btn-primary active" Text=" Lưu dữ liệu "
                    Width="150px" OnClick="buttonSaveData_Click" />
            </div>
        </div>
    </div>
</div>
