namespace ConsoleApp;
class Program
{
    static void Main(string[] args)
    {
        // Expressions used to test the ByteCalculator class.
        string[] expressions = {
            "0", // Should throw an exception, no operator.
            "0+0+0", // Should throw an exception, more than one operator.
            "0 0+0", // Should throw an exception, "0 0" is not a valid operand (not a number).
            "-1+0", // Should throw an exception, "-1" is not a valid operand (negative).
            "0+256", // Should throw an exception, "256" is not a valid operand (overflow).
            "0.1+0", // Should throw an exception, "0.1" is not a valid operand (not an integer).
            "0+0",
            "0-0",
            "0*0",
            "0/0", // Should throw an exception, division by zero.
            "25+32",
            "25-32", // Should throw an exception, underflow.
            "25*32", // Should throw an exception, overflow.
            "25/32",
        };

        // Replace the index from 0 to 13 to test the ByteCalculator class.
        // ByteCalculator calculator = new ByteCalculator(expressions[0]);

        // For question 2, use the ByteCalculatorTests class
        // to run all the tests instead.
        ByteCalculatorTests tests = new ByteCalculatorTests();
        foreach (string expression in expressions) {
            tests.AddTest(expression);
        }
        tests.RunTests();
    }
}
