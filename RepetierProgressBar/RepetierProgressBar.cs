using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepetierHostExtender.interfaces;

namespace RepetierProgressBar
{
    public class RepetierProgressBar : IHostPlugin
    {
        IHost host;

        /// Called first to allow filling some lists. Host is not fully set up at that moment.
        public void PreInitalize(IHost _host)
        {
            host = _host;
        }

        /// Called after everything is initalized to finish parts, that rely on other initializations.
        /// Here you must create and register new Controls and Windows.
        public void PostInitialize()
        {

        }

        /// Last round of plugin calls. All controls exist, so now you may modify them to your wishes.
        public void FinializeInitialize()
        {
            host.ProgressChanged += Host_ProgressChanged;
        }

        private void Host_ProgressChanged(ProgressType pType, double value)
        {
            TaskbarProgress.SetValue(host.HostWindow.Handle, value, 100);
        }
    }
}
