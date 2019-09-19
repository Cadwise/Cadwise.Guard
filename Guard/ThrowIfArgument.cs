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
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Guard
{
    public static partial class ThrowIf
    {
        [System.Diagnostics.Contracts.Pure]
        [PublicAPI]
        public static class Argument
        {
            [ContractAnnotation("argument:null => halt")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void IsNull<T>(
                [CanBeNull, NoEnumeration] T argument, [InvokerParameterName] string argumentName)
            {
                if (ReferenceEquals(null, argument))
                {
                    ThrowHelper.ThrowArgumentNullException(argumentName, ArgumentType.Argument);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void OutOfRange(int argument, int minInclusive, int maxInclusive, [InvokerParameterName] string argumentName)
            {
                if (argument < minInclusive || argument > maxInclusive)
                {
                    ThrowHelper.ThrowArgumentOutOfRangeException(argument, minInclusive, maxInclusive, argumentName,
                        ArgumentType.Argument);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void OutOfRange(
                double argument, double min, double max, [InvokerParameterName] string argumentName)
            {
                if (argument < min || argument > max)
                {
                    ThrowHelper.ThrowArgumentOutOfRangeException(argument, min, max, argumentName,
                        ArgumentType.Argument);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void IsZero(double argument, [InvokerParameterName] string argumentName, double epsilon)
            {
                if (Math.Abs(argument) <= epsilon)
                {
                    ThrowHelper.ThrowArgumentNullException(argumentName, ArgumentType.Argument);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void Negative(double value, [InvokerParameterName] string argumentName)
            {
                if (0 > value)
                {
                    ThrowHelper.ThrowArgumentNegative(value, argumentName, ArgumentType.Argument);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void Negative(int value, [InvokerParameterName] string argumentName)
            {
                if (0 > value)
                {
                    ThrowHelper.ThrowArgumentNegative(value, argumentName, ArgumentType.Argument);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void NegativeOrZero(double value, [InvokerParameterName] string argumentName)
            {
                if (0 >= value)
                {
                    ThrowHelper.ThrowArgumentNegativeOrZero(value, argumentName, ArgumentType.Argument);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void NegativeOrZero(int value, [InvokerParameterName] string argumentName)
            {
                if (0 >= value)
                {
                    ThrowHelper.ThrowArgumentNegativeOrZero(value, argumentName, ArgumentType.Argument);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void IsNullOrEmpty([CanBeNull] string argument, [InvokerParameterName] string argumentName)
            {
                if (string.IsNullOrEmpty(argument))
                {
                    ThrowHelper.ThrowArgumentException(argumentName);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void IsNullOrEmpty<T>(
                [CanBeNull] IEnumerable<T> argument, [InvokerParameterName] string argumentName)
            {
                if (argument == null || !argument.Any())
                {
                    ThrowHelper.ThrowArgumentException(argumentName);
                }
            }

#if !NotStandardFramework
            [ContractAnnotation("argument:null => halt")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static unsafe void IsNullPointer(void* argument, [InvokerParameterName] string argumentName)
            {
                if (argument == null)
                {
                    ThrowHelper.ThrowArgumentNullException(argumentName, ArgumentType.Argument);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void IsIntPtrZero(IntPtr ptr, [InvokerParameterName] string argumentName)
            {
                if (ptr == IntPtr.Zero)
                {
                    ThrowHelper.ThrowArgumentIntPtrZero(argumentName, ArgumentType.Argument);
                }
            }
#endif
        }
    }
}