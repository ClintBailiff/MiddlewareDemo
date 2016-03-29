**Visual Studio 2015 - ASP.NET 5 RC1**  
Standard ASP.NET 5 Template project (no authentication) with one custom middleware module added.

The custom middleware module simply displays the Request URL, Remote IP and Response Time of each request in the Output window.  It's real purpose is to demonstrate how to **create middleware**, **add middleware to the Http pipeline** and how to perform **dependency injection**.

To find pertinent areas of the code search for **_*POI_** (point of interest).  
There are three basic steps to creating middleware with dependency injection.  
To find the three steps in the code, search for **_*POI Step 1_**, **_*POI Step 2_** or **_*POI Step 3_**.

This example simplifies what is required to create custom middleware with dependency injection. At the time of this posting, there are only a few decent articles on the subject.  And most contain a bunch of unnecessary fluff and rarely even get to the basics of how (I believe) it should be done.

This is the first in a series of posts on ASP.NET 5/Core examples that I plan on creating.  I've worked through many issues porting an MVC 5 application to ASP.NET 5/Core and I thought there might be people out there who could benefit from the things I've learned.  Also, I want to have some examples for my own reference.

I hope this helps someone and any comments or suggestions are appreciated.
