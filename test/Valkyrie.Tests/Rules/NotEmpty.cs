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
    public class NotEmptyClass
    {
        [NotEmpty]
        public List<string> ItemA { get; set; }
    }

    public class NotEmptyTests
    {
        [Fact]
        public void Test()
        {
            var Temp = new NotEmptyClass
            {
                ItemA = new List<string>
            {
                "A",
                "B"
            }
            };
            Temp.Validate();
            Temp.ItemA.Clear();
            Assert.Throws<ValidationException>(() => Temp.Validate());
        }
    }
}