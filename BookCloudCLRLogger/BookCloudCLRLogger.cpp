#include "pch.h"

#include "BookCloudCLRLogger.h"

void BookCloudCLRLogger::BookCloudLogger::Logger(String^% string)
{
	Console::WriteLine("BookCloudLogger::" + string);
}