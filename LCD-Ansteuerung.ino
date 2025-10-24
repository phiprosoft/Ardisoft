#include <Wire.h>
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27, 16, 2);

void setup() {
  Serial.begin(9600);
  lcd.init();
  lcd.backlight();
}

void loop() {
  if (Serial.available()) {
    String text = Serial.readStringUntil('\n');
    showTextPaged(text);
  }
}

void showTextPaged(String text) {
  int pos = 0;
  while (pos < text.length()) {
    lcd.clear();

    // Zeile 1
    String line1 = getLine(text, pos, 16);
    lcd.setCursor(0, 0);
    lcd.print(line1);

    // Zeile 2
    String line2 = getLine(text, pos, 16);
    lcd.setCursor(0, 1);
    lcd.print(line2);

    delay(2000); // 2 Sekunden pro Seite
  }
}

// Hilfsfunktion: holt bis zu maxLen Zeichen, bricht an Wortgrenze
String getLine(String &text, int &pos, int maxLen) {
  if (pos >= text.length()) return "";

  int end = pos + maxLen;
  if (end > text.length()) end = text.length();

  // Suche letztes Leerzeichen vor dem Ende
  int lastSpace = -1;
  for (int i = pos; i < end; i++) {
    if (text[i] == ' ') lastSpace = i;
  }

  String line;
  if (end == text.length()) {
    line = text.substring(pos, end);
    pos = end;
  } else if (lastSpace != -1) {
    line = text.substring(pos, lastSpace);
    pos = lastSpace + 1; // nach dem Leerzeichen weitermachen
  } else {
    line = text.substring(pos, end);
    pos = end;
  }

  return line;
}
