using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace SharedLib
{
    public sealed class Singleton
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private static volatile Singleton _instance;
        private static readonly object SyncRoot = new Object();

        private Singleton()
        {
            Log.Info("Created Singleton instance.");
        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new Singleton();
                    }
                }

                return _instance;
            }
        }
    }
}
