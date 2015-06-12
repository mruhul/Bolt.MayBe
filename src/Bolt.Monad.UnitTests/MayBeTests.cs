﻿using System.Collections.Generic;
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

            MayBe<int?> nullInt = (int?) null;
            nullInt.HasValue.ShouldBe(false);

            var maybe = MayBe<int>.None;
            maybe.HasValue.ShouldBe(false);
            maybe.IsNone.ShouldBe(true);

            var value = (string)null;
            value.MayBeNotNull().IsNone.ShouldBe(true);
        }
    }

    public class MayBeExtensionsTests
    {
        [Fact]
        public void Select_Should_Return_Correct_Value()
        {
            Person person = new Person{ Name = "test"};
            person.MayBeNotNull().Select(x => x.Name).Value.ShouldBe("test");

            MayBe<Person> nullPerson = (Person)null;
            nullPerson.Select(x => x.Name).Value.ShouldBeNullOrEmpty();

            IEnumerable<Person> list = new List<Person>{ new Person{ Name = "test"} };

            list.MayBeNotNull().Select(x => new { name = x.Name }).FirstOrDefault().Select(x => x.name).Value.ShouldBe("test");

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
