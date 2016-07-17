<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTopMenu.ascx.cs" Inherits="WN.WebApp.uc.ucTopMenu" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="WN.WebApp.cm" %>
<header id="header">
    <div id="inner-header">
        <div id="main-nav-container">
            <!--<div class="container">-->
            <div class="row">
                <div class="col-md-12 clearfix">
                    <nav id="main-nav">
                        <div id="responsive-nav">
                            <div id="responsive-nav-button">
                                Menu <span id="responsive-nav-button-icon"></span>
                            </div>
                        </div>
                        <ul class="menu clearfix">
                            <li><a class="active" href="/trang-chu">TRANG CHỦ</a> </li>
                            <%if (dataCategoryL1.Rows.Count > 0)
                              { %>
                            <li class="mega-menu-container"><a href="/danh-muc/<%=QueryString.ValidateQueryString(dataCategoryL1.Rows[0]["CAT_L1_NAME"].ToString()) %>/<%=dataCategoryL1.Rows[0]["CAT_L1_ID"].ToString() %>">DANH MỤC</a>
                                <%if (dataCategoryL1.Rows.Count > 0)
                                  { %>
                                <div class="mega-menu clearfix">
                                    <%foreach (DataRow categoryL1 in dataCategoryL1.Rows)
                                      { %>
                                    <div class="col-5">
                                        <a href="/danh-muc/<%=QueryString.ValidateQueryString(categoryL1["CAT_L1_NAME"].ToString()) %>/<%=categoryL1["CAT_L1_ID"].ToString() %>"
                                            class="mega-menu-title">
                                            <%=categoryL1["CAT_L1_NAME"].ToString() %></a>
                                        <%DataRow[] arrRowCatL2 = dataCategoryL2.Select("CAT_L1_ID = '" + categoryL1["CAT_L1_ID"] + "'"); %>
                                        <%if (arrRowCatL2.Length > 0)
                                          { %>
                                        <ul class="mega-menu-list clearfix">
                                            <%foreach (DataRow categoryL2 in arrRowCatL2)
                                              {%>
                                            <li><a href="/danh-muc/<%=QueryString.ValidateQueryString(categoryL1["CAT_L1_NAME"].ToString()) %>/<%=QueryString.ValidateQueryString(categoryL2["CAT_L2_NAME"].ToString()) %>/<%=categoryL2["CAT_L2_ID"].ToString() %>">
                                                <%=categoryL2["CAT_L2_NAME"].ToString() %></a></li>
                                            <%} %>
                                        </ul>
                                        <%} %>
                                    </div>
                                    <%} %>
                                </div>
                                <%} %>
                            </li>
                            <%} %>
                            <li><a href="/thoi-trang/nam">NAM</a> </li>
                            <li><a href="/thoi-trang/nu">NỮ</a> </li>
                            <li><a href="/lien-he">LIÊN HỆ</a></li>
                        </ul>
                    </nav>
                    <div id="quick-access">
                        <div class="form-group">
                            <div class="form-group">
                                <asp:TextBox ID="textboxProName" runat="server" class="form-control_overide" placeholder="Tìm kiếm..."></asp:TextBox>
                                <asp:Button ID="buttonSearch" runat="server" class="btn btn-custom" OnClick="buttonSearch_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End .col-md-12 -->
            </div>
            <!-- End .row -->
            <!--</div> End .container -->
        </div>
        <!-- End #nav -->
    </div>
    <!-- End #inner-header -->
</header>
<!-- End #header -->
