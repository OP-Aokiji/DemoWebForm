<%@ Page Title="" Language="C#" MasterPageFile="~/ShopHTMaster.Master" AutoEventWireup="true"
    CodeBehind="ContactUs.aspx.cs" Inherits="WN.WebApp.ContactUs" %>

<asp:Content ID="contentContactUs" ContentPlaceHolderID="masterPageContentPlaceHolder"
    runat="server">
    <section id="content">
        <div class="sm-margin">
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="input-icon input-icon-user"></span><span
                            class="input-text">Họ tên&#42;</span></span>
                        <asp:TextBox runat="server" name="contact-name" ID="textboxContactName" required
                            class="form-control input-lg" placeholder="Họ tên"></asp:TextBox>
                    </div>
                    <!-- End .input-group -->
                    <div class="input-group">
                        <span class="input-group-addon"><span class="input-icon input-icon-email"></span><span
                            class="input-text">Email&#42;</span></span>
                        <asp:TextBox runat="server" name="contact-email" ID="textboxContactEmail" required
                            class="form-control input-lg" placeholder="Email"></asp:TextBox>
                    </div>
                    <!-- End .input-group -->
                    <div class="input-group">
                        <span class="input-group-addon"><span class="input-icon input-icon-subject"></span><span
                            class="input-text">Tiêu đề&#42;</span></span>
                        <asp:TextBox runat="server" name="contact-subject" ID="textboxContactSubject" required
                            class="form-control input-lg" placeholder="Tiêu đề"></asp:TextBox>
                    </div>
                    <div class="input-group textarea-container">
                        <span class="input-group-addon"><span class="input-icon input-icon-message"></span><span
                            class="input-text">Tin nhắn&#42;</span></span>
                        <asp:TextBox runat="server" name="contact-message" ID="textboxContactMessage" TextMode="MultiLine"
                            class="form-control" Columns="30" Rows="6" placeholder="Tin nhắn"></asp:TextBox>
                    </div>
                    <div class="centered">
                        <asp:Button ID="buttonSendMsg" runat="server" Text=" Gửi Tin Nhắn " class="btn btn-custom-2 md-margin"
                            OnClick="buttonSendMsg_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="text-center">
                    <div id="map" class="map">
                    </div>
                    <hr />
                    <h4>
                        <asp:Label runat="server" ID="labelShopName"></asp:Label></h4>
                    <div>
                        <b>
                        <asp:Label runat="server" ID="labelShopAddress"></asp:Label></b><br />
                        <asp:Label runat="server" ID="labelShopPhone"></asp:Label><br />
                        <asp:Label runat="server" ID="labelShopEmail"></asp:Label><br />
                        <asp:Label runat="server" ID="labelShopSkype"></asp:Label><br />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
