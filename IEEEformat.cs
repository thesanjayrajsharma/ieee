using NumberToBinary;
namespace IEEEformat {

    class IEEE{

        internal static byte[] MyExponent(float num){
        num=Math.Abs(num);
        int NumberIntPart=(int)num ;
        float NumberFractionPart=num-NumberIntPart;
        int Expo= (BinaryFormat.integerToBinary(NumberIntPart)).Length-1+127;             //integer array +127
        byte[] Exponent= BinaryFormat.integerToBinary(Expo);  
        
        return Exponent;
        
        }


        internal static byte[] Mantisa(float num)
        {
        num=Math.Abs(num);
         int NumberIntPart=(int)num ;
         float NumberFractionPart=num-NumberIntPart;

         byte[]Mantisa_sum=new Byte[23];
         byte[]IntegerArray=BinaryFormat.integerToBinary(NumberIntPart);
         for(int i=1;i<IntegerArray.Length;i++){                                    //adding integer array to mantisa
            Mantisa_sum[i-1]=IntegerArray[i];

        }    
         byte[]FractionArray= BinaryFormat.fractionToBinary(NumberFractionPart);
         int StartingIndex=IntegerArray.Length;
         int j=0;
         for(int i=StartingIndex-1;i<23;i++){                                          //adding fraction array to mantisa
            Mantisa_sum[i]=FractionArray[j];
            j++;
        }

            return Mantisa_sum;                                                  // 01000011100000111010011001100110
         }



        internal static byte[] IeeeFormat(float num){
            num=Math.Abs(num);
            byte[] Ieee = new byte[32];

            if(num<0) Ieee[0]=1;
            else Ieee[0]=0;
                int j=(MyExponent(num).Length)-1;
            for(int i=8;i>=1;i--){
               if(j<0) break;
                Ieee[i]=MyExponent(num)[j];
                j--;
            }
              j=0;
            for(int i=9;i<32;i++){
               
                Ieee[i]=Mantisa(num)[j];
                j++;
            }

            return Ieee;
        }



    }
}                           