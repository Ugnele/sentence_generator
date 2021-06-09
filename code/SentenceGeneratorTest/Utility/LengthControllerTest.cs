using Length.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SentenceGeneratorTest.Utility
{
    public class LengthControllerTest
    {
        [Fact]
        public void IsInteger()
        {
            LengthController length = new();

            var testIsInteger = length.GetSentenceLength();
            Assert.IsType<int>(testIsInteger);
        }

        [Fact]
        public void IsInScope()
        {
            LengthController length = new();

            for(int i = 0; i < 1000; i++)
            {
                var testIsInScope = length.GetSentenceLength();
                Assert.IsType<int>(testIsInScope);
                Assert.True(testIsInScope <= 5);
                Assert.True(testIsInScope >= 1);
            }
        }
    }
}
