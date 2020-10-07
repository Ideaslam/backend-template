
using System;
using System.Collections.Generic;
using System.Text;

using FluentValidation.Results;
using Edura.Enums;

namespace Edura.Model.Support
{
    /// <summary>
    /// Represents the default execution response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExecutionResponse<T>
    {
        public ExecutionResponse()
        {

        }
        /// <summary>
        /// Gets or sets the result
        /// </summary>
        public T Result { get; set; }
        /// <summary>
        /// Gets or sets the response state
        /// </summary>
        public virtual ResponseState State { get; set; }
        /// <summary>
        /// Gets or sets the message code
        /// </summary>
        public virtual string MessageCode { get; set; }
        /// <summary>
        /// Gets or sets the message
        /// </summary>
        public virtual string Message { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ValidationResult"/>
        /// </summary>
        public ValidationResult ValidationResult { get; set; }
        /// <summary>
        /// Gets or sets the detailed messages
        /// </summary>
        public virtual List<MetaPair> DetailedMessages { get; set; }
        /// <summary>
        /// Gets or sets the exception
        /// </summary>
        public virtual Exception Exception { get; set; }



    }

}

