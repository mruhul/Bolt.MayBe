using Xunit;
using Shouldly;

namespace Bolt.Monad.UnitTests
{
    public class MayBe_Instance_Should
    {
        [Fact]
        public void Convert_From_Number()
        {
            MayBe<int> maybe = 1;

            maybe.Value.ShouldBe(1);
        }

        [Fact]
        public void Convert_To_Number()
        {
            int num = 1.MayBe();

            num.ShouldBe(1);
        }

        [Fact]
        public void Handle_Status_Correctly()
        {
            int? num = null;
            num.MayBe().HasValue.ShouldBe(false);
            num.MayBe().IsNone.ShouldBe(true);

            var maybe = 0.MayBe();
            maybe.WhenGreaterThanZero().HasValue.ShouldBe(false);
            maybe.HasValue.ShouldBe(true);
        }
    }
}
