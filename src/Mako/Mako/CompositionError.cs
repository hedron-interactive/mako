// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="CompositionError.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako
{
    using System;

    /// <summary>
    /// Type used to surface an error occurence in a block application sequence.
    /// </summary>
    public struct CompositionError : IEquatable<CompositionError>
    {
        /// <summary>
        /// Indicates an unknown error has occurred.
        /// </summary>
        public static readonly CompositionError Unknown = CompositionError.Create(CompositionErrorCode.Unknown);

        /// <summary>
        /// Gets or sets the code associated with the error. <seealso cref="CompositionErrorCode"/> contains standard error codes,
        /// however an application may also supply application specific error codes.
        /// </summary>
        public int Code
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a human readable message associated with the error.
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the exception associated with the error. Note that some SequenceErrors may not contain an exception.
        /// </summary>
        public Exception Exception
        {
            get;
            set;
        }

        /// <summary>
        /// Compares two SequenceError instances for equality.
        /// </summary>
        /// <param name="lval">comparison lvalue.</param>
        /// <param name="rval">comparison rvalue.</param>
        /// <returns>true if the two instances are equal; otherwise, false.</returns>
        public static bool operator ==(CompositionError lval, CompositionError rval)
        {
            return lval.Equals(rval);
        }

        /// <summary>
        /// Compares two SequenceError instances for difference.
        /// </summary>
        /// <param name="lval">comparison lvalue.</param>
        /// <param name="rval">comparison rvalue.</param>
        /// <returns>true if the two instances are different; otherwise, false.</returns>
        public static bool operator !=(CompositionError lval, CompositionError rval)
        {
            return !lval.Equals(rval);
        }

        /// <summary>
        /// Creates a new SequenceError instance. The specified error code is used to attempt a
        /// error description lookup.
        /// </summary>
        /// <param name="code">A numeric code uniquely catagorizing this error.</param>
        /// <returns>A new SequenceError instance.</returns>
        public static CompositionError Create(int code)
        {
            return Create(code, null, CompositionErrorCode.GetErrorDescription(code));
        }

        /// <summary>
        /// Creates a new SequenceError instance. The specified error code is used to attempt a
        /// error description lookup.
        /// </summary>
        /// <param name="code">A numeric code uniquely catagorizing this error.</param>
        /// <param name="e">Optional, exception that caused the error.</param>
        /// <returns>A new SequenceError instance.</returns>
        public static CompositionError Create(int code, Exception e)
        {
            return Create(code, e, CompositionErrorCode.GetErrorDescription(code));
        }

        /// <summary>
        /// Creates a new SequenceError instance.
        /// </summary>
        /// <param name="code">A numeric code uniquely catagorizing this error.</param>
        /// <param name="e">Optional, exception that caused the error.</param>
        /// <param name="description">Optional, user friendly message describing the error.</param>
        /// <returns>A new SequenceError instance.</returns>
        public static CompositionError Create(int code, Exception e, string description)
        {
            return new CompositionError
            {
                Code = code,
                Description = description,
                Exception = e
            };
        }

        /// <summary>
        /// Compares two SequenceError instances for equality.
        /// </summary>
        /// <param name="obj">comparison rvalue.</param>
        /// <returns>true if the two instances are equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is CompositionError)
            {
                return this.Equals((CompositionError)obj);
            }

            return false;
        }

        /// <summary>
        /// Computes this SequenceError instances hash code.
        /// </summary>
        /// <returns>the integer this instance hashes  to.</returns>
        public override int GetHashCode()
        {
            return (this.Code * 214741)
                   ^ (StringComparer.Ordinal.GetHashCode(this.Description) * 214741);
        }

        /// <summary>
        /// Gets the string representation.
        /// </summary>
        /// <returns>a string representing this instance.</returns>
        public override string ToString()
        {
            return string.Format("{{error, {0}, {{description, \"{1}\"}}, {{exception, \"{2}\"}}}}", this.Code, this.Description ?? "none", null != this.Exception ? this.Exception.Message : "none");
        }

        /// <summary>
        /// Compares two SequenceError instances for equality.
        /// </summary>
        /// <param name="other">comparison rvalue.</param>
        /// <returns>true if the two instances are equal; otherwise, false.</returns>
        public bool Equals(CompositionError other)
        {
            return this.Code == other.Code
                   && this.Description == other.Description
                   && this.Exception == other.Exception;
        }
    }
}