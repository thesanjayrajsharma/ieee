using IEEEformat;
using IEEEaddition;
using NumberToBinary;
namespace IEEEsubraction{

class Subtract{
    internal static byte[] IeeeSub (float num1,float num2){
       float positiveNumber=Math.Max(num1,num2);
       float NegativeNumber=Math.Min(num1,num2);
        positiveNumber=Math.Abs(positiveNumber);
        NegativeNumber=Math.Abs(NegativeNumber);
    
        int Len_num1=Add.Exponent(positiveNumber);                           
        int Len_num2=Add.Exponent(NegativeNumber);

        byte[]arr1=IEEE.Mantisa(positiveNumber);
        byte[]arr2=IEEE.Mantisa(NegativeNumber);

        List<byte>Positive_List =new List<byte>(arr1);
        Positive_List.Insert(0,1); 
    
        List<byte>Negative_List =new List<byte>(arr2);
        Negative_List.Insert(0,1);
        
        if(Len_num1<Len_num2){
                while(Len_num2-Len_num1!=0){
                    Positive_List.Insert(0,0);
                    Len_num1 ++;                                                        // equating bias
                }
                                                                       
            }

            else if(Len_num2<Len_num1){
                while(Len_num1-Len_num2!=0){
                    Negative_List.Insert(0,0);
                    Len_num2 ++;
                }
            }

            for(int i=0;i<Negative_List.Count;i++){
                if(Negative_List[i]==0) Negative_List[i]=1;                             // 1's complient
                else if(Negative_List[i]==1) Negative_List[i]=0;
            }

            Positive_List=Positive_List.GetRange(0,24);
            Negative_List=Negative_List.GetRange(0,24);
           
           Console.WriteLine("line 48");
            List<byte>MantisaSum=new List<byte>();               
            int carry=0;
            int temp=0;
            for(int i=23;i>=0;i--){                 
                 temp=Negative_List[i]+Positive_List[i]+carry;                               // addition 
                 
                MantisaSum.Insert(0,(byte)(temp%2));
                carry=temp/2;
                
             }
             Console.WriteLine("line 59");
             for(int i=0;i<MantisaSum.Count;i++){
                System.Console.Write(MantisaSum[i]);
              }
              Console.WriteLine("carry "+carry);
              if(carry==1) {
                for(int i=23;i>=0;i--){                 
                 temp=MantisaSum[i]+carry;                               
                 
                MantisaSum.Insert(0,(byte)(temp%2));
                carry=temp/2;
                }
                
             }
             Console.WriteLine("line 70");
             for(int i=0;i<MantisaSum.Count;i++){
                System.Console.Write(MantisaSum[i]);
              }
             if(carry==0){
                for(int i=0;i<MantisaSum.Count;i++){
                if(MantisaSum[i]==0) MantisaSum[i]=1;                             // 1's complient
                else if(MantisaSum[i]==1) MantisaSum[i]=0;
             }
              }
              Console.WriteLine("line 81");
              for(int i=0;i<MantisaSum.Count;i++){
                System.Console.Write(MantisaSum[i]);
              }
                 Console.WriteLine("line 73");
             while(MantisaSum[0]!=1){
                MantisaSum.RemoveAt(0);
                MantisaSum.Add(0);
                Len_num1--;
             }
             Console.WriteLine("line 73");
             for(int i=0;i<MantisaSum.Count;i++){
                System.Console.Write(MantisaSum[i]);
              }
            
            byte[] ExponentArray=BinaryFormat.integerToBinary(Len_num1+127);        // exponent array 
           

            byte[] FloatSubtract= new byte[32];                                           // array to contain sum of num1 & num2
            FloatSubtract[0]=1;
           
            int j=ExponentArray.Length-1;
            for(int i=8;i>0;i--){ 
                if(j<0)break;                                                  // adding exponent to array
                FloatSubtract[i]=ExponentArray[j];
                j--;

            }

            j=1;
            for(int i=9;i<32;i++){     
                if(j>23)break;                                             // adding mantisa to sum
                FloatSubtract[i]=MantisaSum[j];
                j++;
            }
            Console.WriteLine(" 118 line");
           for(int i=0;i<FloatSubtract.Length;i++){
          Console.Write(FloatSubtract[i]);
           }
            return FloatSubtract;
              }
    }
}