<%@ Page Title="" Language="C#" MasterPageFile="~/Rates.Master" AutoEventWireup="true" CodeBehind="RatesNBRB.aspx.cs" Inherits="OnlineRates.RatesNBRB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="asp" TagName="AllMetalsRates" Src="~/Controls/MetalsRates.ascx" %>
<%@ Register TagPrefix="asp" TagName="AllRates" Src="~/Controls/RatesNBRB.ascx" %>
<%@ Register TagPrefix="asp" TagName="RatesMonitoring" Src="~/Controls/RatesMonitoring.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>Данные из НБ РБ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<ul class="site-nav">
		<li><a href="Finance.aspx">На главную</a></li>
		<li><a href="CrossRatesandConverter.aspx">Конвертер валют</a></li>
		<li><a href="RatesInBanks.aspx">Курсы валют в г. Минске</a></li>
        <li class="last">
          <asp:LinkButton ID="lbtnExit" runat="server" 
            CausesValidation="False" onclick="lbtnExit_Click">Выход</asp:LinkButton></li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<div id="containerRatesNBRB">
        <div>
            <table id="rates_monitoring_header">
                <tr>
                    <td colspan="3" class="redText borderLeft borderTop borderRight">
                        Динамика изменения курсов
                    </td>
                </tr>
                <tr>
                    <td class="column1 borderLeft borderRight">
                        Период мониторинга
                    </td>
                    <td colspan="2" class="borderRight">
                        Анализируемая валюта
                    </td>
                </tr>
                <tr style="font-size: 12px;">
                    <td class="borderLeft borderRight">
                        <div align="center">
                        <!-- выбор периода-->
                        <table>
    				            <tr>
					            <td>
						            с&nbsp;&nbsp;
					            </td>
					            <td>
						            <asp:TextBox ID="tbStartDateCurrency" runat="server" 
										ToolTip="Дата формата dd.MM.yyyy"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" ErrorMessage="*" 
                                        ControlToValidate="tbStartDateCurrency" ForeColor="Red"></asp:RequiredFieldValidator>
									<asp:RegularExpressionValidator ID="revDate1" runat="server" 
										ErrorMessage="Uncorrect Date" ForeColor="Red" ControlToValidate="tbStartDateCurrency" 
										ValidationExpression="(([0-2]\d|3[01])\.(0\d|1[012])\.(\d{4}))" Display="Dynamic"></asp:RegularExpressionValidator>
						            <asp:CalendarExtender ID="calendarAjaxStart" runat="server" TargetControlID="tbStartDateCurrency" Format="dd'.'MM'.'yyyy">
						            </asp:CalendarExtender>
					            </td>
					            <td>
						            по&nbsp;&nbsp;
					            </td>
					            <td>
						            <asp:TextBox ID="tbEndDateCurrency" runat="server">
									ToolTip="Дата формата dd.MM.yyyy"</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ErrorMessage="*" 
                                        ControlToValidate="tbEndDateCurrency" ForeColor="Red"></asp:RequiredFieldValidator>
									<asp:RegularExpressionValidator ID="revDate2" runat="server" 
										ErrorMessage="Uncorrect Date" ForeColor="Red" 
										ValidationExpression="(([0-2]\d|3[01])\.(0\d|1[012])\.(\d{4}))" Display="Dynamic" ControlToValidate="tbEndDateCurrency"></asp:RegularExpressionValidator>
						            <asp:CalendarExtender ID="calendarAjaxEnd" runat="server" TargetControlID="tbEndDateCurrency" Format="dd'.'MM'.'yyyy">
						            </asp:CalendarExtender>
					            </td>
				            </tr>
			            </table>
                        </div>
                    </td>
                    <td class="column2 borderRight">
                        <asp:DropDownList ID="ddlCurrencies" runat="server" AutoPostBack="True" onselectedindexchanged="ddlCurrencies_SelectedIndexChanged">
		                 </asp:DropDownList>
                    </td>
                    <td class="borderRight">
                        <asp:DropDownList ID="ddlMetals" runat="server" AutoPostBack="True" onselectedindexchanged="ddlMetals_SelectedIndexChanged">
			            </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 20px auto;">
             <asp:RatesMonitoring id="ratesMonitoring" runat="server"/>
        </div>
        <!--<div>
	        <asp:GridView runat="server" ID="gvDyn"></asp:GridView>
        </div>
        <div>
	        <asp:GridView ID="gvListFunMetals" runat="server">
	        </asp:GridView>
        </div>-->
        <div style="margin: 20px auto;">
			<table>
				<tr>
					<td>
						<asp:AllRates id="firstHalfRates" runat="server"/>
					</td>
					<td>
						<asp:AllRates id="secondHalfRates" runat="server"/>
					</td>
				</tr>
			</table>
		</div>
        <div>
        <asp:AllMetalsRates id="metalsRates" runat="server"/>
        </div>
		<asp:ScriptManager ID="toolScriptManager" runat="server">
		</asp:ScriptManager>
	</div>
</asp:Content>
