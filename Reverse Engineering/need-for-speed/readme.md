Need for Speed - 400 Points

This challenge sets a timer to exit the program before the flag is generated.

Our solution was to patch out the call to the alarm function with IDA. You could also use the bash trap command to suppress SIGALRM signals, or use LDPRELOAD to replace the SIGALRM handler.