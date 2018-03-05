using System;
using Xunit;
using Shouldly;

namespace Bolt.Monad.UnitTests
{
    public class MayBeGuid_Should
    {
        [Fact]
        public void ConvertToGuid()
        {
            var testId = Guid.NewGuid();
            Guid id = testId.MayBe();
            id.ShouldBe(testId);
        }
        
        [Fact]
        public void ConvertFromGuid()
        {
            var testId = Guid.NewGuid();
            MayBe<Guid> id = testId;
            id.Value.ShouldBe(testId);
        }

        [Fact]
        public void Return_Correct_Result_For_NotEmpty()
        {
            var testGuid = Guid.NewGuid();
            var maybe = testGuid.MayBe();

            maybe.NotEmpty().Value.ShouldBe(testGuid);

            var emptyGuid = Guid.Empty;
            maybe = emptyGuid.MayBe();
            maybe.HasValue.ShouldBe(true);

            maybe.NotEmpty().HasValue.ShouldBe(false);
        }
    }
}
