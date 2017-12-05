namespace Lateetud.NServiceBus.Subscriber
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LateetudServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.LateetudService = new System.ServiceProcess.ServiceInstaller();
            // 
            // LateetudServiceProcessInstaller
            // 
            this.LateetudServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.LateetudServiceProcessInstaller.Password = null;
            this.LateetudServiceProcessInstaller.Username = null;
            // 
            // LateetudService
            // 
            this.LateetudService.Description = "LateetudService";
            this.LateetudService.ServiceName = "Lateetud";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.LateetudServiceProcessInstaller,
            this.LateetudService});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller LateetudServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller LateetudService;
    }
}