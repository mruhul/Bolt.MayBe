using Shouldly;
using Xunit;

namespace Bolt.Monad.UnitTests
{
    public class MayBeTests
    {
        [Fact]
        public void HasValue_Should_Return_Correct_Value()
        {
            MayBe<string> nullString = (string) null;
            nullString.HasValue.ShouldBe(false);

            MayBe<string> stringValue = "Hello";
            stringValue.HasValue.ShouldBe(true);

            MayBe<int> zero = 0;
            zero.HasValue.ShouldBe(true);

            MayBe<int?> nullInt = (int?) null;
            nullInt.HasValue.ShouldBe(false);

            var maybe = MayBe<int>.None;
            maybe.HasValue.ShouldBe(false);
            maybe.IsNone.ShouldBe(true);
        }
    }
}
