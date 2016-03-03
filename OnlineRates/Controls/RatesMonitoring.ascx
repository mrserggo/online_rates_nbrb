<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RatesMonitoring.ascx.cs" Inherits="OnlineRates.Controls.RatesMonitoring" %>
<link href="../Styles/RatesMonitoring.css" rel="stylesheet" type="text/css" />
<asp:Repeater ID="rptRatesMonitoring" runat="server" 
    onitemdatabound="rptRatesMonitoring_ItemDataBound">
    <HeaderTemplate>
		<table id="rates_monitoring_table" cellspacing="0">
			<thead>
				<tr>
					<th class="blackTitle" colspan="2">
						<asp:Literal ID="litTitle" runat="server"/>
					</th>
				</tr>
				<tr>
					<th>
						<asp:Literal runat="server" Text="Курс" />
					</th>
					<th>
						<asp:Literal runat="server" Text="Дата"  />
					</th>
				</tr>
			</thead>
	</HeaderTemplate>
    <ItemTemplate>
		<tr>
			<td class="borderLeft borderRight">
				<asp:Literal ID="litCurrencyValue" runat="server"/>
			</td>
			<td class="borderLeft borderRight">
				<asp:Literal ID="litDate" runat="server"/>
			</td>
		</tr>
	</ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>