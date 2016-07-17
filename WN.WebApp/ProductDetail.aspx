<%@ Page Title="" Language="C#" MasterPageFile="~/ShopHTMaster.Master" AutoEventWireup="true"
    CodeBehind="ProductDetail.aspx.cs" Inherits="WN.WebApp.ProductDetail" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="WN.WebApp.cm" %>
<%@ Import Namespace="WN.Common" %>
<asp:Content ID="contentProductDeatil" ContentPlaceHolderID="masterPageContentPlaceHolder"
    runat="server">
    <section id="content">
        <div id="fb-root"></div>
        <script>(function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.5&appId=176464176035669";
            fjs.parentNode.insertBefore(js, fjs);
            }(document, 'script', 'facebook-jssdk'));

        </script>
        <div class="container">
            <div class="sm-margin">
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-sm-6">
                            <%if (dataProImg.Rows.Count > 0)
                              { %>
                            <div id="carousel" class="carousel slide" data-ride="carousel">
                                <div class="carousel-inner">
                                    <%for (int i = 0; i < dataProImg.Rows.Count; i++)
                                      {
                                          if (i == 0)
                                              {%>
                                        <div class="item active">
                                            <div class="item-detail">
                                                <img src="<%=@"/" + Constants.PRODUCT_DIR + dataProImg.Rows [i]["IMG_NAME"].ToString() %>" />
                                            </div>
                                    </div>
                                    <%}
                                          else
                                          {%>
                                    <div class="item">
                                        <div class="item-detail">
                                            <img src="<%=@"/" + Constants.PRODUCT_DIR + dataProImg.Rows [i]["IMG_NAME"].ToString() %>" />
                                        </div>
                                    </div>
                                    <%}
                                      }%>
                                </div>
                            </div>
                            <%} %>
                        </div>
                        <div class="col-sm-6 product">
                            <div class="lg-margin visible-sm visible-xs">
                            </div>
                            
                            <%if (dataProInfo.Rows.Count > 0)
                              { %>
                            <h1 class="product-name">
                                <%=dataProInfo.Rows[0]["PRO_NAME"].ToString() %></h1>
                            <h1 class="product-price">
                                <%=dataProInfo.Rows[0]["PRO_PRICE"].ToString() %>
                                &nbsp;
                                <%if (!string.IsNullOrEmpty(dataProInfo.Rows[0]["PRO_OLD_PRICE"].ToString()))
                                  { %>
                                <span class="product-old-price">
                                    <%=dataProInfo.Rows[0]["PRO_OLD_PRICE"].ToString() %></span>
                                <%} %>
                            </h1>
                          
                            <ul class="product-list">
                                <li><span>Category: </span><a href="/danh-muc/<%=QueryString.ValidateQueryString(dataProInfo.Rows[0]["CAT_L1_NAME"].ToString()) %>/<%=dataProInfo.Rows[0]["CAT_L1_ID"].ToString()%>">
                                    <%=dataProInfo.Rows[0]["CAT_L1_NAME"].ToString().UpperCaseFirstCharacter() %></a>,
                                    <a href="/danh-muc/<%=QueryString.ValidateQueryString(dataProInfo.Rows[0]["CAT_L1_NAME"].ToString()) %>/<%=QueryString.ValidateQueryString(dataProInfo.Rows[0]["CAT_L2_NAME"].ToString()) %>/<%=QueryString.ValidateQueryString(dataProInfo.Rows[0]["CAT_L2_ID"].ToString()) %>">
                                        <%=dataProInfo.Rows[0]["CAT_L2_NAME"].ToString()%></a></li>
                                <%-- <li><span>Mã sản phẩm:</span><%=dataProInfo.Rows[0]["PRO_ID"].ToString() %></li>--%>
                            </ul>
                              <ul class="product-list">
                                <li><span>Product Code: </span> <%="il_570xN" + dataProInfo.Rows[0]["PRO_ID"].ToString() %></h1></li>
                            </ul>
                            <hr>
                            <%} %>
                            <%if (dataProImg.Rows.Count > 0)
                              { %>
                            <div class="clearfix">
                                <div id="thumbcarousel" class="carousel slide" data-interval="false">
                                    <div class="carousel-inner">
                                        <% int pos = 0;
                                           for (int i = 0; i < Math.Ceiling(dataProImg.Rows.Count * 1.0 / 4); i++)
                                           {
                                               if (i == 0)
                                               {%>
                                        <div class="item active">
                                            <% {
                                                   for (int j = 0; (j < 4 && pos < dataProImg.Rows.Count); j++)
                                                   {%>
                                            <div data-target="#carousel" data-slide-to="<%=pos.ToString()%>" class="thumb">
                                                <img src="<%=@"/" + Constants.PRODUCT_DIR + dataProImg.Rows[pos]["IMG_NAME"].ToString()%>" />
                                            </div>
                                            <% pos++;
                                                   }
                                               }%>
                                        </div>
                                        <%}
                                               else
                                               { %>
                                        <div class="item">
                                            <% {
                                                   for (int j = 0; (j < 4 && pos < dataProImg.Rows.Count); j++)
                                                   { %>
                                            <div data-target="#carousel" data-slide-to="<%=pos.ToString()%>" class="thumb">
                                                <img src="<%=@"/" + Constants.PRODUCT_DIR + dataProImg.Rows[pos]["IMG_NAME"].ToString()%>" />
                                            </div>
                                            <% pos++;
                                                   }
                                               }%>
                                        </div>
                                        <%}
                                           } %>
                                    </div>
                                    <a class="left carousel-control" href="#thumbcarousel" role="button" data-slide="prev">
                                        <span class="glyphicon glyphicon-chevron-left"></span></a><a class="right carousel-control"
                                            href="#thumbcarousel" role="button" data-slide="next"><span class="glyphicon glyphicon-chevron-right">
                                            </span></a>
                                </div>
                            </div>
                            <%} %>
                             <hr>
                        </div>
                    </div>
                    <%if (dataProInfo.Rows.Count > 0)
                      { %>
                   <div class="fb-like" data-href="http://localhost:1118/san-pham/quan-ao/dresses/vdg5er/000020" data-layout="standard" data-action="like" data-show-faces="false" data-share="true"></div>
                    
                    <div class="row">
                        <div class="md-margin">
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div>
                                <p>
                                    <%=dataProInfo.Rows[0]["PRO_DESCRIPTION"].ToString() %>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="fb-comments" data-href="http://developers.facebook.com/docs/plugins/comments/" data-numposts="5"></div>
                    <%} %>
                </div>
            </div>
            <%if (dataAlsoPurchased.Rows.Count > 0)
              { %>
            <div class="row">
                <div class="col-md-12">
                    <div class="xlg-margin">
                    </div>
                    <div id="related-portfolio-container" class="carousel-wrapper">
                        <header class="content-title">
                            <div class="title-bg">
                                <h2 class="title">
                                    Sản phẩm liên quan</h2>
                            </div>
                        </header>
                        <div class="carousel-controls">
                            <div id="related-slider-prev" class="carousel-btn carousel-btn-prev">
                            </div>
                            <div id="related-slider-next" class="carousel-btn carousel-btn-next carousel-space">
                            </div>
                        </div>
                        <div class="related-portfolio owl-carousel">
                            <%foreach (DataRow row in dataAlsoPurchased.Rows)
                              { %>
                            <div class="portfolio-item">
                                <figure>
                                    <img src="<%=@"/" + Constants.PRODUCT_DIR + row["PRO_IMG"].ToString() %>" alt="<%=row["PRO_NAME"].ToString() %>">
                                    <figcaption>
                                        <a href="<%=@"/" + Constants.PRODUCT_DIR + row["PRO_IMG"].ToString() %>" title="<%=row["PRO_NAME"].ToString() %>"
                                            data-rel="prettyPhoto" class="zoom-button"></a><a href="/san-pham/<%=QueryString.ValidateQueryString(row["CAT_L1_NAME"].ToString()) %>/<%=QueryString.ValidateQueryString(row["CAT_L2_NAME"].ToString()) %>/<%=QueryString.ValidateQueryString(row["PRO_NAME"].ToString()) %>/<%=row["PRO_ID"].ToString() %>"
                                                class="link-button"></a>
                                    </figcaption>
                                </figure>
                                <h2>
                                    <a href="/san-pham/<%=QueryString.ValidateQueryString(row["CAT_L1_NAME"].ToString()) %>/<%=QueryString.ValidateQueryString(row["CAT_L2_NAME"].ToString()) %>/<%=QueryString.ValidateQueryString(row["PRO_NAME"].ToString()) %>/<%=row["PRO_ID"].ToString() %>">
                                        <%=row["PRO_NAME"].ToString() %></a></h2>
                                <div class="my-price">
                                    <div class="my-price myprice">
                                        <%=row["PRO_PRICE"].ToString() %>
                                    </div>
                                    <%=WebTag.OldPrice(row["PRO_OLD_PRICE"].ToString())%>
                                </div>
                                <p>
                                    <a href="/danh-muc/<%=QueryString.ValidateQueryString(row["CAT_L1_NAME"].ToString()) %>/<%=row["CAT_L1_ID"].ToString()%>">
                                        <%=row["CAT_L1_NAME"].ToString().UpperCaseFirstCharacter() %></a>, <a href="/danh-muc/<%=QueryString.ValidateQueryString(row["CAT_L1_NAME"].ToString()) %>/<%=QueryString.ValidateQueryString(row["CAT_L2_NAME"].ToString()) %>/<%=QueryString.ValidateQueryString(row["CAT_L2_ID"].ToString()) %>">
                                            <%=row["CAT_L2_NAME"].ToString()%></a>
                                </p>
                            </div>
                            <% } %>
                        </div>
                    </div>
                </div>
            </div>
            <%} %>
        </div>
    </section>
</asp:Content>
