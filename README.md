### Hello World, Welcome to the...

# Outlook Signature Tool
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

## Current issues / To-Do
 - When the user clicks "Apply to Outlook" there is a pause. A "Please Wait..." needs to be added.
 
## Screenshots
[![N|Solid](https://raw.githubusercontent.com/SunsetQuest/OutlookSignatureTool/master/OutlookSignatureTool/Docs/Screenshot.Main.2018-6-7.png)](https://github.com/SunsetQuest/OutlookSignatureTool)

## Licensed under the MIT License: 
> The MIT License
> 
> Copyright (c) 2018 Ryan S. White
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy
> of this software and associated documentation files (the "Software"), to deal
> in the Software without restriction, including without limitation the rights
> to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
> copies of the Software, and to permit persons to whom the Software is
> furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in
> all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
> IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
> FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
> AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
> LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
> OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
> THE SOFTWARE.
