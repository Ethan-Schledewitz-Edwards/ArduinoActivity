void setup() {
  Serial.begin(9600);

  pinMode(2, INPUT_PULLUP);
  pinMode(3, INPUT_PULLUP);
  pinMode(4, INPUT_PULLUP);
}

void loop() {
  uint8_t a = digitalRead(2);
  uint8_t b = digitalRead(3);
  uint8_t c = digitalRead(4);

  uint8_t buttons = a << 2 | b << 1 | c << 0;

  Serial.write((uint8_t)buttons);
}
