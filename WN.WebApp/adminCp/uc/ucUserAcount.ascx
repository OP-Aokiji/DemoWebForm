<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUserAcount.ascx.cs"
    Inherits="WN.WebApp.adminCp.uc.ucUserAcount" %>
    <%@ Import Namespace="WN.Common" %>
<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>User</b> / <a href="<%=Constants.NAVIGATE_DEFAULT_PAGE  + "ucUserAcountCU"%>"><b>Thêm Mới</b></a>
        </div>
        <div class="panel-body">
            <asp:Repeater ID="repeaterUserAcount" runat="server" OnItemCommand="repeaterUserAcount_ItemCommand">
                <HeaderTemplate>
                    <div class="table-responsive">
                        <table class="table table-bordered">
                            <tr>
                               <%-- <td class="centerd">
                                    <b>ID</b>
                                </td>--%>
                                <td>
                                    <b>Username</b>
                                </td>
                                <td>
                                    <b>Họ Tên</b>
                                </td>
                               <%-- <td>
                                    <b>Email</b>
                                </td>--%>
                                <td class="centered">
                                    --
                                </td>
                                <td class="centered">
                                    --
                                </td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr onmouseover="this.style.backgroundColor='#D0D0CF'" onmouseout="this.style.backgroundColor='white'">
                       <%-- <td class="centerd">
                            <%#Eval("USER_ID") %>
                        </td>--%>
                        <td>
                            <%#Eval("USER_NAME") %>
                        </td>
                        <td>
                            <%#Eval("USER_FULLNAME") %>
                        </td>
                        <%--<td>
                            <%#Eval("USER_EMAIL") %>
                        </td>--%>
                        <td class="centered">
                            <asp:LinkButton ID="linkButtonUpdate" runat="server" CommandName="UPDATE_ITEM"
                                CommandArgument='<%#Eval("USER_ID") %>'><img src="/adminCp/img/edit.png" width = "24px" height = "24px" alt="Update User" /></asp:LinkButton>
                        </td>
                        <td class="centered">
                            <asp:LinkButton ID="linkButtonDelete" runat="server" CommandName="DELETE_ITEM"
                                CommandArgument='<%#Eval("USER_ID") %>' OnClientClick="if (!confirm('Bạn muốn xóa User này ?')) return false;"><img src="/adminCp/img/delete.png"  width = "24px" height = "24px" alt="Delete User" /></asp:LinkButton>
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
