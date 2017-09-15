using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace slnRoverHerramientas
{
    public class CorreoElectronico
    {
        private static Configuraciones configuraciones;
        private MailMessage correo;
        private SmtpClient smtp;
        private NetworkCredential credenciales;

        public CorreoElectronico()
        {
            CorreoElectronico.configuraciones = Configuraciones.Instancia; 
            correo = new MailMessage();
            smtp = new SmtpClient(configuraciones.SRV_SMTP,configuraciones.PRT_SRV_SMTP);
            credenciales = new NetworkCredential(configuraciones.USR_SMTP,configuraciones.CLV_USR_SMTP);
        }

        private bool enviarCorreoElectronico() 
        {
            bool salida = false;
            try
            {
                this.smtp.EnableSsl = false;
                this.smtp.UseDefaultCredentials = false;
                this.smtp.Host = configuraciones.SRV_SMTP;
                this.smtp.Credentials = this.credenciales;
                this.smtp.Port = configuraciones.PRT_SRV_SMTP;
                this.smtp.Send(this.correo);
                salida = true;
            }
            catch (Exception ex)
            {
                Herramientas.Excepcion = ex;
            }
            finally
            {
                this.correo.Dispose();
            }
            return salida;
        }

        public bool enviarCorreoRestableceClave(string CorreoDestino, string CuerpoCorreo)
        {
            correo.From = new MailAddress(configuraciones.USR_SMTP);
            correo.To.Add(new MailAddress(CorreoDestino));
            correo.Subject = "RESTABLECER CLAVE REPUESTOS ROVER " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            correo.Body = CuerpoCorreo;
            correo.IsBodyHtml = true;
            return this.enviarCorreoElectronico();
        }

        public bool enviarCorreoContactenos(string CuerpoCorreo)
        {
            correo.From = new MailAddress(configuraciones.USR_SMTP);
            correo.To.Add(new MailAddress(configuraciones.CorreoContactenos));
            correo.Subject = "NUEVO CONTACTENOS REPUESTOS ROVER "+DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            correo.Body = CuerpoCorreo;
            correo.IsBodyHtml = true;
            return this.enviarCorreoElectronico();
        }

    }
}
