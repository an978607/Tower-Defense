The Map00a scene is meant for map testing, and will change constantly as a result
We will not have Map00 as a playable map, reasoning is above

If absolutely needed, another scene can be created if testing multiple maps at
the same time. Naming convention should be Map00(a-z), where a-z is which
number of map is being tested. Map00a, then Map00b, and so on.

Try to keep the amount of testing maps to a minimum, as too many projects at
once can easily slow down production

Map 1:
    Description: Not too complex. 
    Enemies: 5 farmers with 1 second in between

Map 2:
    Description: 2 waves introducing all types. Map has a little more looping
    Enemies: 2 equivalent waves split by 3 seconds
        Wave 1: 2 farmers (F), 1 enraged farmer (EF), 1 farmer w/ tractor (FT)
        Wave 2: Same as above

Map 3:
    Description: Even more looping. Long and slow.
    Enemies: 3 waves split by 3 seconds.
        Wave 1: 2 FT, 1 EF
        Wave 2: 1 FT, 2 EF
        Wave 3: 5 F 1 EF

Map 4:
<!--
    Description: Less looping, more fast-paced
    Enemies: 3 waves split by 2 seconds
        Wave 1: 2 FT, 1 EF (3)
        Wave 2: 3 EF, 1 FT, 3 F (7)
        Wave 3: 3 subwaves split by 1 seconds
            Each subwave consists of 1 FT, 1 F, 1 EF (9)
-->

    **19 enemies as specified in the file**
        
Map 5:
<!--
    Description: Lots of loops but lots of enemies too.
    Enemies: 5 Waves split by 5 seconds, some waves have subwaves
        Wave 1: 15 farmers (sets of 5 split by 1 second) (total: 15)
        Wave 2: 3 subwaves consisting of 2 smaller subwaves of (1 T, 1 EF, 1 F) split by 1 second.(total: 3*(2*3) = 18)
        Wave 3: 5 subwaves, each with 1 tractor and 2 EF (total: 5*3 = 15)
            Ex: 1 tractor comes out followed quickly by 2 enraged farmers, wait 1 second, and the next subwave comes.
        Wave 4: Repeat wave 2, wait 5 seconds, and then launch 10 enraged farmers (total: 18 + 10 = 28)
        Wave 5: 5 subwaves, each consisting of 2 FT, 5 F, 2 EF. Each subwave is split by 3 seconds. (total: 5*9 = 45)
-->
        
        
    map 4 but also more (18 more to be exact) 

