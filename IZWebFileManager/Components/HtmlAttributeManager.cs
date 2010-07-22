﻿//Copyright (c) 2009 Patrik Hägne

//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 

using System;
using System.Web.UI;
using System.Text;
namespace Legend.Web
{
    /// <summary>
    /// Handles the writing of attributes to the HtmlTextWriter specified
    /// in the constructor.
    /// </summary>
    internal class HtmlAttributeManager
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="writer">The writer to use for writing.</param>
        public HtmlAttributeManager(HtmlTextWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");

            this.Writer = writer;
        }

        /// <summary>
        /// The writer this manager writes to.
        /// </summary>
        public HtmlTextWriter Writer { get; private set; }

        /// <summary>
        /// Applies the value to the specified attribute to the HtmlTextWriter
        /// this instance contains.
        /// </summary>
        /// <param name="attribute">The attribute to set.</param>
        /// <param name="value">The value to set to the attribute.</param>
        /// <returns>The attribute manager.</returns>
        public HtmlAttributeManager this[System.Web.UI.HtmlTextWriterAttribute attribute, string value] 
        {
            get 
            {
                this.Writer.AddAttribute(attribute, value);
                return this;
            }
        }

        /// <summary>
        /// Adds the class attribute to the tag being rendered.
        /// </summary>
        /// <param name="className">The name of the class.</param>
        /// <returns>The attribute manager.</returns>
        public HtmlAttributeManager Class(string className)
        {
            return this[HtmlTextWriterAttribute.Class, className];
        }

        /// <summary>
        /// Adds the class attribute to the tag being rendered.
        /// </summary>
        /// <param name="classNames">The names of the classes to set to the attribute.</param>
        /// <returns>The attribute manager.</returns>
        public HtmlAttributeManager Class(params string[] classNames)
        {
            var namesString = new StringBuilder();

            foreach (var name in classNames)
            {
                if (namesString.Length > 0)
                {
                    namesString.Append(" ");
                }

                namesString.Append(name);
            }

            return this[HtmlTextWriterAttribute.Class, namesString.ToString()];
        }

        /// <summary>
        /// Adds the id attribute to the tag being rendered.
        /// </summary>
        /// <param name="className">The id to set.</param>
        /// <returns>The attribute manager.</returns>
        public HtmlAttributeManager Id(string elementId)
        {
            return this[HtmlTextWriterAttribute.Id, elementId];
        }

        /// <summary>
        /// Adds the name attribute to the tag being rendered.
        /// </summary>
        /// <param name="className">The name to set.</param>
        /// <returns>The attribute manager.</returns>
        public HtmlAttributeManager Name(string elementName)
        {
            return this[HtmlTextWriterAttribute.Name, elementName];
        }


    }
}
