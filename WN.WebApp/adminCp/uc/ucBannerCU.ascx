<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBannerCU.ascx.cs"
    Inherits="WN.WebApp.adminCp.uc.ucBannerCU" %>
    <%@ Import Namespace="WN.Common" %>
<div class="page-container-style4">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>Banner</b> / <a href="<%=Constants.NAVIGATE_DEFAULT_PAGE  + "ucBanner"%>"><b>Quay Lại</b></a>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label for="inputImgName">
                    Hình Ảnh (W: 1700 px - H: 450 px)
                </label>
                <asp:FileUpload ID="fileUploadImage" runat="server" class="btn btn-warning"/>
            </div>
            <%if (Request.QueryString.AllKeys.Contains("img_Id") && Request.QueryString.AllKeys.Contains("crud"))
              { %>
            <div class="form-group">
                <asp:TextBox ID="textboxImageName" runat="server" Enabled="false" Width="310px"
                    class="form-control" placeholder="Đường dẫn hình ảnh"></asp:TextBox>
            </div>
            <%} %>
            <div class="form-group">
                <div class="centered">
                    <asp:Image ID="imageView" runat="server" Height="150px" Width="310px" /></div>
            </div>
            <%--<div class="form-group">
                <label for="inputImgHeader">
                    Image Header
                </label>
                <asp:TextBox ID="textboxImgHeader" runat="server" TextMode="MultiLine" class="form-control"
                    placeholder="Image Header"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="inputImgText">
                    Image Text</label>
                <asp:TextBox ID="textboxImgText" runat="server" TextMode="MultiLine" class="form-control"
                    placeholder="Image Text"></asp:TextBox>
            </div>--%>
            <div class="centered">
                <asp:Button ID="buttonSaveData" runat="server" class="btn btn-primary active" Text=" Lưu dữ liệu "
                    Width="150px" OnClick="buttonSaveData_Click" />
            </div>
        </div>
    </div>
</div>
