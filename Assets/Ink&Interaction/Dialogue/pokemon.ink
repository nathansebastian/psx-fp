Welcome, Welcome #speaker:Ms. Yellow #portrait:ms_yellow_neutral #layout:right

Which pokemon do you choose? #speaker:Ms. Yellow #portrait:ms_yellow_neutral #layout:right
    + [Charmander]#colour:red
        -> chosen("Charmander")
    + [Bulbasaur]#colour:green
        -> chosen("Bulbasaur")
    + [Squirtle]#colour:blue
        -> chosen("Squirtle")
        
=== chosen(pokemon) ===
You chose {pokemon}!
And this {pokemon} sucks arse ahaha
-> Question_Why

=== Question_Why ===
Pardon my French*cough* *cough*
Would you care to explain why you chose that pokemon?
    +[They look cute!]
        -> Response("they look cute")
    +[I really just vibe with them]
        -> Response("I really just vibe with them")
    +[Why do you care?]
        -> AvoidQuestion
    
    
=== Response(reason) === 
I see ... it's because "{reason}"
-> END
=== AvoidQuestion ===
How rude *Hmph* , I just happened to be curious 
-> END