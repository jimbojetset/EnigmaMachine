using System;
using System.Reflection;
using System.Windows.Forms;

namespace EnigmaMachine
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            string resource = "EnigmaMachine.Microsoft.VisualBasic.PowerPacks.Vs.dll";
            EmbeddedAssembly.Load(resource, "Microsoft.VisualBasic.PowerPacks.Vs.dll");
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EnigmaMachine());
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }
    }
}