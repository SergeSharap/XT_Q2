window.onload = function () { 
    function bindButton() {
        var send = document.getElementById("send");
        send.addEventListener("click", calculator, false);
    }
    bindButton();
}

function calculator() {
    var str = document.getElementById("string").value;
    var num = calculate(str);

    var resultEl = document.getElementById("result");
    resultEl.value = num;
    
    function calculate(inpStr) {
        var multNum = /\d(\.\d)?[^\+-=\*\/]+\d(\.\d)?/;
        var multOp = /(=|-|\+|\*|\/|\.)\D*(=|-|\+|\*|\/|\.)/;
        var inor = /[^\d=\+\*\/-\s\.]+/;
        var beg =/^(=|-|\+|\*|\/)/;
        var end = /=\s*$/;
        var equals = inpStr.match(/=/g);
        if (multNum.test(inpStr) || multOp.test(inpStr) || inor.test(inpStr) ||
        beg.test(inpStr) || !end.test(inpStr) || equals.length !== 1) {
            return "error";
        }        
        
        var regNum = /\d+(\.?\d+)?/g;
        var regOperation = /\/|\+|-|\*/g;
        var numbers = inpStr.match(regNum);
        var operations = inpStr.match(regOperation);
        
        var result = operation(numbers[0], operations[0], numbers[1]);
        for (var i = 1; i < operations.length; i++)
        {
            result = operation(result, operations[i], numbers[i + 1]);
        }
        return result;
    }
    
    function operation(val1, operation, val2) {
        var newVal;
        switch (operation) {
            case "+":
                newVal = +val1 + +val2;
                break;
            case "-":
                newVal = val1 - val2;
                break;
            case "*":
                newVal = val1 * val2;
                break;
            case "/":
                newVal = val1 / val2;
                break;
            default:
                return "unknown";
        }
    
        return newVal;
    }
}


