<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProductList.ascx.cs"
    Inherits="WN.WebApp.uc.ucProductList" %>
<%@ Import Namespace="WN.WebApp.cm" %>
<%@ Import Namespace="WN.Common" %>
<div class="col-md-3 col-sm-4 col-xs-6 portfolio-item photography">
    <figure>
        <img src="<%#@"/" + Constants.PRODUCT_DIR + Eval("PRO_IMG").ToString() %>" alt="<%#Eval("PRO_NAME").ToString() %>">
        <figcaption>
            <a href="<%#@"/" + Constants.PRODUCT_DIR + Eval("PRO_IMG").ToString() %>" title="<%#Eval("PRO_NAME").ToString() %>"
                data-rel="prettyPhoto" class="zoom-button"></a><a href="/san-pham/<%#QueryString.ValidateQueryString(Eval("CAT_L1_NAME").ToString()) %>/<%#QueryString.ValidateQueryString(Eval("CAT_L2_NAME").ToString()) %>/<%#QueryString.ValidateQueryString(Eval("PRO_NAME").ToString()) %>/<%#Eval("PRO_ID").ToString() %>" class="link-button"></a>
        </figcaption>
    </figure>
    <h2>
        <a href="/san-pham/<%#QueryString.ValidateQueryString(Eval("CAT_L1_NAME").ToString()) %>/<%#QueryString.ValidateQueryString(Eval("CAT_L2_NAME").ToString()) %>/<%#QueryString.ValidateQueryString(Eval("PRO_NAME").ToString()) %>/<%#Eval("PRO_ID").ToString() %>">
            <%#Eval("PRO_NAME").ToString() %></a></h2>
    <div class="my-price">
        <div class="my-price myprice">
            <%#Eval("PRO_PRICE").ToString() %>
        </div>
        <%#WebTag.OldPrice(Eval("PRO_OLD_PRICE").ToString())%>
    </div>
    <p>
         <a href="/danh-muc/<%#QueryString.ValidateQueryString(Eval("CAT_L1_NAME").ToString()) %>/<%#Eval("CAT_L1_ID").ToString()%>">
            <%#Eval("CAT_L1_NAME").ToString().UpperCaseFirstCharacter() %></a>,
        <a href="/danh-muc/<%#QueryString.ValidateQueryString(Eval("CAT_L1_NAME").ToString()) %>/<%#QueryString.ValidateQueryString(Eval("CAT_L2_NAME").ToString()) %>/<%#QueryString.ValidateQueryString(Eval("CAT_L2_ID").ToString()) %>">
            <%#Eval("CAT_L2_NAME").ToString()%></a>
    </p>
</div>
