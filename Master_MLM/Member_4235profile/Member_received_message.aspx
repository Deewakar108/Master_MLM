<%@ Page Title="" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Member_received_message.aspx.cs" Inherits="Master_MLM.Member_4235profile.Member_received_message" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
          <div><!--ALERT-->
            <input onclick="return AlertMessage()" type="button" value="Show" id="btnAlert" style="display: none;"/>
            <input type="hidden" id="hdfAlertMessage" />
        <div class="wthree-typo" style="padding: 10px; display: none;" id="divAlert">
			
            <script>
                function AlertClick(message) { $("#btnAlert").click(); }
                function AlertMessage() {

                    $("#divAlert").show().fadeOut(5000);
                    return false;
                }
            </script>

			<div class="grid_3 grid_5 w3ls" style="padding: 2px; margin: 0;">
				<%--<div class="alert alert-success" role="alert" style="margin: 0;">
					<strong>Well done!</strong>
                    <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
				</div>
				<div class="alert alert-info" role="alert">
					<strong>Heads up!</strong> This alert needs your attention, but it's not super important.
				</div>
				<div class="alert alert-warning" role="alert">
					<strong>Warning!</strong> Best check yo self, you're not looking too good.
				</div>--%>
				<div class="alert alert-danger" role="alert">
					<asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
				</div>
			</div>
			
		</div>
        </div>

        <div class="grid-form">
            <div class="grid-form1">
  	        <h4  class="breadcrumb-item"><a>Received Message</a></h4>
        <div class="panel-body panel-footer">
					<div role="form" class="form-horizontal">
                        <asp:GridView ID="grd_view_received_message" runat="server" CssClass="form-control1" AutoGenerateColumns="false"
                             AllowPaging="True" OnPageIndexChanging="grd_view_received_message_PageIndexChanging"
                            >
                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPreviousFirstLast" NextPageImageUrl="~/Images/next_button.png"
                                            NextPageText="" PreviousPageImageUrl="~/Images/previous_button.png" />
                                        <RowStyle BackColor="#F7F7DE" Font-Size="10pt" ForeColor="#000000" />
                            <EmptyDataTemplate>
                                <div style="text-align: center;">Message not found.</di>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk_reply" runat="server" OnClick="lnk_reply_Click" CausesValidation="False">Reply</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject"  ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_subject" runat="server" Font-Names="Arial" Text='<%#Bind("Subject") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Message">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_message" runat="server" Font-Names="Arial" Text='<%#Bind("Message") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date"  ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Date" runat="server" Font-Names="Arial" Text='<%#Bind("Date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="FROM"  ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_from" runat="server" Font-Names="Arial" Text='<%#Bind("Sender_id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_receiver_id" runat="server" Font-Names="Arial" Text='<%#Bind("Receiver_id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_ID" runat="server" Font-Names="Arial" Text='<%#Bind("id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" />
                                        <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <SelectedRowStyle BackColor="#EFEFEF" Font-Bold="True" ForeColor="#CC0000" />
                                        <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"
                                            ForeColor="White" Height="40px" BackColor="#00A4CC" />
                                        <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>

					</div>
	</div>
	
  </div>
            <asp:Panel ID="pnl_reply" runat="server" Visible="false">
                <div class="grid-form1">
  	        <h4  class="breadcrumb-item"><a>Message Send To</a></h4>
        <div class="panel-body panel-footer">
					<div role="form" class="form-horizontal">
						<div class="form-group">
							<label class="col-md-2 control-label">To</label>
							<div class="col-md-8">
								<div class="input-group">
                                    <asp:TextBox ID="txtTo" ReadOnly="true" runat="server" class="form-control1"  placeholder="Subject"></asp:TextBox>
								</div>
							</div>
						</div>
                        <div class="form-group">
							<label class="col-md-2 control-label">Subject</label>
							<div class="col-md-8">
								<div class="input-group">
									<%--<input type="password" class="form-control1" id="Password1" placeholder="Password">--%>
                                    <asp:TextBox ID="txt_subject" runat="server" class="form-control1"  placeholder="Subject"></asp:TextBox>
								</div>
							</div>
						</div>
                        <div class="form-group">
							<label class="col-md-2 control-label">Message</label>
							<div class="col-md-8">
								<div class="input-group">
									<%--<input type="password" class="form-control1" id="Password2" placeholder="Password">--%>
                                    <asp:TextBox ID="txt_message" style="resize: none;" Height="180" runat="server" class="form-control1" placeholder="Message" 
                                        TextMode="MultiLine"></asp:TextBox>
								</div>
							</div>
						</div>
					</div>
	</div>
	
  </div>
                        </asp:Panel>
        </div>

</asp:Content>
