    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class MobileNotificationManager : MonoBehaviour
{
    #if UNITY_ANDROID
    public AndroidNotificationChannel defaultNotificationChannel;

    private int identifier;

    private void Start()
    {
        defaultNotificationChannel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Channel",
            Description = "For Generic notifications",
            Importance = Importance.Default,
        };

        AndroidNotificationCenter.RegisterNotificationChannel(defaultNotificationChannel);

        /*AndroidNotification notification = new AndroidNotification()
        {
            Title = "Test Notification!",
            Text = "You had the game open for 10 seconds!",
            SmallIcon = "app_icon_small",
            LargeIcon = "app_icon_large",
            FireTime = System.DateTime.Now.AddSeconds(10),
        };

        identifier = AndroidNotificationCenter.SendNotification(notification, "default_channel");*/

        AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler = delegate (AndroidNotificationIntentData data)
        {
            var msg = "Notification received : " + data.Id + "\n";
            msg += "\n Notification received: ";
            msg += "\n .Title: " + data.Notification.Title;
            msg += "\n .Body: " + data.Notification.Text;
            msg += "\n .Channel: " + data.Channel;
            Debug.Log(msg);
        };

        AndroidNotificationCenter.OnNotificationReceived += receivedNotificationHandler;

        var notificationIntentData = AndroidNotificationCenter.GetLastNotificationIntent();

        if(notificationIntentData != null)
        {
            Debug.Log("App was opened with notification!");
        }

    }

    public void NotificationBlock()
    {
        AndroidNotification newNotification = new AndroidNotification()
        {
            Title = "Notification!",
            Text = "You walked past a local store!",
            SmallIcon = "app_icon_small",
            LargeIcon = "app_icon_large",
            FireTime = System.DateTime.Now
        };

        identifier = AndroidNotificationCenter.SendNotification(newNotification, "default_channel");
    }

    private void OnApplicationPause(bool pause)
    {
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Scheduled)
        {
            // If the player had left the game and the game is still running. Send them a new notification
            AndroidNotification newNotification = new AndroidNotification()
            {
                Title = "Reminder Notification!",
                Text = "You just paused our app, we will be reminding you again :D",
                SmallIcon = "app_icon_small",
                LargeIcon = "app_icon_large",
                FireTime = System.DateTime.Now
            };

            // Replace the currently scheduled notification with a new notification
            AndroidNotificationCenter.UpdateScheduledNotification(identifier, newNotification, "default_channel");
        }
        else if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Delivered)
        {
            // Remove the notification from the status bar
            AndroidNotificationCenter.CancelNotification(identifier);
        }

        /*else if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Unknown)
        {
            AndroidNotification notification2 = new AndroidNotification()
            {
                Title = "Test Notification 2!",
                Text = "This is a test notification!",
                SmallIcon = "app_icon_small",
                LargeIcon = "app_icon_large",
                FireTime = System.DateTime.Now.AddSeconds(10)
            };

            // Try sending it again
            identifier = AndroidNotificationCenter.SendNotification(notification2, "default_channel");
        }*/
    }

#endif
}
