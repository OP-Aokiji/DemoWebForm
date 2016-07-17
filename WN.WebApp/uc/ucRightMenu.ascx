<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRightMenu.ascx.cs"
    Inherits="WN.WebApp.uc.ucRightMenu" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="WN.WebApp.cm" %>
<%if (dataCategoryL1.Rows.Count > 0)
  { %>
<div class="widget category-accordion">
    <h3>
       CATEGORY</h3>
    <div class="panel-group" id="accordion">
        <%foreach (DataRow categoryL1 in dataCategoryL1.Rows)
          {%>
        <div class="panel panel-custom">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <%=categoryL1["CAT_L1_NAME"].ToString() %>
                    <a data-toggle="collapse" href="#<%=categoryL1["CAT_L1_ID"].ToString()%>"><span
                        class="icon-box">&plus;</span> </a>
                </h4>
            </div>
            <div id="<%=categoryL1["CAT_L1_ID"].ToString()%>" class="panel-collapse collapse in">
                <%DataRow[] arrCategoryL2 = dataCategoryL2.Select("CAT_L1_ID = '" + categoryL1["CAT_L1_ID"] + "'"); %>
                  <%if (arrCategoryL2.Length > 0) {%>
                
                <div class="panel-body">
                    <ul class="category-accordion-list">
                    <%foreach (DataRow categoryL2 in arrCategoryL2)
	                { %>
		                <li><a href="/danh-muc/<%=QueryString.ValidateQueryString(categoryL1["CAT_L1_NAME"].ToString()) %>/<%=QueryString.ValidateQueryString(categoryL2["CAT_L2_NAME"].ToString()) %>/<%=categoryL2["CAT_L2_ID"].ToString() %>"><%=categoryL2["CAT_L2_NAME"] %></a></li>
	                <%} %>
                    </ul>
                </div>
                <%} %>
            </div>
        </div>
        <%} %>
    </div>
</div>
<%} %>