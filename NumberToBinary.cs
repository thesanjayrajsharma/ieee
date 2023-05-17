using System;
namespace NumberToBinary
{
    class BinaryFormat{

             internal static byte [] integerToBinary (int integer)
                {
                List<byte> arr=new List<byte>();
                if(integer==0){
                    arr.Add(0);
                    
                }
                while(integer>0){
                    if(integer==0) break;
                    arr.Add((byte)(integer%2));
                    integer=integer>>1;
                }

                arr.Reverse();
                byte[]arr1=arr.ToArray();
                 return arr1;
                
                }
               

                

            internal static byte[] fractionToBinary(float fraction){
                    
                    byte[] arr=new byte[23];
                    
                  for(int i=0;i<23;i++) {

                        fraction *= 2;
                         if (fraction >= 1)
                          {
                          arr[i]=1;
                             fraction -= 1;
                          }
                        else
                         {
                        arr[i]=0;
                         }
                        
                    }

                    return arr;
                }
              

    }

}
