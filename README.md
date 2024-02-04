# GTA V Logitech Extreme 3D Pro Flight Stick Mod

Enables native use of the Logitech Extreme 3D Pro Joystick as a flight stick in GTA V. Doesn't emulate an XInput device but rather takes input directly from the joystick with DInput and sends instructions directly to the game. Most importantly, this enables analog yaw control, which can't be done emulating an Xbox 360 controller as far as I know. But it also means no dealing with x360ce.

## Requirements
* [ScriptHookV](http://www.dev-c.com/gtav/scripthookv/)
* [ScriptHookVDotNet](https://github.com/scripthookvdotnet/scripthookvdotnet/releases)
* [My fork of JoystickLibrary](https://github.com/eduardog3000/JoystickLibrary/releases) (thanks to [Wisconsin Robotics](https://www.wisconsinrobotics.org/) for [the original code](https://github.com/WisconsinRobotics/JoystickLibrary))

## Install
Install ScriptHookV and ScriptHookVDotNet per their instructions. Create a `scripts` folder in the game root if it doesn't already exist. Copy the file `dinput8.dll` provided by ScriptHookV into the `scripts` folder. Put `JoystickLibrarySharp.dll` and `FlightStick.dll` into the `scripts` folder.

## Controls
* Yaw - joystick Z Axis (twisting the joystick left/right)
* Pitch - joystick Y Axis (forward/back, flight controls so stick back = plane up)
* Roll - joystick X Axis (left/right)
* Throttle/Brake* - slider


* Trigger - attack
* Button 2 (thumb) - switch weapons
* Button 3 - retract/extend landing gear
* Button 4 - switch camera
* Button 5 - previous radio station
* Button 6 - next radio station
* Button 7 - cinematic camera
* Button 8 - leave vehicle
* Button 11 - *toggle slider between Throttle and Brake

All other buttons plus hat are unused. Feel free to suggest uses for them. I will make it all configurable if there's demand.

Using the slider for the throttle seemed right, but the solution for the brake is inelegant. I find myself still using A on the keyboard for the brake.

## Credits

* Creators of ScriptHookV, ScriptHookVDotNet, and JoystickLibrary as linked above
* [Niziul](https://github.com/Niziul-Grand-Theft-Auto-V-Mods) for his [Alternative Yaw Control](https://github.com/Niziul-Grand-Theft-Auto-V-Mods/alternative-yaw-control) and [Alternative Throttle Control](https://github.com/Niziul-Grand-Theft-Auto-V-Mods/alternative-throttle-control) mods, whose source code made me realize I could do this and helped me learn how to use ScriptHookVDotNet
