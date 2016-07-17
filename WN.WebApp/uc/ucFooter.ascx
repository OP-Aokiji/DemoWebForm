<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFooter.ascx.cs" Inherits="WN.WebApp.uc.ucFooter" %>
<%@ Import Namespace = "System.Data" %>
<%@ Import Namespace="WN.WebApp.cm" %>
<footer id="footer">
    <div id="inner-footer">
        <div class="row">
            <div class="col-md-3 col-sm-4 col-xs-12 widget">
                <h3>
                    SHOP HT MENU</h3>
                <ul class="links">
                    <li><a href="/trang-chu">Trang chủ</a></li>
                    <li><a href="/thoi-trang/nam">Thời trang Nam</a></li>
                    <li><a href="/thoi-trang/nu">Thời trang Nữ</a></li>
                    <li><a href="/lien-he">Liên hệ</a></li>
                </ul>
            </div>
            <div class="col-md-3 col-sm-4 col-xs-12 widget">
                <h3>
                    CATEGORY</h3>
                <%if (dataCategoryL1.Rows.Count > 0)
                  { %>
                    <ul class="links">
                        <%foreach (DataRow row in dataCategoryL1.Rows)
                          {%>
                                <li><a href="/danh-muc/<%=QueryString.ValidateQueryString(row["CAT_L1_NAME"].ToString()) %>/<%=row["CAT_L1_ID"].ToString() %>"><%=row["CAT_L1_NAME"].ToString() %></a></li>
                          <%} %>
                    </ul>
                <%} %>
            </div>
            <div class="col-md-3 col-sm-4 col-xs-12 widget">
                <h3>
                    <%=dataResult.Rows[0]["SHOP_NAME"].ToString() %></h3>
                <ul class="contact-list">
                    <li><strong>
                        <%=dataResult.Rows[0]["SHOP_ADDRESS"].ToString()%></strong></li>
                    <li>
                        <li class="email">
                            <%=dataResult.Rows[0]["SHOP_EMAIL"].ToString()%></li>
                        <li class="skype">
                            <%=dataResult.Rows[0]["SHOP_SKYPE"].ToString()%></li>
                        <li class="phone">
                            <%=dataResult.Rows[0]["SHOP_PHONE"].ToString()%></li>
                </ul>
            </div>
            <div class="clearfix visible-sm">
            </div>
            <div class="col-md-3 col-sm-12 col-xs-12 widget">
                <h3>
                    FACEBOOK LIKE BOX</h3>
                <div class="facebook-likebox">
                    <iframe src="http://www.facebook.com/plugins/likebox.php?href=http%3A%2F%2Fwww.facebook.com%2Fenvato&amp;colorscheme=dark&amp;show_faces=true&amp;header=false&amp;stream=false&amp;show_border=false">
                    </iframe>
                </div>
            </div>
            <!-- End .widget -->
        </div>
        <!-- End .row -->
    </div>
    <!-- End .container -->
</footer>
<!-- End #footer -->
