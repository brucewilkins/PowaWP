using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace Powa.Client.Behaviours
{
    /// <summary>
    /// Enables bound values to be updated as they are changed.
    /// Useful in the case where you need to do entry validation or where
    /// you need to update bindings without using code behind i.e.: when running an AppBar command
    /// </summary>
    public class UpdateTextBindingOnPropertyChanged : Behavior<TextBox>
    {
        private BindingExpression _expression;

        protected override void OnAttached()
        {
            base.OnAttached();

            _expression = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
            AssociatedObject.TextChanged += OnTextChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.TextChanged -= OnTextChanged;
            _expression = null;
        }

        /// <summary>
        /// Updates the source property when the text is changed.
        /// </summary>
        private void OnTextChanged(object sender, EventArgs args)
        {
            _expression.UpdateSource();
        }
    }
}