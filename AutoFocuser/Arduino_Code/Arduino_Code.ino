const int STEPS_PER_REV = 200;  
const int STEP_PIN = 3; 
const int DIR_PIN = 2; 
String data[3];
int index=0;
bool directionPinStatus = true;

void setup()
{
	pinMode(STEP_PIN, OUTPUT);
	pinMode(DIR_PIN, OUTPUT);
  Serial.begin(9600);
}
void loop()
{
  if(Serial.available())
  {
    data[index] = Serial.readStringUntil(',');
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
    digitalWrite(STEP_PIN, HIGH);
    delayMicroseconds(1000); 
    digitalWrite(STEP_PIN, LOW);
    delayMicroseconds(1000); 
  }
}