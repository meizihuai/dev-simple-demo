using System;
using DevExpress.ExpressApp.Xpo;

namespace simple_demo.Blazor.Server.Services {
    public class XpoDataStoreProviderAccessor {
        public IXpoDataStoreProvider DataStoreProvider { get; set; }
    }
}
