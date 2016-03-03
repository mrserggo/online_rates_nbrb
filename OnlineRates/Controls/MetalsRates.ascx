<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MetalsRates.ascx.cs" Inherits="OnlineRates.Controls.MetalsRates" %>
<link href="../Styles/Metals.css" rel="stylesheet" type="text/css" />
<!--   Драгметаллы  -->
<asp:Repeater ID="rptMetalsRates" runat="server" 
    onitemdatabound="rptMetalsRates_ItemDataBound">
	<HeaderTemplate>
		<table id="metals_rates_table">
			<thead>
                <tr>
                    <th colspan="4" class="redMetalTitle">
						<asp:Literal ID="Literal1" runat="server" Text="Цены на мерные слитки"/>
					</th>
                </tr>
				<tr>
					<th>
						<asp:Literal ID="Literal2" runat="server" Text="Драгметалл" />
					</th>
                    <th>
						<asp:Literal ID="Literal3" runat="server" Text="Масса" />
					</th>
                    <th>
						<asp:Literal ID="Literal4" runat="server" Text="Покупка" />
					</th>
                    <th>
						<asp:Literal ID="Literal5" runat="server" Text="Продажа" />
					</th>
				</tr>
			</thead>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<td class="borderLeft">
				<asp:Literal ID="litMetalName" runat="server"/>
			</td>
            <td class="borderLeft">
                <asp:Literal ID="litWeight" runat="server"/>
            </td>
            <td class="borderLeft">
                <asp:Literal ID="litBuy" runat="server"/>
            </td>
            <td class="borderLeft borderRight">
                <asp:Literal ID="Sale" runat="server"/>
            </td>
		</tr>
	</ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>