<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCategoryLevel1.ascx.cs" Inherits="WN.WebApp.adminCp.uc.ucCategoryLevel1" %>
<%@ Import Namespace="WN.Common" %>
<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>DM Cấp 1</b> / Tối đa 5 danh mục<%--<a href="<%=Constants.NAVIGATE_DEFAULT_PAGE  + "ucCategoryLevel1CU"%>"><b>Thêm Mới</b></a>--%>
        </div>
        <div class="panel-body">
            <asp:Repeater ID="repeaterCategoryLevel1" runat="server" OnItemCommand="repeaterCategoryLevel1_ItemCommand">
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
                        <td class="centered">
                            <%#Eval("CAT_L1_ID") %>
                        </td>
                        <td>
                            <%#Eval("CAT_L1_NAME")%>
                        </td>
                        <td>
                            <%#Eval("CAT_L1_DESCRIPTION")%>
                        </td>
                        <td class="centered">
                            <asp:LinkButton ID="linkButtonUpdate" runat="server" CommandName="UPDATE_ITEM"
                                CommandArgument='<%#Eval("CAT_L1_ID") %>'><img src="/adminCp/img/edit.png" width = "24px" height = "24px" alt="Update Category" /></asp:LinkButton>
                        </td>
                        <td class="centered">
                            <asp:LinkButton ID="linkButtonDelete" runat="server" CommandName="DELETE_ITEM"
                                CommandArgument='<%#Eval("CAT_L1_ID") %>' OnClientClick="if (!confirm('Bạn có muốn xóa danh mục cấp 1 này không ?')) return false;"><img src="/adminCp/img/delete.png"  width = "24px" height = "24px" alt="Delete Category" /></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                   </table></div> 
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>