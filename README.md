# SimpleLogger
A very basilar logger for .NET. It is possible to choose a filename for the log and the level of logging.

Installation: get the SimpleLogger.dll and add a reference to it.
In your class include the logger:

#C Sharp Example
    
    using SimpleLogger;
    
    // Create the logger
    Logger logger = new Logger(); // Will be create a file named "log.log"
    Logger logger = new Logger("HartManager.log");
    
    // Use it
    logger.log(Logger.LEVEL.ERROR, e.StackTrace);
