<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainRatesNBRBControl.ascx.cs" Inherits="OnlineRates.Controls.MainRatesNBRBControl" %>
<link href="../Styles/MainRatesStyle.css" rel="stylesheet" type="text/css" />
<asp:Repeater ID="RepeaterRatesMainCurrencies" runat="server" 
    onitemdatabound="RepeaterRatesMainCurrencies_ItemDataBound">
    <HeaderTemplate>
		<table id="main_rates_block" cellspacing="0">
			<thead>
				<tr>
					<th colspan="5" class="redTitle">
						<asp:Literal ID="litDate" runat="server"/>
					</th>
				</tr>
				<tr>
					<th colspan="2">
						<asp:Literal runat="server" Text="Валюта" />
					</th>
					<th colspan="3">
						<asp:Literal runat="server" Text="Динамика изменения курсов НБ РБ"  />
					</th>
				</tr>
			</thead>
	</HeaderTemplate>
    <ItemTemplate>
		<tr>
			<td class="borderLeft">
				<asp:Literal ID="litCurrencyName" runat="server"/>
			</td>
			<td class="borderLeftRightNone">
                <asp:Image ID="imgCurrency" runat="server" />
			</td>
			<td class="borderLeft">
				<asp:Literal ID="litRate" runat="server"/>
			</td>
			<td class="borderLeftRightNone">
				<asp:Image ID="imgState" runat="server" />
			</td>
			<td class="rate_change borderRight">
				<asp:Literal ID="litChange" runat="server" />
			</td>
		</tr>
	</ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>
