
// This file was generated automatically for the PocketBase Application Acme (http://localhost:8090)
//    See CodeGenerationSummary.txt for more details
//
// PocketBaseClient-csharp project: https://github.com/iluvadev/PocketBaseClient-csharp
// Issues: https://github.com/iluvadev/PocketBaseClient-csharp/issues
// License (MIT): https://github.com/iluvadev/PocketBaseClient-csharp/blob/main/LICENSE
//
// pocketbase-csharp-sdk project: https://github.com/PRCV1/pocketbase-csharp-sdk 
// pocketbase project: https://github.com/pocketbase/pocketbase

using PocketBaseClient.BlazorPocket.Services;

namespace PocketBaseClient.BlazorPocket
{
    public partial class BlazorPocketApplication : PocketBaseClientApplication
    {
        private AppDataService? _Data = null;
        /// <summary> Access to Data for Application Acme </summary>
        public AppDataService Data { get=> _Data??new AppDataService(this); }

        private AppAuthService? _Auth = null;
        /// <summary> Access to Auth for Application Acme </summary>
        public new AppAuthService Auth { get => _Auth??new AppAuthService(this); }

        #region Constructors
        public BlazorPocketApplication() : this("http://localhost:8090")
        {
            if (_Data is null)
            {
                _Data = new AppDataService(this);
            }
            if (_Auth is null)
            {
                _Auth = new AppAuthService(this);
            }
        }
        public BlazorPocketApplication(string url, string appName = "BlazorPocketApp") : base(url, appName)
        {
            if (_Data is null)
            {
                _Data = new AppDataService(this);
            }
            if (_Auth is null)
            {
                _Auth = new AppAuthService(this);
            }
        }
        #endregion Constructors
    }
}
