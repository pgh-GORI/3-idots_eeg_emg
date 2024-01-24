void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  int val1 = 0;
  int val2 = 0;
  val1 = analogRead(A0);//왼쪽
  val2 = analogRead(A1);//오른쪽
  Serial.println(val1);
  Serial.println(val2);
  Serial.println("=====");
  delay(50);
}
