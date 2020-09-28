<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSys_Edit.aspx.cs" Inherits="SGAutomotriz.UserSys_Edit" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Edición de usuarios</title>
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
    <!-- jQuery -->
    <script src="js/jquery.min.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
    <!-- Custom Theme JavaScript -->
    <script src="js/sb-admin-2.min.js"></script>
    <!-- Metis Menu Plugin JavaScript -->
    <script src="js/metisMenu.min.js"></script>
    <!-- script para selectboxit --->
    <%--<script type="text/javascript" src="js/jquery-ui-1.8.23.custom.min.js"></script>
    <script type="text/javascript" src="js/jquery.selectBoxIt.min.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function() {
        //Calls the selectBoxIt method on your HTML select box.
        //var selectBox = $("select#tipoUsuario").selectBoxIt().data("Ninguno");         
        });
    </script> 
</head>
<body>
    <div id="wrapper">
        <!------------------------------------------------ Header ------------------------------------>
            <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#">SG Automotriz Solis</a>
                </div>
                <ul class="nav navbar-top-links navbar-right">
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="fa fa-user fa-fw"></i> Sysadmin <i class="fa fa-caret-down"></i>
                        </a>
                        <ul class="dropdown-menu dropdown-messages">
                            <%--<li><a href="#"><i class="fa fa-gear fa-fw"></i> Configuración</a></li>
                            <li class="divider"></li>--%>
                            <li><a href="Index.aspx"><i class="fa fa-sign-out fa-fw"></i> Cerrar sesion</a>
                            </li>
                        </ul>
                    </li>
                </ul>
          <!------------------------------------------------ Menú Lateral ------------------------------------>
            <div class="navbar-default sidebar" role="navigation">
                <div class="sidebar-nav navbar-collapse">
                    <ul class="nav" id="side-menu">
                        <li>
                            <a href="#"><i class="fa fa-home fa-fw"></i> Inicio</a>
                        </li>
                        <li>
                            <a href="#"><i class="fa fa-users fa-fw"></i> Gestión de usuarios<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <!-- son los logs de entradas al sistema -->
                                    <a href="UserSys_Create.aspx">Alta de usuarios</a>
                                </li>
                                <li>
                                    <!-- son los logs de acciones en la BD -->
                                    <a href="UserSys_Details.aspx">Edición de usuarios</a>
                                </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                        <li>
                            <a href="#"><i class="fa fa-book fa-fw"></i> Logs<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <!-- son los logs de entradas al sistema -->
                                    <a href="#">Logs de acceso</a>
                                </li>
                                <li>
                                    <!-- son los logs de acciones en la BD -->
                                    <a href="#">Logs de operacion</a>
                                </li>
                                <%--<li>
                                    <a href="#">Third Level <span class="fa arrow"></span></a>
                                    <ul class="nav nav-third-level">
                                        <li>
                                            <a href="#">Third Level Item</a>
                                        </li>
                                        <li>
                                            <a href="#">Third Level Item</a>
                                        </li>
                                        <li>
                                            <a href="#">Third Level Item</a>
                                        </li>
                                        <li>
                                            <a href="#">Third Level Item</a>
                                        </li>
                                    </ul>
                                </li>--%>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                    </ul>
                </div>
                <!-- /.sidebar-collapse -->
            </div>
            <!-- /.navbar-static-side -->
        </nav>
    <!---- Body ----------------------------------------------------------------------------->
        <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Editar usuario</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Ingrese los siguientes datos
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <form id="form1" runat="server">
                                        <div class="form-group">
                                            <label>Usuario</label>
                                            <input class="form-control" id="userName" type="text" runat="server" required>
                                        </div>
                                        <div class="form-group">
                                            <label>Contraseña</label>
                                            <input class="form-control" id="pass" type="password" runat="server" required>
                                        </div>
                                        <div class="form-group">
                                            <label>Confirma Contraseña</label>
                                            <input class="form-control" id="pass1" type="password" runat="server" required>
                                        </div>
                                         <div class="form-group">
                                            <label>Tipo de usuario</label>
                                             <select  id="tipoUsuario" class="form-control" runat="server">
                                                   <option value="Ninguno" selected>Selecciona tipo de usuario</option>
                                                    <option value="Administrador">Administrador</option>
                                                    <option value="Invitado">Invitado</option>
                                             </select>
                                        </div>
                                        <asp:Button ID="save" CssClass="btn btn-primary" runat="server" Text="Guardar"  />
                                        <asp:Button ID="cancel" CssClass="btn btn-default" runat="server" Text="Cancelar"  />
                                    </form>
                                </div>
                            </div>
                            <!-- /.row (nested) -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /#page-wrapper -->
    </div>
</body>
</html>
