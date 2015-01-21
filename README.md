# robot-wars
Programming test for OpenTable





















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
- De-couple some of the elements? Robot newing up the heading object for example - feels ok in a small example, but decoupling it for testing feels better

###Thoughts
- There is still no interaction/awareness between the robots - feels like we're missing something here (perhaps an opportunity for the overall game to play a part)
- Would events help us here (perhaps in decoupling the knowledge of the board from the robot) - a RobotWarsGame handling and firing events when robots change state may be appropriate



##V0.0.1
###Overall
- starting to think about the overall mapping between the game, the arena and the robot

###Robot
- starting to look at the concept of the robot's heading (as it's own encapsulated set of logic)
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
