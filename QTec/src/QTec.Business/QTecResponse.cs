// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QTecResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The QTec response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QTec.Business
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The QTec response.
    /// </summary>
    /// <typeparam name="T"> The generic response parameter</typeparam>
    public class QTecResponse<T>
    {
        /// <summary>
       /// Gets or sets the response.
       /// </summary>
       public T Response { get; set; }

       /// <summary>
       /// Gets or sets the exceptions.
       /// </summary>
       public Dictionary<string, string> Exceptions { get; set; }
    }
}
