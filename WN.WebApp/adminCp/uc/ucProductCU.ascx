<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProductCU.ascx.cs"
    Inherits="WN.WebApp.adminCp.uc.ucProductCU" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Import Namespace="WN.Common" %>
<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>Sản Phẩm</b> /<a href="<%=Constants.NAVIGATE_DEFAULT_PAGE  + "ucProduct"%>"><b>Quay Lại</b></a>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label for="inputProName">
                    Sản Phẩm
                </label>
                <asp:TextBox ID="textboxProName" runat="server" class="form-control" placeholder="Sản Phẩm"
                    MaxLength="100"></asp:TextBox>
            </div>
            <div class="form-group">
                <div class="table-responsive">
                    <table class="table table-striped">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Repeater runat="server" ID="repeaterImageList" OnItemCommand="repeaterImageList_ItemCommand">
                                        <ItemTemplate>
                                            <div class="repeater-image-style" align="center">
                                                <div style="width: 100px">
                                                    <asp:Label ID="labelImageId" runat="server" Text='<%#Eval("IMG_ID")%>' Visible="false"></asp:Label>
                                                    <asp:Image ID="imageBox" runat="server" Height="100px" class="img-responsive" Width="100px" ImageUrl='<%# @"/" + Constants.PRODUCT_DIR + Eval("IMG_NAME") %>' />
                                                </div>
                                                <div>
                                                    <asp:ImageButton runat="server" ID="imgButtonDeleteImage" class="img-responsive" OnClientClick="if (!confirm('Bạn có muốn xóa hình ảnh này ?')) return false;"
                                                        CommandName="DELETE_ITEM" CommandArgument='<%#Eval("IMG_ID")%>' Height="24px" Width="24px" ImageUrl="/adminCp/img/delete.png" />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="form-group">
                <label for="inputImgUpload">
                    Hình Ảnh (W: 570 px - H: 700 px)
                </label>
                <asp:FileUpload ID="fileUploadImage" runat="server" class="btn btn-warning" />
            </div>
            <div class="form-group">
                <asp:Button ID="buttonUploadImage" runat="server" class="btn btn-primary active"
                    Text=" Upload Image " Width="150px" OnClick="buttonUploadImage_Click" />
            </div>
            <div class="form-group">
                <label for="inputProOldPrice">
                    Giá Cũ
                </label>
                <asp:TextBox ID="textboxProOldPrice" runat="server" class="form-control" placeholder="Giá Cũ"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="inputProPrice">
                    Giá Sản Phẩm
                </label>
                <asp:TextBox ID="textboxProPrice" runat="server" class="form-control" placeholder="Giá Sản Phẩm"></asp:TextBox>
            </div>
            <div class="form-group">
                <div class="table-responsive">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>DM Cấp 2
                                </th>
                                <th class="centered">Nam
                                </th>
                                <th class="centered">Nữ
                                </th>
                                <th class="centered"><span class="glyphicon glyphicon-home"></span>
                                </th>
                            </tr>
                        </thead>

                        <tbody>
                            <tr>
                                <td>
                                    <asp:DropDownList runat="server" CssClass="dropdownlist-style" ID="comboboxCategoryLevel2"
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td class="centered">
                                    <asp:CheckBox runat="server" ID="checkboxNam"/>
                                </td>
                                <td class="centered">
                                    <asp:CheckBox runat="server" ID="checkboxNu"/>
                                </td>
                                <td class="centered">
                                    <asp:CheckBox runat="server" ID="checkBoxHomePage"/>
                                </td>
                            </tr>
                        </tbody>

                    </table>
                </div>
            </div>
            <div class="form-group">
                <label for="inputProDescription">
                    Mô Tả
                </label>
                <CKEditor:CKEditorControl ID="ckeditorProDescription" BasePath="/ad/js/ckeditor/"
                    Height="300px" runat="server"></CKEditor:CKEditorControl>
            </div>
            <div class="centered">
                <asp:Button ID="buttonSaveData" runat="server" class="btn btn-primary active" Text=" Lưu dữ liệu "
                    Width="150px" OnClick="buttonSaveData_Click" />
            </div>
        </div>
    </div>
</div>
