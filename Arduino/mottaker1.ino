#include <Wire.h>

const int ledPin = 11; // LED
const int buzzerPin = 3; // Buzzer

void setup() {
  Wire.begin(8); // Start som I2C slave med adresse 8
  Wire.onReceive(receiveEvent);
  pinMode(ledPin, OUTPUT);
  pinMode(buzzerPin, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  //Tom loop ettersom det ikke er behov for noe.
}

void receiveEvent(int howMany) {
  String message = "";

  while (Wire.available()) {
    char c = Wire.read();
    message += c;
    if (c == '\0') {
      break; // Avslutt på null-terminering
    }
  }

  if (message == "RING") {
    tone(buzzerPin, 750, 300); // Aktiver buzzer
    tone(buzzerPin, 750, 300); // Aktiver buzzer
    tone(buzzerPin, 750, 300); // Aktiver buzzer
    tone(buzzerPin, 750, 300); // Aktiver buzzer
    tone(buzzerPin, 750, 300); // Aktiver buzzer

    digitalWrite(ledPin, HIGH);
    delay(1000);
    digitalWrite(ledPin, LOW);
    
  } 
  else {
    Serial.println(message); // Skriv melding til serial
  }
}
