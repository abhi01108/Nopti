**Nopti**
==
**Made with Unity**
---------------

Unity is a game engine used to development 2d and 3d games. It has 2 render pipelines : HDRP and URP
High Definition Render Pipeline and Universal Render Pipeline.

`Character Controller:`

The Character Controller is an object component through which an object can be translated in the Global environment or Local Environment.
It obeys all physics has various functionalitites. The Player Movement Script is what controls the player body and physics.
The Camera Script controlls the camera and provides rotation with mouse movement integrated to the player.

`Gun Mechanics:`

Unity's Raycast is what makes bullets hit an object and the hit variable returns the properties of the object that has been hit.
The raycast property is inscribed to the center of the screen (the point where the crosshair points) and the rays are going to travel in that direction.
Once the object is hit, the hit variable stores the hit info and other properties and based on that and if the object has the target script as a component, the object will be destroyed and the particle system plays.

`Weapon Swithcing:`

The Weapon Holder is what is responsible for weapon swithching. Based on the scroll value of the mouse's scrollbar, the current weapon is selected. If the current weapon value is 0 the first child of the weapon holder will be selected, if the current weapon value is set to 1, the second gun(second child) will be selected and so on. Based on the current ammo the gun behaves to the reload function.