# LoginPortal
An Application for Daily Log in rewards in Guild Wars 2 on multiple accounts. Implemented using Model, View, Controller setup for practice and ease of implementation.

#Compiling LoginPortal
To start go to the project folder and remove my handywork to get a working certificate. This will more likely than not be fixed next push.
navigate to Login>Login>Login.csproj
you need to edit this file so get out your favorite text editor and open it up.
within the Login.csproj remove the following lines:

'''xml
<PropertyGroup>
   <ManifestCertificateThumbprint>...........</ManifestCertificateThumbprint>
</PropertyGroup>
<PropertyGroup>
   <ManifestKeyFile>xxxxxxxx.pfx</ManifestKeyFile>
</PropertyGroup>
<PropertyGroup>
   <GenerateManifests>true</GenerateManifests>
</PropertyGroup>
<PropertyGroup>
   <SignManifests>false</SignManifests>
</PropertyGroup>
'''
Once those lines have been removed the only thing that should be stopping you from compiling are two missing libraries: IWishRuntimeLibrary and WindowsInput
