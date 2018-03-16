# MonkeyInterpreterInGo
Based on "Writing an interpreter in Go" by Thorsten Ball
[All code done](https://interpreterbook.com/waiig_code_1.4.zip) in GO language

# Monkey specification
In Monkey programming language **EVERYTHING** besides LET and RETURN statments **is an EXPRESSION**
* variable bindings
> `let name = 1;`   
* integers and booleans
> `let age =1;`
* arithmentic expressions
>`let resultExpression = 10*(20/2);`  
* built-in functions
* first-class and higher-order functions (functions which takte other function as argument)
>`let add = fn(a,b) {return a+b: };`   
* closures
* a string datat structure
> `"sdasdsa"`   
* an array data structure
>`let myArray =[1,2,3,4,5];`   
* a hash data structure
>`let hashMap = {"name":"Thorsten", "age":28};`  


# Lexing
source code -> lexer (aka tokenizer/scanner) -> tokens

Token types:
* numbers
* identifiers (e.g. variable names)
* keywords
* special characters


`ILLEGAL` signifies a token we don't know
`EOF` token tells our parser that it can stop ;)

# Parser
We use ["Pratt parser"](https://en.wikipedia.org/wiki/Pratt_parser).
We process tokens from "left to right", expect or reject the next tokens and if everything fits we return an AST node.
[Article about Pratt parsing - **Top down operator precedence**](http://journal.stuffwithstuff.com/2011/03/19/pratt-parsers-expression-parsing-made-easy/)

The Pratt parsing approach is an alternative to parsers based on context-free grammars adn the [BNF](https://en.wikipedia.org/wiki/Backus%E2%80%93Naur_form). In this method you have two parsing functions associated with token (infix and prefix)

Terminology: postfix, prefix, infix and precedence