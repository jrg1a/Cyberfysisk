#include <Wire.h>
#include <LiquidCrystal.h> 

// Definerer LCD pin tilkoblingene! 
const int lcdRSPin = 12;
const int lcdEnablePin = 11;
const int lcdD4Pin = 5;
const int lcdD5Pin = 4;
const int lcdD6Pin = 3;
const int lcdD7Pin = 2;

// Initialisering av LCD pinner
LiquidCrystal lcd(lcdRSPin, lcdEnablePin, lcdD4Pin, lcdD5Pin, lcdD6Pin, lcdD7Pin);

const int ledPin = 10; // LED pin
const int buzzerPin = 9; // Buzzer pin 

void setup() {
  Wire.begin(8); // Setter I2C mottaker-addresse til 8, NB: ADDRESSEN ER INVIDUELL OG UNIK FOR HVER ENKELT MOTTAKER, MÅ ENDRES PER ENHET!
  Wire.onReceive(receiveEvent); // Registrer "event handler" som handterere mottak

  // digitale ping for kontakt signal
  pinMode(ledPin, OUTPUT);
  pinMode(buzzerPin, OUTPUT);

  // setup
  Serial.begin(9600);
  Serial.println("Setup complete, ready to receive messages...");

  // Iinitialisere LCD-en
  lcd.begin(16, 2); // Setter 16 rekker og 2 rader
  lcd.clear(); // Fjerner tidligere meldinger
}

void loop() {
  // Tom loop, siden det er ingenting foregående her
}

void receiveEvent(int howMany) {
  char message[21]; // Karater-array for meldingen (+1 gir nullterminering)
  int index = 0;

  // Leser data fra I2C
  while (Wire.available()) {
    char c = Wire.read(); // leser av en char
    if (index < 20) { // forhindrer overflow 
      message[index++] = c; // legger til char til array
    }
  }

  message[index] = '\0'; // Null-terminering av denne meldingen

  // Displayer den mottate meldingen på LCD
  lcd.clear(); // Fjerner tidligere, slik det er klart for ny beksjed 
  lcd.setCursor(0, 0); // Setter cursor til starten
  lcd.print("Message:"); // Viser "Message:" label
  lcd.setCursor(0, 1); // Går til rad to (Cursor)
  lcd.print(message); // presenterer den mottatte meldingen på skjerm 

  // Logger meldingen til Serial Monitor
  Serial.print("Received message: ");
  Serial.println(message);

  if (strcmp(message, "RING") == 0) {
    // Lyser opp LED og spiller av buzzer lyden når "RING" er mottatt fra Master
    digitalWrite(ledPin, HIGH); // Skrur på LED lyset

    
    for (int i = 0; i < 5; i++) { // Buzzer sequence
      tone(buzzerPin, 580, 700); // Play a tone at 580 Hz for 700 ms Spiller av en tone på 580 HZ for 700 ms
      delay(700); // Venter på tonen skal ta slutt
    }
    delay(2000);
    digitalWrite(ledPin, LOW); // Skrur av LEDlyset 
  }
}
