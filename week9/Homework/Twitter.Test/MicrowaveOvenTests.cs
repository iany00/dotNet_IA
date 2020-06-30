using System;
using _6.Twitter.Interfaces;
using _6.Twitter.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace UnitTest
{
    [TestClass]
    public class MicrowaveOvenTests
    {
        public void Test_SendTweetToServerShouldSendTheMessageToItsServer()
        {
            //prepare
            var writerMock = new Mock<IWriter>();
            var repoMock = new Mock<ITweetRepository>();
            var message = "test";

            repoMock.Setup(o => o.SaveTweet(It.IsAny<string>())).Callback((string mess) => message = mess);
            
            var classUnderTest = new MicrowaveOven(writerMock.Object, repoMock.Object);
            //act
            classUnderTest.SendTweetToServer("My message!");
            //check
            repoMock.Verify(o => o.SaveTweet("My message!"), Times.Exactly(1));
            Assert.Equals("My message!", message);
        }

        [Fact]
        public void Test_WriteTweetShouldCallItsWriterWithTheTweetsMessage()
        {
            //prepare
            var writerMock = new Mock<IWriter>();
            var message = string.Empty;

            writerMock.Setup(o => o.WriteLine(It.IsAny<string>())).Callback((string mess) => message = mess);
            
            var repoMock = new Mock<ITweetRepository>();
            var classUnderTest = new MicrowaveOven(writerMock.Object, repoMock.Object);
            //act
            classUnderTest.WriteTweet("My message!");
            //check
            writerMock.Verify(o => o.WriteLine(It.IsAny<string>()), Times.Exactly(1));
            Assert.Equals("My message!", message);
        }

        [Fact]
        public void WriteTweetShouldCallItsWriterWithTheTweetsMessage()
        {
            // Arrange
            const string Message = "Test";
            var writer = new Mock<IWriter>();
            
            writer.Setup(w => w.WriteLine(It.IsAny<string>()));
            
            var tweetRepo = new Mock<ITweetRepository>();
            var microwaveOven = new MicrowaveOven(writer.Object, tweetRepo.Object);
            // Act
            microwaveOven.WriteTweet(Message);
            // Assert
            writer.Verify(w => w.WriteLine(It.Is<string>(s => s == Message)),
                $"Tweet is not given to the {typeof(MicrowaveOven)}'s writer");
        }
    }
}
