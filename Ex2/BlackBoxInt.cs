using System;

class BlackBoxInt
{
    int number;

    public BlackBoxInt() => number = 0;

    int Add(int num) => (number = num);
    int Subtract(int num) => number -= num;
    int Multiply(int num) => number *= num;
    int Divide(int num) => number /= num;
    int LeftShift(int num) => number <<= num;
    int RightShift(int num) => number >>= num;
}