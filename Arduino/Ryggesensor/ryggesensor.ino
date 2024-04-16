#define trigger      2
#define  echo         3
#define beep        11
#define beep_start 100
#define min_distance  5
#define c 0.0343 // lyd (centimeter / mikrosekund)

long tempo;
float space;

void setup() {
  pinMode(trigger, OUTPUT);
  pinMode(echo,  INPUT);
  pinMode(beep, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  digitalWrite(trigger, LOW);
  delayMicroseconds(5);

  digitalWrite(trigger,  HIGH);
  delayMicroseconds(10);
  digitalWrite(trigger, LOW);
  tempo =  pulseIn(echo, HIGH) / 2;
  space  = tempo * c;
  Serial.println("Distanza  = " + String(space, 1) + " cm");
  if (space < beep_start) { 
    tone(beep, 1000); 
    delay(40); 
    if (space > min_distance)  {
      noTone(beep); 
      delay(space * 4);
    }
  } 
  delay(50);
}
