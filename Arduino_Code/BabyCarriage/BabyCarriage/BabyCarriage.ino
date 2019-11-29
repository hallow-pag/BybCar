#include <dht.h>
#include <Servo.h>
#include "Wire.h"
#include "I2Cdev.h"
#include "MPU6050.h"



#define DHT11_PIN 2      //温湿度引脚
#define readLight_PIN A0 //用于读取光敏值的引脚
Servo myservo9;           //用于控制摇床的舵机的对象
Servo myservo10;          //用于控制遮光的舵机的对象
dht DHT;                  //用于读取温湿度的对象
MPU6050 accelgyro;        //用于控制读取六轴传感器的对象


void initModule();
void DHT11();//温湿度读取函数
void readLight();//光敏值读取函数
double  readXYZ();//读取坐标
void uartSend();//串口传输函数
String uartReceive();//串口接收函数
void orderModule(String str1);//执行指令函数
void doubleTochar(double doublex, char* ch); //double转字符数组
void intTochar(int intx, char* ch); //int转字符数组
void shadingModule(int z);//遮光模块函数0：关闭遮光 1：开启遮光
void shakerModule(int y);//摇床模块函数 1:开启摇床 0：关闭摇床且平衡摇床
void autobalanceModule(int p);//自动平衡模块1：开启平衡 0：关闭平衡


int lightValue_int = 0; //光敏值
char shakerValue = 0; //用于存储上次的摇床指令
char shadingValue = 0; //用于存储上次的遮光指令
char autobalanceValue = 0;//用于存储上次自动平衡指令
int pos9 = 0;    // 用于存储摇床舵机位置的变量
int pos10 = 0;    // 用于存储遮光舵机位置的变量
String order;   //用于接收指令
int flag = 1; 
double PHvalue = 41; //六轴的平衡值
/************************六轴传感器的所需变量*********************************/
unsigned long now, lastTime = 0;
float dt;                                   //微分时间

int16_t ax, ay, az, gx, gy, gz;             //加速度计陀螺仪原始数据
float aax = 0, aay = 0, aaz = 0, agx = 0, agy = 0, agz = 0; //角度变量
long axo = 0, ayo = 0, azo = 0;             //加速度计偏移量
long gxo = 0, gyo = 0, gzo = 0;             //陀螺仪偏移量

float pi = 3.1415926;
float AcceRatio = 16384.0;                  //加速度计比例系数
float GyroRatio = 131.0;                    //陀螺仪比例系数

uint8_t n_sample = 8;                       //加速度计滤波算法采样个数
float aaxs[8] = {0}, aays[8] = {0}, aazs[8] = {0};         //x,y轴采样队列
long aax_sum, aay_sum, aaz_sum;                     //x,y轴采样和

float a_x[10] = {0}, a_y[10] = {0}, a_z[10] = {0} , g_x[10] = {0} , g_y[10] = {0}, g_z[10] = {0}; //加速度计协方差计算队列
float Px = 1, Rx, Kx, Sx, Vx, Qx;           //x轴卡尔曼变量
float Py = 1, Ry, Ky, Sy, Vy, Qy;           //y轴卡尔曼变量
float Pz = 1, Rz, Kz, Sz, Vz, Qz;           //z轴卡尔曼变量
/***************************************************************************/


void setup() {
  Serial.begin(115200);
  myservo9.attach(9);  // 舵机控制信号引脚
  myservo10.attach(10);  // 舵机控制信号引脚

  /*************六轴传感器初始化部分*******************/
  Wire.begin();
  accelgyro.initialize();                 //初始化

  unsigned short times = 200;             //采样次数
  for (int i = 0; i < times; i++)
  {
    accelgyro.getMotion6(&ax, &ay, &az, &gx, &gy, &gz); //读取六轴原始数值
    axo += ax; ayo += ay; azo += az;      //采样和
    gxo += gx; gyo += gy; gzo += gz;
  }
  axo /= times; ayo /= times; azo /= times; //计算加速度计偏移
  gxo /= times; gyo /= times; gzo /= times; //计算陀螺仪偏移
  /*************六轴传感器初始化部分*******************/
  initModule();//初始化零件
}




void loop() {

  int x;
  if(flag==1){
    initModule();//初始化零件
    flag=0;
  }
  
  DHT11();//获取温湿度
  readLight();//获取光敏
  uartSend();//发送数值
  order = uartReceive();//获取命令
  orderModule(order);//执行命令
  //x = readXYZ();
  //Serial.print("XXXX:");
  //Serial.println(x);
  delay(500);

}
void initModule() {
  
  int p9, p10,flag1=0;
  //摇床舵机初始化
  if (p9 = myservo9.read() > 90)
    for (p9 = myservo9.read(); p9 > 90; p9--) {
      myservo9.write(p9);
    }
  else if (p9 = myservo9.read() < 90)
    for (p9 = myservo9.read(); p9 < 90; p9++) {
      myservo9.write(p9);
      delay(15);
    }
  //遮光舵机初始化
  if (p10 = myservo10.read() < 125)
    for (p10 = myservo9.read(); p10 <= 125; p10++) {
      myservo10.write(p10);
      delay(15);
    }
  //坐标稳定
  while(flag1 < 20) {
    PHvalue = readXYZ();
    Serial.print("PHvalue:");
    Serial.println(PHvalue);
    flag1++;
    delay(200);
  }

}



void orderModule(String str) { //执行指令P:平衡 Y摇床 Z遮光
  //第一位字符 控制自动平衡
  if (str.charAt(0) != '0' && (str.charAt(0) == '1' || autobalanceValue == '1')) {
    //Serial.println("bbbbbbbbbbbbbbbbbbbbbbbb");
    autobalanceModule(1);//开启平衡
   // Serial.println("ssssssssssssssssssssssss");
    autobalanceValue = '1'; //更新值
  }
  else if (str.charAt(0) != '1' && (str.charAt(0) == '0' || autobalanceValue == '0')) {
    autobalanceModule(0);//关闭平衡
    autobalanceValue = '0'; //更新值
  }
  //第二位字符 控制摇床
  if (str.charAt(1) != '0' && (str.charAt(1) == '1' || shakerValue == '1')) {
    shakerModule(1);//开启摇床
    shakerValue = '1'; //更新值
  }
  else if (str.charAt(1) != '1' && (str.charAt(1) == '0' || shakerValue == '0')) {
    shakerModule(0);//关闭摇床
    shakerValue = '0'; //更新值
  }
  //第三位字符 控制遮光
  if (str.charAt(2) == '1') {
    shadingModule(1);//开启遮光
    shadingValue = '1'; //更新值
  }
  else if (str.charAt(2) == '0') {
    shadingModule(0);//开启遮光
    shadingValue = '0'; //更新值
  }
}




void autobalanceModule(int p) {
  int  posx ;
  int flag=0;
  double agx = 100;
  int n=15;
  //int nexttime = millis() + 50000; //运行10秒
  //int nowtime = 0;
  if (p == 1 ) {
    while(n--){
      agx = readXYZ();
      //Serial.println(agx);
    }
    
    
    if (agx==100) {
      agx = readXYZ();
    }
    if (agx != 100) {
      posx = myservo9.read();
      while (agx > PHvalue + 5.5 || agx < PHvalue - 5.5) { //agx超出平衡范围 进入调整

        while (agx < PHvalue - 5.5 && posx < 180) {
          posx++; 
          n=5;// 步进角度1度
          myservo9.write(posx);    // 输入对应的角度值，舵机会转到此位置
          delay(10);
          while(n--)
          agx = readXYZ(); //读取X坐标
          //Serial.print("agx:");
          //Serial.println(agx);
         // posx = myservo9.read();
         flag=1;

        }
        
        while (agx > PHvalue + 5.5 && posx > 0) {
          posx--;
          n=5;
          myservo9.write(posx);              // 输入对应的角度值，舵机会转到此位置
          delay(10);
          while(n--)
          agx = readXYZ(); //读取X坐标
          //posx = myservo9.read();
         // Serial.print("agx:");
         // Serial.println(agx);
          flag=2;
        }
        if(flag==1){
          posx++;
          myservo9.write(posx);  
        }
        else if(flag==2){
          posx--;
          myservo9.write(posx);  
        }
        posx = myservo9.read();
        if (posx >= 180 || posx <= 0)
          return ;
      /* nowtime=millis();
       if (nowtime > nexttime)
          break ;*/
      }
    }
  }
  if (p == 0) {
    delay(100);
  }

}





void shakerModule(int y) {
  int nexttime = millis() + 5000; //运行10秒
  int nowtime = 0;
  int posx = 0; //临时坐标
  pos9=1;
  if (y == 1 ) { //y== 1 执行摇床
    // Serial.println("y=1");
    while (1) {
      if(pos9==1)
      for (posx = myservo9.read(); posx < 180; posx += 1) // 获取当前角度-转到180度
      {
        myservo9.write(posx);              // 输入对应的角度值，舵机会转到此位置
        delay(10);                       // 10ms后进入下一个位置
        nowtime = millis();
        if (nowtime > nexttime){
          pos9=1;
          break ;
        }

      }
      pos9=0;
      if(pos9==0)
      for (posx = myservo9.read(); posx >= 1; posx -= 1) // 获取当前角度度-0度
      {
        myservo9.write(posx);              // 输入对应的角度值，舵机会转到此位置
        delay(10);                       // 10ms后进入下一个位置
        nowtime = millis();
        if (nowtime > nexttime)
        {
          pos9=0;
          break ;
        }
          
      }
      pos9=1;
      if (nowtime > nexttime)
          break ;
    }
  }
  if (y == 0) { //y == 0 把床调整到平衡位置退出
    //Serial.println("y=0");
    delay(10);
    /*int i;
      double agx; //存储当前X坐标
      for (i = 0; i <= 2; i++) { //读取X两次
      agx = readXYZ(); //读取X坐标
      }

      if (agx >= -90 && agx <= 90) //排除异常值
      {
      while (agx > PHvalue + 1 || agx < PHvalue - 1 &&(posx<180&&posx>0)) { //agx超出平衡范围 进入调整
        posx = myservo9.read();
        while (agx < PHvalue - 1&&posx<=180) {
          posx++;      // 步进角度1度
          myservo9.write(posx);    // 输入对应的角度值，舵机会转到此位置
          delay(10);
          agx = readXYZ(); //读取X坐标
          posx = myservo9.read();
        }

        while (agx > PHvalue + 1&&posx>=0) {
          posx--;
          myservo9.write(posx);              // 输入对应的角度值，舵机会转到此位置
          delay(10);
          agx = readXYZ(); //读取X坐标
          posx = myservo9.read();
        }
        posx = myservo9.read();
        if(posx>=180||posx<=0)
           return ;
      }
      }
      else
      Serial.println("agx:100");*/
  }

}




void shadingModule(int z) {
  int posx;
  if (z == 0 ) { //关闭遮光
    //Serial.println("z=1");
    //delay(1000);
    for (posx = myservo10.read();  posx < 125; posx += 1) // 从读取当前值度-到125度
    {
      myservo10.write(posx);              // 输入对应的角度值，舵机会转到此位置
      delay(20);                       // 15ms后进入下一个位置
    }

  }
  else if (z == 1 ) { //开启遮光
    // Serial.println("z=0");
    //delay(100);
    for (posx = myservo10.read();  posx > 20 ; posx -= 1) // 从读取当前值度-到20度
    {
      myservo10.write(posx);
      delay(10);
    }
  }

}




void intTochar(int intx, char* ch) {
  int i = -1, c = intx;
  while (c) {
    i++;
    c = c / 10;
  }
  while (intx) {

    ch[i] = intx % 10 + '0';
    intx = intx / 10;
    i--;
  }
}




void doubleTochar(double doublex, char* ch) {
  int intx = (int)doublex;
  int i = -1, c = intx;
  while (c) {
    i++;
    c = c / 10;
  }
  while (intx) {

    ch[i] = intx % 10 + '0';
    intx = intx / 10;
    i--;
  }
}



String uartReceive() {
  String str;
  while (Serial.available() > 0) {
    str += char(Serial.read());
    delay(1);
  }
  return str;
}




void uartSend() {
  char tempValue[5] = {0};
  char humiValue[5] = {0};
  char lightValue_char[5] = {0};
  int i;
  doubleTochar(DHT.temperature, tempValue);
  doubleTochar(DHT.humidity, humiValue);
  intTochar(lightValue_int, lightValue_char);

  /*Serial.print("温度:");
    Serial.println(tempValue);
    Serial.print("湿度:");
    Serial.println(humiValue);
    Serial.print("光敏值:");
    Serial.println(lightValue_char);//4*/
  //  t&h&l:12:89:328
  String str = "t&h&l";
  str += ":";
  str += tempValue;
  str += ":";
  str += humiValue;
  str += ":";
  str += lightValue_char;
  Serial.println(str);
  // Serial.println();
}





void readLight() {

  lightValue_int = analogRead(readLight_PIN);

}




void DHT11() {

  int chk = DHT.read11(DHT11_PIN);
  /*switch (chk)
    {
    case 0:  Serial.println("OK,\t"); break;
    case -1: Serial.print("Checksum error,\t"); break;
    case -2: Serial.print("Time out error,\t"); break;
    default: Serial.print("Unknown error,\t"); break;
    }*/
}




double readXYZ() {

  unsigned long now = millis();             //当前时间(ms)
  dt = (now - lastTime) / 1000.0;           //微分时间(s)
  lastTime = now;                           //上一次采样时间(ms)

  accelgyro.getMotion6(&ax, &ay, &az, &gx, &gy, &gz); //读取六轴原始数值

  float accx = ax / AcceRatio;              //x轴加速度
  float accy = ay / AcceRatio;              //y轴加速度
  float accz = az / AcceRatio;              //z轴加速度

  aax = atan(accy / accz) * (-180) / pi;    //y轴对于z轴的夹角
  aay = atan(accx / accz) * 180 / pi;       //x轴对于z轴的夹角
  aaz = atan(accz / accy) * 180 / pi;       //z轴对于y轴的夹角

  aax_sum = 0;                              // 对于加速度计原始数据的滑动加权滤波算法
  aay_sum = 0;
  aaz_sum = 0;
  for (int i = 1; i < n_sample; i++)
  {
    aaxs[i - 1] = aaxs[i];
    aax_sum += aaxs[i] * i;
    aays[i - 1] = aays[i];
    aay_sum += aays[i] * i;
    aazs[i - 1] = aazs[i];
    aaz_sum += aazs[i] * i;
  }
  aaxs[n_sample - 1] = aax;
  aax_sum += aax * n_sample;
  aax = (aax_sum / (11 * n_sample / 2.0)) * 9 / 7.0; //角度调幅至0-90°
  aays[n_sample - 1] = aay;                      //此处应用实验法取得合适的系数
  aay_sum += aay * n_sample;                     //本例系数为9/7
  aay = (aay_sum / (11 * n_sample / 2.0)) * 9 / 7.0;
  aazs[n_sample - 1] = aaz;
  aaz_sum += aaz * n_sample;
  aaz = (aaz_sum / (11 * n_sample / 2.0)) * 9 / 7.0;

  float gyrox = - (gx - gxo) / GyroRatio * dt; //x轴角速度
  float gyroy = - (gy - gyo) / GyroRatio * dt; //y轴角速度
  float gyroz = - (gz - gzo) / GyroRatio * dt; //z轴角速度
  agx += gyrox;                             //x轴角速度积分
  agy += gyroy;                             //x轴角速度积分
  agz += gyroz;
  /* kalman start */
  Sx = 0; Rx = 0;
  Sy = 0; Ry = 0;
  Sz = 0; Rz = 0;
  for (int i = 1; i < 10; i++)
  { //测量值平均值运算
    a_x[i - 1] = a_x[i];                    //即加速度平均值
    Sx += a_x[i];
    a_y[i - 1] = a_y[i];
    Sy += a_y[i];
    a_z[i - 1] = a_z[i];
    Sz += a_z[i];
  }
  a_x[9] = aax;
  Sx += aax;
  Sx /= 10;                                 //x轴加速度平均值
  a_y[9] = aay;
  Sy += aay;
  Sy /= 10;                                 //y轴加速度平均值
  a_z[9] = aaz;
  Sz += aaz;
  Sz /= 10;

  for (int i = 0; i < 10; i++)
  {
    Rx += sq(a_x[i] - Sx);
    Ry += sq(a_y[i] - Sy);
    Rz += sq(a_z[i] - Sz);
  }
  Rx = Rx / 9;                              //得到方差
  Ry = Ry / 9;
  Rz = Rz / 9;
  Px = Px + 0.0025;                         // 0.0025在下面有说明...
  Kx = Px / (Px + Rx);                      //计算卡尔曼增益
  agx = agx + Kx * (aax - agx);             //陀螺仪角度与加速度计速度叠加
  Px = (1 - Kx) * Px;                       //更新p值

  Py = Py + 0.0025;
  Ky = Py / (Py + Ry);
  agy = agy + Ky * (aay - agy);
  Py = (1 - Ky) * Py;
  Pz = Pz + 0.0025;
  Kz = Pz / (Pz + Rz);
  agz = agz + Kz * (aaz - agz);
  Pz = (1 - Kz) * Pz;

  /* kalman end */
  
    /*Serial.print(agx);Serial.print(",");
    Serial.print(agy);Serial.print(",");
    Serial.print(agz);Serial.println();*/

  if (agx > -100 && agx < 100)
    return agx;
  else
    return 100;

}
