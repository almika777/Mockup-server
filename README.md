# Mockup server (net core 3.1)

This is easy hosting mockup server.

## Application configuration (appsettings.ApplicationConfig)
ApplicationMode: 
- File (all routes in one file)
- Files (one route one file)
- Dirrectory (one route on dirrectory, endpoint is file)

PathToRootFolder: Path to your root folder with routes (```"C:\\MockServerRootFolder"```).

## Route file example
### File Mode
``` JSON
{
  "getObjects": {
    "1": {
      "Id": 1,
      "Name": "testObject1"
    },
    "2": {
      "Id": 2,
      "Name": "testObject2"
    }
  }
}
```
