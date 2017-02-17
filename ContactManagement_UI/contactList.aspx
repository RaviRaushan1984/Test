<%@ Page Title="Contact List" Language="C#" MasterPageFile="~/staffmaster.Master"
    AutoEventWireup="true" CodeBehind="contactList.aspx.cs" Inherits="ContactManagement_UI.contactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="">
        <div class="clearfix">
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_content">
                        <div>
                            <asp:GridView ID="g1" runat="server" CssClass="table table-striped responsive-utilities jambo_table"
                                AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="40px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkboxSelectAll" runat="server" AutoPostBack="false" OnClick="selectAll(this)" />
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkEmp" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false" HeaderText="ContactId" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Office Email" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOfficeEmail" runat="server" Text='<%# Eval("OfficeEmail") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Desgination" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesgination" runat="server" Text='<%# Eval("Desgination") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
        </div>
    </div>
    <div id="errorMessageDiv" runat="server" style="color: Red;">
    </div>
    <div style="padding-top: 16px;">
        <asp:Button ID="btnsendmail" runat="server" OnClientClick="return validateGridCheck()"
            OnClick="btnsendmail_Click" Text="Send Mail" />
    </div>
    <footer>
                    <div class="">
                        <p class="pull-right">Contact Management |
                            © 2015 Dion Global Solutions - All Rights Reserved.
                        </p>
                    </div>
                    <div class="clearfix"></div>
                </footer>
    <script type="text/javascript">
        function selectAll(invoker) {
            debugger;
            // Since ASP.NET checkboxes are really HTML input elements
            //  let's get all the inputs 
            var inputElements = document.getElementsByTagName('input');

            for (var i = 0; i < inputElements.length; i++) {
                var myElement = inputElements[i];

                // Filter through the input types looking for checkboxes
                if (myElement.type === "checkbox") {

                    // Use the invoker (our calling element) as the reference 
                    //  for our checkbox status
                    myElement.checked = invoker.checked;
                }
            }
        }

        function validateGridCheck() {
            var count = 0;
            debugger;
            var inputElements = document.getElementsByTagName('input');

            for (var i = 0; i < inputElements.length; i++) {
                var myElement = inputElements[i];

                // Filter through the input types looking for checkboxes
                if (myElement.type === "checkbox") {

                    // Use the invoker (our calling element) as the reference 
                    //  for our checkbox status
                    if (myElement.checked == true)
                        count++;
                }
            }

            if (count == 0) {
                alert('Please select at least one contact to send email.');
                return false;
            }
            else
                return true;
        }
    </script>
</asp:Content>
