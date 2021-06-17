using System;

namespace BuilderParametr
{
    class Program
    {
        static void Main(string[] args)
        {
            var mail = new MailService();
            mail.SendEmail(e => e
                                .From("sender@mail.ru")
                                .To("test@mail.ru")
                                .Subject("Test message")
                                .Body("Hello world!"));

            Console.ReadLine();
        }
    }

    public class MailService
    {
        public class EmailBuilder
        {
            public class Email
            {
                public string From, To, Subject, Body;
            }

            private readonly Email _email;
            public EmailBuilder(Email email) => _email = email;

            public EmailBuilder From(string from)
            {
                _email.From = from;
                return this;
            }
            public EmailBuilder To(string to)
            {
                _email.To = to;
                return this;
            }
            public EmailBuilder Subject(string subject)
            {
                _email.Subject = subject;
                return this;
            }
            public EmailBuilder Body(string body)
            {
                _email.Body = body;
                return this;
            }
        }

        private void SendEmailInternal(EmailBuilder.Email email) 
        {
            Console.WriteLine($"Сообщение с темой \"{email.Subject}\" - отправлено {DateTime.Now.ToShortTimeString()}");
        }
        public void SendEmail(Action<EmailBuilder> builder)
        {
            var email = new EmailBuilder.Email();
            builder(new EmailBuilder(email));
            SendEmailInternal(email);
        }
    }

}
