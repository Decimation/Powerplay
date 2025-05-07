// Author: Deci | Project: Powerplay.Lib | Name: NvServiceController.cs
// Date: 2025/05/07 @ 15:05:00

using Novus.Win32;
using Novus.Win32.Structures.AdvApi32;
using System.Reflection.Metadata;
using Microsoft.Extensions.Logging;

namespace Powerplay.Lib.App;

public abstract class BaseService : IDisposable
{

	public ScHandle Handle { get; private set; }

	public string Name { get; }

	public static ScHandle ControlManager { get; private set; }

	protected static readonly ILogger _logger;

	static BaseService()
	{
		_logger = AppController.LoggerFactory.CreateLogger(nameof(BaseService));
		OpenManager();
	}

	protected BaseService(string name)
	{
		Name = name;
	}

	internal static ScHandle GetSCManager()
	{
		return Native.OpenSCManager(null, null, ScManagerAccessTypes.SC_MANAGER_ALL_ACCESS);
	}

	public static bool OpenManager()
	{
		if (ControlManager.IsNull) {
			ControlManager = GetSCManager();

		}

		_logger.LogTrace("Control manager open: {CtrlMgr}", ControlManager);
		return !ControlManager.IsNull;
	}

	public static bool CloseManager()
	{
		Native.CloseServiceHandle(ControlManager);
		_logger.LogTrace("Control manager close: {CtrlMgr}", ControlManager);
		ControlManager = default;
		return true;
	}

	public virtual bool Open()
	{
		Handle = Native.OpenService(ControlManager, Name, ServiceAccessTypes.SERVICE_ALL_ACCESS);
		return !Handle.IsNull;
	}

	public virtual bool Start()
	{
		var b = Native.StartService(Handle);
		return b;
	}

	public virtual bool Pause(out ServiceStatus status)
	{
		var b = Native.ControlService(Handle, ServiceControl.SERVICE_CONTROL_PAUSE, out status);
		return b;
	}

	public virtual bool Stop(out ServiceStatus status)
	{
		var b = Native.StopService(Handle, out status);
		return b;
	}


	protected static T Control<T>(ScHandle hScManager, string svcName, Func<ScHandle, T> fn)
	{
		T ret = default;

		if (!hScManager.IsNull) {
			var hSc = Native.OpenService(hScManager, svcName, ServiceAccessTypes.SERVICE_ALL_ACCESS);

			ret = fn(hScManager);

			// Native.CloseServiceHandle(hScManager);
			Native.CloseServiceHandle(hSc);
		}

		return ret;
	}

#region Implementation of IDisposable

	public void Dispose()
	{
		Native.CloseServiceHandle(Handle);
		Handle = default;
	}

#endregion

}

public class NvServiceController : BaseService
{

	private NvServiceController(string name) : base(name) { }

	public static BaseService NvContainer { get; private set; } = new NvServiceController(SVC_LOCAL_CONTAINER);

	public const string SVC_LOCAL_CONTAINER = "NvContainerLocalSystem";

	public static bool Close()
	{
		NvContainer?.Dispose();
		NvContainer = null;

		return true;
	}

}