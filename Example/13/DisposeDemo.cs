using System;
using System.ComponentModel;
public class BaseResource: IDisposable  //基类
{
	private IntPtr handle;  //外部资源
	private Component Components; //内部资源
	private bool disposed = false; //状态

	public BaseResource() //构造方法
	{
	}

	public void Dispose() //实现IDisposable接口
	{
		Dispose(true);
		GC.SuppressFinalize(this); //阻止
	}

	protected virtual void Dispose(bool disposing) //虚方法，子类可以覆盖
	{
		if(!this.disposed)
		{
			if(disposing)
			{
				Components.Dispose(); //所引用资源的释放
			}
			CloseHandle(handle);  //外部资源的释放
			handle = IntPtr.Zero;
		}
		disposed = true;         
	}

	~BaseResource()     //析构方法
	{
		Dispose(false);  //调用Dispose()方法
	}

	public void Close() //有意义的名字，供外部调用
	{
		if(this.disposed)
		{
			throw new ObjectDisposedException("...");
		}
	}

	public void CloseHandle(IntPtr n)
	{
		//......
	}

}

public class MyResourceWrapper: BaseResource  //子类
{
	private ManagedResource addedManaged;
	private NativeResource addedNative;
	private bool disposed = false;

	public MyResourceWrapper()
	{
	}

	protected override void Dispose(bool disposing)
	{
		if(!this.disposed)
		{
			try
			{
				if(disposing)
				{
					addedManaged.Dispose();         
				}
				CloseHandle(addedNative);
				this.disposed = true;
			}
			finally
			{
				base.Dispose(disposing);  //调用父类的Dispose()方法
			}
		}
	}

	public void CloseHandle(NativeResource n)
	{
		//......
	}

}

public class ManagedResource
{
	//......
	public virtual void Dispose()
	{
		//......
	}
}

public class NativeResource
{
	//......
}

public class Test
{
	static void Main()
	{
	}
}
