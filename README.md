# godot-bulletml-prototype

Small prototype using bulletml in godot based on BulletMLLib source found here: <https://github.com/dmanning23/BulletMLLib>

The original repository relies on the Microsoft Xna Framework. Here, this has been replace with godot native types (e.g. Vector2).

![Screen](/screenshots/bulletml.gif)
![Screen](/screenshots/screen1.png)
![Screen](/screenshots/screen2.png)
![Screen](/screenshots/screen3.png)
![Screen](/screenshots/screen4.png)
![Screen](/screenshots/screen5.png)

Use 'SPACE' to cycle through the bullet patterns.

Cursor keys to move the player.

Supports godot 4 and 3.5 (see branch) mono versions.

## Differences

Godot's default forward direction is positive along the X axis in 2D. The original library has bullets facing up i.e. zero (North) degrees, so an initial direction of 90 degrees (clockwise) would move the bullet along the positive X axis. In godot, an initial bullet direction of 90 degrees will move along the Y axis. Something to be wary of when writing patterns that have absolute directions.
