using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class D8Registers
{
        
    public static void Part1(){
        var registers = new Dictionary<string, int>();
        var instructions = new List<Instruction>();

        var lines = File.ReadAllLines("Files/D8.txt");

        var AllTimeMax = int.MinValue;
        foreach (var l in lines)
        {
            Console.WriteLine("\n----");
            var i = ParseInstruction(l);
            instructions.Add( i );
            Compile(registers,i);
            Console.WriteLine(i);
            Console.WriteLine("");
            Printer.Print(registers);
            AllTimeMax = Math.Max(registers.Select( r => r.Value).Max(),AllTimeMax);
        }

        var max = registers.Select( r => r.Value).Max();
        Console.WriteLine(String.Format("Max value in the register is {0}",max));
        Console.WriteLine(String.Format("The all time Max value in the registers is {0}",AllTimeMax));
    }

	private static void Compile(Dictionary<string, int> registers, Instruction i)
	{
        var value = GetOrCreate(registers,i.Register);
        
        var conditionRegisterValue = GetOrCreate(registers,i.ConditionRegister);
        if(Compile(conditionRegisterValue,i.Condition,i.ConditionValue)){
            value += i.Add;
            registers[i.Register] = value;
        }

	}

	private static bool Compile(int conditionRegisterValue, Comparaison condition, int conditionValue)
	{
        switch(condition){
            case Comparaison.Equal:
                return conditionRegisterValue == conditionValue;
            case Comparaison.Greater:
                return conditionRegisterValue > conditionValue;
            case Comparaison.Lesser:
                return conditionRegisterValue < conditionValue;
            case Comparaison.LesserEqual:
                return conditionRegisterValue <= conditionValue;
            case Comparaison.GreaterEqual:
                return conditionRegisterValue >= conditionValue;
            case Comparaison.NotEqual:
                return conditionRegisterValue != conditionValue;
        }
        Console.WriteLine("EERRUR");
        return false;
	}

	private static int GetOrCreate(Dictionary<string, int> registers, string register){
        if(!registers.ContainsKey(register))
            registers.Add(register,0);
            return registers.GetValueOrDefault(register);
    }

	private static Instruction ParseInstruction(string l)
	{
        var token = l.Split(" ");
        var register = token[0];
        var operation = token[1];
        var amount = token[2];
        var conditionRegister = token[4];
        var condition = GiveMeTheCondition(token[5]);
        var conditionValue = int.Parse(token[6]);

        
        var amountValue = int.Parse(amount.Replace('-',' ').Trim());
        if(amount.Contains('-'))
            amountValue *= -1;
        if(operation.Equals("dec"))
            amountValue *= -1;

        return new Instruction(){
            Register = register,
            Add = amountValue,
            Condition = condition,
            ConditionRegister = conditionRegister,
            ConditionValue = conditionValue

        };
	}

	private static Comparaison GiveMeTheCondition(string v)
	{
        if(v.Equals(">"))
            return Comparaison.Greater;
        else if(v.Equals(">="))
            return Comparaison.GreaterEqual; 
        else if(v.Equals("<"))
            return Comparaison.Lesser;
        else if(v.Equals("<="))
            return Comparaison.LesserEqual;
        else if(v.Equals("=="))
            return Comparaison.Equal;
        else if(v.Equals("!="))
            return Comparaison.NotEqual;
        else 
            return Comparaison.Equal;
	}
}


public class Instruction{
    public string Register;

    public int Add;

    public string ConditionRegister;
    public Comparaison Condition;
    public int ConditionValue;

    public override string ToString(){
        return String.Format("{0} + {1}",Register,Add);
    }
}

public enum Comparaison{Greater,Lesser,Equal,LesserEqual,GreaterEqual,NotEqual}