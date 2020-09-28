<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdmin_CreateVehicle.aspx.cs" Inherits="SGAutomotriz.UserAdmin_CreateVehicle" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Alta de Vehiculos</title>
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
            alertify.success('Exito! al guardar');
        }
        function showAlert2() {
            alertify.success('Exito! al cambiar');
        }
        function showEmpty() {
            alertify.error('Campos vacios');
        }
        function showError() {
            alertify.error('Los pass no coinciden');
        }
        function showError2() {
            alertify.error('Error al cambiar');
        }
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
                        <i class="fa fa-user fa-fw"></i><asp:Label ID="Label1" runat="server" Text=""></asp:Label> <i class="fa fa-caret-down"></i>
                        </a>
                        <ul class="dropdown-menu dropdown-messages">
                            <li><a data-toggle="modal" data-target="#responsive" href="#" ><i class="fa fa-key fa-fw"></i> Cambiar password</a></li>
                            <li><a href="Index.aspx"><i class="fa fa-sign-out fa-fw"></i> Cerrar sesion</a></li>
                        </ul>
                    </li>
                </ul>
          <!------------------------------------------------ Menú Lateral ------------------------------------>
            <div class="navbar-default sidebar" role="navigation">
                <div class="sidebar-nav navbar-collapse">
                    <ul class="nav" id="side-menu">
                        <li>
                            <a href="UserAdmin_Home.aspx"><i class="fa fa-home fa-fw"></i> Inicio</a>
                        </li>
                        <li>
                            <a href="#"><i class="fa fa-users fa-fw"></i> Gestión de clientes<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <!-- son los logs de entradas al sistema -->
                                    <a href="UserAdmin_CreateClient.aspx">Alta de clientes</a>
                                </li>
                                <li>
                                    <!-- son los logs de acciones en la BD -->
                                    <a href="UserAdmin_DetailsClient.aspx">Edición de clientes</a>
                                </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                        <li>
                            <a href="#"><i class="fa fa-car fa-fw"></i> Gestion de Vehiculos<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <!-- son los logs de entradas al sistema -->
                                    <a href="UserAdmin_CreateVehicle.aspx">Alta de vehiculos</a>
                                </li>
                                <li>
                                    <!-- son los logs de acciones en la BD -->
                                    <a href="UserAdmin_DetailsVehicle.aspx">Edición de vehiculos</a>
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
                         <li>
                            <a href="#"><i class="fa fa-chain fa-fw"></i> Asignación Cliente - Vehiculo<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <!-- son los logs de entradas al sistema -->
                                    <a href="UserAdmin_CreateClientVehicle.aspx">Asignación</a>
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
                        <li>
                            <a href="#"><i class="fa fa-wrench fa-fw"></i> Bitácoras de trabajo<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <!-- son los logs de entradas al sistema -->
                                    <a href="UserAdmin_CreateBitacora.aspx">Crear bitácora</a>
                                </li>

                                <li>
                                    <!-- son los logs de acciones en la BD -->
                                    <a href="UserAdmin_DetailsBitacora.aspx">Buscar bitácora</a>
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
                    <h1 class="page-header">Alta de Vehiculos</h1>
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
                                            <label>Marca</label>
                                            <select class="form-control" id="marca" runat="server">
                                                <option disabled selected value>Selecciona una marca</option>
                                                <option>Audi</option>
                                                <option>Ford</option>
                                                <option>Chevrolet</option>
                                                <option>Volkswagen</option>
                                                <option>Nissan</option>
                                            </select>
                                        </div>
                                        <div class="form-group">
                                            <label>Nombre</label>
                                            <input class="form-control" id="nombre" type="text" runat="server" required>
                                        </div>
                                        <div class="form-group">
                                            <label>Modelo</label>
                                            <input class="form-control" id="modelo" type="text" runat="server" required>
                                        </div>
                                        <div class="form-group">
                                            <label>color</label>
                                            <input class="form-control" id="color" type="text" runat="server" required>
                                        </div>
                                        <div class="form-group">
                                            <label>cilindros</label>
                                            <input class="form-control" id="cilindros" type="text" runat="server" required>
                                        </div>
                                        <div class="form-group">
                                            <label>Detalles</label>
                                            <textarea class="form-control" id="otrodetalle" runat="server" rows="3"></textarea>
                                        </div>
                                        <asp:Button ID="save" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="save_Click"  />
                                        <asp:Button ID="clean" CssClass="btn btn-default" runat="server" Text="Limpiar" OnClick="clean_Click" />
                                   
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
            
            <div class="modal fade" id="responsive" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" runat="server">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel">Cambio Password</h4>
                                        </div>
                                        <div class="modal-body">
                                         <p>Nuevo password</p>
                                            <input class="form-control" id="pass" type="password" runat="server">
                                         <p>Confirma password</p>
                                            <input class="form-control" id="pass1" type="password" runat="server">   
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="modal" runat="server" Text="Cambiar" CssClass="btn btn-primary" OnClick="modal_Click" />
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
            
            </div>
            </form>
        </div>
        <!-- /#page-wrapper -->
    </div>
</body>
</html>
