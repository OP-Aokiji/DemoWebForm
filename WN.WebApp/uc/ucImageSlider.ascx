<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucImageSlider.ascx.cs"
    Inherits="WN.WebApp.uc.ucImageSlider" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="WN.Common" %>
<%if (dataBanner.Rows.Count > 0)
  { %>
<div class="row">
    <div class="col-md-12">
        <div class="carousel slide" data-ride="carousel" id="carousel-example">
            <ol class="carousel-indicators">
                <%for (int i = 0; i < dataBanner.Rows.Count; i++)
                  {
                      if (i == 0)
                      { %>
                <li data-target="#carousel-example" data-slide-to="0" class="active"></li>
                <%}
                      else
                      {%>
                <li data-target="#carousel-example" data-slide-to="<%=i.ToString() %>"></li>
                <%} %>
                <%} %>
            </ol>
            <div class="carousel-inner">
                <%for (int i = 0; i < dataBanner.Rows.Count; i++)
                  {
                      if (i == 0)
                      { %>
                <div class="item active">
                    <img src="<%=@"/" + Constants.BANNER_DIR + dataBanner.Rows[0]["IMG_NAME"].ToString()  %>"
                        alt="<%=dataBanner.Rows[0]["IMG_NAME"].ToString() %>" />
                </div>
                <%}
                   else
                   { %>
                <div class="item">
                    <img src="<%=@"/" + Constants.BANNER_DIR + dataBanner.Rows[i]["IMG_NAME"].ToString()  %>"
                        alt="<%=dataBanner.Rows[i]["IMG_NAME"].ToString() %>" />
                </div>
                <%}
                  } %>
            </div>
            <a href="#carousel-example" class="left carousel-control" data-slide="prev"><span
                class="glyphicon glyphicon-chevron-left"></span></a><a href="#carousel-example" class="right carousel-control"
                    data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span>
            </a>
        </div>
    </div>
</div>
<div class="xs-margin">
</div>
<%} %>
