using System.Net;

namespace SixtenLabs.Spawn
{
	public class WebClientFactory : IWebClientFactory
	{
		public string DownloadSpecFromUri(string uri)
		{
			return new WebClient().DownloadString(uri);
		}
	}
}
