### Hello World, Welcome to the...

# Outlook Signature Tool
An easy way for Organizations to deploy a standardized signature in Outlook. 

## How to deploy this tool in your organization
1) Download the Outlook Signature Tool to some shared location. 
2) Create a folder named 'Templates'.  
3) In Outlook, create a signature. For user fillable fields you want to create, like Full Name and Phone Number, encapsulate these with {* and *}.  Example: {*Full Name*}  
4) When creating a signature (like above) it will create three files and a folder. Navigate to %AppData%\Microsoft\Signatures and grab these three files and folder and copy them into the 'Templates' folder you created above.
5) Congratulations! You just created your first template. 

## How do end users use the tool.
1) End users just need to run the executable - usually from a shared drive or network path.
2) Select the template they want to use. (if there is more than one)
3) Fill-in their information and preview it.
4) Push the "Apply to Outlook" button at the bottom.

## Past issues:
 - images do not display in the preview window (resolved 6-7-2018)
 - When the user clicks "Apply to Outlook" there is a pause. A "Please Wait..." needs to be added.
 
## Current issues / To-Do
(none known at this time)
 
## Screenshots
[![N|Solid](https://raw.githubusercontent.com/SunsetQuest/OutlookSignatureTool/master/Other/Screenshot.Main.png)](https://github.com/SunsetQuest/OutlookSignatureTool)

# Licensed under the MIT License.
