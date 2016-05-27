# SimpleLogger
A very basilar logger for .NET. It is possible to choose a filename for the log and the level of logging message.

Installation: extract the archive SimpleLogger_binary.zip and put the SimpleLogger.dll in your project then add a reference to it.

###C Sharp Example
In your class include the logger:

    **using SimpleLogger;**
    
    // Create the logger without a file name (Will be create a file named "log.log")...
    '''csharp
    **Logger logger = new Logger();**
    
    // ...or specify a filename
    **Logger logger = new Logger("HartManager.log");**
    
    // OPTIONAL: Set the log level (Remember: CRITICAL < ERROR < WARNING < INFO < VERBOSE)
    // so if you set the level to WARNING, you will have in the log the CRITICAL, ERROR and WARNING
    // if you set the level to CRITICAL, you will have only CRITICAL in the log
    // Default value is VERBOSE
    **logger.setLoggingLevel(Logger.LEVEL.INFO);**

    // Use it
    **logger.log(Logger.LEVEL.ERROR, e.StackTrace);**

####OUTPUT EXAMPLE
    00001|2016-05-27|12:17:34:7126|Information|Arbitration Start
    00002|2016-05-27|12:17:34:7686|Information|setTRASMIT_REQUEST at 16
    00003|2016-05-27|12:17:35:0326|Verbose|8 13
    00004|2016-05-27|12:17:35:1796|Verbose|13 14
    00005|2016-05-27|12:17:35:4066|Information|ENABLE.Indicate - ACK | STX | OACK | USING
    00006|2016-05-27|12:17:35:8016|Verbose|14 16
