Most likely another process is already using this port
Run the following command to find out which process:

   lsof -n -i4TCP:8081 

You can either shut down the other process:

   kill -9 <PID> 

