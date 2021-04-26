# SK-MobileAP-XR
This github repository contains both AR and VR

How to install Unity.
- Go to Unity’s Download Page "https://store.unity.com/download" and click “Download Installer for Windows”. A UnityDownloadAssistant-x.x.exe file should be downloaded to your “Downloads” folder (where x.x is the current Unity version).
- Open the downloaded installer
- Accept the license and terms and click Next.
- Select the components you would like to be installed with Unity and click “Next”. Note: If you ever want to change the components, you can re-run the installer.
- You can change where you want Unity installed, or leave the default option and click “Next”.
- Depending on the components you selected, you may see additional prompts before installing. Follow the prompts and click “Install”. Installing Unity may take some time. After the installation is finished, Unity will be installed on your computer.

How to install vuforia in your unity file:

- The Vuforia Engine will be visible in the GameObject Menu. 

If this menu is not shown, this means that you did not install Vuforia with Unity (Unity versions before 2019.2) or did not add the Vuforia Engine package to your project (Unity 2019.2 and later).

- Start by adding an ARCamera. This is a Unity camera game object that includes the VuforiaBehaviour to add support for augmented reality apps for both handheld devices and digital eyewear. 

Add an ARCamera GameObject from the Vuforia Engine menu. 
Select the ARCamera and Open Vuforia Configuration from the Inspector
Add a Vuforia Development License Key in the App License Key field. For a guide on getting a license key, see Vuforia License Manager

Note: Delete the default Main Camera after adding an ARCamera. The ARCamera contains its own Camera component. The Main Camera is not needed unless you are using it to render a specific camera overlay, e.g. user interface.

Vuforia: How to add image tracking feature.

- After activating Vuforia Engine in Unity, you can add features from the Vuforia Engine menu to your project from the Unity GameObject Menu. 
- Navigate to the Vuforia Engine Menu and select Image Target. or any of the other targets you wish to use. (VuMark, Ground Plane, and Mid Air are also trackable targets).
For configurations for using other targets, please consult the Features Overview linked just above. It presents Unity guides for each Vuforia target. 


Each Vuforia Engine GameObject can be configured in the Inspector.  When a target is added, it will appear in the Hierarchy. 

Select the Image Target GameObject from the Hierarchy and choose from the Type dropdown either
From database – Image Target databases can be made in the Vuforia Target Manager. Targets to the project. Vuforia will therefore ask you if you wish to Import Default Image Target Database in a pop-up window.

Press Import. 
Note: Maintain an accurate scale between the Vuforia targets and physical prints or objects. Using targets that deviate in size from the real-life object you wish to track might impact the quality.
