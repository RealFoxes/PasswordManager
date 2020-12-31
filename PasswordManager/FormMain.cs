using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PasswordManager
{
	public partial class FormMain : Form
	{
        List<Account> accounts;
		static string pathOfFile = @"Passwords.aes";
        private string _PasswordForCrypt;
		string PasswordForCryptGet() => Decrypt(_PasswordForCrypt, KeyFromPassword);
		
        void PasswordForCryptSet(string PasswordForCrypt)
        {
            textBoxAuth.Clear();
              _PasswordForCrypt = Encrypt(PasswordForCrypt, KeyFromPassword);
        }

		private const int Keysize = 256;
        private const int DerivationIterations = 1000;
        static bool IsFileExist() => File.Exists(pathOfFile);
		string symbols = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM[]!@#$%^&*()1234567890";
		string keyOfIntegrity = "IntegrityOfFileTRUE\n";
        string KeyFromPassword ="";
		Random random;
		public FormMain()
		{
			InitializeComponent();
			random = new Random();
            accounts = new List<Account>();
			for (int i = 0; i < 12; i++)
			{
                KeyFromPassword += symbols[random.Next(symbols.Length)];
			}
		}

		private void textBoxAuth_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				PasswordForCryptSet(textBoxAuth.Text);
				panelAuth.Visible = !LoadPasswords();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
            PasswordForCryptSet(textBoxAuth.Text);
            panelAuth.Visible = !LoadPasswords();

		}
        public static string Encrypt(string plainText, string passPhrase)
        {
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }

        private bool LoadPasswords()
        {
            if (IsFileExist())
            {
                return UpdateDataGridView();

            }
            else
            {
                Account account = new Account() { Service = "Тестовый Сервис", Login = "Логин", Password = "Пароль", Description = "Описание" };
                accounts.Clear();
                accounts.Add(account);
                ReWriteFile();
                return UpdateDataGridView();
            }
        }

        private void ReWriteFile()
        {
            string json = JsonConvert.SerializeObject(accounts);
            json = json.Insert(0, keyOfIntegrity);
            json = Encrypt(json, PasswordForCryptGet());
            using (var fileStream = File.Create(pathOfFile))
            {
                fileStream.Write(Encoding.UTF8.GetBytes(json), 0, json.Length);
                fileStream.Close();
            }
        }

        private bool UpdateDataGridView()
		{
            string file = File.ReadAllText(pathOfFile);
			try
			{
                file = Decrypt(file, PasswordForCryptGet());
                if (file.StartsWith(keyOfIntegrity))
                {
                    file = file.Replace(keyOfIntegrity, "");
                    accounts = JsonConvert.DeserializeObject<List<Account>>(file);
                }
                else
                {
                    MessageBox.Show("Неправильный пароль");
                    return false;
                }
                dataGridView.Rows.Clear();
                comboBoxService.Items.Clear();
                List<object> list = new List<object>();
                for (int i = 0; i < accounts.Count; i++)
                {
                    Account account = accounts[i];
                    list.Add(account.Service.ToString());
                    dataGridView.Rows.Add(i, account.Service, account.Login, account.Description);
                }
                comboBoxService.Items.AddRange(list.Cast<string>().ToList().Distinct().ToArray());
                return true;
            }
			catch (Exception)
			{
				MessageBox.Show("Неправильный пароль");
                return false;
            }
            
        }

		private void buttonAddAccount_Click(object sender, EventArgs e)
		{
            Account account = new Account() { Service = comboBoxService.Text, Login = textBoxLogin.Text, Password = textBoxPassword.Text, Description = textBoxDescription.Text };
            accounts.Add(account);
            ReWriteFile();
            UpdateDataGridView();
		}

		private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
            int id = (int)dataGridView.CurrentRow.Cells[0].Value;
            Account account = accounts[id];
            comboBoxService.Text = account.Service;
            textBoxLogin.Text = account.Login;
            textBoxPassword.Text = account.Password;
            textBoxDescription.Text = account.Description;
        }

		private void buttonCreatePassword_Click(object sender, EventArgs e)
		{
            textBoxPassword.Clear();
			for (int i = 0; i < 10; i++)
			{
                textBoxPassword.Text += symbols[random.Next(symbols.Length)];
			}
		}

		private void buttonCopyPassword_Click(object sender, EventArgs e)
		{
            Clipboard.SetText(textBoxPassword.Text);
        }

		private void buttonChangeAccount_Click(object sender, EventArgs e)
		{
            int id = (int)dataGridView.CurrentRow.Cells[0].Value;
            accounts[id] = new Account() { Service = comboBoxService.Text, Login = textBoxLogin.Text, Password = textBoxPassword.Text, Description = textBoxDescription.Text };
            ReWriteFile();
            UpdateDataGridView();
        }

		private void buttonExport_Click(object sender, EventArgs e)
		{
            string file = File.ReadAllText(pathOfFile);
            file = Decrypt(file, PasswordForCryptGet());
            if (file.StartsWith(keyOfIntegrity))
            {
                file = file.Replace(keyOfIntegrity, "");
                var temp = JsonConvert.DeserializeObject<List<Account>>(file);
                file = JsonConvert.SerializeObject(temp, Formatting.Indented);

                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = PasswordForCryptGet();

                    zip.AddEntry("Passwords.json", Encoding.UTF8.GetBytes(file));
                    zip.Save("Passwords.zip");
                }
            }
        }

		private void buttonDelete_Click(object sender, EventArgs e)
		{
            int id = (int)dataGridView.CurrentRow.Cells[0].Value;
            accounts.RemoveAt(id);
            ReWriteFile();
            UpdateDataGridView();
        }

		private void textBoxSearch_TextChanged(object sender, EventArgs e)
		{
            dataGridView.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.Cells["ColumnService"].Value.ToString().Contains(textBoxSearch.Text))
                .ToList().ForEach(r=> r.Visible=false);

            dataGridView.Rows.Cast<DataGridViewRow>()
                .Where(r => r.Cells["ColumnService"].Value.ToString().Contains(textBoxSearch.Text))
                .ToList().ForEach(r=> r.Visible=true);
		}
	}
}