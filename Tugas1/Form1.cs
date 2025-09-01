using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BindingList<User> users = new BindingList<User>();
        private static string phonePattern = @"^(\+62|62|0)(8[1-9][0-9])[0-9]{6,9}$";
        private static Regex phoneRegex = new Regex(phonePattern, RegexOptions.Compiled);

        public static bool IsValidIndonesianPhone(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Remove any spaces, hyphens, or other common separators
            string cleanNumber = Regex.Replace(phoneNumber, @"[\s\-\.\(\)]", "");

            return phoneRegex.IsMatch(cleanNumber);
        }

        private bool formValidation()
        {

            return true;
        }
        private bool isEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool isEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (isEmpty(textBox1.Text) ||
                isEmpty(textBox2.Text) ||
                isEmpty(textBox3.Text) ||
                isEmpty(textBox4.Text) ||
                isEmpty(textBox5.Text) ||
                isEmpty(textBox6.Text) ||
                isEmpty(textBox7.Text) ||
                comboBox1.SelectedItem == null ||
                (!radioButton1.Checked && !radioButton2.Checked)
                )
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }

            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Password and Confirm Password do not match.");
                return;
            }
            if (!isEmailValid(textBox6.Text))
            {
                MessageBox.Show("Email is not valid.");
                return;
            }
            if (!IsValidIndonesianPhone(textBox4.Text))
            {
                MessageBox.Show("Phone Number is not valid.");
                return;
            }

            User u = new User(
                textBox1.Text,
                textBox5.Text,
                textBox2.Text,
                textBox3.Text,
                (int)numericUpDown1.Value,
                radioButton1.Checked ? "Laki-laki" : "Perempuan",
                comboBox1.SelectedItem.ToString(),
                textBox6.Text,
                textBox4.Text,
                textBox7.Text
                );

            users.Add(u);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (users.Count > 0)
            {
                User u = users[comboBox2.SelectedIndex];

                listBox1.Items.Clear();
                listBox1.Items.Add("Username: " + u.username);
                listBox1.Items.Add("Nama Lengkap: " + u.nama_lengkap);
                listBox1.Items.Add("Password: " + u.password);
                listBox1.Items.Add("Umur: " + u.umur);
                listBox1.Items.Add("Jenis Kelamin: " + u.jenis_kelamin);
                listBox1.Items.Add("Status Pendidikan: " + u.status_pendidikan);
                listBox1.Items.Add("Alamat: " + u.alamat);
                listBox1.Items.Add("Nomor Handphone: " + u.nomor_handphone);
                listBox1.Items.Add("Email: " + u.email);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = users;
            comboBox2.DisplayMember = "username";
        }

        private void UpdateProgress()
        {
            int progress = 0;

            if (!isEmpty(textBox1.Text)) progress += 10;
            if (!isEmpty(textBox2.Text)) progress += 10;
            if (!isEmpty(textBox3.Text)) progress += 10;
            if (IsValidIndonesianPhone(textBox4.Text)) progress += 10;
            if (!isEmpty(textBox5.Text)) progress += 10;
            if (isEmailValid(textBox6.Text)) progress += 10;
            if (!isEmpty(textBox7.Text)) progress += 10;
            if (comboBox1.SelectedItem != null) progress += 10;
            if (radioButton1.Checked || radioButton2.Checked) progress += 10;
            if (numericUpDown1.Value > 0) progress += 10;

            progressBar1.Value = progress;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void groupBox1_Leave(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            UpdateProgress();
        }
    }
}
