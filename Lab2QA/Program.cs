using System;
using System.Collections.Generic;
using System.IO;

namespace Lab2QA
{
	public interface IFileReader
	{
		IEnumerable<string> ReadWords(string filename);
	}

	public class FileReader : IFileReader
	{
		public IEnumerable<string> ReadWords(string filename)
		{
			using (StreamReader file = new StreamReader(filename))
			{
				string word = "";
				while (!file.EndOfStream)
				{
					char x = (char)file.Read();
					if (char.IsLetter(x))
					{
						word += x;
					}
					else
					{
						if (word.Length > 0)
						{
							yield return word;
						}
						word = "";
					}
				}
			}
		}
	}

	public class SP
	{
		private readonly IFileReader fileReader;

		public SP(IFileReader fileReader)
		{
			this.fileReader = fileReader;
		}

		public bool IsRight(string word)
		{
			if (word.Length > 30)
			{
				return false;
			}

			int vowels = 0;
			foreach (char letter in word)
			{
				char upperLetter = char.ToUpper(letter);
				if (upperLetter == 'A' || upperLetter == 'E' || upperLetter == 'I' || upperLetter == 'O' || upperLetter == 'U' || upperLetter == 'Y')
				{
					vowels++;
				}
			}

			return word.Length - vowels < vowels;
		}

		public SortedSet<string> Result(string filename)
		{
			SortedSet<string> setResult = new SortedSet<string>();
			foreach (var word in fileReader.ReadWords(filename))
			{
				if (IsRight(word))
				{
					setResult.Add(word);
				}
			}
			return setResult;
		}
		public static void Main(string[] args)
		{

		}
	}

}
