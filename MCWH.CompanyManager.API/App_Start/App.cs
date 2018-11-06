using MCWH.CompanyManager.API.Models;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MCWH.CompanyManager.API.App), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(MCWH.CompanyManager.API.App), "Stop")]

namespace MCWH.CompanyManager.API
{   
    public static class App
    {
        public static void Start()
        {
            DependencyConfig.SetupDependencies();
            ModelMapper.Config();
        }

        public static void Stop()
        {

        }
    }
}