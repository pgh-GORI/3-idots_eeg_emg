void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  int count1 = 0;
  int val1 = 0;
  int sum1 = 0;
  for(int d = 0; d < 50; d++){
    val1 = 0;
    sum1 = 0;
    for(int a = 0; a < 10; a++){
      val1 = analogRead(A0);
      sum1 = sum1 + val1;
    }
    float ave1 = sum1 * 0.1;
    if (ave1 > 90){
     count1++;
    }
  }
  int data1 = 0;
  if (count1 >= 20){ data1 = 1; }
  else{ data1 = 0; }
  // 오른쪽

  int count2 = 0;
  int val2 = 0;
  int sum2 = 0;
  for(int c = 0; c < 50; c++){
    val2 = 0;
    sum2 = 0;
    for(int b = 0; b < 10; b++){
      val2 = analogRead(A1);
      sum2 = sum2 + val2;
    }
    float ave2 = sum2 * 0.1;
    if (ave2 > 90){
     count2++;
    }
  }
  int data2 = 0;
  if (count2 >= 20){ data2 = 2; }
  else{ data2 = 0; }
   // 왼쪽

  Serial.println(data1 + data2);
  delay(10);
}
