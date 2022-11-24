using apisistec.Context;
using apisistec.Entities;
using apisistec.Enums;
using apisistec.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Reflection;

namespace apisistec.Services
{
    public class MailingService : IMailingService
    {
        private DataContext _context;
        public MailingService(DataContext context)
        {
            _context = context;
        }
        public string? sendMail(string mailTo, object sendObject, string typeMail = TypesMail.CREATE_USER)
        {
            Mailing configUSerMail = configurationSenderUser();
            if (configUSerMail == null)
                throw new Exception("No existe un correo previamente configurado");

            TemplateMails? template = _context.TemplateMails.Where(x => x.name == typeMail).FirstOrDefault();
            if (template == null)
                throw new Exception($"No existe un template previamente configurado con nombre: {typeMail}");

            MimeMessage headeMail = headerEmail(configUSerMail, mailTo, obtenerSubjectEmail(typeMail), template, sendObject);
            var responseSendEmail = SendMailSMTP(headeMail, configUSerMail);
            return responseSendEmail;
        }

        public string obtenerSubjectEmail(string typeEmail)
        {
            switch (typeEmail)
            {
                case TypesMail.BUY_PLAN: return "PAGO DEL PLAN";
                case TypesMail.RESTORE_EMAIL: return "RESTAURAR CONTRASEÑAR";
                default: return "BIENVENIDO AL SISTEMA WISE";
            }
        }

        public MimeMessage headerEmail(Mailing configUSerMail,
                                string mailTo,
                                string subject,
                                TemplateMails template,
                                object objectReplace)
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(configUSerMail.Username));
            email.To.Add(MailboxAddress.Parse(mailTo));
            email.Subject = subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = replaceParamsInHtml(template.template, objectReplace);
            email.Body = builder.ToMessageBody();
            return email;
        }

        private string SendMailSMTP(MimeMessage email, Mailing userConfiguration)
        {
            using var smtp = new SmtpClient();
            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            smtp.Connect(userConfiguration.Host, userConfiguration.Port, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(userConfiguration.Username, userConfiguration.Password);
            string response = smtp.Send(email);
            smtp.Disconnect(true);
            return response;
        }

        public Mailing configurationSenderUser()
        {
            Mailing? template = _context.Mailing.FirstOrDefault();
            return template;

        }
        public string replaceParamsInHtml(string bodyHtml, object parameters)
        {
            string templateBase = getTemplateBase();
            templateBase = templateBase.Replace("{body}", bodyHtml);
            Type _type = parameters.GetType();
            PropertyInfo[] listaPropiedades = _type.GetProperties();
            foreach (PropertyInfo property in listaPropiedades)
            {
                if (property != null)
                {
                    string NombreAtributo = property.Name;
                    if (property.GetValue(parameters) is not null)
                    {
                        string? Valor = property.GetValue(parameters).ToString();
                        templateBase = templateBase.Replace("{" + property.Name + "}", Valor);
                    }
                }
            }
            return templateBase;
        }

        private string getTemplateBase()
        {
            TemplateMails? template = _context.TemplateMails.FirstOrDefault(x => x.name == TypesMail.TEMPLATE_BASE);
            if (template == null)
                return "";
            return template.template;
        }


    }
}
