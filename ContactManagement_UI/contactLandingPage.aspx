<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contactLandingPage.aspx.cs"
    Inherits="ContactManagement_UI.contactLandingPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/custom.css" rel="stylesheet" type="text/css" />
    <script src="http://localhost:4872/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
    <div>
        <asp:Label Text="" ID="errMsgLbl" runat="server" Visible="false" ForeColor="Red" />
        <%--<div id="contactDiv" runat="server" visible="true">
            <asp:HyperLink ID="contactLink" Text="Click here to update contact" NavigateUrl=""
                Target="_blank" runat="server" />
        </div>--%>
        <asp:Label Text="" ID="successMsg" Visible="false" ForeColor="Green" runat="server" />
    </div>
    <fieldset id="editContainer" runat="server" visible="true">
        <div class="row">
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="inputEmail" class="col-md-4 control-label">
                        Title</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="titleDropDown" runat="server">
                            <asp:ListItem Text="--Select One" Value="0" />
                            <asp:ListItem Text="Mr" Value="Mr" />
                            <asp:ListItem Text="Mrs" Value="Mrs" />
                            <asp:ListItem Text="Miss" Value="Miss" />
                            <asp:ListItem Text="Dr" Value="Dr" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ValidationGroup="contact" ControlToValidate="titleDropDown"
                            InitialValue="Please select" ErrorMessage="Please select title" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="inputLabel3" class="col-md-4 control-label">
                        First Name</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="fname" class="form-control" placeholder="First Name" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="contact"
                            runat="server" ControlToValidate="fname" ErrorMessage="First name is required" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="inputPassword" class="col-md-4 control-label">
                        Middle Name:</label>
                    <div class="col-md-8">
                        <asp:TextBox class="form-control" ID="mname" placeholder="Middle Name" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="inputLabel4" class="col-md-4 control-label">
                        Last Name</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="lname" placeholder="Last Name" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="contact"
                            runat="server" ControlToValidate="lname" ErrorMessage="Last name is required" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input5" class="col-md-4 control-label">
                        Desgination</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="desgination" placeholder="Desgination" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input6" class="col-md-4 control-label">
                        Company</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="company" placeholder="Company" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="contact"
                            runat="server" ControlToValidate="company" ErrorMessage="Company is required" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input7" class="col-md-4 control-label">
                        Mobile</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="mobile" placeholder="Mobile" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input8" class="col-md-4 control-label">
                        Home Phone</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="homePhone" placeholder="Home Phone" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input9" class="col-md-4 control-label">
                        Office Phone</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="officePhone" placeholder="Office Phone" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Fax</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="fax" placeholder="Fax" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Office Email</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="officeEmail" placeholder="Office Email" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Personal Email</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="personalEmail" placeholder="Personal Email" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Website</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="website" placeholder="Website" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Industry Type</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="industryType" placeholder="Industry Type" />
                    </div>
                </div>
            </div>
            <legend>Address 1</legend>
            <asp:HiddenField ID="Address1Id" runat="server" />
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Line 1</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="address1_line1" placeholder="Address 1" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Line 2</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="address1_line2" placeholder="Address 2" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Line 3</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="address1_line3" placeholder="Address 3" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Country</label>
                    <div class="col-md-8">
                        <%--<select id="address1_country">
                        </select>--%>
                        <asp:DropDownList runat="server" ID="address1_country" DataTextField="CountryName"
                            DataValueField="Id">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        State</label>
                    <div class="col-md-8">
                        <%--  <select id="address1_state">
                            <option value="0">--Select One--</option>
                        </select>--%>
                        <asp:DropDownList ID="address1_state" DataTextField="Name" DataValueField="Id" runat="server">
                            <asp:ListItem Text="--Select One--" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        City</label>
                    <div class="col-md-8">
                        <%-- <select id="address1_city">
                            <option value="0">--Select One--</option>
                        </select>--%>
                        <asp:DropDownList ID="address1_city" DataTextField="Name" DataValueField="Id" runat="server">
                            <asp:ListItem Text="--Select One--" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Pincode</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="address1_pincode" placeholder="Pincode" />
                    </div>
                </div>
            </div>
            <legend>Address 2</legend>
            <asp:HiddenField ID="Address2Id" runat="server" />
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Line 1</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="address2_line1" placeholder="Address 1" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Line 2</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="address2_line2" placeholder="Address 2" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Line 3</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="address2_line3" placeholder="Address 2" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Country</label>
                    <div class="col-md-8">
                        <%--<select id="address2_country">
                        </select>--%>
                        <asp:DropDownList ID="address2_country" DataTextField="CountryName" DataValueField="Id"
                            runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        State</label>
                    <div class="col-md-8">
                        <%--<select id="address2_state">
                            <option value="0">--Select One--</option>
                        </select>--%>
                        <asp:DropDownList ID="address2_state" DataTextField="Name" DataValueField="Id" runat="server">
                            <asp:ListItem Text="--Select One--" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        City</label>
                    <div class="col-md-8">
                        <%--<select id="address2_city">
                            <option value="0">--Select One--</option>
                        </select>--%>
                        <asp:DropDownList ID="address2_city" DataTextField="Name" DataValueField="Id" runat="server">
                            <asp:ListItem Text="--Select One--" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Pincode</label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" class="form-control" ID="address2_pincode" placeholder="Pincode" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-4">
                <div class="form-group">
                    <label for="input10" class="col-md-4 control-label">
                        Status</label>
                    <div id="checkedDIV" class="col-md-8">
                        <asp:RadioButton Text="Active" ID="activeStatusRadio" Checked="true" ValidationGroup="address2"
                            value="1" runat="server" />
                        <%--<input type="radio" id="activeStatusRadio" checked="checked" name="address2" value="1" />Active
                        <br>
                        <input type="radio" id="inactiveStatusRadio" name="address2" value="0" />Inactive--%>
                        <asp:RadioButton Text="Inactive" runat="server" ID="inactiveStatusRadio" ValidationGroup="address2"
                            value="0" />
                    </div>
                </div>
            </div>
            <p>
                <%--<input type="submit" onclick="updateContactDetails()" value="Update" />--%>
                <asp:Button Text="Update" runat="server" ID="UpdateBtn" OnClick="UpdateBtn_Click" />
            </p>
        </div>
    </fieldset>
    </form>
    <script type="text/javascript">

        $("#address1_country").change(function () {
            $.ajax({
                type: "POST",
                url: '/Master/GetStateList',
                data: { countryId: $("#address1_country > option:selected").attr("value") },
                success: function (data) {
                    var items = [];
                    items.push("<option>--Select One--</option>");
                    $.each(data, function () {
                        items.push("<option value=" + this.Id + ">" + this.Name + "</option>");
                    });
                    $("#address1_state").html(items.join(' '));
                }
            })
        });
        $("#address2_country").change(function () {
            $.ajax({
                type: "POST",
                url: '/Master/GetStateList',
                data: { countryId: $("#address2_country > option:selected").attr("value") },
                success: function (data) {
                    var items = [];
                    items.push("<option>--Select One--</option>");
                    $.each(data, function () {
                        items.push("<option value=" + this.Id + ">" + this.Name + "</option>");
                    });
                    $("#address2_state").html(items.join(' '));
                }
            })
        });

        $("#address1_state").change(function () {
            $.ajax({
                type: "POST",
                url: '/Master/GetCityList',
                data: { stateId: $("#address1_state > option:selected").attr("value") },
                success: function (data) {
                    var items = [];
                    items.push("<option>--Select One--</option>");
                    $.each(data, function () {
                        items.push("<option value=" + this.Id + ">" + this.Name + "</option>");
                    });
                    debugger;
                    $("#address1_city").html(items.join(' '));
                }
            })
        });

        $("#address2_state").change(function () {
            $.ajax({
                type: "POST",
                url: '/Master/GetCityList',
                data: { stateId: $("#address2_state > option:selected").attr("value") },
                success: function (data) {
                    var items = [];
                    items.push("<option>--Select One--</option>");
                    $.each(data, function () {
                        items.push("<option value=" + this.Id + ">" + this.Name + "</option>");
                    });
                    $("#address2_city").html(items.join(' '));
                }
            })
        });



        function redirectToHome() {
            var url = "/Staff/ContactList";
            window.location.href = url;
        }


        function validateControls() {
            if ($("#fname").val() == "") {
                $("#title").css("border-color", "red")
            }
        }   </script>
</body>
</html>
