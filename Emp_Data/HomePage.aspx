<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Emp_Data.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="CSVFileUpload" runat="server" />
        </div>
        <p>
            <asp:Button ID="Import" runat="server" BackColor="Yellow" BorderColor="White" OnClick="Import_Click" Text="Import" />
        </p>
        <p>
            <asp:Button ID="Save" runat="server" BackColor="Yellow" BorderColor="White" OnClick="Save_Click" Text="Save" />
        </p>
        <p>
            <asp:Label ID="StatusLbl" runat="server"></asp:Label>
        </p>
        <p>
            <asp:GridView ID="EmployeeGrid" runat="server">
            </asp:GridView>
        </p>
    </form>
</body>
</html>
