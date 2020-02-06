// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace TkMobile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1601 // Partial elements should be documented
    public partial class PromptPage : ContentPage
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        private readonly Action<string> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="PromptPage"/> class.
        /// </summary>
        /// <param name="prompt">¨The text displayed to the user.</param>
        /// <param name="callback">Will be called with the result.</param>
        public PromptPage(string prompt, Action<string> callback)
        {
            InitializeComponent();
            action = callback;
            PromptLabel.Text = prompt;
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            action(PromptEntry.Text);
            Navigation.PopModalAsync();
        }
    }
}