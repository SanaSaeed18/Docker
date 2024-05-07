listensToMusic(mia). 
happy(yolanda).
playsAirGuitar(mia) :- listensToMusic(mia). 
playsAirGuitar(sana) :- listensToMusic(yolanda). 
listensToMusic(sana):- happy(yolanda).