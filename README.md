# Folk Village

## Thought Process
(Note: During the whole thought process the thought of creating modular systems and trying to follow design patterns for everything keeps kicking in)
- I started with the input and the input manager which is a Scriptable Object that can be attached to any Game Object that wants to listen for input.
- After that I created character movement. I wanted something simple so I went for Transform.Translate taking movement input and speed, normalized by deltatime as parameters at the beginning.
- Animated the base character sprite (without clothes/equipment) using Unity's built-in Animator & Blend trees for Idle & Walk animations in the 4 directions.
- Created an inventory and equipment system, yet again, from scratch. I wanted to consider item quantities and stackable items but I ended up scratching that in a future commit.
- Then, I thought how I could create animations for the clothes:
1. Store animation clips for each equipment item inside it according to direction , animation type (idle, walking, running, etc..)
2. Store frames/sprites for each direction and animation type in the item but update each equipment slot's renderer with those frames on equip using overriden animator controllers.
3. Store frames/sprites like in 2 but use a custom Animator and AnimationDetails SO which is a 3D array for each dimension (animation type, direction, frames).
After a LONG process of comparison and thinking, I picked the 3rd option.
- After finishing that part, I needed a break so I tinkered around with 2D lights and URP for a good looking scene
- Created inventory and equipment UI.
- I wanted to create a modular shop system with graphs for dialogue nodes but there was no time so I went for a simpler shop system with UI.
- Fixed some bugs
- Added audio
- Added Main Menu

## Controls
- Press W, A, S or D to move
- Press I to open inventory
- Click on items to equip or de-equip them
- Approach Shop Keeper to open the shop
- Click on items in the shop to buy them or click on your items to sell them
- Enjoy!

## Duration
This game was made in around 39-40 hours. </br>
<b> There are roughly 7-8 hours remaining but I will get some sleep then maybe if I have time I will try to clean code and polish the game more </b>

Thank you for reading!
