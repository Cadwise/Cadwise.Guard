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

using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Guard
{
    [System.Diagnostics.Contracts.Pure]
    [PublicAPI]
    [Localizable(false)]
    public static partial class ThrowIf
    {
        [System.Diagnostics.Contracts.Pure]
        [PublicAPI]
        public static class Precondition
        {
            [ContractAnnotation("precondition:false => halt")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void Failed(bool precondition, [NotNull] string message)
            {
                if (false == precondition)
                {
                    ThrowHelper.ThrowInvalidOperationException(message);
                }
            }
        }

        [System.Diagnostics.Contracts.Pure]
        [PublicAPI]
        public static class Invariant
        {
            [ContractAnnotation("invariant:false => halt")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void Failed(bool invariant, [NotNull] string message)
            {
                if (false == invariant)
                {
                    ThrowHelper.ThrowInvalidOperationException(message);
                }
            }
        }

        [System.Diagnostics.Contracts.Pure]
        [PublicAPI]
        public static class Struct
        {
            [ContractAnnotation("isInitialized:false => halt")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void IsNotInitialized(bool isInitialized)
            {
                if (!isInitialized)
                {
                    ThrowHelper.ThrowStructIsNotInitializedException();
                }
            }
        }
    }
}