# SimpleLogger
A very basilar logger for .NET. It is possible to choose a filename for the log and the level of logging message.

Installation: extract the archive SimpleLogger_binary.zip and put the SimpleLogger.dll in your project then add a reference to it.

###C Sharp Example
In your class include the logger:

    using SimpleLogger;
    
    // Create the logger without a file name (Will be create a file named "log.log")...
    Logger logger = new Logger();
    // ...or specify a filename
    Logger logger = new Logger("HartManager.log");
    
    // Use it
    logger.log(Logger.LEVEL.ERROR, e.StackTrace);
