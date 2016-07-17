﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProduct.ascx.cs" Inherits=" WN.WebApp.adminCp.uc.ucProduct" %>
<%@ Import Namespace="WN.Common" %>
<div class="page-container-style3">
    <div class="panel panel-info">
        <div class="panel-heading">
            <b>Sản Phẩm</b> / <a href="<%=Constants.NAVIGATE_DEFAULT_PAGE  + "ucProductCU"%>"><b>Thêm Mới</b></a>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <asp:TextBox ID="textboxProName" runat="server" class="form-control_overide" placeholder="Sản phẩm"></asp:TextBox>
                 <asp:Button ID="buttonSearch" runat="server" class="btn btn-primary active"
                    Text=" Tìm kiếm " OnClick="buttonSearch_Click"/>
            </div>
            <asp:Repeater ID="repeaterProduct" runat="server" OnItemCommand="repeaterProduct_ItemCommand">
                <HeaderTemplate>
                    <div class="table-responsive">
                        <table class="table table-bordered">
                            <tr>
                                <td class="centered">
                                    <b>--</b>
                                </td>
                                 <td>
                                    <b>Sản Phẩm</b>
                                </td>
                                <td>
                                    <b>Giá</b>
                                </td>
                                <td>
                                    <b>Nam/Nữ</b>
                                </td>
                                 <td>
                                    <b>DM Cấp 2</b>
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
                             <%#Eval("PRO_HOME_PAGE") %> <%#Eval("PRO_ID") %>
                        </td>
                        <td>
                            <%#Eval("PRO_NAME")%>
                        </td>
                        <td>
                            <%#Eval("PRO_PRICE")%>
                        </td>
                        <td>
                            <%#Eval("PRO_GENDER")%>
                        </td>
                         <td>
                            <%#Eval("CAT_L2_NAME")%>
                        </td>
                        <td class="centered">
                            <asp:LinkButton ID="linkButtonUpdate" runat="server" CommandName="UPDATE_ITEM"
                                CommandArgument='<%#Eval("PRO_ID") %>'><img src="/adminCp/img/edit.png" width = "24px" height = "24px" alt="Update Product" /></asp:LinkButton>
                        </td>
                        <td class="centered">
                            <asp:LinkButton ID="linkButtonDelete" runat="server" CommandName="DELETE_ITEM"
                                CommandArgument='<%#Eval("PRO_ID") %>' OnClientClick="if (!confirm('Bạn muốn xóa sản phẩm này ?')) return false;"><img src="/adminCp/img/delete.png"  width = "24px" height = "24px" alt="Delete Product" /></asp:LinkButton>
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