using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace csharpcore.Tests
{
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void ThirtyDays()
        {
            var output = new StringBuilder();

            Console.SetOut(new StringWriter(output));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(Array.Empty<string>());

            Approvals.Verify(output.ToString());
        }
    }
}