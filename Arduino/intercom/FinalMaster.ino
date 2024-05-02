#include <Wire.h>

String readString; // For å lese fra serial
byte I2C_OnOff; // Lagrer tilstand til å sende via I2C
const int greenBtnPin = 2;
const int blueBtnPin = 3;
const int whiteBtnPin = 4;
const int ledPinGreen = 9;
const int ledPinRed = 8;
const int recipientAddresses[] = {8, 9, 10};
const int numRecipients = sizeof(recipientAddresses) / sizeof(recipientAddresses[0]);

unsigned long lastDebounceTime = 0;
unsigned long debounceDelay = 50;

bool lastGreenButtonState = HIGH;
bool lastBlueButtonState = HIGH;
bool lastWhiteButtonState = HIGH;

bool greenButtonPressed = false;
bool blueButtonPressed = false;
bool whiteButtonPressed = false;

void setup() {
  Wire.begin(); // Start som I2C master
  Serial.begin(9600);
  Serial.println("Type 'BlueOn' to turn on the Blue LED and 'BlueOff' to turn it off!");
  Serial.println("Type 'YellowOn' to turn on the Yellow LED and 'YellowOff' to turn it off!");
  Serial.println("Type 'RedOn' to turn on the Red LED and 'RedOff' to turn it off!");

  pinMode(greenBtnPin, INPUT_PULLUP);
  pinMode(blueBtnPin, INPUT_PULLUP);
  pinMode(whiteBtnPin, INPUT_PULLUP);
  pinMode(ledPinGreen, OUTPUT);
  pinMode(ledPinRed, OUTPUT);
  digitalWrite(ledPinGreen, HIGH);
}

void loop() {
  if (Serial.available()) {
    delay(2);
    char c = Serial.read();
    if (c == '\n') {
      handleSerialCommand(readString);
      readString = ""; // Reset readString after handling
    } else {
      readString += c;
    }
  }

  checkButton(greenBtnPin, 8, &lastGreenButtonState, &greenButtonPressed);
  checkButton(blueBtnPin, 9, &lastBlueButtonState, &blueButtonPressed);
  checkButton(whiteBtnPin, 10, &lastWhiteButtonState, &whiteButtonPressed);
}

void handleSerialCommand(String command) {
  command.toLowerCase(); // Convert command to lower case
  Serial.println(command); // Echo command back to Serial Monitor

  int address = 0;
  String message = ""; // Create a string for the message instead of a boolean state

  if (command.startsWith("blue")) {
    address = 10;
    message = command.substring(4); // Get the remainder of the command after "blue"
  } else if (command.startsWith("yellow")) {
    address = 9;
    message = command.substring(6); // Get the remainder of the command after "yellow"
  } else if (command.startsWith("red")) {
    address = 8;
    message = command.substring(3); // Get the remainder of the command after "red"
  }

  if (address != 0) {
    Wire.beginTransmission(address);
    // Instead of writing a binary state, we will send the message as a string
    for (int i = 0; i < message.length(); i++) {
      Wire.write(message[i]); // Send each character of the message
    }
    Wire.endTransmission();
  }
}


void checkButton(int buttonPin, int address, bool *lastButtonState, bool *buttonPressed) {
  bool currentButtonState = digitalRead(buttonPin) == LOW;  // LOW when button is pressed

  if (currentButtonState != *lastButtonState && millis() - lastDebounceTime > debounceDelay) {
    lastDebounceTime = millis();  // Update the debounce time

    if (currentButtonState) {  // Button pressed
      if (!*buttonPressed) {  // New press, not held down
        *buttonPressed = true;

        // Turn off the green LED
        digitalWrite(ledPinGreen, LOW);

        // Turn on the red LED
        digitalWrite(ledPinRed, HIGH);

        // Send the "RING" message
        Wire.beginTransmission(address);
        Wire.write("RING\0", 5);  // Send the "RING" message
        Wire.endTransmission();

        delay(500);  // Longer delay for a clear flash (you can adjust this duration)

        // Turn off the red LED after the delay
        digitalWrite(ledPinRed, LOW);

        // Turn the green LED back on after a delay
        delay(1500);  // Adjust this duration for desired effect
        digitalWrite(ledPinGreen, HIGH);  // Restore the green LED
      }
    } else {  // Button released
      *buttonPressed = false;
    }

    *lastButtonState = currentButtonState;  // Update the last known button state
  }
}
