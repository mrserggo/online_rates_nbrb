<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RatesInBanks.ascx.cs" Inherits="OnlineRates.Controls.RatesInBanks" %>
<link href="../Styles/RatesInBanks.css" rel="stylesheet" type="text/css" />
<asp:Repeater ID="rptRatesInBanks" runat="server"
onitemdatabound="rptRatesInBanks_ItemDataBound" 
	onitemcommand="rptRatesInBanks_ItemCommand"
	EnableViewState="true">
    <HeaderTemplate>
		<table id="rates_in_banks_table" cellspacing="0">
			<thead>
				<tr>
					<th class="redTitle" colspan="7">
						<asp:Literal ID="litTitle" runat="server"/>
					</th>
				</tr>
				<tr>
					<th style="text-align: left;">
						&nbsp;<asp:Literal runat="server" Text="Банк" />
					</th>
					<th colspan="2">
						<asp:Literal runat="server" Text="USD пок./прод."  />
					</th>
					<th colspan="2">
						<asp:Literal runat="server" Text="EUR пок./прод."  />
					</th>
					<th colspan="2">
						<asp:Literal runat="server" Text="RUB пок./прод."  />
					</th>
					<asp:Panel runat="server" ID="pAdminHeader">
					<th>
						<asp:ImageButton ID="ibtnAddRate" runat="server" 
                        ImageUrl="~/Images/RatesInBanks/onebit_31.png" CommandName = "AddNewRate" CommandArgument = "true" Width="30" Height="30" />
					</th>
					</asp:Panel>
				</tr>
			</thead>
	</HeaderTemplate>
    <ItemTemplate>
		<tr>
			<td class="borderLeft" style="text-align: left;">
				<asp:HyperLink ID="hlBankInfo" runat="server">HyperLink</asp:HyperLink>
			</td>
			<td class="borderLeft">
                <asp:Literal ID="litUSD_Buying" runat="server"/>
			</td>
			<td class="borderLeft">
                <asp:Literal ID="litUSD_Selling" runat="server"/>
			</td>
			<td class="borderLeft">
				<asp:Literal ID="litEUR_Buying" runat="server"/>
			</td>
			<td class="borderLeft">
				<asp:Literal ID="litEUR_Selling" runat="server"/>
			</td>
			<td class="borderLeft">
				<asp:Literal ID="litRUB_Buying" runat="server"/>
			</td>
			<td class="borderLeft borderRight">
				<asp:Literal ID="litRUB_Selling" runat="server"/>
			</td>
			<asp:Panel runat="server" ID="pAdmin">
			<td class="borderRight">

                <asp:ImageButton ID="ibtnUpdateRate" runat="server" CommandName="UpdateRate" 
                    ImageUrl="~/Images/RatesInBanks/onebit_39.png" Width="30" Height="30" />
                <asp:ImageButton ID="ibtnDeleteRate" runat="server" CommandName="DeleteRate" 
                    ImageUrl="~/Images/RatesInBanks/onebit_33.png" Height="30" Width="30" />

			</td>
			</asp:Panel>
		</tr>
	</ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>
