<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTag.ascx.cs" Inherits="WN.WebApp.uc.ucTag" %>
<%@ Import Namespace="System.Data" %>
<%if(dataTag.Rows.Count > 0) {%>
<div class="widget tags">
    <h3>TAG</h3>
    <ul class="tags-list">
        <%foreach (DataRow row in dataTag.Rows)
          {%>
               <li><a href="<%=row["TAG_URL"].ToString()%>" target="_blank"><%=row["TAG_NAME"].ToString()%></a></li>
          <%} %>
    </ul>
</div>
<%} %>
