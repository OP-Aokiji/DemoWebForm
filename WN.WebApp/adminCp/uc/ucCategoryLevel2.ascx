<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCategoryLevel2.ascx.cs" Inherits="WN.WebApp.adminCp.uc.ucCategoryLevel2" %>
<%@ Import Namespace="WN.Common" %>
<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>DM Cấp 2</b> / <a href="<%=Constants.NAVIGATE_DEFAULT_PAGE  + "ucCategoryLevel2CU"%>"><b>Thêm Mới</b></a>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label for="inputProName">
                    Lọc theo DM Cấp 1
                </label>
               <asp:DropDownList runat="server" CssClass="dropdownlist-style" ID="comboboxCategoryL1" AutoPostBack="true"
                Width="200px" OnSelectedIndexChanged="comboboxCategoryL1_SelectedIndexChanged">
            </asp:DropDownList>
            </div>
           
            <asp:Repeater ID="repeaterCategoryLevel2" runat="server" OnItemCommand="repeaterCategoryLevel2_ItemCommand">
                <HeaderTemplate>
                    <div class="table-responsive">
                        <table class="table table-bordered">
                            <tr>
                                <td class="centered">
                                    <b>--</b>
                                </td>
                                <td>
                                    <b>DM Cấp 1</b>
                                </td>
                                <td>
                                    <b>DM Cấp 2</b>
                                </td>
                                <td>
                                    <b>Mô tả</b>
                                </td>
                                <td class="centered">--
                                </td>
                                <td class="centered">--
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr onmouseover="this.style.backgroundColor='#D0D0CF'" onmouseout="this.style.backgroundColor='white'">
                        <td class="centered     ">
                            <%#Eval("CAT_L2_ID") %>
                        </td>
                        <td>
                            <%#Eval("CAT_L1_NAME") %>
                        </td>
                        <td>
                            <%#Eval("CAT_L2_NAME")%>
                        </td>
                        <td>
                            <%#Eval("CAT_L2_DESCRIPTION")%>
                        </td>
                        <td class="centered">
                            <asp:LinkButton ID="linkButtonUpdate" runat="server" CommandName="UPDATE_ITEM"
                                CommandArgument='<%#Eval("CAT_L2_ID") %>'><img src="/adminCp/img/edit.png" width = "24px" height = "24px" alt="Update Category" /></asp:LinkButton>
                        </td>
                        <td class="centered">
                            <asp:LinkButton ID="linkButtonDelete" runat="server" CommandName="DELETE_ITEM"
                                CommandArgument='<%#Eval("CAT_L2_ID") %>' OnClientClick="if (!confirm('Bạn có muốn xóa danh mục cấp 2 này không ?')) return false;"><img src="/adminCp/img/delete.png"  width = "24px" height = "24px" alt="Delete Category" /></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                   </table> </div> 
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
