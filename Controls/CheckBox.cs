using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFLibrary.Controls
{
    public class CheckBox : Image
    {
        TapGestureRecognizer tapGestureRecognizer;
        public CheckBox()
        {
            base.Source = ImageSource.FromResource("XFLibrary.Resources.Image_Unchecked.png");
            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;

            base.GestureRecognizers.Add(tapGestureRecognizer);
        }

        public static BindableProperty CheckedProperty = BindableProperty.Create(
            propertyName: "Checked",
            returnType: typeof(Boolean?),
            declaringType: typeof(CheckBox),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: CheckedValueChanged);

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Checked = !Checked;
        }

        public Boolean? Checked
        {
            get
            {
                if (GetValue(CheckedProperty) == null)
                {
                    return null;
                }
                return (Boolean)GetValue(CheckedProperty);
            }
            set
            {
                SetValue(CheckedProperty, value);
                OnPropertyChanged();
                RaiseCheckedChanged();
            }
        }

        public Boolean isChecked()
        {
            return (Boolean)GetValue(CheckedProperty);
        }


        private static void CheckedValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null && (Boolean)newValue == true)
            {
                ((CheckBox)bindable).Source = ImageSource.FromResource("XFLibrary.Resources.Image_Checked.png");
            }
            else
            {
                ((CheckBox)bindable).Source = ImageSource.FromResource("XFLibrary.Resources.Image_Unchecked.png");
            }
        }

        public event EventHandler CheckedChanged;
        private void RaiseCheckedChanged()
        {
            if (CheckedChanged != null)
                CheckedChanged(this, EventArgs.Empty);
        }

        private Boolean _IsEnabled = true;
        public new Boolean IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            set
            {
                _IsEnabled = value;
                OnPropertyChanged();
                if (value == true)
                {
                    this.Opacity = 1;
                }
                else
                {
                    this.Opacity = .5;
                }
                base.IsEnabled = value;
            }
        }

    }
}
