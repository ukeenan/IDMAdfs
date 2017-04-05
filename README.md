# IDMAdfs2016
Demo Identity Management Active Directory Federation System 2016

Prerequisites
-------------
* ADFS 2016.
* Clone the project to your VisualStudio.
* Manage Group Application for Native & WebApi
* Add Relaying Party Trusts for 2 Application C# Web Form & Web MVC 

Application Settings
------------ 
* -add key="ida:ADFSMetadata" value="adfs/FederationMetadata/2007-06/FederationMetadata.xml" />
* -add key="ida:Wtrealm" value="{urn:xxx:***}" /> 
* -add key="ida:Application" value="{Your Application Name}" />
* -add key="ida:ApiUser" value="{Api User}" />
* -add key="ida:ApiPassword" value="{Api Password}" />
* -add key="ida:ApiGrantType" value="password" />
* -add key="ida:ApiUrl" value="https://localhost:44331/" /> 

Source Contains
---------

1. C# WPF
2. C# Web Api
3. C# Web Form
4. C# Web MVC

Usage
-----

Open your VisualStudio and Clone this Project  

Reference
---------

1. https://technet.microsoft.com/en-us/windows-server-docs/identity/ad-fs/development/ad-fs-on-behalf-of-authentication-in-windows-server-2016
2. https://msdn.microsoft.com/en-us/library/bb897402.aspx
3. https://technet.microsoft.com/en-us/windows-server-docs/identity/ad-fs/development/enabling-openid-connect-with-ad-fs-2016
