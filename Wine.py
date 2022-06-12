from sense_hat import SenseHat
sense = SenseHat()
sense.clear()

green = (0, 255, 0)
red = (255, 0, 0)

while True:
  #Winetemp = sense.get_temperature()
  Winetemp = 5

  if Winetemp == 20:
    back_colour = green
  elif Winetemp >= 30: 
    sense.show_message("WARNING")
  elif Winetemp <= 10: 
    sense.show_message("WARNING")
  else:
    back_colour = red
    
  sense.clear(back_colour)
