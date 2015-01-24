# robot-wars
Programming test for OpenTable


- Next branches
	- arena/game interaction, and tracking the location of the robots on the arena


##v0.0.4 - Robots now take each move in turn
- Slight refactoring to allow robots to make a single move at a time
- Makes it easier to have all robots move in parallel (if that's where the spec took it)

####TODO
- Use the IInputRenderer, IOutputRenderer in the DataCollection classes
- Investigate ways we can make the robot less dependent upon the knowledge of the arena bounds 
- Make each robot take their turns 'in turn' rather than a robot go through it's full set of moves
- Need to clarify what the role of the RobotWarsGame is - I think it's a little superfluous at the moment


####FUTURE
- Robots running in parallel 
- Non-zero based grids
- Full support of non-rectangular arena's (would need solid point checking against inside/outside of polygon)
- Collision detection/awareness between the robots
- Events based notifications
- Z axis? ;)


> **NOTE** From this point up over, we're into 'funsies' category - v0.0.3 delivers on the basic spec
> as a developer I'd want to do a lot more with it



##v0.0.3 - First version complete as per spec
- Console input now supported
- Validation against inputs in place
- Abstraction of some of the domain to better deliver SRP and keep the concerns simple
- Arena is now a more fixed 'bottom left', 'top right' approach than what I'd had up until here

####TODO
- Use the IInputRenderer, IOutputRenderer in the DataCollection classes
- Investigate ways we can make the robot less dependent upon the knowledge of the arena bounds 
- Make each robot take their turns 'in turn' rather than a robot go through it's full set of moves
- Need to clarify what the role of the RobotWarsGame is - I think it's a little superfluous at the moment


####FUTURE
- Robots running in parallel 
- Non-zero based grids
- Full support of non-rectangular arena's (would need solid point checking against inside/outside of polygon)
- Collision detection/awareness between the robots
- Events based notifications
- Z axis? ;)







##V0.0.2
- First full run through where both robots (hard coded in startup) play through to their natural conclusion
- Up to 20 unit tests now

###TODO
- Still masses - don't like the way the robot is dependent upon the arena to know whether it can move there
- Need to test what happens when a robot attempts to move outside the bounds of the arena
- Need to accept user input during startup rather than hard coding values
- Need to work out the role of the 'RobotWarsGame' - it feels like I should have something that maintains state of where each robot is at each time
- What about robots moving in parallel (or at least taking each of their moves in turn - first move for all robots, second move for all robots, etc.)
- Bounds checking on the arena is clunky - the maths on the internet to look at points falling within a polygon seems to require a longer beard than I posses (read: maths)
- De-couple some of the elements? Robot newing up the orientation object for example - feels ok in a small example, but decoupling it for testing feels better

###Thoughts
- There is still no interaction/awareness between the robots - feels like we're missing something here (perhaps an opportunity for the overall game to play a part)
- Would events help us here (perhaps in decoupling the knowledge of the board from the robot) - a RobotWarsGame handling and firing events when robots change state may be appropriate



##V0.0.1
###Overall
- starting to think about the overall mapping between the game, the arena and the robot

###Robot
- starting to look at the concept of the robot's orientation (as it's own encapsulated set of logic)
- thinking about the set of moves a robot will perform (and indeed how)
- at the moment, still unclear on how asking the robot to move is going to interact with the arena (the robot is aware of the size of the arena, though this feels like a dependency that I would rather avoid

###TODO
- loads
- accept input as per the spec (all values are hard coded at the moment)
- solidify thinking on all of the above
- more testing

###Thoughts
- how does 'movement' happen? movement is very much the interaction between the robot and the arena - the two are symbiotic (e.g. moving outside of the bounds of the arena)
- collision detection?
