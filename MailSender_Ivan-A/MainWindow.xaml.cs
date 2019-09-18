using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender_Ivan_A
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var host = "smtp.yandex.ru";
            var port = 25;

            var user_name = UserName.Text;
            SecureString password = UserPassword.SecurePassword;

            var msg = "Hellow, It's test message from C# lessons" + DateTime.Now;

            using (var client = new SmtpClient(host, port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(user_name, password);

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress("aiscorp@yandex.ru", "Ivan A");
                    message.To.Add(new MailAddress("aiscorp@yandex.ru", "Ivan A"));
                    message.Subject = "Mail header from " + DateTime.Now;
                    //message.Attachments.Add(new Attachment());

                    try
                    {
                        client.Send(message);
                        MessageBox.Show("Message has delivered!");

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Message delivering was failed!");
                        throw;
                    }
                }
            }


        }
    }
}
