function getIndexesOfSelectedOptions(select)
{
	if (!select.options) return null;
	var selectedOptions = [];
    for (var i = 0; i < select.options.length; i++) 
        if (select.options[i].selected) 
            selectedOptions.push(i);
	return selectedOptions.length==0?null:selectedOptions;
}

function getIndexesOfNotSelectedOptions(select)
{
	if (!select.options) return null;
	var selectedOptions = [];
    for (var i = 0; i < select.options.length; i++) 
        if (!select.options[i].selected) 
            selectedOptions.push(i);
	return selectedOptions.length==0?null:selectedOptions;
}

function moveAllToRight(stringSelect1, stringSelect2)
{
    var select1 = document.getElementById(stringSelect1);
    var select2 = document.getElementById(stringSelect2);

    for (var i = 0; i < select1.options.length; i++)
        select2.options[select2.options.length] = new Option(select1.options[i].text, select1.options[i].value);
    select1.options.length = 0;
}

function moveAllToLeft(stringSelect1, stringSelect2)
{
    var select1 = document.getElementById(stringSelect1);
    var select2 = document.getElementById(stringSelect2);

    for (var i = 0; i < select2.options.length; i++)
        select1.options[select1.options.length] = new Option(select2.options[i].text, select2.options[i].value);
    select2.options.length = 0;
}

function moveToRight(stringSelect1, stringSelect2)
{
    var select1 = document.getElementById(stringSelect1);
    var select2 = document.getElementById(stringSelect2);
    var selected = getIndexesOfSelectedOptions(select1);

    if (selected === null)
        alert("No options selected");
    for (var i = 0; i < selected.length; i++)
        select2.options[select2.options.length] = new Option(select1.options[selected[i]].text, select1.options[selected[i]].value);

    var notSelected = getIndexesOfNotSelectedOptions(select1);
    if (notSelected === null)
        select1.options.length = 0;

    for (var i = 0; i < notSelected.length; i++)
        select1.options[i] = new Option(select1.options[notSelected[i]].text, select1.options[notSelected[i]].value)

    select1.options.length = notSelected.length;
}

function moveToLeft(stringSelect1, stringSelect2)
{
    var select1 = document.getElementById(stringSelect1);
    var select2 = document.getElementById(stringSelect2);
    var selected = getIndexesOfSelectedOptions(select2);

    if (selected === null)
        alert("No options selected");
    for (var i = 0; i < selected.length; i++)
        select1.options[select1.options.length] = new Option(select2.options[selected[i]].text, select2.options[selected[i]].value);

    var notSelected = getIndexesOfNotSelectedOptions(select2);
    if (notSelected === null)
        select2.options.length = 0;

    for (var i = 0; i < notSelected.length; i++)
        select2.options[i] = new Option(select2.options[notSelected[i]].text, select2.options[notSelected[i]].value)
    
    select2.options.length = notSelected.length;

}