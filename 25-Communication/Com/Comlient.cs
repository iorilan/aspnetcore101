using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace ComDemo
{
	public class ComClient : IDisposable
	{
		private static ILog logger = LogManager.GetLogger(typeof(ComClient));
		private SerialPort _serialPort;
		public ComClient()
		{
			Init();
		}

		public void Send(byte[] command)
		{
			logger.Debug($"sending command : '{command}'");
			_serialPort.Write(command, 0, command.Length);
			logger.Debug($"command sent : '{command}'");
		}

		private void Init()
		{
			try
			{
				logger.Info("Starting Open COM");

				_serialPort = new SerialPort(ComConfig.ComPort)
				{
					BaudRate = ComConfig.ComBaudRate,
					Parity = Parity.None,
					StopBits = StopBits.One,
					DataBits = ComConfig.ComDataBits,
					Handshake = Handshake.None,
					RtsEnable = ComConfig.ComRtsEnable,
					DtrEnable = ComConfig.ComDtrEnable,

					ReadTimeout = ComConfig.ReadTimeout
				};

				_serialPort.ErrorReceived += (sender, args) =>
				{
					logger.Error("######error");
					logger.Error(args.EventType);
				};
				_serialPort.DataReceived += (sender, args) =>
				{
					logger.Debug($"data reccrived");
					logger.Debug(args.EventType.ToString());
				};

				// keep trying until open the com
				var maxTry = 20;
				var count = 0;
				while (count < maxTry)
				{
					try
					{
						_serialPort.Open();
						break;
					}
					catch
					{
						logger.Error($"### COM OPEN FAILED ###  - TRYING AGAIN {count} times .");
						count++;
					}
					finally
					{
						Thread.Sleep(1000);
					}
				}

				if (count >= maxTry)
				{
					Console.WriteLine($"failed to open com port {ComConfig.ComPort}");
					return;
				}

				logger.Info("####COM PORT opened...");

				var cmd = new byte[0];
				logger.Debug($"sending command :{cmd}");
				Send(cmd); // send init command to device
			}
			catch (Exception ex)
			{

			}

			
		}

		public void Dispose()
		{
			try
			{
				logger.Debug($"closing COM port ...");
				_serialPort.Close();
				logger.Debug($"disposing COM port ...");
				_serialPort?.Dispose();
				logger.Debug($"disposed COM port ...");
			}
			catch (Exception ex)
			{
				logger.Error("### Error on disposing COM###");
				logger.Error(ex);
			}

		}
	}
}
