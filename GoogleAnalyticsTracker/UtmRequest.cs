using System;
using System.Globalization;
using System.Text;

namespace GoogleAnalyticsTracker
{
    public class UtmRequest
    {

        private static readonly Random Random = new Random();

        public UtmRequest()
        {
            Encoding = new UTF8Encoding();
            TrackingCodeVersion = "5.3.0";
        }


        /// <summary>
        /// Account String. Appears on all requests. utmac
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Cookie values. This request parameter sends all the cookies requested from the page. utmcc
        /// </summary>
        public object Cookie { get; set; }


        /// <summary>
        /// Language encoding for the browser. Some browsers don't set this, in which case it is set to "-" utmcs
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// Page title, which is a URL-encoded string. utmdt
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Page request of the current page. utmp
        /// </summary>
        public string ResourceUrl { get; set; }

        public string Resolution { get; set; }
        public string ColorDepth { get; set; }
        public CultureInfo Language { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// Indicates the type of request, which is one of: 
        /// event, transaction, item, or custom variable. 
        /// If this value is not present in the GIF request, the request is typed as page. utmt
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// Host Name, which is a URL-encoded string. utmhn
        /// </summary>
        public string HostName { get; set; }
        public string Referer { get; set; }

        /// <summary>
        /// Tracking code version. utmwv
        /// </summary>
        public string TrackingCodeVersion { get; private set; }


        /// <summary>
        /// Unique ID generated for each GIF request to prevent caching of the GIF image. utmn
        /// </summary>
        private int UniqueRequestId
        {
            get
            {
                return Random.Next(1111111111, 1142651215);
            }
        }



        public string GetRequestUrl()
        {
            Validate();
            var sb = new StringBuilder("http://www.google-analytics.com/__utm.gif?");

            Append(sb, "utmac", AccountNumber);
            Append(sb, "utmdt", Title);
            Append(sb, "utmhn", HostName);
            Append(sb, "utmn", UniqueRequestId.ToString(CultureInfo.InvariantCulture));
            Append(sb, "utmp", ResourceUrl);
            Append(sb, "utmt", Event);

            if (Encoding == null)
            {
                Append(sb, "utmcs", "-");
            }
            else
            {
                Append(sb, "utmcs", Encoding.EncodingName);
            }

            return sb.ToString();
        }


        private static void Append(StringBuilder stringBuilder, string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
                stringBuilder.Append(key + "=" + value + "&");
        }

        private void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
