window.onload = function () { 
    function bindButton() {
        var send = document.getElementById("send");
        send.addEventListener("click", getRemovedString, false);
    }
    bindButton();
}

function getRemovedString() {
    var text = document.getElementById("string").value;
    var words =  text.split(' ').join(',').split(':').join(',').split('?').join(',').split('!').join(',')
    .split(';').join(',').split('.').join(',').split('\t').join(',').split(',');
    var duplicateCharacters = [];
    
    for (var i = 0; i < words.length; i++)
    {
        duplicateCharacters = duplicateCharacters.concat(GetDuplicateCharacters(words[i]));
    }
    
    var result = replaceAll(text, duplicateCharacters[0], '');
    for (var i = 1; i < duplicateCharacters.length; i++)
    {
        result = replaceAll(result, duplicateCharacters[i], '');
    }
    var resText = document.getElementById("result");
    resText.value = result;
    
    function GetDuplicateCharacters(string) 
    {
        return string
          .split('')
          .filter(function(item, pos, self) {
            return self.indexOf(item) != pos;
          })
    }
    
    function replaceAll(string, search, replace)
    {
        return string.split(search).join(replace);
    }
}
