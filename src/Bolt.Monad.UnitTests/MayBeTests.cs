using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

            zero.WhenGreaterThanZero().HasValue.ShouldBe(false);

            var data = 10;

            data.MayBe().WhenGreaterThanZero().Otherwise(11).Value.ShouldBe(10);


            data = 0;

            data.MayBe().WhenGreaterThanZero().Otherwise(11).Value.ShouldBe(11);

            MayBe<int?> nullInt = (int?) null;
            nullInt.HasValue.ShouldBe(false);

            var maybe = MayBe<int>.None;
            maybe.HasValue.ShouldBe(false);
            maybe.IsNone.ShouldBe(true);

            var value = (string)null;
            value.MayBe().IsNone.ShouldBe(true);
        }
    }

    public class MayBeExtensionsTests
    {
        [Fact]
        public void Map_Should_Return_Correct_Value()
        {
            Person person = new Person{ Name = "test"};
            person.MayBe().Map(x => x.Name).Value.ShouldBe("test");

            MayBe<Person> nullPerson = (Person)null;
            nullPerson.Map(x => x.Name).Value.ShouldBeNullOrEmpty();

            IEnumerable<Person> list = new List<Person>{ new Person{ Name = "test"} };

            list.MayBe().Select(x => new { name = x.Name }).FirstOrDefault().Map(x => x.name).Value.ShouldBe("test");

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public IEnumerable<Contact> Contacts { get; set; } 
    }

    public class Contact
    {
        public string Phone { get; set; }
    }
}
