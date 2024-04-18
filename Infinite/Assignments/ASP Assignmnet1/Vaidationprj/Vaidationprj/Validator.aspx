<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="YourNamespace.Validator" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="color:purple;font-size:20px;text-align:left;"><u>Insert Your Details</u></h1>
            <br />
            Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtname" runat="server" BackColor="LightPink" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtname" ErrorMessage="Name Cannot Be Blank" ForeColor="Red" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
            <br />
            <br />
            Family Name:&nbsp;&nbsp;
            <asp:TextBox ID="txtFamilyName" runat="server" BackColor="LightPink"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFamilyName" runat="server"
                ControlToValidate="txtFamilyName" ErrorMessage="Family Name cannot be blank"
                ForeColor="Red" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidatorFamilyName" runat="server"
                ControlToValidate="txtFamilyName" ControlToCompare="txtname"
                ErrorMessage="Name and Family Name cannot be the same" ForeColor="Red"
                ValidationGroup="regngrp" Operator="NotEqual">*</asp:CompareValidator>
            <br />
            <br />
            Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddress" runat="server" BackColor="LightPink"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server"
                ControlToValidate="txtAddress" ErrorMessage="Address cannot be blank"
                ForeColor="Red" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorAddress" runat="server"
                ControlToValidate="txtAddress" ErrorMessage="Address should have at least 2 letters"
                ForeColor="Red" ValidationExpression="^.{2,}$" ValidationGroup="regngrp">*</asp:RegularExpressionValidator>
            <br />
            <br />
            City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCity" runat="server" BackColor="LightPink"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" runat="server"
                ControlToValidate="txtCity" ErrorMessage="City cannot be blank"
                ForeColor="Red" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorCity" runat="server"
                ControlToValidate="txtCity" ErrorMessage="City should have at least 2 letters"
                ForeColor="Red" ValidationExpression="^.{2,}$" ValidationGroup="regngrp">*</asp:RegularExpressionValidator>
            <br />
            <br />
            Zip Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtZipCode" runat="server" BackColor="LightPink"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorZipCode" runat="server"
                ControlToValidate="txtZipCode" ErrorMessage="Zip Code cannot be blank"
                ForeColor="Red" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorZipCode" runat="server"
                ControlToValidate="txtZipCode" ErrorMessage="Zip Code must be 5 digits"
                ForeColor="Red" ValidationExpression="\d{5}" ValidationGroup="regngrp">*</asp:RegularExpressionValidator>
            <br />
            <br />
            Phone:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPhone" runat="server" BackColor="LightPink"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server"
                ControlToValidate="txtPhone" ErrorMessage="Phone cannot be blank"
                ForeColor="Red" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" runat="server"
                ControlToValidate="txtPhone" ErrorMessage="Phone must be in the format XX-XXXXXXX or XXX-XXXXXXX"
                ForeColor="Red" ValidationExpression="^(\d{2}-\d{8}|\d{3}-\d{7})" ValidationGroup="regngrp">*</asp:RegularExpressionValidator>

            <br />
            <br />
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtemail" runat="server" BackColor="LightPink"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                ControlToValidate="txtemail" ErrorMessage="Email cannot be blank"
                ForeColor="Red" ValidationGroup="regngrp">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                ControlToValidate="txtemail" ErrorMessage="Invalid Email Format"
                ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ValidationGroup="regngrp">*</asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="btnvalidate" runat="server" Text="Validate" OnClick="btnvalidate_Click" ValidationGroup="regngrp" />
            <br />
            <br />
            <h4 style="color:red">Validation Sum </h4>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="regngrp" />
            <br />
            <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
