# Battle Tank

Battle Tank is a Unity 3D Game that I have made to learn various Design patterns. I have also followed the best principles and practices to make the code more readable, manageable, and scalable.

<img src= "https://i.imgur.com/d3PAvTi.png">

[Click Here](https://vik7am.itch.io/battle-tank) to play WebGL Build.

### Design Patterns Used
1. Model View Controller - MVC is used for Bullets, Enemy Tanks, and Player Tanks to increase the scalability of the game.
2. Observer Pattern - Used Observer Pattern in Achievement System to avoid spaghetti code.
3. Singleton - Added Singleton classes to create Services
4. Object Pooling - Object Pooling is used in Enemy Tanks, Bullets, and Particle Effects to improve performance by creating a pool of game objects and reusing them instead of destroying them. 
5. State Machine - Used in Enemy Tanks to easily switch between different states.

### Features
1. Different Types of Tanks and Bullets - Scriptable Objects are used to make the process of adding variations to tanks and bullets like speed, damage, and color.
2. Virtual Joystick/Keyboard Inputs - This game supports both keyboard and Virtual Joystick for Inputs and can be easily switched from the main menu.
3. Random Enemy Spawn - Enemy spawns at random locations within the playable area.
4. Enemy AI- Enemy uses NavMesh to find random destinations to patrol. Enemy tanks can detect player tanks and chase them around the map. They also shoot at the player when the player is within their shooting range.
5. Score and Health UI - Events are used to update the UI elements and the player's health and score.

### Best Practices Used
1. Proper naming convention for methods and variables.
2. Proper use of abstract class and interface for abstraction.
3. Following the single responsibility principle.
4. Caching data to reduce function calls.
5. Enums to improve code readability.
6. Generic classes to reduce code repetition.
7. Used Extension functions to increase the functionality of the existing class.
