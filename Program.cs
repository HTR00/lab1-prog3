using System;
using System.Collections.Generic;

namespace Conversor
{
    class App
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) 
            {
                Console.WriteLine("Os parâmetros não foram enviados.");
                return;
            }

            var parameters = new Dictionary<string,string>();
            for(int i = 0; i < args.Length; i += 2)
            {
                parameters.Add(args[i], args[i+1]);
            }

            Console.WriteLine("Parâmetros entregues: ");
            foreach (var param in parameters)
            {
                Console.WriteLine($"{param.Key}:{param.Value}");
            }

            if (parameters.ContainsKey("int"))
            {
                int intValue = int.Parse(parameters["int"]);
                Console.WriteLine($"int para short: {ConversorIntShort(intValue)}");
                Console.WriteLine($"int para long: {ConversorIntLong(intValue)}");
            }

            if(parameters.ContainsKey("float"))
            {
                float floatValue = float.Parse(parameters["float"]);
                Console.WriteLine($"float para int: {ConversorFloatInt(floatValue)}");
            }

            if(parameters.ContainsKey("bool"))
            {
                bool boolValue = bool.Parse(parameters["bool"]);
                Console.WriteLine($"bool para string: {conversorBoolString(boolValue)}");
            }

            if (parameters.ContainsKey("boxing"))
            {
                Console.WriteLine($"boxing: {Boxing(int.Parse(parameters["boxing"]))}");
            }

            if (parameters.ContainsKey("unboxing"))
            {
                Console.WriteLine($"unboxing: {Unboxing(int.Parse(parameters["unboxing"]))}");

            }
        }
        
        static short ConversorIntShort(int value)
        {
            if(value > short.MaxValue || value < short.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "valor muito grande para short");    
            }

            return (short)value;
        }

        static long ConversorIntLong(int value)
        {
            return (long)value;
        }

        static int ConversorFloatInt(float value)
        {
            if (value > int.MaxValue || value < int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "o valor está fora do tamanho possível de int");
            }

            return (int)value;
        }

        static string conversorBoolString(bool value)
        {
            return value.ToString();
        }

        static object Boxing (int value)
        {
            return value;
        }

        static int Unboxing(object value)
        {
            if (value is int)
            {
                return (int)value;
            }
            throw new InvalidCastException("Não consigo converter o valor");
        }
    }
}