#include <Wire.h>

const int greenBtnPin = 2;  // Green button pin
const int blueBtnPin = 3;   // Blue button pin
const int whiteBtnPin = 4;  // White button pin
const int ledPinGreen = 9;  // LED - available
const int ledPinRed = 8;    // LED - occupied

unsigned long lastDebounceTime = 0;  // Last button state change time
unsigned long debounceDelay = 50;    // Debounce delay in milliseconds
bool lastGreenButtonState = HIGH;    // Last state of the green button
bool lastBlueButtonState = HIGH;     // Last state of the blue button
bool lastWhiteButtonState = HIGH;    // Last state of the white button
bool greenButtonPressed = false;     // Flag for the green button press
bool blueButtonPressed = false;      // Flag for the blue button press
bool whiteButtonPressed = false;     // Flag for the white button press

void setup() {
  Wire.begin(); // Start as I2C master
  Serial.begin(9600);
  pinMode(greenBtnPin, INPUT_PULLUP);
  pinMode(blueBtnPin, INPUT_PULLUP);
  pinMode(whiteBtnPin, INPUT_PULLUP);
  pinMode(ledPinGreen, OUTPUT);
  pinMode(ledPinRed, OUTPUT);
  digitalWrite(ledPinGreen, HIGH); // Initially indicate system is available
}

void loop() {
  static String messageBuffer;
  int readingGreen = digitalRead(greenBtnPin);
  int readingBlue = digitalRead(blueBtnPin);
  int readingWhite = digitalRead(whiteBtnPin);

  // Debounce and action logic for the green button
  if (readingGreen != lastGreenButtonState) {
    lastDebounceTime = millis();
  }
  if ((millis() - lastDebounceTime) > debounceDelay) {
    if (readingGreen == LOW && !greenButtonPressed) {
      greenButtonPressed = true;
      digitalWrite(ledPinRed, HIGH);
      digitalWrite(ledPinGreen, LOW);
      Wire.beginTransmission(8); // Address for the green button action
      Wire.write("RING\0");
      Wire.endTransmission();
      digitalWrite(ledPinRed, LOW);
      delay(100);
    } else if (readingGreen == HIGH) {
      greenButtonPressed = false;
    }
  }
  lastGreenButtonState = readingGreen;

  // Debounce and action logic for the blue button
  if (readingBlue != lastBlueButtonState) {
    lastDebounceTime = millis();
  }
  if ((millis() - lastDebounceTime) > debounceDelay) {
    if (readingBlue == LOW && !blueButtonPressed) {
      blueButtonPressed = true;
      digitalWrite(ledPinRed, HIGH);
      digitalWrite(ledPinGreen, LOW);
      Wire.beginTransmission(9); // Address for the blue button action
      Wire.write("RING\0");
      Wire.endTransmission();
      digitalWrite(ledPinRed, LOW);
      delay(100);
    } else if (readingBlue == HIGH) {
      blueButtonPressed = false;
    }
  }
  lastBlueButtonState = readingBlue;

  // Debounce and action logic for the white button
  if (readingWhite != lastWhiteButtonState) {
    lastDebounceTime = millis();
  }
  if ((millis() - lastDebounceTime) > debounceDelay) {
    if (readingWhite == LOW && !whiteButtonPressed) {
      whiteButtonPressed = true;
      digitalWrite(ledPinRed, HIGH);
      digitalWrite(ledPinGreen, LOW);
      Wire.beginTransmission(10); // Address for the white button action
      Wire.write("RING\0");
      Wire.endTransmission();
      digitalWrite(ledPinRed, LOW);
      delay(100);
    } else if (readingWhite == HIGH) {
      whiteButtonPressed = false;
    }
  }
  lastWhiteButtonState = readingWhite;

  // Handling serial input
  if (Serial.available()) {
    char receivedChar = Serial.read();
    if (receivedChar == '\n') {
      messageBuffer += '\0'; // Null-terminate the message
      Wire.beginTransmission(8); // Assuming address 8 for serial input, adjust as needed
      Wire.write(messageBuffer.c_str());
      Wire.endTransmission();
      messageBuffer = ""; // Clear buffer
      delay(100);
    } else {
      messageBuffer += receivedChar;
    }
  }
}
