using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications;

namespace RMBCapConverter.Services
{
    internal partial class ToastNotificationsService
    {
        public void ShowConvertNotification(string capChs, string orgInput)
        {
            // Create the toast content
            var content = new ToastContent()
            {
                // Documentation: https://developer.microsoft.com/en-us/windows/uwp-community-toolkit/api/microsoft_toolkit_uwp_notifications_toastcontent
                Launch = "ToastContentActivationParams",

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = capChs
                            },

                            new AdaptiveText()
                            {
                                Text = orgInput
                            }
                        }
                    }
                }
            };

            // Create the toast
            var toast = new ToastNotification(content.GetXml())
            {
                // Documentation: https://docs.microsoft.com/uwp/api/windows.ui.notifications.toastnotification
                Tag = "ToastTag"
            };

            // And show the toast
            ShowToastNotification(toast);
        }
    }
}
