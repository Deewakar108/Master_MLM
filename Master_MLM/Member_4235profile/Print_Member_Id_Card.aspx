<%@ Page Title="" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Print_Member_Id_Card.aspx.cs" Inherits="Master_MLM.Member_4235profile.Print_Member_Id_Card" %>
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
				<div class="alert alert-danger" role="alert">
					<asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
				</div>
			</div>
			
		</div>
        </div>

        <div class="grid-form">
            <div class="grid-form1">
  	        <h4  class="breadcrumb-item"><a>Print Id Card</a></h4>
        <div class="panel-body panel-footer">
					<div role="form" class="form-horizontal" style="text-align:center;">
						<div class="form-inline">
                          <div class="form-group" style="padding: 0 30px;">
                            <%--<label for="exampleInputName2">Name</label>--%>
                            <asp:RadioButton ID="radio_print_front" runat="server" Text="Print Front" GroupName="a" Checked="true" />
                          </div>
                          <div class="form-group" style="padding: 0 30px;">
                            <asp:RadioButton ID="radio_print_back" runat="server" Text="Print Back" GroupName="a" />
                          </div>                          
                        </div>
					</div>
	</div>	
      

      <div class="panel-footer">
		<div class="row">
			<div class="col-sm-12" style="text-align: center;">

<%--				<button class="btn-inverse btn">Reset</button>
				<button class="btn-default btn">Cancel</button>				
                <button class="btn-primary btn">Submit</button>--%>

                <asp:Button ID="btn_find" class="btn-primary btn" runat="server" Text="Find" OnClick="btn_find_Click" />
			</div>
		</div>
	 </div>
    
  </div>
        </div>

</asp:Content>
