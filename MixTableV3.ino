#include <Velleman_KA12.h>

int all[24];
int sensor1;

void setup() {
  Serial.begin(9600);
  ka12_init(); 
}

void loop() {
  ka12_readAll(all);
  for (int i=0; i < 24; i=i+1) {
  //send
  Serial.write(all[i]/4);
  /*
  if(i!=23){
    Serial.print("/"); 
    }
  }
  Serial.println();
  */
  delay(100);
  
}
}

/*
  sensor1 = ka12_read(6);
  Serial.print("Sensor 1 :");
  Serial.println(sensor1); 
  */
