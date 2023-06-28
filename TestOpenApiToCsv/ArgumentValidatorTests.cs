using OpenApiToCsv;
using FluentAssertions;

namespace TestOpenApiToCsv
{
    public class ArgumentValidatorTests
    {
        private readonly IArgumentValidator validator = new ArgumentValidator();


        [Fact]
        public void GivenNoArguments_WhenIsValid_ThenFalseAndNoArgumentsPassed()
        {
            
            string[] givenNoArguments = { };

            (bool whenIsValid,var results) = validator.IsValid(givenNoArguments);

            whenIsValid.Should().BeFalse();
            string? andNoArgumentsPassed = results?[0];
            andNoArgumentsPassed.Should().Be("No arguments passed - 1 required");

        }
        [Fact]
        public void GivenTooManyArguments_WhenIsValid_ThenFalseAndTooManyArgumentsPassed()
        {
            string[] givenNoArguments = {"","" };

            (bool whenIsValid, var results) = validator.IsValid(givenNoArguments);

            whenIsValid.Should().BeFalse();
            string? andNoArgumentsPassed = results?[0];
            andNoArgumentsPassed.Should().Be("No arguments passed - 1 required");
        }
        [Theory]
        [InlineData("testfile.json")]
        [InlineData("1.json")]
        [InlineData("12.json")]
        [InlineData("123.json")]
        [InlineData("1234.json")]
        [InlineData("12345.json")]
        [InlineData("123456.json")]
        [InlineData("1234567.json")]
        [InlineData("12345678.json")]
        [InlineData("1234567890.json")]
        [InlineData("asdfghjklo.json")]
        [InlineData("hsliewneks.json")]
        [InlineData("SHSLIEHLS.json")]
        [InlineData("FILE1.json")]
        [InlineData("File1.json")]
        public void GivenOneArgumentCorrectlyFormatted_WhenIsValid_ThenTrueAndNoResult(string validFilename)
        {
            string[] givenOneArgumentCorrectlyFormatted = { validFilename };

            (bool whenIsValid, var results) = validator.IsValid(givenOneArgumentCorrectlyFormatted);

            whenIsValid.Should().BeTrue();
            string? andNoArgumentsPassed = results?[0];
            andNoArgumentsPassed.Should().BeNull();
        }
        [Theory]
        [InlineData("testfile.txt")]
        [InlineData("testfile.json")]
        [InlineData("£1.json")]
        [InlineData("£12.json")]
        [InlineData(".123.json")]
        [InlineData("!1234.json")]
        [InlineData("@12345.json")]
        [InlineData("~123456.json")]
        [InlineData("#1234567.json")]
        [InlineData(" 12345678.json")]
        [InlineData("123 4567890.json")]
        [InlineData("as  dfghjklo.json")]
        [InlineData("hsli-ewneks.json")]
        [InlineData("SHSL_IEHLS.json")]
        [InlineData("FILE1.jsn")]
        [InlineData("File1json")]
        public void GivenOneArgumentInCorrectlyFormatted_WhenIsValid_ThenFalseAndInvalidFileName(string invalidFilename)
        {
            string[] givenOneArgumentInCorrectlyFormatted = { "testfile.txt" };

            (bool whenIsValid, var results) = validator.IsValid(givenOneArgumentInCorrectlyFormatted);

            whenIsValid.Should().BeFalse();
            string? andNoArgumentsPassed = results?[0];
            andNoArgumentsPassed.Should().Be("Argument must be 10 digit json filename conforming to Regex - ^[a-z0-9A-Z]{1,10}.json$");
        }
    }
}