namespace UnitTests
{
    using System;
    using Domain;
    using Domain.Entities;
    using Domain.Services;
    using Moq;
    using Xunit;

    public class PensionServiceV2UnitTests
    {
        [Fact]
        public void PersonWithAge38_ShouldNotHavePensionAndShouldNotBeNotified()
        {
            // arrange

            var personUnderTest = new Person
            {
                FullName = "Andrei",
                Id = Guid.NewGuid(),
                DateOfBirth = new DateTime(1981, 1, 1)
            };

            var mockPersonRepo = new Mock<IPersonRepository>();

            mockPersonRepo
                .Setup(r => r.Get(personUnderTest.Id))
                .Returns(personUnderTest);

            //mockPersonRepo.Setup(r => r.Get(It.IsAny<Guid>())).Returns(personUnderTest);

            var mailSenderMock = new Mock<IMailSender>();

            PensionServiceV2 sut = new PensionServiceV2(mockPersonRepo.Object, mailSenderMock.Object);

            // act

            var actual = sut.Calculate(personUnderTest.Id);

            // assert

            var expected = false;

            Assert.Equal(expected, actual.IsPensionable);

            mailSenderMock.Verify(ms => ms.Send(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void PersonWithAge42_ShouldNotHavePensionAndShouldBeNotified()
        {
            var personUnderTest = new Person
            {
                FullName = "Andrei",
                Id = Guid.NewGuid(),
                DateOfBirth = new DateTime(1978, 1, 1)
            };

            var mockPersonRepo = new Mock<IPersonRepository>();

            mockPersonRepo
                .Setup(r => r.Get(personUnderTest.Id))
                .Returns(personUnderTest);

            var mailSenderMock = new Mock<IMailSender>();

            PensionServiceV2 sut = new PensionServiceV2(mockPersonRepo.Object, mailSenderMock.Object);

            // act

            var actual = sut.Calculate(personUnderTest.Id);

            // assert

            var expected = false;

            Assert.Equal(expected, actual.IsPensionable);

            //mailSenderMock.Verify(ms => ms.Send(It.IsAny<string>()), Times.Once);

            mailSenderMock.Verify(ms => ms.Send(It.Is<string>(p => p == "at 51 you'll have pension :)")), Times.Once);

        }

        [Fact]
        public void PersonWithAge52_ShouldHavePensionAndShouldBeNotified()
        {

            var personUnderTest = new Person
            {
                FullName = "Andrei",
                Id = Guid.NewGuid(),
                DateOfBirth = new DateTime(1968, 1, 1)
            };

            var mockPersonRepo = new Mock<IPersonRepository>();

            mockPersonRepo
                .Setup(r => r.Get(personUnderTest.Id))
                .Returns(personUnderTest);

            var mailSenderMock = new Mock<IMailSender>();

            PensionServiceV2 sut = new PensionServiceV2(mockPersonRepo.Object, mailSenderMock.Object);

            // act

            var actual = sut.Calculate(personUnderTest.Id);

            // assert

            var expected = true;

            Assert.Equal(expected, actual.IsPensionable);

            mailSenderMock.Verify(ms => ms.Send(It.IsAny<string>()), Times.Once);
        }
    }
}
