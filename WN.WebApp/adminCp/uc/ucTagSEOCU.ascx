<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTagSEOCU.ascx.cs" Inherits="WN.WebApp.adminCp.uc.ucTagSEOCU" %>
<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>Tag</b> / <a href="Default.aspx?ctr=ucTagSEO"><b>Quay Lại</b></a>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label for="inputTagName">
                    Tag 
                <asp:RequiredFieldValidator ID="requiredFieldValidatorTagName" runat="server" ControlToValidate="textboxTagName"
                    ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="textboxTagName" runat="server" class="form-control" placeholder="Tag"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="inputTagURL">
                    Tag URL</label>
                <asp:TextBox ID="textboxTagURL" runat="server" TextMode="MultiLine" class="form-control"
                    placeholder="Tag URL"></asp:TextBox>
            </div>
            <div class="centered">
                <asp:Button ID="buttonSaveData" runat="server" class="btn btn-primary active" Text=" Lưu dữ liệu " OnClick="buttonSaveData_Click" />
            </div>
        </div>
    </div>
</div>
