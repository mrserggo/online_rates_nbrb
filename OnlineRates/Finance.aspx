<%@ Page Title="" Language="C#" MasterPageFile="~/Rates.Master" AutoEventWireup="true" CodeBehind="Finance.aspx.cs" Inherits="OnlineRates.Finance" %>
<%@ Register TagPrefix="asp" TagName="MainRates" Src="~/Controls/MainRatesNBRBControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<ul class="site-nav">
		<li><a href="RatesNBRB.aspx">Курсы валют (НБРБ)</a></li>
		<li><a href="CrossRatesandConverter.aspx">Конвертер валют</a></li>
		<li><a href="RatesInBanks.aspx">Курсы валют в г. Минске</a></li>
        <li class="last">
          <asp:LinkButton ID="lbtnExit" runat="server" 
            CausesValidation="False" onclick="lbtnExit_Click">Выход</asp:LinkButton></li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="containerFinance">
		    <table id="event_table" cellspacing="0">
			    <tr>
				    <td class="first_column header_news text_center">
					    Финансовое событие
				    </td>
				    <td class="second_column header_news text_center">
					    Дата
				    </td>
			    </tr>
			    <tr>
				    <td>
						<div class="news">
							Последняя дата установления Национальным банком Республики Беларусь цен покупки и продажи драгоценных металлов в виде мерных слитков
						</div>
				    </td>
				    <td class="text_center">
						<asp:Label ID="lblIngotsLastDate" runat="server" Text="Label"></asp:Label>
				    </td>
			    </tr>
			    <tr>
				    <td>
						<div class="news">
							Последняя дата установления Национальным банком Республики Беларусь официального курса белорусского рубля по отношению к иностранным валютам на ежедневной основе
						</div>
					</td>
				    <td class="text_center">
					    <asp:Label ID="lblLastDailyExRatesDate" runat="server" Text="Label"></asp:Label>
				    </td>
			    </tr>
			    <tr>
				    <td>
						<div class="news">
							Последняя дата установления Национальным банком Республики Беларусь цен на драгоценные металлы в виде банковских слитков
						</div>
					</td>
				    <td class="text_center">
					    <asp:Label ID="lblMetalsLastDate" runat="server" Text="Label"></asp:Label>
				    </td>
			    </tr>
			    <tr>
				    <td>
						<div class="news">
							Последняя дата установления курса белорусского рубля по отношению к основным иностранным валютам по итогам дополнительной торговой сессии ОАО "Белорусская валютно-фондовая биржа"
						</div>
					</td>
				    <td class="text_center">
					    <asp:Label ID="lblStockAddRatesLastDate" runat="server" Text="Label"></asp:Label>
				    </td>
			    </tr>
		    </table>
		<div align="center" class="margin_main_rates">
			<div>
				<table>
					<tr>
						<td>
							<asp:MainRates id="mainRatesTableToday" runat="server"/>
						</td>
						<td>
							<asp:MainRates id="mainRatesTableTomorrow" runat="server"/>
						</td>
					</tr>
				</table>
			</div>
		</div>
		<div style="clear: both;">
			
		</div>
    </div>
</asp:Content>
