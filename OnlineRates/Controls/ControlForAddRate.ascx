<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlForAddRate.ascx.cs" Inherits="OnlineRates.Controls.ControlForAddRate" %>
<link href="../Styles/EditRate.css" rel="stylesheet" type="text/css" />
<div style="margin-top: 20px;">
    <table id="edit_rate_table">
        <thead>
        <tr>
            <th colspan="8" class="redTitle">
                Добавление курсов валют
            </th>
        </tr>
        <tr>
            <th style="width: 199px;">
                Банк
            </th>
            <th style="width: 90px;">
                USD пок.
            </th>
            <th style="width: 90px;">
                USD прод.
            </th>
            <th style="width: 88px;">
                EUR пок.
            </th>
            <th style="width: 89px;">
                EUR прод.
            </th>
            <th style="width: 89px;">
                RUB пок.
            </th>
            <th style="width: 89px;">
                RUB прод.
            </th>
            <th>
                Сохранить/Отменить
            </th>
        </tr>
        </thead>
        <tr>
            <td>
                <asp:DropDownList ID="ddlFreeBanksToAddRateToday" runat="server" Width="170px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbUSDBuying" runat="server" Width="50px" ToolTip="Разделитель - запятая"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDecimalWithPoint1" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbUSDBuying" Display="Dynamic" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDecimalWithPoint1" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbUSDBuying" 
                            ValidationExpression="^\d*\,?\d*$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="tbUSDSelling" runat="server" Width="50px" ToolTip="Разделитель - запятая"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDecimalWithPoint2" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbUSDSelling" Display="Dynamic" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDecimalWithPoint2" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbUSDSelling" 
                            ValidationExpression="^\d*\,?\d*$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="tbEURBuying" runat="server" Width="50px" ToolTip="Разделитель - запятая"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDecimalWithPoint3" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbEURBuying" Display="Dynamic" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDecimalWithPoint3" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbEURBuying" 
                            ValidationExpression="^\d*\,?\d*$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="tbEURSelling" runat="server" Width="50px" ToolTip="Разделитель - запятая"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDecimalWithPoint4" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbEURSelling" Display="Dynamic" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDecimalWithPoint4" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbEURSelling" 
                            ValidationExpression="^\d*\,?\d*$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="tbRUBBuying" runat="server" Width="50px" ToolTip="Разделитель - запятая"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvDecimalWithPoint5" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbRUBBuying" Display="Dynamic" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDecimalWithPoint5" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbRUBBuying" 
                            ValidationExpression="^\d*\,?\d*$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="tbRUBSelling" runat="server" Width="50px" ToolTip="Разделитель - запятая"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvDecimalWithPoint6" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbRUBSelling" Display="Dynamic" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDecimalWithPoint6" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbRUBSelling" 
                            ValidationExpression="^\d*\,?\d*$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
            <td>    
                <div>
                    <div style="float: left;">
                        <asp:ImageButton ID="ibtnSaveAddedRate" runat="server" 
                    ImageUrl="~/Images/RatesInBanks/onebit_12.png"
                    Height="30px" Width="30px" onclick="ibtnSaveAddedRate_Click" />
                    </div>
                   <div style="float: left;">
                        <asp:ImageButton ID="ibtnCansel" runat="server" 
                    ImageUrl="~/Images/RatesInBanks/onebit_11.png"
                    Height="30px" Width="30px" onclick="ibtnCansel_Click"
                    CausesValidation="False" />
                   </div>
                </div>
            </td>
        </tr>
    </table>			
</div>