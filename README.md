# MonkeyInterpreterInGo
Based on "Writing an interpreter in Go" by Thorsten Ball
[All code done](https://interpreterbook.com/waiig_code_1.4.zip)

# Monkey specification
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
