using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI display;
    [SerializeField] TextMeshProUGUI answer;
    [SerializeField] AudioSource buttonClick;
    [SerializeField] Animator animator;


    string Op;
    string expression;
    double input1;
    double input2;

    public void Operation(char op)
    {
        if(op == '+')
        {
            Op = "add";
        }
        else if(op == '-')
        {
            Op = "sub";
        }
        else if(op == '*')
        {
            Op = "mul";
        }else if(op == '/')
        {
            Op = "div";
        }
    }

    public int OpIndex(string expression)
    {
        int index = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i].Equals('+') || expression[i].Equals('-') || expression[i].Equals('*') || expression[i].Equals('/'))
            {
                index = i;
                Operation(expression[i]);
            }
        }
        return index;
    }
    public void Equals()
    {
        double ans = 0;
        string value1 = "";
        string value2 = "";
        int index = OpIndex(expression);
        for(int i = 0; i < index; i++)
        {
            if(expression[i].Equals('1') || expression[i].Equals('2') || expression[i].Equals('3') ||
               expression[i].Equals('4') || expression[i].Equals('5') || expression[i].Equals('6') ||
               expression[i].Equals('7') || expression[i].Equals('8') || expression[i].Equals('9'))
            {
                value1 += expression[i];
            }
        }
        for (int i = index + 1; i < expression.Length; i++)
        {
            if (expression[i].Equals('1') || expression[i].Equals('2') || expression[i].Equals('3') ||
               expression[i].Equals('4') || expression[i].Equals('5') || expression[i].Equals('6') ||
               expression[i].Equals('7') || expression[i].Equals('8') || expression[i].Equals('9'))
            {
                value2 += expression[i];
            }
        }
        input1 = Convert.ToDouble(value1);
        input2 = Convert.ToDouble(value2);

        if (Op == "add")
        {
            ans = input1 + input2;
        }
        else if (Op == "sub")
        {
            ans = input1 - input2;
        }
        else if (Op == "mul")
        {
            ans = input1 * input2;
        }
        else if (Op == "div")
        {
            ans = input1 / input2;
        }

        answer.text += ans.ToString();
    }

    public void Input(string value)
    {
        display.text += value;
        expression = display.text;

        if(value == "c")
        {
            expression = null;
            answer.text = null;
            display.text = null;
        }
    }
}
