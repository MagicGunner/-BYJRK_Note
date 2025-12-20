using System.Windows;
using System.Windows.Controls;

namespace DPAndAP;

public class TextBoxHelper {
    #region Title

    public static readonly DependencyProperty TitleProperty = DependencyProperty.RegisterAttached("Title", typeof(string), typeof(TextBoxHelper), new PropertyMetadata(string.Empty));

    public static void SetTitle(DependencyObject obj, string value) {
        obj.SetValue(TitleProperty, value);
    }

    public static string GetTitle(DependencyObject obj) {
        return (string)obj.GetValue(TitleProperty);
    }

    #endregion

    #region HasText

    // public static readonly DependencyProperty HasTextProperty = DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false));
    //
    // public static void SetHasText(DependencyObject obj, bool value) {
    //     obj.SetValue(HasTextProperty, value);
    // }
    //
    // public static bool GetHasText(DependencyObject obj) {
    //     return (bool)obj.GetValue(HasTextProperty);
    // }

    public static bool GetHasText(DependencyObject obj) => (bool)obj.GetValue(HasTextProperty);

    private static void SetHasText(DependencyObject obj, bool value) => obj.SetValue(HasTextPropertyKey, value);


    private static readonly DependencyPropertyKey HasTextPropertyKey = DependencyProperty.RegisterAttachedReadOnly("HasText", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false));

    public static readonly DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

    #endregion


    #region MonitorTextChange

    public static readonly DependencyProperty MonitorTextChangeProperty
        = DependencyProperty.RegisterAttached("MonitorTextChange", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false, MonitorTextChanged));

    private static void MonitorTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        if (d is not TextBox textBox) throw new NotSupportedException();

        if ((bool)e.NewValue) {
            textBox.TextChanged += OnTextChanged;
            SetHasText(textBox, !string.IsNullOrEmpty(textBox.Text));
        } else {
            textBox.TextChanged -= OnTextChanged;
        }
    }

    private static void OnTextChanged(object sender, TextChangedEventArgs e) {
        var box = (sender as TextBox)!;
        SetHasText(box, !string.IsNullOrEmpty(box.Text));
    }

    public static void SetMonitorTextChange(DependencyObject obj, bool value) {
        obj.SetValue(MonitorTextChangeProperty, value);
    }

    public static bool GetMonitorTextChange(DependencyObject obj) {
        return (bool)obj.GetValue(MonitorTextChangeProperty);
    }

    #endregion
}