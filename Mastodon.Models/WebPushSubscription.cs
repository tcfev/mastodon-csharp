namespace Mastodon.Models;

/// <summary>
/// Represents a subscription to the push streaming server.
/// </summary>
public sealed partial class WebPushSubscription
{
    /// <summary>
    /// The ID of the Web Push subscription in the database.
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// Where push alerts will be sent to.
    /// </summary>
    public required string Endpoint { get; set; }

    /// <summary>
    /// The streaming server’s VAPID key.
    /// </summary>
    public required string ServerKey { get; set; }

    /// <summary>
    /// Which alerts should be delivered to the endpoint.
    /// </summary>
    public required AlertHash Alerts { get; set; }


    /// <summary>
    /// Which alerts should be delivered to the endpoint.
    /// </summary>
    public sealed partial class AlertHash
    {
        /// <summary>
        /// Receive a push notification when someone else has mentioned you in a status?
        /// </summary>
        public bool Mention { get; set; }
        /// <summary>
        /// Receive a push notification when a subscribed account posts a status?
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Receive a push notification when a status you created has been boosted by someone else?
        /// </summary>
        public bool Reblog { get; set; }

        /// <summary>
        /// Receive a push notification when someone has followed you?
        /// </summary>
        public required bool Follow { get; set; }

        /// <summary>
        /// Receive a push notification when a status you created has been favourited by someone else?
        /// </summary>
        public bool Favourite { get; set; }

        /// <summary>
        /// Receive a push notification when a poll you voted in or created has ended?
        /// </summary>
        public bool Poll { get; set; }
        /// <summary>
        /// Receive a push notification when a status you interacted with has been edited?
        /// </summary>
        public bool Update { get; set; }

        /// <summary>
        /// Admin notifications.
        /// </summary>
        public AdminHash? Admin { get; set; }

        /// <summary>
        /// Admin notifications.
        /// </summary>
        public sealed partial class AdminHash
        {
            /// <summary>
            /// Receive a push notification when a new user has signed up?
            /// </summary>
            public bool SignUp { get; set; }

            /// <summary>
            /// Receive a push notification when a new report has been filed?
            /// </summary>
            public bool Report { get; set; }
        }
    }
}
