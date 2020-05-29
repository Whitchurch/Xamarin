using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace practice.Views
{
    public partial class reviewStageTwo : ContentPage
    {
        public reviewStageTwo()
        {
            InitializeComponent();
            BindingContext = new ViewModels.viewmodel_reviewStageTwo();
        }
    }
}
