namespace Integrate.Utils
{
    using System;
    using System.Collections;
    using System.Net.Mail;
    using System.Text;

    public class cFuncionesMail
    {

        private static void sendMailMessage(MailMessage mailMessage)
        {
            string mailHost = cParametrosUtils.mailHost;
            SmtpClient smtpClient = new SmtpClient(mailHost, 25);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
            smtpClient.Send(mailMessage);
        }


        public static void SendMeetingRequest(DateTime startTime, string mailDestino, string mailAsunto, string mailMsj)
        {
            try
            {
                startTime = startTime.AddHours(4);
                SmtpClient sc = new SmtpClient(cParametrosUtils.mailHost);

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(cParametrosUtils.mailFrom, "Sistema");
                msg.To.Add(new MailAddress(mailDestino, mailDestino));
                msg.Subject = mailAsunto;
                msg.Body = mailMsj;

                StringBuilder str = new StringBuilder();
                str.AppendLine("BEGIN:VCALENDAR");
                str.AppendLine("PRODID:-//Ahmed Abu Dagga Blog");
                str.AppendLine("VERSION:2.0");
                str.AppendLine("METHOD:REQUEST");
                str.AppendLine("BEGIN:VEVENT");
                str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", startTime));
                str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));
                str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", startTime.AddMinutes(5)));
                str.AppendLine("LOCATION: Autoridad de Fiscalización y Control Social de Pensiones y Seguros (APS)");
                str.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
                str.AppendLine(string.Format("DESCRIPTION:{0}", msg.Body));
                str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", msg.Body));
                str.AppendLine(string.Format("SUMMARY:{0}", msg.Subject));
                str.AppendLine(string.Format("ORGANIZER:MAILTO:{0}", msg.From.Address));

                str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", msg.To[0].DisplayName, msg.To[0].Address));

                str.AppendLine("BEGIN:VALARM");
                str.AppendLine("TRIGGER:-PT15M");
                str.AppendLine("ACTION:DISPLAY");
                str.AppendLine("DESCRIPTION:Reminder");
                str.AppendLine("END:VALARM");
                str.AppendLine("END:VEVENT");
                str.AppendLine("END:VCALENDAR");
                System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType("text/calendar");
                ct.Parameters.Add("method", "REQUEST");
                AlternateView avCal = AlternateView.CreateAlternateViewFromString(str.ToString(), ct);
                msg.AlternateViews.Add(avCal);

                sc.Port = cParametrosUtils.mailPort;
                sc.Credentials = new System.Net.NetworkCredential(cParametrosUtils.mailUsername, cParametrosUtils.mailPassword);
                sc.Send(msg);
            }
            catch (Exception exp)
            {
                if (cParametrosUtils.mailNotificarError)
                    throw exp;
            }
        }

        public static void SendMeetingRequest(DateTime startTime, DateTime endTime, string mailDestino, string mailAsunto, string mailMsj)
        {
            try
            {
                startTime = startTime.AddHours(4);
                endTime = endTime.AddHours(4);
                SmtpClient sc = new SmtpClient(cParametrosUtils.mailHost);

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(cParametrosUtils.mailFrom, "Sistema");
                msg.To.Add(new MailAddress(mailDestino, mailDestino));
                msg.Subject = mailAsunto;
                msg.Body = mailMsj;

                StringBuilder str = new StringBuilder();
                str.AppendLine("BEGIN:VCALENDAR");
                str.AppendLine("PRODID:-//Ahmed Abu Dagga Blog");
                str.AppendLine("VERSION:2.0");
                str.AppendLine("METHOD:REQUEST");
                str.AppendLine("BEGIN:VEVENT");
                str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", startTime));
                str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));
                str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", endTime));
                str.AppendLine("LOCATION: Autoridad de Fiscalización y Control Social de Pensiones y Seguros (APS)");
                str.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
                str.AppendLine(string.Format("DESCRIPTION:{0}", msg.Body));
                str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", msg.Body));
                str.AppendLine(string.Format("SUMMARY:{0}", msg.Subject));
                str.AppendLine(string.Format("ORGANIZER:MAILTO:{0}", msg.From.Address));

                str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", msg.To[0].DisplayName, msg.To[0].Address));

                str.AppendLine("BEGIN:VALARM");
                str.AppendLine("TRIGGER:-PT15M");
                str.AppendLine("ACTION:DISPLAY");
                str.AppendLine("DESCRIPTION:Reminder");
                str.AppendLine("END:VALARM");
                str.AppendLine("END:VEVENT");
                str.AppendLine("END:VCALENDAR");
                System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType("text/calendar");
                ct.Parameters.Add("method", "REQUEST");
                AlternateView avCal = AlternateView.CreateAlternateViewFromString(str.ToString(), ct);
                msg.AlternateViews.Add(avCal);

                sc.Port = cParametrosUtils.mailPort;
                sc.Credentials = new System.Net.NetworkCredential(cParametrosUtils.mailUsername, cParametrosUtils.mailPassword);
                sc.Send(msg);
            }
            catch (Exception exp)
            {
                if (cParametrosUtils.mailNotificarError)
                    throw exp;
            }
        }

        public static void sendMail(string mailDestino, string mailAsunto, string mailMsj, string strPathAdjunto)
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient(cParametrosUtils.mailHost);

                mail.From = new MailAddress(cParametrosUtils.mailFrom);
                mail.To.Add(mailDestino);
                mail.Subject = mailAsunto;
                mail.Body = mailMsj;

                Attachment attachment = new Attachment(strPathAdjunto);
                mail.Attachments.Add(attachment);

                smtpServer.Port = cParametrosUtils.mailPort;
                smtpServer.Credentials = new System.Net.NetworkCredential(cParametrosUtils.mailUsername, cParametrosUtils.mailPassword);
                //SmtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (Exception exp)
            {
                if (cParametrosUtils.mailNotificarError)
                    throw exp;
            }
        }

        public static void sendMail(string mailDestino, string mailAsunto, string mailMsj)
        {
            try
            {

                SmtpClient smtpServer = new SmtpClient(cParametrosUtils.mailHost, cParametrosUtils.mailPort)
                {
                    UseDefaultCredentials = true,
                    Credentials = new System.Net.NetworkCredential(cParametrosUtils.mailUsername, cParametrosUtils.mailPassword),
                    EnableSsl = true
                };
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(cParametrosUtils.mailFrom, "NeuroDiagnostico");
                mail.To.Add(mailDestino);
                mail.Subject = mailAsunto;
                mail.Body = mailMsj;
                mail.IsBodyHtml = true;


                smtpServer.Send(mail);
            }
            catch (Exception exp)
            {
                //if (cParametrosUtils.mailNotificarError)
                throw exp;
            }
        }

        public static void sendMail(ArrayList mailDestino, string mailAsunto, string mailMsj)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient(cParametrosUtils.mailHost);

                mail.From = new MailAddress(cParametrosUtils.mailFrom);

                foreach (string destinatario in mailDestino)
                {
                    mail.To.Add(destinatario);
                }
                mail.Subject = mailAsunto;
                mail.Body = mailMsj;

                smtpServer.Port = cParametrosUtils.mailPort;
                smtpServer.Credentials = new System.Net.NetworkCredential(cParametrosUtils.mailUsername, cParametrosUtils.mailPassword);
                //smtpServer.EnableSsl = true;
                //smtpServer.Timeout = 10;

                smtpServer.Send(mail);
            }
            catch (Exception exp)
            {
                if (cParametrosUtils.mailNotificarError)
                    throw exp;


            }
        }
    }
}
