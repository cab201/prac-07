class ByteCalculator {
    private string expression;
    private byte operand1;
    private byte operand2;

    /// <summary>
    /// The operator defined in the expression.
    /// </summary>
    private string op;
    public string Expression {
        get {
            return expression;
        }
        set {
            ParseOperatorFromExpression(value);
            ParseOperandsFromExpression(value);
            expression = value;
        }
    }

    /// <summary>
    /// Parse and set the operator from the expression.
    /// </summary>
    /// <param name="expression">The expression to parse.</param>
    /// <exception cref="ArgumentException">Thrown if the expression does not contain one valid operator.</exception>
    private void ParseOperatorFromExpression(string expression){
        int numberOfOperators = 0;
        // Check if the expression contains a valid operator.
        if (expression.Contains("+")) {
            op = "+";
            numberOfOperators++;
        } else if (expression.Contains("-")) {
            op = "-";
            numberOfOperators++;
        } else if (expression.Contains("*")) {
            op = "*";
            numberOfOperators++;
        } else if (expression.Contains("/")) {
            op = "/";
            numberOfOperators++;
        } else {
            // Throw an exception if the expression does not contain a valid operator.
            throw new ArgumentException("The expression does not contain a valid operator.");
        }
        // Throw an exception if the expression contains more than one operator.
        if (numberOfOperators > 1) {
            throw new ArgumentException($"The expression contains more than one operator. ${numberOfOperators} operators found.");
        }
    }

    /// <summary>
    /// Parse and set the two operands from the expression.
    /// </summary>
    /// <param name="expression">The expression to parse.</param>
    /// <exception cref="ArgumentException">Thrown if the expression does not contain two valid operands.</exception>
    private void ParseOperandsFromExpression(string expression){
        string[] operands = expression.Split(op);
        // Trim the operands.
        for (int i = 0; i < operands.Length; i++) {
            operands[i] = operands[i].Trim();
        }
        // Throw an exception if the expression does not contain two operands.
        if (operands.Length != 2) {
            throw new ArgumentException($"The expression does not contain two operands. {operands.Length} operands found.");
        }
        // Throw an exception if either operand is not valid byte values.
        if (!byte.TryParse(operands[0], out operand1)) {
            throw new ArgumentException($"The first operand, {operands[0]}, is not a valid byte value.");
        }
        if (!byte.TryParse(operands[1], out operand2)) {
            throw new ArgumentException($"The second operand, {operands[1]}, is not a valid byte value.");
        }
    }

    /// <summary>
    /// Create a new instance of the ByteCalculator class.
    /// </summary>
    /// <param name="expression">The expression to evaluate.</param>
    public ByteCalculator(string expression) {
        Expression = expression;
    }

    /// <summary>
    /// Evaluate the expression.
    /// </summary>
    /// <returns>The result of the expression.</returns>
    /// <exception cref="DivideByZeroException">Thrown if the expression contains a division by zero.</exception>
    /// <exception cref="OverflowException">Thrown if the result of the expression is greater than the maximum value of a byte or less than the minimum value of a byte.</exception>
    public byte Evaluate() {
        // Check for division by zero.
        if (op == "/" && operand2 == 0) {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }

        // Evaluate the expression.
        int result = 0;
        switch (op) {
            case "+":
                result = operand1 + operand2;
                break;
            case "-":
                result = operand1 - operand2;
                break;
            case "*":
                result = operand1 * operand2;
                break;
            case "/":
                result = operand1 / operand2;
                break;
        }

        // Check for overflow or underflow.
        if (result > byte.MaxValue) {
            throw new OverflowException($"The result of the expression, {result}, is greater than the maximum value of a byte.");
        }
        if (result < byte.MinValue) {
            throw new OverflowException($"The result of the expression, {result}, is less than the minimum value of a byte.");
        }
        return (byte)result;
    }
}