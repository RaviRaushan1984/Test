function ShowTooltip1(tooltip) {
    window.setTimeout(function () {
        tooltip.show();
    }, 50);
}
function Required_ClientValidate(source, arguments) {
    ////debugger;
    var Name = $('#' + source.controltovalidate);
    if (Name.val().trim().length > 0) {
        Name.removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        Name.addClass('error_class');
        arguments.IsValid = false;
    }
}

function Required_Name_ClientValidate(source, arguments) {
    var Name = $('#' + source.controltovalidate);
    if ($find(source.controltovalidate).get_value().trim().length > 0) {
        Name.parent().parent('div').removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        Name.parent().parent('div').addClass('error_class');
        arguments.IsValid = false;
    }
}
function Required_Editor_ClientValidate(source, arguments) {
    var Editor = $('#' + source.controltovalidate);
    if (Editor.val().trim().length > 0) {
        Editor.removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        Editor.addClass('error_class');
        arguments.IsValid = false;
    }
}
function Required_Calender_ClientValidate(source, arguments) {
    var Calender = $('#' + source.controltovalidate);
    if (Calender.val().trim().length > 0) {
        Calender.parent('div').find('span').removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        Calender.parent('div').find('span').addClass('error_class');
        arguments.IsValid = false;
    }
}
function Email_ClientValidate(source, arguments) {
    email_regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i;

    var Email = $('#' + source.controltovalidate);
    if (Email.val().trim().length > 0) {
        var EmailId = Email.val().trim();
        var match = email_regex.test(EmailId)
        if (match) {
            Email.removeClass('error_class');
            arguments.IsValid = true;
        }
        else {
            Email.addClass('error_class');
            arguments.IsValid = false;
        }
    }
    else {
        arguments.IsValid = true;

    }
}

function Email_mandatory_ClientValidate(source, arguments) {
    email_regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i;

    var Email = $('#' + source.controltovalidate);
    if (Email.val().trim().length > 0) {
        var EmailId = Email.val().trim();
        var match = email_regex.test(EmailId)
        if (match) {
            Email.removeClass('error_class');
            arguments.IsValid = true;
        }
        else {
            Email.addClass('error_class');
            arguments.IsValid = false;
        }
    }
    else {
        Email.addClass('error_class');
        arguments.IsValid = false;
    }
}
function Email_ClientValidateNotManadatory(source, arguments) {
    email_regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i;
    var Email = $find(source.controltovalidate);
    var EmailValue = Email.get_value();
    if (EmailValue.length > 0) {
        var Email = $('#' + source.controltovalidate);
        var EmailId = Email.val().trim();
        var match = email_regex.test(EmailId)
        if (match) {
            Email.parent().parent().parent('div').removeClass('error_class');
            arguments.IsValid = true;
        }
        else {
            Email.parent().parent().parent('div').addClass('error_class');
            arguments.IsValid = false;
        }
    }
    else {
        $('#' + source.controltovalidate).parents('span').removeClass('error_class');
        arguments.IsValid = true;
    }
}
function Url_ClientValidate(source, arguments) {
    //URL_regex = /^(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i;
    URL_regex = /^(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i;
    var URL = $('#' + source.controltovalidate);
    var Wesite_URL = URL.val().trim();
    var match = URL_regex.test(Wesite_URL)
    if (match) {
        URL.parent().parent().parent('div').removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        URL.parent().parent().parent('div').addClass('error_class');
        arguments.IsValid = false;
    }
}
function Phone_ClientValidate(source, arguments) {
    Phone_regex = /^\(?\d{3}\)-?\d{3}\-?\d{4}$/;
    var Phone = $('#' + source.controltovalidate);
    var PhoneNo = Phone.val().trim();
    var match = Phone_regex.test(PhoneNo)
    if (match == true && PhoneNo != "") {
        Phone.parent().parent().parent('div').removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        Phone.parent().parent().parent('div').addClass('error_class');
        arguments.IsValid = false;
    }
}

//Check ZIP Code Length is equal to 5.
function CheckZipCodeLength(source, arguments) {
    var Zip = $find(source.controltovalidate);
    var ZipCode = Zip.get_textBoxValue().trim();
    if (ZipCode.length != 5) {
        $('#' + source.controltovalidate).parents('span').addClass('error_class');
        arguments.IsValid = false;
    }
    else {
        $('#' + source.controltovalidate).parents('span').removeClass('error_class');
        arguments.IsValid = true;
    }
}

//Check Bank Routing No Length is equal to 9.
function CheckBankRoutingLength(source, arguments) {
    var Routing = $find(source.controltovalidate);
    var BankRouting = Routing.get_textBoxValue().trim();
    if (BankRouting.trim().length != 9) {
        $('#' + source.controltovalidate).parents('span').addClass('error_class');
        arguments.IsValid = false;
    }
    else {
        $('#' + source.controltovalidate).parents('span').removeClass('error_class');
        arguments.IsValid = true;
    }
}

//Check Bank Account No Length is equal to 16.
function CheckBankAccountNoLength(source, arguments) {
    var Routing = $find(source.controltovalidate);
    var BankRouting = Routing.get_textBoxValue().trim();
    if (BankRouting.trim().length != 16) {
        $('#' + source.controltovalidate).parents('span').addClass('error_class');
        arguments.IsValid = false;
    }
    else {
        $('#' + source.controltovalidate).parents('span').removeClass('error_class');
        arguments.IsValid = true;
    }
}

//US Phone Format- (XXX) XXX-XXXX
function Phone_ClientValidateNotManadatory(source, arguments) {
    Phone_regex = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
    var Phone = $find(source.controltovalidate);
    var PhoneNo = Phone.get_value().trim();
    if (PhoneNo.length > 0) {
        var match = Phone_regex.test(PhoneNo)
        if (match == true && PhoneNo != "") {
            $('#' + source.controltovalidate).parents('span').removeClass('error_class');
            arguments.IsValid = true;
        }
        else {
            $('#' + source.controltovalidate).parents('span').addClass('error_class');
            arguments.IsValid = false;
        }
    }
    else {
        $('#' + source.controltovalidate).parents('span').removeClass('error_class');
        arguments.IsValid = true;
    }
}

//US Phone Format- (XXX) XXX-XXXX
function Phone_ClientValidateManadatory(source, arguments) {
    Phone_regex = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
    var Phone = $('#' + source.controltovalidate);
    var PhoneNo = Phone.val().trim();
    var match = Phone_regex.test(PhoneNo)
    if (match == true && PhoneNo != "") {
        Phone.parent().parent().parent('div').removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        Phone.parent().parent().parent('div').addClass('error_class');
        arguments.IsValid = false;
    }
}

// To show message- Invalid Number
function valueChanged(sender, args) {
    if (sender.get_value().trim().length < 10 && sender.get_value().trim().length > 0) {
        setTimeout(function () {
            var eventArgs = new Telerik.Web.UI.MaskedTextBoxEventArgs(args.get_newValue(), args.get_oldValue(), null);
            sender.raise_error(eventArgs);

            sender._textBoxElement.value = "Invalid Phone";
            sender._textBoxElement.innerText = "Invalid Phone";
            args.IsValid = false;
        }, 0);
    }
}

function Number_ClientValidate(source, arguments) {
    Number_regex = /^[\-\+]?\d+$/;
    var Number = $('#' + source.controltovalidate);
    var Number_val = Number.val().trim();
    var match = Number_regex.test(Number_val)
    if (match == true && Number_val != "") {
        Number.parent().parent().parent('div').removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        Number.parent().parent().parent('div').addClass('error_class');
        arguments.IsValid = false;
    }
}

function IPAddress_ClientValidate(source, arguments) {
    var IpAddress = $('#' + source.controltovalidate);
    var IpAddressVal = IpAddress.val().trim();
    if (IpAddressVal != '000.000.000.000') {
        IpAddress.removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        IpAddress.addClass('error_class');
        arguments.IsValid = false;
    }
}
function Ip_ClientValidate(source, arguments) {
    var IpAddress = $('#' + source.controltovalidate);
    var IpAddressVal = IpAddress.val().trim();
    if (IpAddressVal != '000.000.000.000') {
        var IpSegmentCounter = 0;
        for (var i = 0; i < IpAddressVal.split('.').length; i++) {
            if (IpAddressVal.split('.')[i] != '' && !IpAddressVal.split('.')[i].indexOf('_') == 0) {
                if (parseInt(IpAddressVal.split('.')[i]) <= 255) {
                    if (parseInt(IpAddressVal.split('.')[i]) == 255) {
                        IpSegmentCounter++;
                    }
                }
                else {
                    IpAddress.parents('span').addClass('error_class');
                    arguments.IsValid = false;
                    return;
                }
            }
            else {
                IpAddress.parents('span').addClass('error_class');
                arguments.IsValid = false;
                return;
            }
        }
        if (IpSegmentCounter == 4) {
            IpAddress.parents('span').addClass('error_class');
            arguments.IsValid = false;
            return;
        }
        else {
            IpAddress.parents('span').removeClass('error_class');
            arguments.IsValid = true;
        }
    }
    else {
        IpAddress.parents('span').addClass('error_class');
        arguments.IsValid = false;
    }
}
function Combo_ClientValidate(source, arguments) {
    var combo = $find(source.controltovalidate);
    combo = $find(source.controltovalidate);
    if (combo.get_selectedIndex() != 0 && combo.get_selectedIndex() != null) {
        $('#' + source.controltovalidate).removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        $('#' + source.controltovalidate).addClass('error_class');
        arguments.IsValid = false;
    }
}

function LoadOnDemandCombo_ClientValidate(source, arguments) {
    var combo = $find(source.controltovalidate);
    combo = $find(source.controltovalidate);
    //if (combo.get_text() != '' && combo.get_text() == combo._emptyMessage && combo._highlightedItem == null) {
    if (combo._highlightedItem == null && combo.get_value().trim() == '') {
        $('#' + source.controltovalidate).addClass('error_class');
        arguments.IsValid = false;
    }
    else {
        $('#' + source.controltovalidate).removeClass('error_class');
        arguments.IsValid = true;
    }
}

function OnClientSelectedIndexChanged(sender, eventArgs) {
    var item = eventArgs.get_item().trim();
    var Combobox = sender;
    if (Combobox.get_selectedIndex() > 0) {
        eventArgs._item._parent.removeCssClass('error_class');
    }
    else {
        eventArgs._item._parent.addCssClass('error_class');
    }
}
function History_Required_ClientValidate(source, arguments) {
    var CarrierName = $('#' + source.controltovalidate);
    if (CarrierName.val().trim().length > 0 && CarrierName.val().trim().toLowerCase() != "search") {
        HideToolTip_Error($find(source.controltovalidate)._element);
        CarrierName.removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        CarrierName.addClass('error_class');
        showToolTip_Error($find(source.controltovalidate)._element);
        arguments.IsValid = false;
    }
}
function Canonical_URL_Validate(source, arguments) {
    canonicalURL_Regx = /^[0-9a-zA-Z-_ ]+$/;
    var CanonicalUrl = $('#' + source.controltovalidate);
    var CanonicalUrlVal = CanonicalUrl.val().trim();
    var match = canonicalURL_Regx.test(CanonicalUrlVal)
    if (match == true && CanonicalUrlVal != "") {
        CanonicalUrl.parents('span').removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        CanonicalUrl.parents('span').addClass('error_class');
        arguments.IsValid = false;
    }
}
function Required_RadNumeric_ClientValidate(source, arguments) {
    var Name = $('#' + source.controltovalidate);
    if ($find(source.controltovalidate).get_value() != "") {
        Name.parent('span').removeClass('error_class');
        arguments.IsValid = true;
    }
    else {
        if ($find(source.controltovalidate).get_value() === 0) {
            Name.parent('span').removeClass('error_class');
            arguments.IsValid = true;
        }
        else {
            Name.parent('span').addClass('error_class');
            arguments.IsValid = false;
        }
    }
}

function clientBeforeShow(sender, eventArgs) {
    if (sender._targetControlID != null) {
        if (sender._targetControlID.indexOf('RadEditor') > 0
                || sender._targetControlID.indexOf('InsertButton') > 0
                || sender._targetControlID.indexOf('EditButton_InsertCommandColumn') > 0
                || sender._targetControlID.indexOf('BtnExpandColumn') > 0
                || sender._targetControlID.indexOf('AddNewRecordButton') > 0
                || sender._targetControlID.indexOf('RefreshButton') > 0
                || sender._targetControlID.indexOf('GoToPageLinkButton') > 0
                || sender._targetControlID.indexOf('ChangePageSizeLinkButton') > 0
                || sender._targetControlID.indexOf('popupButton') > 0
                || sender._targetControlID.indexOf('NextButton') > 0
                || sender._targetControlID.indexOf('PrevButton') > 0
                || sender._targetControlID.indexOf('LastButton') > 0
                || sender._targetControlID.indexOf('FirstButton') > 0
                || sender._targetControlID.indexOf('Filter_') > 0) {
            eventArgs.set_cancel(true);
        }
    }
    else {
        eventArgs.set_cancel(true);
    }
}

function List_ClientValidate(source, arguments) {
    var List = $("#" + source.controltovalidate);
    var flag = false;

    if (List.length > 0) {
        List.find("input").each(function (i, elem) {
            if ($(elem)[0].checked)
                flag = true;
        });

        if (flag)
            List.removeClass('error_class');
        else
            List.addClass('error_class');
        arguments.IsValid = flag;
        return;
    }
    List.addClass('error_class');
    arguments.IsValid = flag;
}

function OnDemadComboClientBlur(source, args) {
    var SearchTxt = $('#' + source.get_id()).val().trim().toUpperCase();
    var itemToSelect = source.findItemByText(SearchTxt);
    if (itemToSelect != null) {
        itemToSelect.select();
        source.set_selectedItem(itemToSelect);
    }
    else {
        source.set_selectedItem(null);
    }
    source.hideDropDown();
}

//Check Check # Length is equal to 6.
//function CheckCreditcardLength(source, arguments) {
//    var Routing = $find(source.controltovalidate);
//    var BankRouting = Routing.get_textBoxValue();
//    if (BankRouting.trim().length != 6) {
//        $('#' + source.controltovalidate).parents('span').addClass('error_class');
//        arguments.IsValid = false;
//    }
//    else {
//        $('#' + source.controltovalidate).parents('span').removeClass('error_class');
//        arguments.IsValid = true;
//    }
//}

