
namespace case_4
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            string login = login_textBox.Text;
            string password = password_textBox.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }
            if (DatabaseManager.ValidateUser(login, password))
            {
                MusicForMeApp mainForm = new MusicForMeApp(login);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
    