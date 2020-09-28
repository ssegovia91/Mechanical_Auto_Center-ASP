<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdmin_DetailsVehicle.aspx.cs" Inherits="SGAutomotriz.UserAdmin_DetailsVehicle" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Vehiculos</title>
        <link runat="server" rel="shortcut icon" href="~/icon.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="~/icon.ico" type="image/icon" />
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="css/sb-admin-2.css" rel="stylesheet">
    <!-- se utiliza CDN de font awesome ya que en IIS se pone rudo xD -->
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <!-- Select Box it Css -->
    <%--<link rel="stylesheet" type="text/css" href="css/jquery.selectBoxIt.css">--%>
    <!-- table responsive CDN --->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
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
    <%--<script type="text/javascript" src="js/jquery-ui-1.8.23.custom.min.js"></script>
    <script type="text/javascript" src="js/jquery.selectBoxIt.min.js"></script>--%>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        //script para el paginator del footable
        $(function () {
            $('[id*=GridView1]').footable();
            $('[id*=GridView1] tr :last').closest('table').closest('tr').find('td').show();
            //$(window).resize(function () {
            //    location.reload();
            //});
            $('[id*=GridView1] tr :last').closest('table').closest('tr').on('click', function () {
                $(this).next('tr').hide();
            });
        });
       
        //function showConfirm() {
        //    alertify.confirm('Confirm Title', 'Confirm Message', function () { alert('ok');} , function () { alertify.confirm().close(); });
        //}

        //alerta para notificar registro eliminado
        function showDelete() {
            alertify.success('Registro Eliminado!');
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
                    <h1 class="page-header">Vehiculos</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <div class="row">
                <div class="col-lg-12">
                           <form id="form1" runat="server">
                               <asp:GridView ID="GridView1" DataKeyNames="idVehiculo" runat="server" AutoGenerateColumns="False" 
                                   PageSize="10" DataKeysName="ID" 
                                   CssClass="footable" AllowPaging="True" 
                                   OnPageIndexChanging="GridView1_PageIndexChanging" PagerStyle-CssClass="pagination">
                                        <Columns>
                                            <asp:BoundField DataField="idVehiculo" HeaderText="ID" Visible="false" />
                                            <asp:BoundField DataField="marca" HeaderText="Marca"/>
                                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                            <asp:BoundField DataField="modelo" HeaderText="Modelo"/>
                                            <asp:BoundField DataField="color" HeaderText="Color"/>
                                            <asp:BoundField DataField="cilindros" HeaderText="Cilindros"/>
                                            <asp:BoundField DataField="otrodetalle" HeaderText="Detalles" />
                                            <asp:HyperLinkField DataNavigateUrlFields="idVehiculo" DataNavigateUrlFormatString="UserAdmin_EditVehicle.aspx?idVehiculo={0}" ControlStyle-CssClass="fa-edit" HeaderText="Edici&oacute;n">
                                            <ControlStyle CssClass="fa fa-edit"></ControlStyle>
                                            </asp:HyperLinkField>
                                            <asp:TemplateField HeaderText="Eliminar">
                                                <ItemTemplate>
                                                    <span onclick="return confirm('estas seguro de eliminar este registro?')">
                                                        <asp:LinkButton ID="LinkButton1"  runat="server" OnClick="Button2_Click2"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                   <PagerSettings FirstPageText="Inicio" LastPageText="&nbsp; - Ultimo" Mode="NextPreviousFirstLast" NextPageText="&nbsp; - Siguiente" PreviousPageText="&nbsp; - Anterior" />
                                </asp:GridView>
                         
                    </div>
                </div>
                <!-- /.col-lg-12 -->
              
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
