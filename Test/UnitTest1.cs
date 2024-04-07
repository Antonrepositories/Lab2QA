using Lab2QA;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

public class ProgramTests
{
	private SP sP;
	private string Filepath = "C:\\Users\\anton\\source\\repos\\LabQA\\LabQA\\test.txt";
    private SortedSet<string> NeededResult = new SortedSet<string> { "aaeabbb", "aahkiop", "arereeeeeeaaa", "eeeees", "hfksdaaaaaaa", "rionneuyu" };

	public ProgramTests()
	{
		sP = new SP();
	}

	[Fact]
	[Trait("Category", "Group1")]
	public void TestIsRight()
	{
		//SP sP = new SP(); // Initialize sP before each test
		Assert.True(sP.IsRight("hellooo"));
		Assert.False(sP.IsRight("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
	}

	[Fact]
	[Trait("Category", "Group1")]
	public void TestException()
	{
		//SP sP = new SP(); // Initialize sP before each test
						  // Test if an exception is thrown when passing a non-existing file path
		Assert.Throws<FileNotFoundException>(() => sP.Result("non-existing-file.txt"));
	}

	[Theory]
	[InlineData("aaattt", false)]
	[InlineData("eeett", true)]
	[Trait("Category", "Group2")]
	public void TestIsRightWithParam(string word, bool expected)
	{
		//SP sP = new SP(); // Initialize sP before each test
		Assert.Equal(expected, sP.IsRight(word));
	}

	[Fact]
	[Trait("Category", "Group2")]
	public void TestMatchers()
	{
		//SP sP = new SP(); // Initialize sP before each test
		SortedSet<string> result = sP.Result(this.Filepath);
		Assert.Equal(this.NeededResult, result);
		Assert.Equal(6, result.Count);
	}
}
