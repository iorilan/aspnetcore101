
using System.Configuration;

namespace ComDemo
{
	public class ComConfig
	{
		public static string ComPort
		{
			get { return ConfigurationManager.AppSettings["Com_Port"]; }
		}

		public static int ComBaudRate
		{
			get { return int.Parse(ConfigurationManager.AppSettings["Com_BaudRate"]); }
		}

		public static int ComDataBits
		{
			get { return int.Parse(ConfigurationManager.AppSettings["Com_DataBits"]); }
		}

		public static bool ComRtsEnable
		{
			get { return bool.Parse(ConfigurationManager.AppSettings["Com_RtsEnable"]); }
		}

		public static bool ComDtrEnable
		{
			get { return bool.Parse(ConfigurationManager.AppSettings["Com_DtrEnable"]); }
		}

		public static int ReadTimeout
		{
			get { return int.Parse(ConfigurationManager.AppSettings["Com_ReadTimeout"]); }
		}
	}
}
