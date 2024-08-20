<br />

<p align="center">
  <a href="https://github.com/airar-dev/AIRAR-ColorMappingAR-UnitySample">
    <img src="http://airar.co.kr/ColorMapping/Img/logo_A_W.png" alt="Logo" width="80" height="80">
  </a>

  <h1 align="center"> ColorMappingAR Sample </h1>

  <p align="center"> <br />
    This project is a sample of the AIRAR-CM package. <br />
    This is a Unity project, and it uses ARFoundation. <br />
    It also supports URP. <br /><br />
    <a href="https://youtube.com/shorts/lYUXs7PsM3g?feature=shared" target="_blank">View Demo</a> <br /><br />
    
 <table align="center">
  <tr>
    <td>
      <a href="https://youtube.com/shorts/lYUXs7PsM3g?feature=share" rel="nofollow">
        <img src="http://airar.co.kr/ColorMapping/Img/Default/airar_cm_demo_2.gif" alt="demo">
      </a>
    </td>
  </tr>
</table>

<br />


## Table of Contents

* [Requirements](#requirements)
* [Quick Start](#quick-start)
* [Release](#release)
* [Contributing](#contributing)
* [Contact](#contact)

<br />


## Requirements

* Unity3D 2023.2.0f1
* ARFoundation 5.1.5v
<br />

## Quick Start

  **Create Android App Project Demo(https://youtu.be/pjDla8z-ORA?feature=shared)**<br />
  **Create iOS App Project Demo(https://youtu.be/lHyW9rD6I-Q?feature=shared)**<br /><br />
  
  **1. Download Sample Project.** <br /> <br />
  
  **2. Import AIRAR_CM Package(Will be distributed to the Asset Store in the future)** <br /> 
  -　Import files from the Plugins folder. <br /> <br />
  
  **3. Player Settings for Android**
  <table>
  <tr><td>Auto Graphics API</td><td>Disable</td></tr>
  <tr><td>Graphics APIs</td><td>Remove all, leaving only the 'OpenGLES3’</td></tr>
  <tr><td>Minimum API Level</td><td>Android 8.0 ‘Oreo’ (API level 26)</td></tr>
  <tr><td>Target Architectures</td><td>Enable ‘Arm64’ only</td></tr>
  <tr><td>Strip Engine Code</td><td>Disable</td></tr>
  <tr><td>XR Plug-in Management</td><td>Enable ‘Google ARCore’</td></tr>
  </table>
  <br />
  
  **4. Player Settings for iOS**
  <table>
  <tr><td>Strip Engine Code</td><td>Disable</td></tr>
  <tr><td>XR Plug-in Management</td><td>Enable ‘Apple ARKit’</td></tr>
  </table>
  <br />
  
  **5. Setting Up URP** <br /> 
  <table>
  <tr><td>Default Render Pipeline value of the Graphics option</td><td>Drag and drop 'Assets\AIRAR_CM\Rendering\New Universal Render Pipeline Asset.asset' file</td></tr>
  <tr><td>Render Pipeline Asset value of the Quality option</td><td>Drag and drop 'Assets\AIRAR_CM\Rendering\New Universal Render Pipeline Asset.asset' file</td></tr>
  </table>
  <br />

## Release
| Version | New Features | Date |
|:---:|---|:---:|
| v1.0.0 | [AIRAR-CM-Sample-v1.0.0-20240820](https://github.com/airar-dev/AIRAR-ColorMappingAR-UnitySample/releases/tag/1.0.0) | 2024.08.20 |

<br />

## Contributing

* Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are greatly appreciated. <br /><br />
　1.　Fork the Project. <br />
　2.　Create your Feature Branch. <br />
　3.　Commit your Changes. <br />
　4.　Push to the Branch. <br />
　5.　Open a Pull Request. <br />

<br />

## Contact
* oh@airar.co (sung hoon oh)

<br /><br />
