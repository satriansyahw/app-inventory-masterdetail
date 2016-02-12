using System;
using Intersoft.Crosslight.Forms;

namespace MyInventory.Models
{
    [Form(Title = "Settings")]
	public class UserSettingsFormMetadata
	{
        [Section(Header = "General", Footer = "This is just an example setting screen. Feel free to define the actual settings that applicable to your app.")]
        public static GeneralSection General;

        [Section(Header = "Notifications")]
        public static NotificationSection Notification;

        public class GeneralSection
        {
            [Display(Caption = "Text Size")]
            public static TextSize TextSize;

            [Display(Caption = "Automatic Refresh")]
            [Editor(EditorType.Switch)]
            public static bool AutoRefresh;

            [Display(Caption = "Synchronization Interval")]
            [StringInput(Alignment = TextAlignment.Right)]
            public static int SyncInterval;
        }

        public class NotificationSection
        {
            [Display(Caption = "Enable Notification")]
            [Editor(EditorType.Switch)]
            public static bool EnableNotification;

            [Display(Caption = "In-App Sound")]
            [Editor(EditorType.Switch)]
            [VisibilityBinding(Path = "EnableNotification")]
            public static bool EnableInAppSound;

            [Display(Caption = "In-App Vibrate")]
            [Editor(EditorType.Switch)]
            [VisibilityBinding(Path = "EnableNotification")]
            public static bool EnableInAppVibrate;
        }
	}
}

