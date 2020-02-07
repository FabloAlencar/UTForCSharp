using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class HouseKeeperServiceTests
    {
        private Mock<IStatementGenerator> _mockStatementGenerator;
        private Mock<EmailSender> _mockEmailSender;
        private Mock<IXtraMessageBox> _mockMessageBox;
        private HousekeeperService _service;
        private DateTime _statementDate = new DateTime(2017, 1, 1);
        private Housekeeper _houseKeeper;
        private string _statementFileName;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _houseKeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _houseKeeper
            }.AsQueryable());

            _statementFileName = "fileName";
            _mockStatementGenerator = new Mock<IStatementGenerator>();
            _mockStatementGenerator
                            .Setup(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)))
                            .Returns(() => _statementFileName);

            _mockEmailSender = new Mock<EmailSender>();
            _mockMessageBox = new Mock<IXtraMessageBox>();

            _service = new HousekeeperService(
               mockUnitOfWork.Object,
               _mockStatementGenerator.Object,
               _mockEmailSender.Object,
               _mockMessageBox.Object);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            // Act
            _service.SendStatementEmails(_statementDate);

            // Assert
            _mockStatementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)));
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void SendStatementEmails_HousekeeperEmailIsInvalid_ShouldNotGenerateStatements(string email)
        {
            // .. continue Arrange
            _houseKeeper.Email = email;

            // Act
            _service.SendStatementEmails(_statementDate);

            // Assert
            _mockStatementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)), Times.Never);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatements()
        {
            // Act
            _service.SendStatementEmails(_statementDate);

            // Assert
            VerifyEmailSent();
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void SendStatementEmails_StatementFileNameIsInvalid_ShouldNotEmailTheStatements(string statementFileName)
        {
            // Act
            _statementFileName = statementFileName;

            _service.SendStatementEmails(_statementDate);

            // Assert
            VerifyEmailNotSent();
        }

        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox()
        {
            // Act
            _mockEmailSender.Setup(es => es.EmailFile(
                            It.IsAny<String>(),
                            It.IsAny<String>(),
                            It.IsAny<String>(),
                            It.IsAny<String>()
                            )).Throws<Exception>();

            _service.SendStatementEmails(_statementDate);

            // Assert
            _mockMessageBox.Verify(mb => mb.Show(It.IsAny<String>(), It.IsAny<String>(), MessageBoxButtons.OK));
        }

        private void VerifyEmailNotSent()
        {
            _mockEmailSender.Verify(es => es.EmailFile(
                            It.IsAny<String>(),
                            It.IsAny<String>(),
                            It.IsAny<String>(),
                            It.IsAny<String>()),
                            Times.Never);
        }

        private void VerifyEmailSent()
        {
            _mockEmailSender.Verify(es => es.EmailFile(
                            _houseKeeper.Email,
                            _houseKeeper.StatementEmailBody,
                            _statementFileName,
                            It.IsAny<String>()));
        }
    }
}