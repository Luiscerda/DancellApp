using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DancellApp.Controls
{
    public sealed class EntryCompletedBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);
            entry.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            base.OnDetachingFrom(entry);
            entry.TextChanged -= OnEntryTextChanged;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(((Entry)sender).Text))
            {
                if (((Entry)sender).Text != "$")
                {
                    var value = string.IsNullOrEmpty(((Entry)sender).Text) ? 0 : ((Entry)sender).Text.Contains('$') ?
                        Convert.ToDecimal(((Entry)sender).Text.Replace("$", "").Replace(",", "")) : Convert.ToDecimal(((Entry)sender).Text);
                    if (value != 0)
                    {
                        ((Entry)sender).Text = value.ToString("C0", CultureInfo.CurrentCulture);
                        ((Entry)sender).CursorPosition = ((Entry)sender).Text.Length + 1;
                    }
                }
                else
                {
                    ((Entry)sender).Text = string.Empty;
                }               
            }           
        }
    }
}
