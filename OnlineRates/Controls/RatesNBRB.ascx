<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RatesNBRB.ascx.cs" Inherits="OnlineRates.Controls.RatesNBRB" %>
<link href="../Styles/MainRatesStyle.css" rel="stylesheet" type="text/css" />
<asp:Repeater ID="rptRates" runat="server" 
    onitemdatabound="rptRates_ItemDataBound">
    <HeaderTemplate>
		<table id="main_rates_block" cellspacing="0" class="all_rates_table">
			<thead>
				<tr>
					<th colspan="3" class="redTitle">
						<asp:Literal ID="litDate" runat="server"/>
					</th>
				</tr>
				<tr>
					<th>
						<asp:Literal runat="server" Text="Код" />
					</th>
                    <th>
						<asp:Literal runat="server" Text="Валюта" />
					</th>
                    <th>
						<asp:Literal runat="server" Text="Курс" />
					</th>
				</tr>
			</thead>
	</HeaderTemplate>
    <ItemTemplate>
		<tr>
			<td class="borderLeft">
				<asp:Literal ID="litCode" runat="server"/>
			</td>
			<td class="borderLeft">
                <asp:Literal ID="litCurrency" runat="server" />
			</td>
			<td class="borderLeft borderRight">
				<asp:Literal ID="litRate" runat="server"/>
			</td>
		</tr>
	</ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>
