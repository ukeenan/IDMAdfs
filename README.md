# IDMAdfs2016OnPremise
Demo Identity Management Active Directory Federation System 2016 Premise

Prerequisites
-------------
* ADFS 2016.
* Clone the project to your VisualStudio.
* Manage Group Application for Native & WebApi
* Add Relaying Party Trusts for 2 Application C# Web Form & Web MVC 

Application Settings
------------ 
Find in each Application web.config
* &lt;add key="ida:ADFSMetadata" value="adfs/FederationMetadata/2007-06/FederationMetadata.xml" />
* &lt;add key="ida:Wtrealm" value="{urn:xxx:***}" />
* &lt;add key="ida:Application" value="{Your Application Name}" />
* &lt;add key="ida:ApiUser" value="{Api User}" />
* &lt;add key="ida:ApiPassword" value="{Api Password}" />
* &lt;add key="ida:ApiGrantType" value="password" />
* &lt;add key="ida:ApiUrl" value="https://localhost:44331/" />

Source Contains
---------
1. C# WPF
2. C# Web Api
3. C# Web Form
4. C# Web MVC

Usage
-----
Open your VisualStudio and Clone this Project  

ScreenShoot
-------

![alt text](https://github.com/ukeenan/IDMAdfs2016/blob/master/Administration%20ADFS%20ScreenShoot/Capture-1.PNG "Web MVC User Claims ")
 
![alt text](https://github.com/ukeenan/IDMAdfs2016/blob/master/Administration%20ADFS%20ScreenShoot/Capture-4.PNG "Get Token Web MVC")

 
![alt text](https://github.com/ukeenan/IDMAdfs2016/blob/master/Administration%20ADFS%20ScreenShoot/Capture-3.PNG "Web Form User Claims ")
 
![alt text](https://github.com/ukeenan/IDMAdfs2016/blob/master/Administration%20ADFS%20ScreenShoot/Capture-2.png "Get Token Web Form")


![alt text](https://github.com/ukeenan/IDMAdfs2016/blob/master/Administration%20ADFS%20ScreenShoot/Capture-5.PNG "WPF Retun Value")


Reference
---------
1. What's new in Active Directory Federation Services for Windows Server 2016 https://technet.microsoft.com/en-us/windows-server-docs/identity/ad-fs/development/ad-fs-on-behalf-of-authentication-in-windows-server-2016
2. About Active Directory Federation Services https://msdn.microsoft.com/en-us/library/bb897402.aspx
3. Create an Application Group in AD FS 2016  https://technet.microsoft.com/en-us/windows-server-docs/identity/ad-fs/development/enabling-openid-connect-with-ad-fs-2016
