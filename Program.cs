using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ny4rlk0IdleBrowser
{
    internal static class Program
    {
        public static Process PriorProcess()
        // Returns a System.Diagnostics.Process pointing to
        // a pre-existing process with the same name as the
        // current one, if any; or null if the current process
        // is unique.
        {
            try
            {
                Process curr = Process.GetCurrentProcess();
                Process[] procs = Process.GetProcessesByName(curr.ProcessName);
                foreach (Process p in procs)
                {
                    if ((p.Id != curr.Id) &&
                        (p.MainModule.FileName == curr.MainModule.FileName))
                        return p;
                }
                return null;
            }
            catch (Exception) { return null; }

        }
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //if (PriorProcess() != null) {MessageBox.Show("Programın birden fazla kopyasını aynı anda çalıştırmayın!\nBunun yerine kullanıcı adlarını toplu olarak her kullanıcı adı şifresine karşılık gelecek şekilde program arayüzüne ekleyin!"); Environment.Exit(0); }//Aynı uygulama zaten çalışıyorsa yeniden başlamayalım.
            Application.Run(new logic());
        }
    }
}
