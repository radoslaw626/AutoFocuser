const int STEPS_PER_REV = 200;  
const int STEP_PIN = 3; 
const int DIR_PIN = 2; 
const int LIMITSWITCH_PIN = 4;
String data[3];
int index=0;
bool directionPinStatus = true;

void setup()
{
	pinMode(STEP_PIN, OUTPUT);
	pinMode(DIR_PIN, OUTPUT);
  pinMode(LIMITSWITCH_PIN, INPUT);
  Serial.begin(9600);
}
void loop()
{
  if(Serial.available())
  {
    data[index] = Serial.readStringUntil(',');
    if(data[index]=="CallHoming")
    {
      HomePosition();
      index = 0;
      return;
    }
    Serial.print("data read: "); Serial.println(data[index]);
    index++;
    if(index == 2)
    {
      index = 0;
      moveStepper(data[0].toInt(), data[1].toInt());
    }

  }
}
void moveStepper(int steps, int direction)
{
   Serial.print("direction: ");
     Serial.println(direction);
   if(direction==1)
   {
    directionPinStatus=true;
   }
   else if(direction==0)
   {
    directionPinStatus=false;
   }

  digitalWrite(DIR_PIN, directionPinStatus ? HIGH : LOW); 
  Serial.print("bool: ");
  Serial.println(directionPinStatus);
  for (int i = 0; i < steps; i++)
   {
     if(digitalRead(LIMITSWITCH_PIN)==1 && direction == 1)
     {
       return;
     } 
    digitalWrite(STEP_PIN, HIGH);
    delayMicroseconds(500); 
    digitalWrite(STEP_PIN, LOW);
    delayMicroseconds(500); 
  }
}

void HomePosition()
{
  digitalWrite(DIR_PIN, HIGH);
  while(digitalRead(LIMITSWITCH_PIN)==0)
  {
      digitalWrite(STEP_PIN, HIGH);
      delayMicroseconds(500); 
      digitalWrite(STEP_PIN, LOW);
      delayMicroseconds(500); 
  }
}