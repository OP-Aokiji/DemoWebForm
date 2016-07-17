<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTagSEO.ascx.cs" Inherits="WN.WebApp.adminCp.uc.ucTagSEO" %>
<%@ Import Namespace="WN.Common" %>
<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>Tag</b> / <a href="<%=Constants.NAVIGATE_DEFAULT_PAGE  + "ucTagSEOCU"%>"><b>Thêm Mới</b></a>
        </div>
        <div class="panel-body">
            <asp:Repeater ID="repeaterTagSEO" runat="server" OnItemCommand="repeaterTagSEO_ItemCommand">
                <HeaderTemplate>
                    <div class="table-responsive">
                        <table class="table table-bordered">
                            <tr>
                                <td class="centered">
                                    <b>--</b>
                                </td>
                                <td>
                                    <b>Tag</b>
                                </td>
                                <td>
                                    <b>Tag URL</b>
                                </td>
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
                        <td class="centered">
                            <%#Eval("TAG_ID") %>
                        </td>
                        <td>
                            <%#Eval("TAG_NAME")%>
                        </td>
                        <td>
                            <%#Eval("TAG_URL")%>
                        </td>
                        <td class="centered">
                            <asp:LinkButton ID="linkButtonUpdate" runat="server" CommandName="UPDATE_ITEM" CommandArgument='<%#Eval("TAG_ID") %>'><img src="/adminCp/img/edit.png" width = "24px" height = "24px" alt="Update Tag SEO" /></asp:LinkButton>
                        </td>
                        <td class="centered">
                            <asp:LinkButton ID="linkButtonDelete" runat="server" CommandName="DELETE_ITEM" CommandArgument='<%#Eval("TAG_ID") %>'
                                OnClientClick="if (!confirm('Bạn muốn xóa tag này ?')) return false;"><img src="/adminCp/img/delete.png"  width = "24px" height = "24px" alt="Delete Tag SEO" /></asp:LinkButton>
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
