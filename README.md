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
    "many": [
      {
        "Id": 1,
        "Name": "many1"
      },
      {
        "Id": 2,
        "Name": "many2"
      },
      {
        "Id": 3,
        "Name": "many3"
      }
    ]
  }
}
```
In dirrectory root folder you are need create file ```routes.json```, in which to prescribe the routes.

#### You are can write in url comparison operators. 
Just write on url query e.g.: ```localhost/getObjects/many?Id>=2``` and the answer will be one object from array (see example): 
``` JSON
{
  "Id": 2,
  "Name": "many2"
},
{
  "Id": 3,
  "Name": "many3"
}
```

#### Version 1.2.1 plan:
- Add filter in query by dictionary
