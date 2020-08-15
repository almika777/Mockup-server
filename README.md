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
    },
    "many": {
      "1": {
        "Id": 1,
        "Name": "many1"
      },
      "2": {
        "Id": 1,
        "Name": "many2"
      }
    }
  }
}
```
In dirrectory root folder you are need create file ```routes.json```, in which to prescribe the routes.

#### File mode support unlimited nesting (from version 1.1.0)
