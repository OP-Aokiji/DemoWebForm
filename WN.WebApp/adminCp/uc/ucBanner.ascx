<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBanner.ascx.cs" Inherits="WN.WebApp.adminCp.uc.ucBanner" %>
<%@ Import Namespace="WN.Common" %>
<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>Banner</b> / <a href="<%=Constants.NAVIGATE_DEFAULT_PAGE  + "ucBannerCU"%>"><b>Thêm
                Mới</b></a>
        </div>
        <div class="panel-body">
            <asp:Repeater ID="repeaterBanner" runat="server" OnItemCommand="repeaterBanner_ItemCommand">
                <HeaderTemplate>
                    <div class="table-responsive">
                        <table class="table-no-border">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="centered" colspan="2">
                            <img src="<%#@"/" + Constants.BANNER_DIR + Eval("IMG_NAME") %>" alt="<%#Eval("IMG_NAME")%>"
                                class="img-responsive" width="800px" height="250px" />
                            <br />
                              (<%#Eval("IMG_NAME")%>)
                        </td>
                    </tr>
                    <tr>
                        <td class="_right">
                            <asp:LinkButton ID="linkButtonUpdate" runat="server" CommandName="UPDATE_ITEM" CommandArgument='<%#Eval("IMG_ID") %>'><img src="/adminCp/img/edit.png" width = "24px" height = "24px" alt="Update Banner" /></asp:LinkButton>&nbsp;
                        </td>
                        <td class="_left">
                            &nbsp;<asp:LinkButton ID="linkButtonDelete" runat="server" CommandName="DELETE_ITEM" CommandArgument='<%#Eval("IMG_ID") %>'
                                OnClientClick="if (!confirm('Bạn muốn xóa banner này ?')) return false;"><img src="/adminCp/img/delete.png"  width = "24px" height = "24px" alt="Delete Banner" /></asp:LinkButton>
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table> </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
