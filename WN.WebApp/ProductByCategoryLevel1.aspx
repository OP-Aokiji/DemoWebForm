<%@ Page Title="" Language="C#" MasterPageFile="~/ShopHTMaster.Master" AutoEventWireup="true"
    CodeBehind="ProductByCategoryLevel1.aspx.cs" Inherits="WN.WebApp.ProductByCategoryLevel1" %>

<%@ Import Namespace="WN.WebApp.cm" %>
<%@ Import Namespace="WN.Common" %>
<%@ Register Src="~/uc/ucProductList.ascx" TagPrefix="shopHT" TagName="ucProductList" %>
<%@ Register Src="~/uc/ucRightMenu.ascx" TagPrefix="shopHT" TagName="ucRightMenu" %>
<%@ Register Src="~/uc/ucTag.ascx" TagPrefix="shopHT" TagName="ucTag" %>
<asp:Content ID="contentProductByCategoryLevel1" ContentPlaceHolderID="masterPageContentPlaceHolder"
    runat="server">
    <section id="content">
        <div class="sm-margin">
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-9 col-sm-8 col-xs-12">
                        <div class="row portfolio-item-container" data-max-col="3">
                            <asp:ListView runat="server" ID="listViewProduct">
                                <ItemTemplate>
                                    <shopHT:ucProductList runat="server" ID="ucProductList" />
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <div class="paging">
                            <p>
                                <asp:DataPager ID="dataPagerPaging" PagedControlID="listViewProduct" runat="server"
                                    PageSize="15" QueryStringField="page">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="false" PreviousPageText="‹" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowPreviousPageButton="false" NextPageText="›" />
                                    </Fields>
                                </asp:DataPager>
                            </p>
                        </div>
                    </div>
                    <aside class="col-md-3 col-sm-4 col-xs-12 sidebar">
                        <shopHT:ucRightMenu runat="server" ID="ucRightMenu" />
                        <shopHT:ucTag runat="server" ID="ucTag" />
                    </aside>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
