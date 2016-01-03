<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script>
        function myclick()
        {
            //alert("test");
            MyWebService.HelloWorld(OnRequsetComplete, OnRequsetError);
            alert(msg);
        }
        function OnRequsetComplete(result) {
            alert("成功");
            alert(result);
        }
        function OnRequsetError() {
            alert("失败");
        }
    </script>
</head>
 

<body>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/MyWebService.asmx" />
        </Services>
    </asp:ScriptManager>
  
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick ="myclick()"/>
        <input type="button"  onclick="myclick()" value="Button2" ID="Button2"/>
   
    </div>
    </form>
</body>
</html>
