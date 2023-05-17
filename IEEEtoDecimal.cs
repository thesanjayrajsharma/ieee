using IEEEaddition;
using IEEEformat;
using NumberToBinary;
using IEEEsubraction;

namespace IEEEtoDecimal{
 class FloatToDecimal{

            internal static float ToDecimal(float num1,float num2){
                byte[]temp=new byte[32];
                if(num1==0.0 && num2==0.0) return 0.0f;
                if((num1+num2>0)||(num1+num2<0)&&num1*num2>0){temp=Add.IeeeSum(num1,num2);}
                Console.WriteLine("line 13");
               // if(num1*num2<0){temp=Subtract.IeeeSub(num1,num2);}

                Console.WriteLine("sid2134124asndj");
                byte[] FloatArray=temp;
                int Sign =FloatArray[0];
                int Exponent=0,j=0;
                for(int i=8;i>=1;i--){
                    Exponent+=FloatArray[i]*(int)(Math.Pow(2,j));
                    j++;
                }
                Exponent=Exponent-127;
                float Mantisa=0;
                j=-1;
                
                for(int i=9;i<32;i++){
                    Mantisa+=FloatArray[i]*(float)(Math.Pow(2,j));
                    j=j-1;
                }
                
                 return (float)((Math.Pow(-1,Sign))*(1+Mantisa)*(Math.Pow(2,Exponent)));
            }
    }
}