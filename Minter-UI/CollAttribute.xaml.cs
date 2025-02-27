﻿using Chia_Metadata_CHIP_0007_std;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Minter_UI
{
    /// <summary>
    /// Interaction logic for CollAttribute.xaml
    /// </summary>
    public partial class CollAttribute : UserControl
    {
        public CollAttribute(CollectionAttribute attr = null)
        {
            InitializeComponent();
            this.Type_ComboBox.ItemsSource = _AvailableAttributes;
            if (attr != null)
            {
                Value = attr;
            }
        }
        private static List<string> _AvailableAttributes = new List<string>()
        {
            "description",
            "icon",
            "banner",
            "website",
            "twitter",
            "discord"
        };
        public CollectionAttribute Value
        {
            get
            {
                CollectionAttribute attribute = new CollectionAttribute(this.Type_ComboBox.Text, this.Value_TextBox.Text);
                return attribute;
            }
            set
            {
                this.Type_ComboBox.Text = value.type;
                this.Value_TextBox.Text = (string)value.@value;
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }
        private bool LastValueTextBoxStateWasValid = true;
        private void Value_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.Value_TextBox.Text == "" ||this.Type_ComboBox.Text == "")
            {
                this.Value_TextBox.Background = null;
                LastValueTextBoxStateWasValid = true;
                return;
            }
            if (this.Type_ComboBox.Text == "banner"|| this.Type_ComboBox.Text == "icon"  
                || this.Type_ComboBox.Text == "website" || this.Type_ComboBox.Text == "discord")
            {
                try
                { // textbox content is valid
                    new Uri(this.Value_TextBox.Text);
                    if (!LastValueTextBoxStateWasValid)
                    {
                        this.Value_TextBox.Background = null;
                        LastValueTextBoxStateWasValid = true;
                    }
                }
                catch (Exception ex)
                {
                    if (LastValueTextBoxStateWasValid)
                    {
                        this.Value_TextBox.Background = Brushes.LightCoral;
                        LastValueTextBoxStateWasValid = false;
                    }
                }

            }
        }
    }
}
