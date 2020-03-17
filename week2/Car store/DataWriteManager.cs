using Car_store.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car_store
{
    class DataWriteManager
    {
        public DataWriteManager() { }
        public DataWriteManager(bool emptyFile)
        {
            // Empty log file
            if(emptyFile && WriteDestination.destination == WriteDestination.Type.File)
            {
                Logger log = new Logger();
                log.EmptyFile();
                Console.WriteLine("All your data details stored in Log\\Logfile.log");
            }
        }

        public void WriteLine(string data, LogLevel level = LogLevel.INFO)
        {
            if(WriteDestination.destination == WriteDestination.Type.Console)
            {
                Console.WriteLine(data);
               
            } else if(WriteDestination.destination == WriteDestination.Type.File)
            {
                Logger log = new Logger();
                switch (level)
                {
                    case LogLevel.INFO:
                        log.Info(data);
                        break;
                    case LogLevel.DEBUG:
                        log.Debug(data);
                        break;
                    case LogLevel.WARNING:
                        log.Warning(data);
                        break;
                    case LogLevel.ERROR:
                        log.Error(data);
                        break;
                    case LogLevel.FATAL:
                        log.Fatal(data);
                        break;
                    default:
                        log.Info(data);
                        break;
                }
              
            }
        }

        public void ReadLine()
        {
            if (WriteDestination.destination == WriteDestination.Type.Console)
            {
                Console.ReadLine();
            }
        }
    }
}
