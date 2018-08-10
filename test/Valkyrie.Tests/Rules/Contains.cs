﻿/*
Copyright 2017 James Craig

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Xunit;

namespace Valkyrie.Tests.Rules
{
    public class ClassC
    {
        [Contains("A")]
        public List<string> ItemA { get; set; }
    }

    public class ContainsTests
    {
        [Fact]
        public void IsValid()
        {
            var TestObject = new ContainsAttribute('A');
            Assert.True(TestObject.IsValid("ASDFG"));
            Assert.False(TestObject.IsValid("SDFG"));
        }

        [Fact]
        public void IsValidString()
        {
            var TestObject = new ContainsAttribute("ASDF");
            Assert.True(TestObject.IsValid("ASDFG"));
            Assert.False(TestObject.IsValid("SDFG"));
        }

        [Fact]
        public void Test()
        {
            var Temp = new ClassC
            {
                ItemA = new List<string>
            {
                "A",
                "B"
            }
            };
            Temp.Validate();
            Temp.ItemA.Clear();
            Temp.ItemA.Add("B");
            Assert.Throws<ValidationException>(() => Temp.Validate());
        }
    }
}