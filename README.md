# robot-wars
Programming test for OpenTable

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
