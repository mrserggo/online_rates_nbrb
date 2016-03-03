<%@ Page Title="" Language="C#" MasterPageFile="~/Rates.Master" AutoEventWireup="true" CodeBehind="RatesInBanks.aspx.cs" Inherits="OnlineRates.RatesInBanks"%>
<%@ Register TagPrefix="asp" TagName="RatesInBanks" Src="~/Controls/RatesInBanks.ascx" %>
<%@ Register TagPrefix="asp" TagName="EditRateControl" Src="~/Controls/ControlForEditRate.ascx" %>
<%@ Register TagPrefix="asp" TagName="AddRateControl" Src="~/Controls/ControlForAddRate.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<ul class="site-nav">
        <li><a href="Finance.aspx">На главную</a></li>
		<li><a href="RatesNBRB.aspx">Курсы валют (НБРБ)</a></li>
		<li><a href="CrossRatesandConverter.aspx">Конвертер валют</a></li>
        <li class="last">
          <asp:LinkButton ID="lbtnExit" runat="server" 
            CausesValidation="False" onclick="lbtnExit_Click">Выход</asp:LinkButton></li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div id="rates_in_Minsk">
	<!-- <asp:Button ID="TestAdd" runat="server" Text="TestAdd"/> -->
	<asp:RatesInBanks id="RatesInBanksControl" runat="server" />

    <asp:EditRateControl id="UpdateRateControl" runat="server" Visible="false" />

    <asp:AddRateControl id="AddRateControl" runat="server" Visible="false" />
</div>
</asp:Content>