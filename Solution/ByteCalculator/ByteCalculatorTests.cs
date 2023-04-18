class ByteCalculatorTests {
    private List<ByteCalculator> calculators;

    /// <summary>
    /// Initialise the private list of calculators.
    /// </summary>
    public ByteCalculatorTests(){
        calculators = new List<ByteCalculator>();
    }

    /// <summary>
    /// Add a test to the list of tests.
    /// </summary>
    /// <param name="expression">The expression to test.</param>
    public void AddTest(string expression){
        try {
            calculators.Add(new ByteCalculator(expression));
        } catch (Exception e) {
            Console.WriteLine($"{expression} threw an exception: {e.Message}");
        }
    }

    /// <summary>
    /// Evaluate all the calculators in the list, catching any exceptions
    /// and printing the result to the console.
    /// </summary>
    public void RunTests(){
        foreach (ByteCalculator calculator in calculators) {
            try {
                Console.WriteLine($"{calculator.Expression} = {calculator.Evaluate()}");
            } catch (Exception e) {
                Console.WriteLine($"{calculator.Expression} threw an exception: {e.Message}");
            }
        }
    }
}