// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace TkMobile
{
    using System;
    using System.Reflection;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Provides an Image from a resource (for XAML).
    /// </summary>
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        public string Source { get; set; }

        /// <inheritdoc/>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}