# AppCenter Test Task

## Description
C# console application which receives list of branches from appcenter for the app and builds it.
Output is printed in following format:

    <branch> build <status> in <time> seconds. Link to build logs: <link>

Note does not take into queue time and calculate only real build time 

## Getting Started
- Build application and run it
- Pass all required params:
  - application name
  - owner name
  - app token

## TODO:
- Use client APIs generators instead of writing client/models by self
- Tests
- Timeouts
