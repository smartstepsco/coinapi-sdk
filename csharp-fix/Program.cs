using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_fix
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                new CoinApi("73034021-0EBC-493D-8A00-E0F138111F41").twitter_last_data(5);
                //QuickFix.SessionSettings settings = new QuickFix.SessionSettings("config_ssl.cfg");
                //MarketDataApp application = new MarketDataApp();
                //QuickFix.IMessageStoreFactory storeFactory = new QuickFix.FileStoreFactory(settings);
                //QuickFix.ILogFactory logFactory = new QuickFix.ScreenLogFactory(settings);
                //QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(application, storeFactory, settings, logFactory);
                //initiator.Start();

                //System.Threading.Thread.Sleep(TimeSpan.MaxValue);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.ReadLine();
            }
            Environment.Exit(1);
        }
    }
}
