VAR isGreen = false
VAR hp = 100


thing#variable_change:isGreen
-> main

=== main ===
Hello there! #speaker:Dr. Green #portrait:dr_green_neutral #layout:left
{ isGreen == true:-> Green  }
-> today



=== Green ===
Hey your colour, thats, thats my thing! #speaker:Dr. Green #portrait:dr_green_sad #layout:left
Anyway... #speaker:Dr. Green #portrait:dr_green_neutral #layout:left
-> today
=== today ===
How are you feeling today?
+ [Happy]
    That makes me feel <color=\#F8FF30>happy</color> as well! #portrait:dr_green_happy
+ [Sad]
    Oh, well that makes me <color=\#5B81FF>sad</color> too. #portrait:dr_green_sad
    
- Don't trust him, he's <b><color=\#FF1E35>not</color></b> a real doctor! #speaker:Ms. Yellow #portrait:ms_yellow_neutral #layout:right
-> Questions

=== Questions === 
Well, do you have any more questions? #speaker:Dr. Green #portrait:dr_green_neutral #layout:left
+ [Yes]
    -> Main1
+ [No]
    Goodbye then!
    -> END
    
=== Main1 ===
+ [Are you even a Doctor?]
    No

- I knew it !!! #speaker:Ms. Yellow #portrait:ms_yellow_happy #layout:right
- I had to put on this persona as a doctor to make money for my baby cubes  #speaker:Dr. Green #portrait:dr_green_sad #layout:left
- I know it wasnt the right thing but i had to do it for their sake #speaker:Dr. Green #portrait:dr_green_sad #layout:left
- I am sorry but now you must  <color=\#F8FF30> die</color> ..., <color=\#FF0000>you know too much</color> #speaker:Dr. Green #portrait:dr_green_sad #layout:left
- <color=\#FF0000>Game Over</color> #speaker: #portrait:default #layout:right
-> END