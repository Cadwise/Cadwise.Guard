// The MIT License (MIT)

// Copyright (c) 2018 Ltd Cadwise-N

// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Guard.Tests
{
    [TestFixture]
    public sealed class ThrowIfTests
    {
        [Test]
        public void ThrowIfIntIsOutOfRange_OutOfRange_Throw()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Argument.OutOfRange(-1, 0, 1, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Variable.OutOfRange(-1, 0, 1, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Field.OutOfRange(-1, 0, 1, ""));
        }

        [Test]
        public void ThrowIfIntIsOutOfRange_InRange_NotThrow()
        {
            Assert.DoesNotThrow(() => ThrowIf.Argument.OutOfRange(1, 0, 1, ""));
            Assert.DoesNotThrow(() => ThrowIf.Variable.OutOfRange(1, 0, 1, ""));
            Assert.DoesNotThrow(() => ThrowIf.Field.OutOfRange(1, 0, 1, ""));
        }

        [Test]
        public void ThrowIfDoubleIsOutOfRange_OutOfRange_Throw()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Argument.OutOfRange(-1.5, 0, 1, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Variable.OutOfRange(-1.5, 0, 1, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Field.OutOfRange(-1.5, 0, 1, ""));
        }

        [Test]
        public void ThrowIfDoubleIsOutOfRange_InRange_NotThrow()
        {
            Assert.DoesNotThrow(() => ThrowIf.Argument.OutOfRange(0.5, 0, 1, ""));
            Assert.DoesNotThrow(() => ThrowIf.Variable.OutOfRange(0.5, 0, 1, ""));
            Assert.DoesNotThrow(() => ThrowIf.Field.OutOfRange(0.5, 0, 1, ""));
        }

        [Test]
        public void ThrowIfDoubleIsZero_Zero_Throw()
        {
            Assert.Throws<ArgumentNullException>(() => ThrowIf.Argument.IsZero(0, "", double.Epsilon));
            Assert.Throws<ArgumentNullException>(() => ThrowIf.Variable.IsZero(0, "", double.Epsilon));
            Assert.Throws<ArgumentNullException>(() => ThrowIf.Field.IsZero(0, "", double.Epsilon));
        }

        [Test]
        public void ThrowIfDoubleIsZero_NotZero_NotThrow()
        {
            Assert.DoesNotThrow(() => ThrowIf.Argument.IsZero(0.1, "", double.Epsilon));
            Assert.DoesNotThrow(() => ThrowIf.Variable.IsZero(0.1, "", double.Epsilon));
            Assert.DoesNotThrow(() => ThrowIf.Field.IsZero(0.1, "", double.Epsilon));
        }

        [Test]
        public void ThrowIfIntIsNegative_Negative_Throw()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Argument.Negative(-1, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Variable.Negative(-1, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Field.Negative(-1, ""));
        }

        [Test]
        public void ThrowIfIntIsNegative_NotNegative_NotThrow()
        {
            Assert.DoesNotThrow(() => ThrowIf.Argument.Negative(0, ""));
            Assert.DoesNotThrow(() => ThrowIf.Variable.Negative(0, ""));
            Assert.DoesNotThrow(() => ThrowIf.Field.Negative(0, ""));
        }

        [Test]
        public void ThrowIfDoubleIsNegative_Negative_Throw()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Argument.Negative(-0.1, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Variable.Negative(-0.1, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Field.Negative(-0.1, ""));
        }

        [Test]
        public void ThrowIfDoubleIsNegative_NotNegative_NotThrow()
        {
            Assert.DoesNotThrow(() => ThrowIf.Argument.Negative(0.0, ""));
            Assert.DoesNotThrow(() => ThrowIf.Variable.Negative(0.0, ""));
            Assert.DoesNotThrow(() => ThrowIf.Field.Negative(0.0, ""));
        }
       
        [Test]
        public void ThrowIfIntIsNegativeOrZero_Zero_Throw()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Argument.NegativeOrZero(0, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Variable.NegativeOrZero(0, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Field.NegativeOrZero(0, ""));
        }

        [Test]
        public void ThrowIfIntIsNegativeOrZero_Positive_NotThrow()
        {
            Assert.DoesNotThrow(() => ThrowIf.Argument.NegativeOrZero(1, ""));
            Assert.DoesNotThrow(() => ThrowIf.Variable.NegativeOrZero(1, ""));
            Assert.DoesNotThrow(() => ThrowIf.Field.NegativeOrZero(1, ""));
        }

        [Test]
        public void ThrowIfDoubleIsNegativeOrZero_Zero_Throw()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Argument.NegativeOrZero(0.0, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Variable.NegativeOrZero(0.0, ""));
            Assert.Throws<ArgumentOutOfRangeException>(() => ThrowIf.Field.NegativeOrZero(0.0, ""));
        }

        [Test]
        public void ThrowIfDoubleIsNegativeOrZero_Positive_NotThrow()
        {
            Assert.DoesNotThrow(() => ThrowIf.Argument.NegativeOrZero(0.1, ""));
            Assert.DoesNotThrow(() => ThrowIf.Variable.NegativeOrZero(0.1, ""));
            Assert.DoesNotThrow(() => ThrowIf.Field.NegativeOrZero(0.1, ""));
        }
        
        [Test]
        public void ThrowIfIsNullOrEmpty_StringNull_Throw()
        {
            Assert.Throws<ArgumentException>(() => ThrowIf.Argument.IsNullOrEmpty(null, ""));
            Assert.Throws<ArgumentException>(() => ThrowIf.Variable.IsNullOrEmpty(null, ""));
            Assert.Throws<ArgumentException>(() => ThrowIf.Field.IsNullOrEmpty(null, ""));
        }

        [Test]
        public void ThrowIfIsNullOrEmpty_StringEmpty_Throw()
        {
            Assert.Throws<ArgumentException>(() => ThrowIf.Argument.IsNullOrEmpty(string.Empty, ""));
            Assert.Throws<ArgumentException>(() => ThrowIf.Variable.IsNullOrEmpty(string.Empty, ""));
            Assert.Throws<ArgumentException>(() => ThrowIf.Field.IsNullOrEmpty(string.Empty, ""));
        }

        [Test]
        public void ThrowIfIsNullOrEmpty_StringWithContent_NotThrow()
        {
            var str = "test";
            Assert.DoesNotThrow(() => ThrowIf.Argument.IsNullOrEmpty(str, nameof(str)));
            Assert.DoesNotThrow(() => ThrowIf.Variable.IsNullOrEmpty(str, nameof(str)));
            Assert.DoesNotThrow(() => ThrowIf.Field.IsNullOrEmpty(str, nameof(str)));
        }

        [Test]
        public void ThrowIfIsNullOrEmpty_CollectionNull_Throw()
        {
            Assert.Throws<ArgumentException>(() => ThrowIf.Argument.IsNullOrEmpty((IEnumerable<object>)null, ""));
            Assert.Throws<ArgumentException>(() => ThrowIf.Variable.IsNullOrEmpty((IEnumerable<object>)null, ""));
            Assert.Throws<ArgumentException>(() => ThrowIf.Field.IsNullOrEmpty((IEnumerable<object>)null, ""));
        }

        [Test]
        public void ThrowIfIsNullOrEmpty_CollectionEmpty_Throw()
        {
            Assert.Throws<ArgumentException>(() => ThrowIf.Argument.IsNullOrEmpty(Enumerable.Empty<object>(), ""));
            Assert.Throws<ArgumentException>(() => ThrowIf.Variable.IsNullOrEmpty(Enumerable.Empty<object>(), ""));
            Assert.Throws<ArgumentException>(() => ThrowIf.Field.IsNullOrEmpty(Enumerable.Empty<object>(), ""));
        }

        [Test]
        public void ThrowIfIsNullOrEmpty_CollectionWithContent_NotThrow()
        {
            var collection = new []{new object()};
            Assert.DoesNotThrow(() => ThrowIf.Argument.IsNullOrEmpty(collection, nameof(collection)));
            Assert.DoesNotThrow(() => ThrowIf.Variable.IsNullOrEmpty(collection, nameof(collection)));
            Assert.DoesNotThrow(() => ThrowIf.Field.IsNullOrEmpty(collection, nameof(collection)));
        }

        [Test]
        public void ThrowIfArgumentIsNull_ReferenceNull_Throw()
        {
            Assert.Throws<ArgumentNullException>(() => ThrowIf.Argument.IsNull((string) null, ""));
            Assert.Throws<ArgumentNullException>(() => ThrowIf.Variable.IsNull((string) null, ""));
            Assert.Throws<ArgumentNullException>(() => ThrowIf.Field.IsNull((string) null, ""));
        }

        [Test]
        public void ThrowIfArgumentIsNull_ReferenceNotNull_NotThrow()
        {
            var str = "test";
            Assert.DoesNotThrow(() => ThrowIf.Argument.IsNull(str, nameof(str)));
            Assert.DoesNotThrow(() => ThrowIf.Variable.IsNull(str, nameof(str)));
            Assert.DoesNotThrow(() => ThrowIf.Field.IsNull(str, nameof(str)));
        }

        [Test]
        public void ThrowIfArgumentIsNull_NullableStructNull_Throw()
        {
            Assert.Throws<ArgumentNullException>(() => ThrowIf.Argument.IsNull((int?) null, ""));
            Assert.Throws<ArgumentNullException>(() => ThrowIf.Variable.IsNull((int?) null, ""));
            Assert.Throws<ArgumentNullException>(() => ThrowIf.Field.IsNull((int?) null, ""));
        }

        [Test]
        public void ThrowIfArgumentIsNull_NullableStructNotNull_NotThrow()
        {
            var nullableInt = (int?)1;
            Assert.DoesNotThrow(() => ThrowIf.Argument.IsNull(nullableInt, nameof(nullableInt)));
            Assert.DoesNotThrow(() => ThrowIf.Variable.IsNull(nullableInt, nameof(nullableInt)));
            Assert.DoesNotThrow(() => ThrowIf.Field.IsNull(nullableInt, nameof(nullableInt)));
        }

        /// <summary>
        /// In release mode JIT-ed code of this method should be empty
        /// </summary>
        [Test]
        public void ThrowIfArgumentIsNull_ValueType_NotThrow()
        {
            ThrowIf.Argument.IsNull(1, "");
            ThrowIf.Variable.IsNull(1, "");
            ThrowIf.Field.IsNull(1, "");
            ThrowIf.Argument.IsNull(1.0, "");
            ThrowIf.Argument.IsNull('c', "");
            ThrowIf.Argument.IsNull(new DateTime(), "");
        }
        
        [Test]
        public void ThrowIfStructIsNotInitalized_Throw()
        {
            Assert.Throws<StructIsNotInitializedException>(() => ThrowIf.Struct.IsNotInitialized(false));
        }

        [Test]
        public void ThrowIfStructIsNotInitalized_NotThrow()
        {
            ThrowIf.Struct.IsNotInitialized(true);
        }

        [Test]
        public void ThrowIfPreconditionFailed_Failed_Throw()
        {
            Assert.Throws<InvalidOperationException>(() => ThrowIf.Precondition.Failed(false, ""));
        }
        
        [Test]
        public void ThrowIfPreconditionFailed_NotFailed_NotThrow()
        {
            Assert.DoesNotThrow(() => ThrowIf.Precondition.Failed(true, ""));
        }
    }
}