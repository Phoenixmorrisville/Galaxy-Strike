What is the difference between an Action Map and an Input Action?

An Action Map is a group of related controls, such as the Player map. An Input Action is one individual control inside that map, such as Move, Look, or Attack.


Why do Move and Look both use Vector2, even though the game is 3D?

They each need two input values. Move uses X and Y movement input, while Look uses horizontal and vertical aiming input.


Which line or method prevents the ship or turret from moving beyond its allowed range?

Mathf.Clamp() prevents the values from going below the minimum or above the maximum.


What did Mathf.Lerp() improve in your scenario?

Mathf.Lerp() made the aiming movement smoother by gradually moving from the current angle toward the target angle instead of instantly snapping to it.
