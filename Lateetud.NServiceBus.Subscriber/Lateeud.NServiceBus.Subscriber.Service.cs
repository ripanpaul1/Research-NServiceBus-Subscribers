using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Lateetud.NServiceBus.Subscriber
{
    partial class Lateetud : ServiceBase
    {
        public Lateetud()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Program program = new Program();
            program.ServiceConfig();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        public void debug()
        {
            OnStart(null);
        }
    }
}
