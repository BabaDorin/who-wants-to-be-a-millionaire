# WHO WANTS TO BE A MILLIONAIRE
It is a WPF App which comes to replicate the real WWTBM game.
#### Note: I've built this project just to get comfortable with WPF (.NET Core 3.1) and MVVM pattern.

## Administration
Password for accessing the administration panel is 'admin'. (I'll add a config file later, maybe) 

## Features
* Operates with an unlimited number of questions
* Questions can be assigned with various difficulty levels
  * Easy
  * Medium
  * Hard
  * Einstein
* Questions' difficulty level increases as you progress through the game
* CRUD operations on questions can be performed directly to the XML files or via administration panel
* Game results are stored in a .XML file 
* GUI relates to the real WWTBAM game
* Three LifeLines
  * 50/50
  * Ask Audience
  * Call a friend
* LifeLines efficiency decreases with the increasing of questions' difficulty level
* Plays native WWTBAM sounds (Can be turned off)

## Weaknesses
* Stores and retrieves data from .XML files (Might switch to MongoDB later idk)
* Little bugs here and there
* No configuration file

## Lilbit of overview

![](https://i.ibb.co/vVm5v0h/image-2021-01-24-004157.png)

![](https://i.ibb.co/RYTWHV1/image-2021-01-24-004424.png)

## I didn't know how to name this section
Please be gentle to it ;) It's has not been properly tested yet. Feel free to open Issues if you found a bug or smth.

