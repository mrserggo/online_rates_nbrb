<%@ Page Title="" Language="C#" MasterPageFile="~/Rates.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineRates.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<ul class="site-nav">
      <li class="last"><a href="Default.aspx">Вход в систему</a></li>
     </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	 <div id="containermain">
		 <%--<div id="info">--%>
		 <!-- Authorization table -->
		 <!--Control MultiView для отображения формы Входа в систему и формы регистрации поочередно-->
			 <asp:MultiView ID="MV_RegAuth" runat="server">
				 <!--Форма входа в систему-->
				 <asp:View ID="FormLogin" runat="server">  
				  <div>
				  <center>Вход в систему</center>
				   <table id="table1" class="center">
						<tr>
							<td width="30%">
								&nbsp;Логин</td>
							<td width="40%">
								<asp:TextBox ID="tbLogin" runat="server" Width="125px"></asp:TextBox>
							</td>
							<td>
									<asp:RequiredFieldValidator
										ID="LoginRequiredValidator" runat="server"
										ErrorMessage="*" ControlToValidate="tbLogin" ForeColor="Red" />
							</td>
						</tr>
						<tr>
							<td>
								&nbsp;Пароль</td>
							<td>
								<asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="125px"></asp:TextBox>
							</td>
							<td>    
								<asp:RequiredFieldValidator ID="PwdRequiredValidator"
									runat="server" ErrorMessage="*"
									ControlToValidate="tbPassword" ForeColor="Red"/>
							</td>
						</tr>
						<tr> 
							<td>
								&nbsp;<a style="text-align:left;font-size:small; color:Black; font-style:italic;" href="Default.aspx?Registration=true">регистрация</a>
								&nbsp;
							</td>
							<td>
								<asp:ImageButton ID="ibtnAuthorization" runat="server" 
									ImageUrl="~/Styles/buttonAuthorization.jpg" onclick="ibtnAuthorization_Click" />
							</td>
							<td>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<br />
								<asp:Label ID="LegendStatus" runat="server"
									EnableViewState="False" Font-Size="X-Small" ForeColor="Red" />
									&nbsp;
							</td>
						</tr>
					</table>
				 <!-- table1end-->
				  </div>
				 </asp:View>
				 <!--FormLogin_End-->

				 <!--Форма регистрации-->
				 <asp:View ID="FormAuthorization" runat="server">  
				 <!--===========================Таблица регистрации================================-->
				 <div>
				 <span style="text-align: center">Пожалуйста, заполните регистрационные поля</span>
					<table id="table2" class="center">
						<tr>
							<td style="width:25%">
								Логин&nbsp;</td>
							<td style="width:40%">
								<asp:TextBox ID="tbLogin_" runat="server" Width="148px" 
                                
									ToolTip="Ваш логин (6-24 символов, принимает латинские буквы в обоих регистрах, цифры, символы тире и нижнего подчеркивания)"></asp:TextBox>
							</td>
							<td>
								<asp:RequiredFieldValidator ID="rfvLogin_" runat="server" 
									ControlToValidate="tbLogin_" ErrorMessage="*" ForeColor="Red" 
									Display="Dynamic"></asp:RequiredFieldValidator>
								<asp:RegularExpressionValidator ID="revLogin" runat="server" 
									ControlToValidate="tbLogin_" ErrorMessage="Неправильный логин" Font-Size="X-Small" 
									ForeColor="Red" ValidationExpression="[\-a-zA-Z0-9_]{6,24}" 
									Display="Dynamic"></asp:RegularExpressionValidator>
							</td>
						</tr>
						<tr>
							<td>
								Пароль&nbsp;</td>
							<td>
								<asp:TextBox ID="tbPassword_" runat="server" TextMode="Password" Width="148px" 
                                
                                
									ToolTip="Ваш пароль (6-50 символов, принимает латинские буквы в обоих регистрах, цифры, символы тире и нижнего подчеркивания)"></asp:TextBox>
							</td>              
							<td> 
								<asp:RequiredFieldValidator ID="rfvPassword_" runat="server" 
									ControlToValidate="tbPassword_" ErrorMessage="*" ForeColor="Red" 
									Display="Dynamic"></asp:RequiredFieldValidator>
								<asp:RegularExpressionValidator ID="revPassword_" runat="server" 
									ControlToValidate="tbPassword_" Display="Dynamic" 
									ErrorMessage="Неправильный пароль" Font-Size="X-Small" ForeColor="Red" 
									ValidationExpression="[\-a-zA-Z0-9_]{6,50}"></asp:RegularExpressionValidator>
							</td>
						</tr>
						<tr>
							<td>
							   ФИО
								&nbsp;</td>
							<td>
								<asp:TextBox ID="tbFullName" runat="server" TextMode="SingleLine"
									Width="148px" 
                                
									ToolTip=" Ваши ФИО (до 100 символов, принимает латинские и кириллические буквы в обоих регистрах, цифры, символ пробела)"></asp:TextBox>
							</td>
							<td>
								<asp:RequiredFieldValidator ID="rfvFullName" runat="server" 
									ControlToValidate="tbFullName" ErrorMessage="*" ForeColor="Red" 
									Display="Dynamic"></asp:RequiredFieldValidator>
								<asp:RegularExpressionValidator ID="revLogin0" runat="server" 
									ControlToValidate="tbFullName" Display="Dynamic" 
									ErrorMessage="Неправильные ФИО" Font-Size="X-Small" ForeColor="Red" 
									ValidationExpression="[a-zA-Zа-яА-ЯёЁ\s\d]{1,100}"></asp:RegularExpressionValidator>
							</td>
						</tr>
						<tr>
							<td>
								Телефон
								&nbsp;</td>
							<td>
								<asp:TextBox ID="tbPhone" runat="server" 
									Width="148px" 
									ToolTip="Ваш номер телефона (до 50 символов, принимает только цифры)"></asp:TextBox>
							</td>
							<td>
								<asp:RegularExpressionValidator ID="revPhone" runat="server" 
									ControlToValidate="tbPhone" ErrorMessage="Неправильный номер" Font-Size="X-Small" 
									ForeColor="Red" ValidationExpression="[\d]{1,50}"></asp:RegularExpressionValidator>
							</td>
						</tr>
						<tr>
							<td>
								<asp:Label ID="lblError" runat="server" Font-Size="XX-Small" ForeColor="Red"></asp:Label>
							</td>
							<td>
								<asp:ImageButton ID="ibtnRegister" runat="server" Height="51px" 
									Width="148px" ImageUrl="~/Styles/buttonRegistration.jpg" 
									onclick="ibtnRegister_Click" />
							</td>
							<td>
							</td>
						</tr>
					</table>
				  </div>
            
	<!--===================FormRegistration_End==========================-->
				 </asp:View>
				 <!--FormAuthorization_End-->
			 </asp:MultiView>
			 <!--MV_RegAuth_End-->
		<%--</div>--%>
    </div>

</asp:Content>
