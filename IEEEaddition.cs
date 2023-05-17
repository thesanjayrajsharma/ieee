using NumberToBinary;
using IEEEformat;
namespace IEEEaddition{
    class Add{
       internal static int Exponent(float num)
        {
            num=Math.Abs(num);
        int NumberIntPart=(int)num;
        int Exponent=0;
        byte[]FloatArray=IEEE.IeeeFormat(num);
        int j=0;
        for(int i=8;i>=1;i--){

            Exponent+=FloatArray[i]*((int)(Math.Pow(2,j)));
            j++;
        }
         return Exponent-127;
        }

       internal static byte[] IeeeSum(float num1,float num2){       //32 bit IEEE rep of sum

            int Len_num1=Exponent(num1);                           
            int Len_num2=Exponent(num2);
            

            byte[]arr1=IEEE.Mantisa(num1);
            byte[]arr2=IEEE.Mantisa(num2);

           
            List<byte> list1 =new List<byte>(arr1);
             if(num1>=1){
            list1.Insert(0,1); 
            } 
              if(num1<1&&num1>=0)list1.Insert(0,0);

            
            List<byte> list2 =new List<byte>(arr2);
            if(num2>=1){
            list2.Insert(0,1);
            }
          
             if(num2<1&&num2>=0)list2.Insert(0,0);
            

            if(Len_num1<Len_num2){
                while(Len_num2-Len_num1!=0){
                    list1.Insert(0,0);
                    Len_num1 ++;
                }
                                                                       // equating bias
            }

            else if(Len_num2<Len_num1){
                while(Len_num1-Len_num2!=0){
                    list2.Insert(0,0);
                    Len_num2 ++;
                }
            }

            list1=list1.GetRange(0,24);
            list2=list2.GetRange(0,24);   
            
            List<byte>MantisaSum=new List<byte>();               
            int carry=0;
            int temp=0;
            for(int i=23;i>=0;i--){                 
                 temp=list1[i]+list2[i]+carry;
                 
                MantisaSum.Insert(0,(byte)(temp%2));
                carry=temp/2;
                
             }
            if(carry==1) MantisaSum.Insert(0,(byte)carry);
           
            Console.WriteLine(" ");
             for(int i=0;i<MantisaSum.Count;i++){
      Console.Write(MantisaSum[i]);
    }
           
                if(MantisaSum.Count>24) Len_num1++;
            
            byte[] ExponentArray=BinaryFormat.integerToBinary(Len_num1+127);        // exponent array of sum1
            

            byte[] FloatSum= new byte[32];                                           // array to contain sum of num1 & num2
            if(num1+num2>=0) FloatSum[0]=0;
            else FloatSum[0]=1;
            int j=0;
            for(int i=1;i<=8;i++){   
                if(j==ExponentArray.Length-1) break;                                                // adding exponent to array
                FloatSum[i]=ExponentArray[j];
                j++;

            }
            j=1;
            for(int i=9;i<32;i++){                                                  // adding mantisa to sum
                FloatSum[i]=MantisaSum[j];
                j++;
            }
             
             return FloatSum;
        }
     }           
}           