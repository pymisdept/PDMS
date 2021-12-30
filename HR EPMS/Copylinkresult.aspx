<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Copylinkresult.aspx.cs" Inherits="HR_EPMS.LinkEdit" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>HR Department - EPMS</title>

  <!-- Custom fonts for this template-->
  <link href="include/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">

  <!-- Custom styles for this template-->
  <link href="css/sb-admin-2.css" rel="stylesheet">
  <link href="include/bootstrap/css/bootstrap-toggle.min.css" rel="stylesheet" type="text/css" />
    <link href="include/datatables/dataTables.bootstrap4.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <h1>Successful generated link, You can paste to target place!</h1>
&nbsp;&nbsp;
        <p ID="p1" runat="server" title=""></p>
        <Button ID="btnCopy" value="Copy to Clipboard" OnClick="btnCopyClicked()" >
Copy to Clipboard </button>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Close" />

    </form>
</body>
    
<script type="text/javascript">

    function btnCopyClicked() {
        //alert('here');
        var result = document.getElementById('p1');
        var text = result.textContent;
        if (!navigator.clipboard) {
            fallbackCopyTextToClipboard(text);
            return;
        }
        navigator.clipboard.writeText(text).then(function () {
            alert('Async: Copying to clipboard was successful!');
        }, function (err) {
            alert('Async: Could not copy text: ', err);
        });
    }
</script>
</html>
