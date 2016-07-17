<%@ Page Title="" Language="C#" MasterPageFile="~/ShopHTMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WN.WebApp.Default" %>

<%@ Import Namespace="WN.WebApp.cm" %>
<%@ Import Namespace="WN.Common" %>
<%@ Register Src="~/uc/ucImageSlider.ascx" TagPrefix="shopHT" TagName="ucImageSlider" %>
<%@ Register Src="~/uc/ucProductList.ascx" TagPrefix="shopHT" TagName="ucProductList" %>

<asp:Content ID="contentDefault" ContentPlaceHolderID="masterPageContentPlaceHolder"
    runat="server">
    <shopHT:ucImageSlider runat="server" ID="ucImageSlider" />
    <section id="content">
        <div class="row">
            <div class="col-md-12">
                <div class="row portfolio-item-container" data-max-col="4">
                    <asp:ListView runat="server" ID="listViewProduct">
                        <ItemTemplate>
                            <shopHT:ucProductList runat="server" ID="ucProductList" />
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
            <div class="paging">
                <p>
                    <asp:DataPager ID="dataPagerPaging" PagedControlID="listViewProduct" runat="server"
                        PageSize="20" QueryStringField="page">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="false" PreviousPageText="‹" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowPreviousPageButton="false" NextPageText="›" />
                        </Fields>
                    </asp:DataPager>
                </p>
            </div>
            <div class="sm-margin">
            </div>
        </div>
    </section>
</asp:Content>
