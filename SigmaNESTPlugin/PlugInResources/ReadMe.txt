This plugin template includes a convention based approach to embedding Win32 resources as a compilation task. 
Because of this there is no longer a need to create and include a compiled resource script (e.g. “PlugInResourcesFile.res”) in your project. 
Simply place the resources in the included project directory called “PlugInResources”. 

Within this directory can be the following optional files: 
•	“PlugInICON.png” – This resource can be included to dictate the Icon for your plugin.
•	“PlugInINIFile.ini” – This resource can be included to define a default config ini file.
•	“PlugInXMLFile.xml” – This resource can be included to define a default config xml file.
