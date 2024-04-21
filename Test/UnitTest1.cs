using Lab2QA;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

public class SPTests
{
	[Fact]
	public void Result_WhenFileContainsValidWords_ReturnsExpectedResult()
	{
		// Arrange
		var fileReaderMock = new Mock<IFileReader>();
		fileReaderMock.Setup(x => x.ReadWords(It.IsAny<string>())).Returns(new List<string> { "aaaapp", "bananaaaa", "oooooorange" });

		var sp = new SP(fileReaderMock.Object);

		// Act
		var result = sp.Result("dummyFilename");

		// Assert
		Assert.Equal(3, result.Count);
		Assert.Contains("aaaapp", result);
		Assert.Contains("bananaaaa", result);
		Assert.Contains("oooooorange", result);
		fileReaderMock.Verify(x => x.ReadWords(It.IsAny<string>()), Times.Once);
	}

	[Fact]
	public void Result_WhenFileReaderThrowsException()
	{
		// Arrange
		var fileReaderMock = new Mock<IFileReader>();
		fileReaderMock.Setup(x => x.ReadWords(It.IsAny<string>())).Throws<IOException>();

		var sp = new SP(fileReaderMock.Object);

		// Act
		//var result = sp.Result("dummyFilename");

		// Assert
		Assert.Throws<IOException>(() => sp.Result("dummyFilename")); 
		fileReaderMock.Verify(x => x.ReadWords(It.IsAny<string>()), Times.Once);
	}

	[Fact]
	public void Result_WhenWordLengthExceeds30_ReturnsEmptyResult()
	{
		// Arrange
		var fileReaderMock = new Mock<IFileReader>();
		fileReaderMock.Setup(x => x.ReadWords(It.IsAny<string>())).Returns(new List<string> { "supercalifragilisticexpialidocious" });

		var sp = new SP(fileReaderMock.Object);

		// Act
		var result = sp.Result("dummyFilename");

		// Assert
		Assert.Empty(result);
		fileReaderMock.Verify(x => x.ReadWords(It.IsAny<string>()), Times.Once);
	}

	[Fact]
	public void Result_WhenFileContainsInvalidWords_ReturnsExpectedResult()
	{
		// Arrange
		var fileReaderMock = new Mock<IFileReader>();
		fileReaderMock.Setup(x => x.ReadWords(It.IsAny<string>())).Returns(new List<string> { "123", "word1", "invalid" });

		var sp = new SP(fileReaderMock.Object);

		// Act
		var result = sp.Result("dummyFilename");

		// Assert
		Assert.Empty(result);
		fileReaderMock.Verify(x => x.ReadWords(It.IsAny<string>()), Times.Once);
	}
}