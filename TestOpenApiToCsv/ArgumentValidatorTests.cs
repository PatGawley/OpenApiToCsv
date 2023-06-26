using OpenApiToCsv;

namespace TestOpenApiToCsv
{
    public class ArgumentValidatorTests
    {
        private IArgumentValidator validator;

        ArgumentValidatorTests()
        {
            validator = new ArgumentValidator();
        }

        [Fact]
        public void GivenNoArguments_WhenIsValid_ThenFalseAndIncorrectNumberOfArguments()
        {
            var givenNoArguments
        }
    }
}