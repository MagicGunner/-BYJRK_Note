using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DPAndAP;

public class CustomTextBox : TextBox {
    #region IsHightlight

    public static readonly DependencyProperty IsHighlightProperty = DependencyProperty.Register(nameof(IsHighlight), typeof(bool), typeof(CustomTextBox), new PropertyMetadata(false, CallBack));

    private static void CallBack(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        var box = d as CustomTextBox;
        box?.Background = Brushes.Red;
    }

    public bool IsHighlight {
        get => (bool)GetValue(IsHighlightProperty);
        set => SetValue(IsHighlightProperty, value);
    }

    #endregion

    #region HasText

    public bool HasText => (bool)GetValue(HasTextProperty);

    public static readonly DependencyProperty    HasTextProperty;
    public static readonly DependencyPropertyKey HasTextPropertyKey;

    static CustomTextBox() {
        HasTextPropertyKey = DependencyProperty.RegisterReadOnly("HasText", typeof(bool), typeof(CustomTextBox), new PropertyMetadata(false));
        HasTextProperty = HasTextPropertyKey.DependencyProperty;
    }

    #endregion
}