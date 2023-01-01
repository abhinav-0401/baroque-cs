namespace Baroque;

public class Token
{
    private readonly TokenType type;
    private readonly string? lexeme;
    private readonly Object? literal;
    private readonly int line;

    public Token(TokenType type, string? lexeme, Object? literal, int line)
    {
        this.type = type;
        this.lexeme = lexeme;
        this.literal = literal;
        this.line = line;
    }

    public override string ToString()
    {
        return String.Format("type {0} lexeme {1} literal {2}", type, lexeme, literal);
    }
}