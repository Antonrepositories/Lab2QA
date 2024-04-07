using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Lab2QA
{
	public class SP
	{
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
			StreamReader file = new StreamReader(filename);
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
					//Console.WriteLine(word);
					if (word.Length > 0 && IsRight(word))
					{
						// wordsResult.Add(word);
						setResult.Add(word);
					}
					word = "";
				}
			}
			file.Close();
			return setResult;

		}
		//public void ResultOut(SortedSet<string> setResult)
		//{
		//	Console.WriteLine("RESULT: " + setResult.Count + " words found >>>>>>>>>>>>>>>>>");

		//	int i = 1;
		//	foreach (string item in setResult)
		//	{
		//		Console.WriteLine(i + ". " + item);
		//		i++;
		//	}
		//}

	}
	public class Runner
	{
		public static void Main()
		{
			//string filename = "C:\\Users\\anton\\source\\repos\\LabQA\\LabQA\\test.txt";
			//SP prog = new SP();
			//SortedSet<string> result = prog.Result(filename);
			//prog.ResultOut(result);
		}
	}
}