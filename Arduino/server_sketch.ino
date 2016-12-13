int inSize=0; // Переменная, которая будет содержать размер буфера 
int val = 0; // Переменная, которая бутет содержать состояние реле
char str[8]; // Так как типа string тут нет, будем использовать массив символов 
int Relay = 4; // Пин D4
int Relay_LED = 13; // Пин D13


void setup() 
{ 
  pinMode(Relay, OUTPUT); 
  Serial.begin(9600); // Открываем порт с скоростью передачи в 9600 бод(бит/с) 
  digitalWrite(Relay_LED, HIGH);
} 

void ROn() 
{ 
  digitalWrite(Relay, LOW); // реле включено 
  digitalWrite(Relay_LED, LOW);
} 

void ROff() 
{ 
  digitalWrite(Relay, HIGH); // реле выключено 
  digitalWrite(Relay_LED, HIGH);
} 

void loop() 
{ 
  if(Serial.available() > 0) 
  { 
    delay(200); // Ждем, для того, чтобы пришли все данные 
    inSize = Serial.available(); // Получаем длину строки и записываем ее в переменную 
    for (int i = 0; i < inSize; i++) 
    { 
      str[i] = Serial.read(); // Читаем каждый символ, и пишем его в массив 
    } 
  
    // Сравнять массив с строкой будем используя функцию strcmp 
    if (strcmp(str, "on") == 0) // Если было передано строку "foward" - вращаем вперед 
    { 
      ROn(); 
      val = digitalRead(Relay);
      if (val == 1)
        val = 0;
      else if (val == 0)
        val = 1;
      Serial.println(val);
    } 
    else if (strcmp(str, "of") == 0) // Если было передано строку "back" - вращаем назад 
    { 
      ROff(); 
      val = digitalRead(Relay);
      if (val == 1)
        val = 0;
      else if (val == 0)
        val = 1;
      Serial.println(val);
    } 
    else if (strcmp(str, "st") == 0) // получение состояния реле
    { 
      val = digitalRead(Relay);
      if (val == 1)
        val = 0;
      else if (val == 0)
        val = 1;
      Serial.println(val);
    } 
    else 
    { 
      Serial.println("Error command!"); 
    } 
  } 
}
