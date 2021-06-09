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
        /// Checks if generated length is an integer
        [Fact]
        public void IsInteger()
        {
            LengthController length = new();

            var testIsInteger = length.GetSentenceLength();
            Assert.IsType<int>(testIsInteger);
        }

        /// Checks if generated length is within scope 1 to 5
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

        /// Checks if generated length can obtain maximum length of 5
        [Fact]
        public void MaxValue()
        {
            LengthController length = new();
            Boolean maximum = false;
            while (!maximum)
            {
                var testIsInScope = length.GetSentenceLength();
                if (testIsInScope == 5) maximum = true;
                
            }
            Assert.True(maximum);
        }

        /// Checks if generated length can obtain minimum length of 5
        [Fact]
        public void MinValue()
        {
            LengthController length = new();
            Boolean minimum = false;
            while (!minimum)
            {
                var testIsInScope = length.GetSentenceLength();
                if (testIsInScope == 1) minimum = true;

            }
            Assert.True(minimum);
        }
    }
}
