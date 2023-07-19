namespace CSharpSyntax
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string fullName = Utils.FormatName("Brad", "Sandorf");

            Assert.Equal("Sandorf, Brad", fullName);
        }
    }
}