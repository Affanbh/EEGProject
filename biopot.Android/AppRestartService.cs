using Android.App;
using Android.Content;
using Android.OS;
using biopot.Droid;  // Replace with your actual namespace
using biopot.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppRestartService))]
namespace biopot.Droid
{
    public class AppRestartService : IAppRestartService
    {
        public void RestartApp()
        {
            var context = Android.App.Application.Context;
            Intent intent = context.PackageManager.GetLaunchIntentForPackage(context.PackageName);
            intent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);  // Clear current task stack
            context.StartActivity(intent);

            // Kill the current process to ensure a full restart
            Process.KillProcess(Process.MyPid());
        }
    }
}