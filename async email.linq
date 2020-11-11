<Query Kind="Program">
  <Reference>D:\Vault\branches\Current\eRequester\website\Bin\eRequester.Framework.dll</Reference>
  <Namespace>eRequester.Validation</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var timer = new Timer(); 
	
	timer.Start("sync");
	await SendSync();
	timer.Stop(); 
	
	timer.Start("async"); 
	await SendAsync(); 
	timer.Stop(); 
	
}

// Define other methods and classes here
public async Task SendSync()
{
	await Email.Send();
	await Email.Send();
	await Email.Send();
	await Email.Send();
	await Email.Send();
	await Email.Send();
	await Email.Send();
	await Email.Send();
	await Email.Send();
	await Email.Send();
	await Email.Send();
	await Email.Send();
	await Email.Send();
	await Email.Send();
	await Email.Send();
}

public async Task SendAsync()
{
	var emailList = new List<Task>() {
		Email.Send()
		, Email.Send()
		, Email.Send()
		, Email.Send()
		, Email.Send()
		, Email.Send()
		, Email.Send()
		, Email.Send()
		, Email.Send()
		, Email.Send()
		, Email.Send()
		, Email.Send()
		, Email.Send()
		, Email.Send()
		, Email.Send()
	};

	emailList.Count().Dump("# of emails to send");

	foreach (var email in emailList)
	{
		await email;
	}

}
public class Timer
{
	private Stopwatch _stopwatch = new Stopwatch();
	private string _name;  
	public void Start(string name)
	{
		_name = name;
		_stopwatch.Reset();
		_stopwatch.Start();
	}
	public void Stop()
	{
		_stopwatch.Stop();
		_stopwatch.Elapsed.Dump(_name);
	}
}
public class Email
{
	public static Task Send()
	{
		return Task.Delay(1000);
	}
}