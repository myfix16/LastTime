using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LastTime.Behaviors
{
    public class BindableCommandBarBehavior : Behavior<CommandBar>
    {
        /// <summary>
        /// PrimaryCommands that the app bar has.
        /// </summary>
        public ObservableCollection<AppBarButton> PrimaryCommands
        {
            get { return (ObservableCollection<AppBarButton>)GetValue(PrimaryCommandsProperty); }
            set { SetValue(PrimaryCommandsProperty, value); }
        }

        public static readonly DependencyProperty PrimaryCommandsProperty
            = DependencyProperty.Register(
                "PrimaryCommands",
                typeof(ObservableCollection<AppBarButton>),
                typeof(BindableCommandBarBehavior),
                new PropertyMetadata(default(ObservableCollection<AppBarButton>), UpdateCommands));

        private static void UpdateCommands(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (!(dependencyObject is BindableCommandBarBehavior behavior)) return;

            var oldList = dependencyPropertyChangedEventArgs.OldValue as ObservableCollection<AppBarButton>;
            if (dependencyPropertyChangedEventArgs.OldValue != null)
            {
                oldList.CollectionChanged -= behavior.PrimaryCommandsCollectionChanged;
            }

            var newList = dependencyPropertyChangedEventArgs.NewValue as ObservableCollection<AppBarButton>;
            if (dependencyPropertyChangedEventArgs.NewValue != null)
            {
                newList.CollectionChanged += behavior.PrimaryCommandsCollectionChanged;
            }
            behavior.UpdatePrimaryCommands();
        }


        private void PrimaryCommandsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdatePrimaryCommands();
        }

        /// <summary>
        /// Update the primary commands for CommandBar.
        /// </summary>
        private void UpdatePrimaryCommands()
        {
            if (PrimaryCommands != null && AssociatedObject != null)
            {
                AssociatedObject.PrimaryCommands.Clear();
                foreach (var command in PrimaryCommands)
                {
                    AssociatedObject.PrimaryCommands.Add(command);
                }
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            UpdatePrimaryCommands();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (PrimaryCommands != null)
            {
                PrimaryCommands.CollectionChanged -= PrimaryCommandsCollectionChanged;
            }
        }
    }
}
