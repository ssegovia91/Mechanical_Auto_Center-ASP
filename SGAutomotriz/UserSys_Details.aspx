<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSys_Details.aspx.cs" Inherits="SGAutomotriz.UserSys_Details" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Usuarios del sistema</title>
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
        $(document).ready(function () {
            $('[id*=GridView1]').footable();
            $('[id*=GridView1] tr :last').closest('table').closest('tr').find('td').show();
            //$(window).resize(function () {
            //    location.reload();
            //});
            $('[id*=GridView1] tr :last').closest('table').closest('tr').on('click', function () {
                $(this).next('tr').hide();
            });
        });
        //alerta para notificar registro eliminado
        function showDelete() {
            alertify.success('Registro Eliminado!');
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
                    <h1 class="page-header">Edición de usuarios</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <div class="row">
                <div class="col-lg-12">
                           <form id="form1" runat="server">
                               <%--<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno">
                                   <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                   <Columns>
                                       <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0">
                                       </dx:GridViewCommandColumn>
                                       <dx:GridViewDataTextColumn FieldName="idUs">
                                       </dx:GridViewDataTextColumn>
                                       <dx:GridViewDataTextColumn FieldName="nombreUsuario">
                                       </dx:GridViewDataTextColumn>
                                       <dx:GridViewDataTextColumn FieldName="password">
                                       </dx:GridViewDataTextColumn>
                                       <dx:GridViewDataTextColumn FieldName="tipoUsuario">
                                       </dx:GridViewDataTextColumn>
                                       <dx:GridViewDataTextColumn FieldName="fechaCreacion">
                                       </dx:GridViewDataTextColumn>
                                       <dx:GridViewDataTextColumn FieldName="status">
                                       </dx:GridViewDataTextColumn>
                                   </Columns>
                               </dx:ASPxGridView>
                               --%>
                              <asp:GridView ID="GridView1" DataKeyNames="idUs" runat="server" AutoGenerateColumns="False" 
                                   PageSize="10" DataKeysName="ID" 
                                   CssClass="footable" AllowPaging="True" 
                                   OnPageIndexChanging="GridView1_PageIndexChanging" PagerStyle-CssClass="pagination">
                                        <Columns>
                                            <asp:BoundField DataField="idUs" HeaderText="ID" Visible="false" />
                                            <asp:BoundField DataField="nombreUsuario" HeaderText="Nombre Usuario"/>
                                            <asp:BoundField DataField="password" HeaderText="password" Visible="false"/>
                                            <asp:BoundField DataField="tipoUsuario" HeaderText="Tipo de Usuario"/>
                                            <asp:BoundField DataField="fechaCreacion" HeaderText="Fecha de Creacion"/>
                                            <asp:BoundField DataField="status" HeaderText="Status" Visible="false"/>
                                            <asp:HyperLinkField DataNavigateUrlFields="idUs" DataNavigateUrlFormatString="UserSys_Edit.aspx?idUs={0}" ControlStyle-CssClass="fa-edit" HeaderText="Edici&oacute;n">
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
                           </form>
                    </div>
                </div>
                <!-- /.col-lg-12 -->
           
        </div>
        <!-- /#page-wrapper -->
    </div>
</body>
</html>
