<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGAutomotriz.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>SG Automotriz Solis</title>
    <link runat="server" rel="shortcut icon" href="~/icon.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="~/icon.ico" type="image/icon" />
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="css/sb-admin-2.css" rel="stylesheet">
    <!-- se utiliza CDN ya que en IIS se pone rudo xD -->
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <!-- Select Box it Css -->
    <link rel="stylesheet" type="text/css" href="css/jquery.selectBoxIt.css">
    <!-- alertas css -->
    <link rel="stylesheet" href="http://cdn.jsdelivr.net/alertifyjs/1.8.0/css/alertify.min.css"/>
    <!-- jQuery -->
    <script src="js/jquery.min.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
    <!-- Custom Theme JavaScript -->
    <script src="js/sb-admin-2.min.js"></script>
    <!-- Metis Menu Plugin JavaScript -->
    <script src="js/metisMenu.min.js"></script>
    <!-- alertas -->
    <script src="http://cdn.jsdelivr.net/alertifyjs/1.8.0/alertify.min.js"></script>
    <!-- script para selectboxit --->
   <%-- <script type="text/javascript" src="js/jquery-ui-1.8.23.custom.min.js"></script>
    <script type="text/javascript" src="js/jquery.selectBoxIt.min.js"></script>--%>
    <script type="text/javascript">
        function showAlert() {
            alertify.error('Revisa tu usuario y/o password');
        }
        function showAlert2() {
            alertify.error('Error de comunicación, intenta de nuevo');
        }
    </script> 
</head>
<body>
     <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">SG Automotriz Solis</h3>
                    </div>
                    <div class="panel-body">
                            <fieldset>
                                <form id="form1" runat="server">
                                    <div class="form-group">
                                        <input class="form-control" placeholder="Usuario" id="user" runat="server" type="text" autofocus>
                                    </div>
                                    <div class="form-group">
                                        <input class="form-control" placeholder="Password" id="password" runat="server" type="password">
                                    </div>
                                    <asp:Button ID="loginbutton" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Entrar" onclick="loginbutton_Click1" />
                                </form>
                             </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
