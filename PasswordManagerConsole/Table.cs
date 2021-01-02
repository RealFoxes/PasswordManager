using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerConsole
{
	public static class Table
	{
		public static string GetStringTable<T>(List<T> items, string[] properties)
		{
			StringBuilder stringTable = new StringBuilder();
			if (items.Count != 0)
			{
				int[] MaxCountOfSymbolsPropeties = new int[properties.Length + 1];
				MaxCountOfSymbolsPropeties[0] = items.Count.ToString().Length > 4 ? items.Count.ToString().Length : 4; // count a number of id
				for (int p = 0; p < properties.Length; p++) // сount a number of characters in properties
				{
					MaxCountOfSymbolsPropeties[p + 1] = GetMaxLengthOfString(items, properties[p]) > properties[p].Length + 2 ? GetMaxLengthOfString(items, properties[p]) : properties[p].Length + 2;
				}
				stringTable.Append($"|{GetMonospaceWord("Id", MaxCountOfSymbolsPropeties[0])}"); // add id header

				for (int p = 0; p < properties.Length; p++)// add rest header
				{
					stringTable.Append($"|{GetMonospaceWord(properties[p], MaxCountOfSymbolsPropeties[p + 1])}");
				}
				stringTable.Append("|\n");


				for (int i = 0; i < items.Count; i++)
				{
					for (int p = 0; p < properties.Length + 1; p++) // add horizatal border
					{
						stringTable.Append($"|{new string('-', MaxCountOfSymbolsPropeties[p])}");
					}
					stringTable.Append("|\n");

					stringTable.Append($"|{GetMonospaceWord(i.ToString(), MaxCountOfSymbolsPropeties[0])}"); //add id row
					for (int p = 0; p < properties.Length; p++)// add rest row
					{
						stringTable.Append($"|{GetMonospaceWord((string)items[i].GetType().GetProperty(properties[p]).GetValue(items[i], null), MaxCountOfSymbolsPropeties[p + 1])}");
					}
					stringTable.Append("|\n");
				}
			}
			else
			{
				stringTable.Append("Records does not exist!");
			}
			return stringTable.ToString();
		}
		static int GetMaxLengthOfString<T>(List<T> items, string NameOfProperyWithString)
		{
			T item = items.Aggregate((i1, i2) => i1.GetType().GetProperty(NameOfProperyWithString).GetValue(i1, null).ToString().Length > i2.GetType().GetProperty(NameOfProperyWithString).GetValue(i2, null).ToString().Length ? i1 : i2);
			int length = ((string)item.GetType().GetProperty(NameOfProperyWithString).GetValue(item, null)).Length;
			return length;
		}
		static string GetMonospaceWord(string word, int numOfMonospace)
		{
			StringBuilder monospaceWord = new StringBuilder();
			int numOfSpacesBeforeWord = (int)Math.Ceiling(Convert.ToDouble(numOfMonospace - word.Length) / 2);
			int numOfSpacesAfterWord = (int)Math.Floor(Convert.ToDouble(numOfMonospace - word.Length) / 2);
			monospaceWord.Insert(0, new string(' ', numOfSpacesBeforeWord));
			monospaceWord.Insert(numOfSpacesBeforeWord, word);
			monospaceWord.Insert(numOfSpacesBeforeWord + word.Length, new string(' ', numOfSpacesAfterWord));
			return monospaceWord.ToString();
		}
	}
}
