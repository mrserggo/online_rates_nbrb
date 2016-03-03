<%@ Page Title="" Language="C#" MasterPageFile="~/Rates.Master" AutoEventWireup="true" CodeBehind="CrossRatesandConverter.aspx.cs" Inherits="OnlineRates.CrossRatesandConverter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Styles/StylesJS/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.effects.core.js" type="text/javascript"></script>
    <script src="Scripts/jquery.effects.blind.js" type="text/javascript"></script>
<style type="text/css">
.ddlImg
{
      width: 20px;
      height: 20px;
}
.ddlText
{
      font-size: 14px;
      cursor: pointer;
      float: left;
      width: 165px;
      vertical-align: top;
}

#ContentPlaceHolder2_effect1
{
      width: 188px;
      height: 135px;
      position: absolute;
      z-index: 2;
      overflow: auto;
}
#ContentPlaceHolder2_effect2
{
      width: 188px;
      height: 135px;
      position: absolute;
      z-index: 2;
      overflow: auto;
}

.textbox
{
      width: 185px;
      height: 14px;
}

</style>
<!-- *************scripts*********** -->
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $("#ddlDiv1").css({
            display: 'block'
        });
        $("#ddlDiv2").css({
            display: 'block'
        });
        $("#ContentPlaceHolder2_effect1").hide();
        $("#ContentPlaceHolder2_effect2").hide();

        //run the currently selected effect
        function runEffect1() {
            //get effect type from
            if (!($('#ContentPlaceHolder2_effect1').is(":visible"))) {
                //run the effect
                $("#ContentPlaceHolder2_effect1").show('blind', 200);
            }
            else {
                $("#ContentPlaceHolder2_effect1").hide('blind', 200);
            }
        };

        function runEffect2() {
            //get effect type from
            if (!($('#ContentPlaceHolder2_effect2').is(":visible"))) {
                //run the effect
                $("#ContentPlaceHolder2_effect2").show('blind', 200);
            }
            else {
                $("#ContentPlaceHolder2_effect2").hide('blind', 200);
            }
        };

        //set effect from image dropdown value
        $("#ddlArrow1").click(function () {
            runEffect1();
            return false;
        });

        $("#ddlArow2").click(function () {
            runEffect2();
            return false;
        });
        $(document).click(function (e) {
            if (($('#ContentPlaceHolder2_effect1').is(":visible"))) {
                $("#ContentPlaceHolder2_effect1").hide('blind', 200);
            }
            if (($('#ContentPlaceHolder2_effect2').is(":visible"))) {
                $("#ContentPlaceHolder2_effect2").hide('blind', 200);
            }

        });
        $('#ContentPlaceHolder2_effect1').click(function (e) {
            e.stopPropagation();
        });

        $('#ContentPlaceHolder2_effect2').click(function (e) {
            e.stopPropagation();
        });
    });
      function GetSelectedValue1(ddlId) {
            var objTextBox = document.getElementById("<%=txtChkValue1.ClientID%>");
            objTextBox.value = $(ddlId).text();
            if (!($('#ContentPlaceHolder2_effect1').is(":visible"))) {
            //run the effect
                $("#ContentPlaceHolder2_effect1").show('blind', 200);
            }
            else {
                $("#ContentPlaceHolder2_effect1").hide('blind', 200);
            }
            $("#<%=hidValue1.ClientID%>").val($(ddlId).attr("id"));
        }
        function GetSelectedValue2(ddlId) {
            var objTextBox = document.getElementById("<%=txtChkValue2.ClientID%>");
            objTextBox.value = $(ddlId).text();
            if (!($('#ContentPlaceHolder2_effect2').is(":visible"))) {
                //run the effect
                $("#ContentPlaceHolder2_effect2").show('blind', 200);
            }
            else {
                $("#ContentPlaceHolder2_effect2").hide('blind', 200);
            }
            $("#<%=hidValue2.ClientID%>").val($(ddlId).attr("id"));
        }
</script>
<!--*********************************-->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    	<ul class="site-nav">
        <li><a href="Finance.aspx">На главную</a></li>
		<li><a href="RatesNBRB.aspx">Курсы валют (НБРБ)</a></li>
		<li><a href="RatesInBanks.aspx">Курсы валют в г. Минске</a></li>
        <li class="last">
          <asp:LinkButton ID="lbtnExit" runat="server" 
            CausesValidation="False" onclick="lbtnExit_Click">Выход</asp:LinkButton></li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">   
      <div id="cross_and_converter">
            <div class="titleInfo">
                Конвертер валют
            </div>
            <div style="margin: 10px 0px;">
            <table id="converter_table">
                <tr>
                    <td class="column1">
                        <asp:TextBox ID="tbConvertValue1" runat="server" Width="55px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDecimalWithPoint" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbConvertValue1" Display="Dynamic" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDecimalWithPoint" runat="server" 
                            ErrorMessage="*" ControlToValidate="tbConvertValue1" 
                            ValidationExpression="^\d*\,?\d*$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                    <td class="column2">
                        <div id="ddlDiv1" style="display: none">
                          <asp:TextBox ID="txtChkValue1" runat="server" CssClass="textbox"></asp:TextBox>
                          <img id="ddlArrow1" src="Images/Converter/down_arrow.jpg" style="margin-left: -23px; margin-bottom: -4px" />      
                        </div>
                        <div id="effect1" class="ui-widget-content" runat="server">
                        </div>
                        <input type="hidden" runat="server" id="hidValue1" />
                    </td>
                    <td class="column3">
                            <asp:ImageButton ID="imgConvert" runat="server" 
                            ImageUrl="~/Images/Converter/convert.png" onclick="imgConvert_Click" />
                    </td>
                    <td class="column4">
                        <div id="ddlDiv2" style="display: none">
                            <asp:TextBox ID="txtChkValue2" runat="server" CssClass="textbox"></asp:TextBox>
                            <img id="ddlArow2" src="Images/Converter/down_arrow.jpg" style="margin-left: -23px; margin-bottom: -4px" />      
                        </div>
                        <div id="effect2" class="ui-widget-content" runat="server">
                        </div>
                        <input type="hidden" runat="server" id="hidValue2" />
                    </td>
                    <td class="column5">
                        <asp:TextBox ID="tbConvertValue2" runat="server" Width="55px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div class="titleInfo">
            <asp:Label ID="lblcrossTitle" runat="server" Text="Label"></asp:Label>
        </div>
        <div style="margin-top: 10px;">
            <table id="cross_rates_table">
                <tr>
                    <td class="borderLeft borderTop">
                        EUR / USD
                    </td>
                    <td class="borderTop borderRight align_right">
                        <asp:Label ID="lblEUR_USD" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="borderLeft">
                        EUR / RUB
                    </td>
                    <td class="borderRight align_right">
                        <asp:Label ID="lblEUR_RUB" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="borderLeft">
                        USD / EUR
                    </td>
                    <td class="borderRight align_right">
                        <asp:Label ID="lblUSD_EUR" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="borderLeft">
                        USD / RUB
                    </td>
                    <td class="borderRight align_right">
                        <asp:Label ID="lblUSD_RUB" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="borderLeft">
                        RUB / EUR
                    </td>
                    <td class="borderRight align_right">
                        <asp:Label ID="lblRUB_EUR" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="borderLeft">
                        RUB / USD
                    </td>
                    <td class="borderRight align_right">
                        <asp:Label ID="lblRUB_USD" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gvData" runat="server">
            </asp:GridView>
        </div>
      </div>
</asp:Content>
