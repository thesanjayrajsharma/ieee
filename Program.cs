using NumberToBinary;
using IEEEformat;
using IEEEaddition;
using IEEEtoDecimal;
class Program{
    public static void Main(){

    float firstNumber=10.4f;
    float secondNumber=30.6f;
    /*if(firstNumber+secondNumber<8&& firstNumber+secondNumber==4){
    Console.WriteLine("   "+2*(FloatToDecimal.ToDecimal(firstNumber,secondNumber)));
    }
    else if(firstNumber+secondNumber<4&&firstNumber+secondNumber>0){
    Console.WriteLine("   "+(FloatToDecimal.ToDecimal(firstNumber,secondNumber))/2);   
    }
else
{
  Console.WriteLine("   "+(FloatToDecimal.ToDecimal(firstNumber,secondNumber))); 
} */

Console.WriteLine("   "+(FloatToDecimal.ToDecimal(firstNumber,secondNumber)));

   
     }       
    }
