using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManagerConsole
{
	class Program
	{
		static List<Account> accounts = new List<Account>();
		static string pathOfFile = @"Passwords.aes";
		static bool IsFileExist() => File.Exists(pathOfFile);
		static string _PasswordForCrypt;
		static string KeyFromPassword = "";
		static string PasswordForCryptGet() => Crypt.Decrypt(_PasswordForCrypt, KeyFromPassword);
		static void PasswordForCryptSet(string PasswordForCrypt) => _PasswordForCrypt = Crypt.Encrypt(PasswordForCrypt, KeyFromPassword);
		static Random random = new Random();
		static string symbols = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM[]!@#$%^&*()1234567890";
		static string keyOfIntegrity = "IntegrityOfFileTRUE\n";
		
		static void Main(string[] args)
		{
			Console.InputEncoding = Encoding.UTF8;
			Console.OutputEncoding = Encoding.UTF8;

			

			Console.WriteLine("Enter your password");
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 12; i++) //Create key for password
			{
				stringBuilder.Insert(i, symbols[random.Next(symbols.Length)]);
			}
			KeyFromPassword = stringBuilder.ToString();
			PasswordForCryptSet(GetConsolePassword());
			Console.Clear();

			if (!IsFileExist())
			{
				Account account = new Account() { Service = "ServiceSample", Login = "LoginSample", Password = "PasswordSample", Description = "DescriptionExample" };
				accounts.Add(account);
				ReWriteFile();
			}
			while (true)
			{
				Console.Clear();
				ReadFile();
				Console.WriteLine(Table.GetStringTable(accounts, new string[] { "Service", "Login" }));
				WriteHelp();
				switch (Console.ReadLine())
				{
					case "exit":
						Environment.Exit(0);
						break;
					case "selectRow":
						Console.WriteLine("Enter the Id of account");
						try
						{
							int id = Convert.ToInt32(Console.ReadLine());
							SelectLine(id);

						}
						catch (Exception)
						{
							Console.WriteLine("Wrong input!");
						}
						
						break;
					case "addRow":
						Account account = new Account();
						Console.WriteLine("Enter the Service");
						account.Service = Console.ReadLine();
						Console.WriteLine("Enter the Login");
						account.Login = Console.ReadLine();
						Console.WriteLine("Enter the Password");
						account.Password = GetConsolePassword();
						Console.WriteLine("Enter the Description");
						account.Description = Console.ReadLine();
						accounts.Add(account);
						ReWriteFile();
						Console.WriteLine("The account was added succesfully!");
						Console.WriteLine("Press any key to contiune...");
						Console.ReadKey();
						break;
					case "deleteRow":
						Console.WriteLine("Enter the Id of account");
						try
						{
							accounts.RemoveAt(Convert.ToInt32(Console.ReadLine()));
							ReWriteFile();
							Console.WriteLine("The account was removed succesfully!");
						}
						catch (Exception)
						{
							Console.WriteLine("Wrong input!");
						}
						Console.WriteLine("Press any key to contiune...");
						Console.ReadKey();

						break;
					case "exportZip":
						ExportZip();
						Console.WriteLine("The export was succesful!");
						Console.WriteLine("Your password from the archive is the password that you entered at the start");
						Console.WriteLine("Press any key to contiune...");
						Console.ReadKey();
						break;
					default:
						Console.WriteLine("Command does not exist!");
						Console.WriteLine("Press any key to contiune...");
						Console.ReadKey();
						break;
				}
			}
		}
		static void SelectLine(int id)
		{
			while (true)
			{
				ReadFile();
				Console.Clear();
				Console.WriteLine(Table.GetStringTable(accounts.GetRange(id,1), new string[] { "Service", "Login" }));
				Console.WriteLine("Description:");
				Console.WriteLine(accounts[id].Description);
				Console.WriteLine();
				WriteRowHelp();
				switch (Console.ReadLine())
				{
					case "changeService":
						Console.WriteLine("Enter the new name of Service");
						accounts[id].Service = Console.ReadLine();
						ReWriteFile();
						Console.WriteLine("The Service was changed succesfully!");
						Console.WriteLine("Press any key to contiune...");
						Console.ReadKey();
						break;
					case "changeLogin":
						Console.WriteLine("Enter the new Login");
						accounts[id].Login = Console.ReadLine();
						ReWriteFile();
						Console.WriteLine("The Login was changed succesfully!");
						Console.WriteLine("Press any key to contiune...");
						Console.ReadKey();
						break;
					case "changePassword":
						Console.WriteLine("generateNewPassword || writeSelf");
						if(Console.ReadLine() == "generateNewPassword")
						{
							StringBuilder stringBuilder = new StringBuilder();
							for (int i = 0; i < 10; i++)
							{
								stringBuilder.Insert(i, symbols[random.Next(symbols.Length)]);
							}
							accounts[id].Password = stringBuilder.ToString();
						}
						else
						{
							Console.WriteLine("Enter the new Password");
							accounts[id].Password = GetConsolePassword();
						}
						
						ReWriteFile();
						Console.WriteLine("The Password was changed succesfully!");
						Console.WriteLine("Press any key to contiune...");
						Console.ReadKey();
						break;
					case "changeDescription":

						Console.WriteLine("Enter the new Description");
						accounts[id].Description = Console.ReadLine();
						ReWriteFile();
						Console.WriteLine("The Service was Description succesfully!");
						Console.WriteLine("Press any key to contiune...");
						Console.ReadKey();
						break;
					case "removeRow":
						accounts.RemoveAt(Convert.ToInt32(id));
						ReWriteFile();
						Console.WriteLine("The account was removed succesfully!");
						Console.WriteLine("Press any key to contiune...");
						Console.ReadKey();
						return;
					case "return":
						return;
					case "copyPassword":
						Thread thread = new Thread(() => Clipboard.SetText(accounts[id].Password));
						thread.SetApartmentState(ApartmentState.STA);
						thread.Start();
						thread.Join();
						Console.WriteLine("The Password copied succesfully!");
						Console.WriteLine("Press any key to contiune...");
						Console.ReadKey();
						break;
					default:
						break;
				}
			}
		}
		static void WriteHelp()
		{
			Console.WriteLine("exit");
			Console.WriteLine("selectRow");
			Console.WriteLine("addRow");
			Console.WriteLine("deleteRow");
			Console.WriteLine("exportZip");
		}
		static void WriteRowHelp()
		{
			Console.WriteLine("changeService");
			Console.WriteLine("changeLogin");
			Console.WriteLine("changePassword");
			Console.WriteLine("changeDescription");
			Console.WriteLine("removeRow");
			Console.WriteLine("copyPassword");
			Console.WriteLine("return");
		}
		static void ReadFile()
		{
			string file = File.ReadAllText(pathOfFile);
			try
			{
				file = Crypt.Decrypt(file, PasswordForCryptGet());
				if (file.StartsWith(keyOfIntegrity))
				{
					file = file.Replace(keyOfIntegrity, "");
					accounts = JsonConvert.DeserializeObject<List<Account>>(file);
				}
				else
				{
					Console.WriteLine("Неправильный пароль");
				}
			}
			catch
			{

			}
		}
		static void ReWriteFile()
		{
			string json = JsonConvert.SerializeObject(accounts);
			json = json.Insert(0, keyOfIntegrity);
			json = Crypt.Encrypt(json, PasswordForCryptGet());
			using (var fileStream = File.Create(pathOfFile))
			{
				fileStream.Write(Encoding.UTF8.GetBytes(json), 0, json.Length);
				fileStream.Close();
			}
		}
		static void ExportZip()
		{
			string jsonString = JsonConvert.SerializeObject(accounts, Formatting.Indented);
			string csvString = "Service;Login;Password;Description;\n";
			accounts.ForEach(a => csvString += $"{a.Service};{a.Login};{a.Password};{a.Description};\n");

			using (ZipFile zip = new ZipFile())
			{
				zip.Password = PasswordForCryptGet();

				zip.AddEntry("Passwords.csv", Encoding.UTF8.GetBytes(csvString));
				zip.AddEntry("Passwords.json", Encoding.UTF8.GetBytes(jsonString));
				zip.Save("Passwords.zip");
			}

			Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory); // Open folder with zip
		}
		private static string GetConsolePassword()
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (true)
			{
				ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
				if (consoleKeyInfo.Key == ConsoleKey.Enter)
				{
					Console.WriteLine();
					break;
				}

				if (consoleKeyInfo.Key == ConsoleKey.Backspace)
				{
					if (stringBuilder.Length > 0)
					{
						Console.Write("\b\0\b");
						stringBuilder.Length--;
					}

					continue;
				}

				Console.Write('*');
				stringBuilder.Append(consoleKeyInfo.KeyChar);
			}

			return stringBuilder.ToString();
		}

		
	}
}
