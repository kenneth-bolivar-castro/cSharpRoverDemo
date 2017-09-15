﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoAutorizado.aspx.cs" Inherits="slnRoverUI.admin.NoAutorizado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>No Autorizado</title>
    <link rel="shortcut icon" href="/favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <h1>
                <font color="red">Error de verificacion de credenciales.</font>
            </h1>
            <hr width="100%" size="1" />
            <h2>
                <i>No se ha iniciado session.</i>
            </h2>
        </div>
        <font face="Arial, Helvetica, Geneva, SunSans-Regular, sans-serif ">
            <b>Descripción: </b>
            Se ha intentado ingresar a una pagina sin primero realizar el inicio de session.
            <br />
            <br />
            <b>Valide Primero Su Informacion: </b>
            <br />
            <a href="/admin/Default.aspx" title="Inicio Session">Inicio Session</a>
            <br />
            <br />
        </font>
        <hr width="100%" size="1" />
    </div>
    </form>
</body>
</html>
