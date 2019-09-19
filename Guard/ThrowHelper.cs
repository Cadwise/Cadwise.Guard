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
using JetBrains.Annotations;

namespace Guard
{
    [System.Diagnostics.Contracts.Pure]
    [PublicAPI]
    public static class ThrowHelper
    {
        [ContractAnnotation("=> halt")]
        public static void ThrowArgumentNullException(string argumentName, ArgumentType argumentType)
        {
            throw new ArgumentNullException(
                $"{GetArgumentTypeName(argumentType)} {argumentName} is null",
                (Exception) null);
        }

        [ContractAnnotation("=> halt")]
        public static void ThrowArgumentIntPtrZero(string argumentName, ArgumentType argumentType)
        {
            throw new ArgumentNullException(
                $"{GetArgumentTypeName(argumentType)} {argumentName} is IntPtr.Zero",
                (Exception) null);
        }

        [ContractAnnotation("=> halt")]
        public static void ThrowArgumentOutOfRangeException(
            double value, double minValue, double maxValue, string argumentName, ArgumentType argumentType)
        {
            throw new ArgumentOutOfRangeException(
                $"{GetArgumentTypeName(argumentType)} {argumentName}={value} is out of range [{minValue}, {maxValue}]",
                (Exception) null);
        }

        [ContractAnnotation("=> halt")]
        public static void ThrowArgumentNegative(
            double value, string argumentName, ArgumentType argumentType)
        {
            throw new ArgumentOutOfRangeException(
                $"{GetArgumentTypeName(argumentType)} {argumentName}={value} must be equal or greater than zero",
                (Exception) null);
        }

        [ContractAnnotation("=> halt")]
        public static void ThrowArgumentNegativeOrZero(
            double value, string argumentName, ArgumentType argumentType)
        {
            throw new ArgumentOutOfRangeException(
                $"{GetArgumentTypeName(argumentType)} {argumentName}={value} must be greater than zero",
                (Exception) null);
        }

        [ContractAnnotation("=> halt")]
        public static void ThrowInvalidOperationException([NotNull] string message)
        {
            throw new InvalidOperationException(message);
        }
        
        [ContractAnnotation("=> halt")]
        public static void ThrowArgumentException(string argumentName)
        {
            throw new ArgumentException(argumentName);
        }

        [ContractAnnotation("=> halt")]
        public static void ThrowStructIsNotInitializedException()
        {
            throw new StructIsNotInitializedException();
        }

        [NotNull]
        private static string GetArgumentTypeName(ArgumentType argumentType)
        {
            switch (argumentType)
            {
                case ArgumentType.Variable:
                    return "variable";
                case ArgumentType.Field:
                    return "field";
                case ArgumentType.Argument:
                    return "argument";
                default:
                    throw new ArgumentOutOfRangeException(nameof(argumentType), argumentType, null);
            }
        }
    }
}