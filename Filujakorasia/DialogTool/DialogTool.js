var DialogLength = 1;
var ChoiceCount = 0;
var arrDialog;
var startinglines;
var currentLine = 0;
var Triggers;
var Characters = ["Player", "Pahapoika", "Kauppias"];
var currentDialog;

function init() {
    var html = "";
    html = "<div id='InputField'><div id='Line_0'><div>SpeakingChar:</div><div><select id='DChar_0'>" + CharacterList(0) + "</select></div><br>Dialog:<div><textarea id='DEntry_0' name='DialogEntry'></textarea></div></div></div><br />";
    var dialogIndex = document.getElementById("DialogForm");
    dialogIndex.innerHTML = html;
    InitButtons();
    InitDNum();
}
function initWC(content, selectedChar) {
    var html = "";
    html = "<div id='InputField'><div id='Line_0'><div>SpeakingChar:</div><div><select id='DChar_0'>" + CharacterList(selectedChar) + "</select></div><br>Dialog:<div><textarea id='DEntry_0' name='DialogEntry'>" + content + "</textarea></div></div></div><br />";
    var dialogIndex = document.getElementById("DialogForm");
    dialogIndex.innerHTML = html;
    InitButtons();
}
function CharacterList(selected) {
    var html = "";
    var i;
    for (i = 0; i < Characters.length; i++) {
        html += "<option value='" + (i+1) + "'";
        if (i == selected - 1) {
            html += "selected='selected'";
        }
        html += ">" + Characters[i] + "</option>";
    }
    return html;
}
function TriggerList(selected) {
    var html = "";
    var i;
    for (i = 1; i <= Triggers; i++) {
        html += "<option value='" + i + "'";
        if (i == selected) {
            html += "selected='selected'";
        }
        html += ">" + i + "</option>";
    }
    return html;
}
function InitButtons() {
    var html = "<div id='buttons'><button type='button' onclick='AddLine()'>Add line</button></div><div><button type='button' onclick='AddChoices()'>Add Choices</button></div><div><button type='button' onclick='AddTriggerToLine(1)'>Add Trigger</button></div><div><button type='button' onclick='RemoveLine()'>Remove</button></div><div><button type='button' onclick='Save()'>Save</button></div >";
    var dialogIndex = document.getElementById("DialogForm");
    dialogIndex.innerHTML += html;
}
function InitDNum() {
    var html = "<select id='DNumberSelect' onChange='initDialog(this.value)'><option value='0'>1</option>";
    initDialog(0);
    var i;
    for (i = 1; i < startinglines.length-1; i++) {
        html += "<option value='" + i + "'>" + (i+1) + "</option>";
    }
    html += "</select>";
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("DNumber").appendChild(container);  
}
function AddLine() {
    var html = "";
    html = "<div id='Line_" + DialogLength + "'><div>SpeakingChar:</div><div><select id='DChar_" + DialogLength + "'>" + CharacterList(0) + "</select></div><br>Dialog:<div> <textarea id='DEntry_" + DialogLength + "' name='DialogEntry'></textarea></div></div>";
    DialogLength++;
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("InputField").appendChild(container);  
}
function AddTriggerToLine(selectedTrigger) {
    var html = "";
    html = "<div id='Line_" + DialogLength + "'><div>Trigger:</div><div><select id='Triggers_" + DialogLength + "'>" + TriggerList(selectedTrigger) + "</select><button type='button' onclick='AddTrigger()'>Add New Trigger</button></div</div>";
    DialogLength++;
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("InputField").appendChild(container);
}
function AddLineWC(content, char) {
    var html = "";
    html = "<div id='Line_" + DialogLength + "'><div>SpeakingChar:</div><div><select id='DChar_" + DialogLength + "'>" + CharacterList(char) + "</select></div><br>Dialog:<div> <textarea id='DEntry_" + DialogLength + "' name='DialogEntry'>"+content+"</textarea></div></div>";
    DialogLength++;
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("InputField").appendChild(container);
}
function AddLineToChoices(ChoiceIndex, ChoiceCountNum) {
    var i = 0;
    do {
        i++;
    } while (document.getElementById("ChoiceLine_" + ChoiceCountNum + "_" + ChoiceIndex+"_" + i) != null);
    var html = "";
    html = "<div id='ChoiceLine_" + ChoiceCountNum + "_" + ChoiceIndex + "_" + i + "'><br><div>SpeakingChar:</div><div><select id='DChar_" + ChoiceCountNum + "_" + ChoiceIndex + "_" + i + "'>" + CharacterList(0) + "</select></div><br>Message:<div> <textarea id='DEntry_" + ChoiceCountNum + "_" + ChoiceIndex + "_"+i+"' name='DialogEntry'></textarea></div></div>";
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("continueDialog_" + ChoiceCountNum + "_" + ChoiceIndex).appendChild(container);
}
function AddTriggerToChoices(ChoiceIndex, ChoiceCountNum, selectedTrigger) {
    var i = 0;
    do {
        i++;
    } while (document.getElementById("ChoiceLine_" + ChoiceCountNum + "_" + ChoiceIndex + "_" + i) != null);
    var html = "";
    html = "<div id='ChoiceLine_" + ChoiceCountNum + "_" + ChoiceIndex + "_" + i + "'><br><div>Trigger:</div><div><select id='Triggers_" + ChoiceCountNum + "_" + ChoiceIndex + "_" + i + "'>" + TriggerList(selectedTrigger) + "</select><button type='button' onclick='AddTrigger()'>Add New Trigger</button></div</div>";
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("continueDialog_" + ChoiceCountNum + "_" + ChoiceIndex).appendChild(container);
}
function AddLineToChoicesWC(ChoiceIndex, ChoiceCountNum, content, char) {
    var i = 0;
    do {
        i++;
    } while (document.getElementById("ChoiceLine_" + ChoiceCountNum + "_" + ChoiceIndex + "_" + i) != null);
    var html = "";
    html = "<div id='ChoiceLine_" + ChoiceCountNum + "_" + ChoiceIndex + "_" + i + "'><br><div>SpeakingChar:</div><div><select id='DChar_" + ChoiceCountNum + "_" + ChoiceIndex + "_" + i + "'>" + CharacterList(char) + "</select></div><br>Message:<div> <textarea id='DEntry_" + ChoiceCountNum + "_" + ChoiceIndex + "_" + i + "' name='DialogEntry'>" + content + "</textarea></div></div>";
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("continueDialog_" + ChoiceCountNum + "_" + ChoiceIndex).appendChild(container);
}
function RemoveLine() {
    DialogLength--;
    var element = document.getElementById("Line_" + DialogLength);
    var lastChoice = document.getElementById("Choices_" + ChoiceCount);
    if (element.contains(lastChoice)) {
        ChoiceCount--;
    }
    element.parentNode.removeChild(element);
}
function RemoveLineFromChoices(ChoiceIndex, ChoiceCountNum) {
    var i = 0;
    do {
        i++;
    } while (document.getElementById("ChoiceLine_" + ChoiceCountNum + "_" + ChoiceIndex + "_" + i) != null);
    i--;
    var element = document.getElementById("ChoiceLine_" + ChoiceCountNum + "_" + ChoiceIndex + "_"+ i);
    element.parentNode.removeChild(element);
}
function AddChoices() {
    ChoiceCount++;
    var ChoiceNum = 1;
    var html = "";
    html = "<div id='Line_" + DialogLength + "'><div id='Choices_" + ChoiceCount + "' ><div id= 'ChoiceContainer_" + ChoiceCount + "' class='container' ><div id='choice_" + ChoiceCount + "_1' class='floatbox'> 1:<textarea id='CEntry_" + ChoiceCount + "_1'></textarea></div></div >";
    html += "<button type='button' onclick='AddChoice(" + ChoiceCount + ")'>Add choice</button><button type='button' onclick='RemoveChoice(" + ChoiceCount +")'>Remove choice</button></div >"

    html += "<div id='ContinueField_" + ChoiceCount + "' class='container'>";
    var i
    for (i = 1; i <= ChoiceNum; i++) {
        html += "<div id='cDialog_" + ChoiceCount + "_" + i + "' class='floatbox'><div id='continueDialog_" + ChoiceCount + "_" + i + "'><div id='ChoiceLine_" + ChoiceCount + "_" + i + "_1'>" + i + ":<br><div>SpeakingChar:<select id='DChar_" + ChoiceCount + "_" + i + "_1'>" + CharacterList(0) + "</select></div><textarea id='DEntry_" + ChoiceCount + "_" + i + "_1'></textarea></div></div>";
        var ChoiceButtons
        ChoiceButtons = "<div id='buttons'><div><button type='button' onclick='AddLineToChoices(" + i + "," + ChoiceCount + ")'>Add line</button></div ><div><button type='button' onclick='AddTriggerToChoices(" + i + "," + ChoiceCount + ", 1)'>Add Trigger</button></div ><div><button type='button' onclick='RemoveLineFromChoices(" + i + "," + ChoiceCount + ")'>Remove</button></div><div><button type='button' onclick='EndDialog(" + i + "," + ChoiceCount + ")'>End Dialog</button></div></div >"

        html += ChoiceButtons + "</div>";
        
    }
    html += "</div></div></div>";
    DialogLength++;
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("InputField").appendChild(container);
}
function AddChoicesWC(content, concontent, char) {
    ChoiceCount++;
    var ChoiceNum = 1;
    var html = "";
    html = "<div id='Line_" + DialogLength + "'><div id='Choices_" + ChoiceCount + "' ><div id= 'ChoiceContainer_" + ChoiceCount + "' class='container' ><div id='choice_" + ChoiceCount + "_1' class='floatbox'> 1:<textarea id='CEntry_" + ChoiceCount + "_1'>" + content + "</textarea></div></div >";
    html += "<button type='button' onclick='AddChoice(" + ChoiceCount + ")'>Add choice</button><button type='button' onclick='RemoveChoice(" + ChoiceCount + ")'>Remove choice</button></div >"

    html += "<div id='ContinueField_" + ChoiceCount + "' class='container'>";
    var i
    for (i = 1; i <= ChoiceNum; i++) {
        html += "<div id='cDialog_" + ChoiceCount + "_" + i + "' class='floatbox'><div id='continueDialog_" + ChoiceCount + "_" + i + "'><div id='ChoiceLine_" + ChoiceCount + "_" + i + "_1'>" + i + ":<div>SpeakingChar:<select id='DChar_" + ChoiceCount + "_" + i + "_1'>" + CharacterList(char) + "</select></div><textarea id='DEntry_" + ChoiceCount + "_" + i + "_1'>" + concontent + "</textarea></div></div>";
        var ChoiceButtons
        ChoiceButtons = "<div id='buttons'><div><button type='button' onclick='AddLineToChoices(" + i + "," + ChoiceCount + ")'>Add line</button></div ><div><button type='button' onclick='AddTriggerToChoices(" + i + "," + ChoiceCount + ", 1)'>Add Trigger</button></div ><div><button type='button' onclick='RemoveLineFromChoices(" + i + "," + ChoiceCount + ")'>Remove</button></div><div><button type='button' onclick='EndDialog(" + i + "," + ChoiceCount + ")'>End Dialog</button></div></div >"

        html += ChoiceButtons + "</div>";

    }
    html += "</div></div></div>";
    DialogLength++;
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("InputField").appendChild(container);
}
function EndDialog(ChoiceIndex, ChoiceCountNum) {
    var i = 0;
    do {
        i++;
    } while (document.getElementById("ChoiceLine_" + ChoiceCountNum + "_" + ChoiceIndex + "_" + i) != null);
    var html = "";
    html = "<div id='ChoiceLine_" + ChoiceCountNum + "_" + ChoiceIndex + "_"+i+"' END='END'>END</div>";
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("continueDialog_" + ChoiceCountNum + "_" + ChoiceIndex).appendChild(container);
}
function AddChoice(ChoiceCount) {
    var i = 0;
    do {
        i++;
    } while (document.getElementById("choice_" + ChoiceCount + "_" + i) != null);
    var html = "";
    html += "<div id='choice_" + ChoiceCount + "_" + i + "' class='floatbox'>" + i + ":<textarea id='CEntry_" + ChoiceCount + "_" + i +"'></textarea></div>";
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("ChoiceContainer_" + ChoiceCount).appendChild(container);

    html = "<div id='cDialog_" + ChoiceCount + "_" + i + "' class='floatbox'><div id='continueDialog_" + ChoiceCount + "_" + i + "'><div id='ChoiceLine_" + ChoiceCount + "_" + i + "_1'>" + i + ":<div>SpeakingChar:<select id='DChar_" + ChoiceCount + "_" + i + "_1'>" + CharacterList(0) + "</select></div><textarea id='DEntry_" + ChoiceCount + "_" + i + "_1'></textarea></div></div>";
    var ChoiceButtons
    ChoiceButtons = "<div id='buttons'><div><button type='button' onclick='AddLineToChoices(" + i + "," + ChoiceCount + ")'>Add line</button></div ><div><button type='button' onclick='AddTriggerToChoices(" + i + "," + ChoiceCount + ", 1)'>Add Trigger</button></div ><div><button type='button' onclick='RemoveLineFromChoices(" + i + "," + ChoiceCount + ")'>Remove</button></div><div><button type='button' onclick='EndDialog(" + i + "," + ChoiceCount + ")'>End Dialog</button></div></div >"
    html += ChoiceButtons + "</div>";
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("ContinueField_" + ChoiceCount).appendChild(container);
}
function AddChoiceWC(ChoiceCount, content, concontent, char) {
    var i = 0;
    do {
        i++;
    } while (document.getElementById("choice_" + ChoiceCount + "_" + i) != null);
    var html = "";
    html += "<div id='choice_" + ChoiceCount + "_" + i + "' class='floatbox'>" + i + ":<textarea id='CEntry_" + ChoiceCount + "_" + i +"'>"+content+"</textarea></div>";
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("ChoiceContainer_" + ChoiceCount).appendChild(container);
    if (concontent.indexOf("!") == 0 || concontent.indexOf("_") == 0) {
        document.getElementById("debugLog").value = "mo";
        html = "<div id='cDialog_" + ChoiceCount + "_" + i + "' class='floatbox'><div id='continueDialog_" + ChoiceCount + "_" + i + "'><div id='ChoiceLine_" + ChoiceCount + "_" + i + "_1' end='end'>END</div></div>";
    }
    else {
        html = "<div id='cDialog_" + ChoiceCount + "_" + i + "' class='floatbox'><div id='continueDialog_" + ChoiceCount + "_" + i + "'><div id='ChoiceLine_" + ChoiceCount + "_" + i + "_1'>" + i + ":<div>SpeakingChar:<select id='DChar_" + ChoiceCount + "_" + i + "_1'>" + CharacterList(char) + "</select></div><textarea id='DEntry_" + ChoiceCount + "_" + i + "_1'>" + concontent + "</textarea></div></div>";
    }

   
    var ChoiceButtons
    ChoiceButtons = "<div id='buttons'><div><button type='button' onclick='AddLineToChoices(" + i + "," + ChoiceCount + ")'>Add line</button></div ><div><button type='button' onclick='AddTriggerToChoices(" + i + "," + ChoiceCount + ", 1)'>Add Trigger</button></div ><div><button type='button' onclick='RemoveLineFromChoices(" + i + "," + ChoiceCount + ")'>Remove</button></div><div><button type='button' onclick='EndDialog(" + i + "," + ChoiceCount + ")'>End Dialog</button></div></div >"
    html += ChoiceButtons + "</div>";
    var container = document.createElement("div");
    container.innerHTML = html;
    document.getElementById("ContinueField_" + ChoiceCount).appendChild(container);

}
function RemoveChoice(ChoiceCount) {
    var i = 0;
    do {
        i++;
    } while (document.getElementById("choice_" + ChoiceCount + "_" + i) != null);
    i--;
    var element = document.getElementById("choice_" + ChoiceCount + "_" + i);
    element.parentNode.removeChild(element);
    var element = document.getElementById("cDialog_" + ChoiceCount + "_" + i);
    element.parentNode.removeChild(element);
}
function AddDialog() {
    var container = document.createElement("option");
    container.value = startinglines.length-1;
    container.innerHTML = startinglines.length;
    document.getElementById("DNumberSelect").appendChild(container);  
}
function SetDialog(dialog) {
    var dialogi = (new VBArray(dialog)).toArray();;

    arrDialog = dialogi;
}
function SetStartLines(startLines) {
    startinglines = (new VBArray(startLines)).toArray();;
}
function SetTriggers(newTriggers) {
    Triggers = newTriggers;
}
function initDialog(selectedDialog) {
    currentDialog = selectedDialog;
    DialogLength = 1;
    ChoiceCount = 0;
    readFile();
    if (selectedDialog >= startinglines.length - 1) {
        initWC("",0);
    } else {
        currentLine = startinglines[selectedDialog];
        currentLine++;
        var a = arrDialog[currentLine].charAt(1)
        var char = TryParseInt(a, 0);
        currentLine++;
        initWC(arrDialog[currentLine], char);
        currentLine++;
        while (arrDialog[currentLine].indexOf("#") != 0) {
            if (arrDialog[currentLine].indexOf("!") == 0) {
                currentLine++;
                return;
            } else if (arrDialog[currentLine].indexOf("?") == 0) {
               
                var a = arrDialog[currentLine].substring(1, arrDialog[currentLine].length + 1);
                var qn = TryParseInt(a, 0);
                AddTriggerToLine(qn);
                currentLine++;
            } else if (arrDialog[currentLine].indexOf("-") == 0) {
                currentLine++;
                while (arrDialog[currentLine].indexOf("-") != 0) {
                    var a = arrDialog[currentLine].substring(1, arrDialog[currentLine].length+1);
                    var qn = TryParseInt(a, 0);
                    currentLine++;
                    var cl = currentLine;
                    while (arrDialog[cl].indexOf("+" + qn) != 0 && arrDialog[cl].indexOf("+0") != 0) {
                        cl++;
                    }
                    cl++;
                    a = arrDialog[cl].charAt(1);
                    var char = TryParseInt(a, 0);
                    cl++;
                    if (qn == 1) {
                        AddChoicesWC(arrDialog[currentLine], arrDialog[cl], char);
                    } else {
                        if (arrDialog[cl].indexOf("!") == 0 || arrDialog[cl].indexOf("!") == 0) {
                            AddChoiceWC(ChoiceCount, arrDialog[currentLine], "!", char)
                        }
                        else {
                            AddChoiceWC(ChoiceCount, arrDialog[currentLine], arrDialog[cl], char)
                        }

                    }

                    while (arrDialog[cl].indexOf("+") != 0 && arrDialog[cl].indexOf("_") != 0) {
                        if (arrDialog[cl].indexOf("!") == 0) {
                            EndDialog(qn, ChoiceCount);
                        } else if (arrDialog[cl].indexOf("?") == 0) {
                            var n = arrDialog[cl].substring(1, arrDialog[cl].length + 1);
                            var an = TryParseInt(n, 0);
                            AddTriggerToChoices(qn, ChoiceCount, an);
                            
                        }
                        else if (arrDialog[cl].indexOf(".") == 0) {
                            a = arrDialog[cl].substring(1, arrDialog[cl].length+1);
                            char = TryParseInt(a, 0);
                            cl++;
                            AddLineToChoicesWC(qn, ChoiceCount, arrDialog[cl], char);
                        }
                        cl++;
                    }
                    currentLine++;
                }
                while (arrDialog[currentLine].indexOf("_") != 0) {
                    currentLine++;
                }
                currentLine++;
            } else if (arrDialog[currentLine].indexOf("_") == 0) {
                currentLine++;
            } else if (arrDialog[currentLine].indexOf(".") == 0) {
                var a = arrDialog[currentLine].substring(1, arrDialog[currentLine].length+1);
                var char = TryParseInt(a, 0);
                currentLine++;
                AddLineWC(arrDialog[currentLine], char);
                currentLine++;
            } else {
                AddLineWC(arrDialog[currentLine], char);
                currentLine++;
            }
        }
    }
    
}
function Save() {
    var line = 0;
    var choice = 1;
    var newDialog = new Array("#" + (parseInt(currentDialog) +1));
    do {
        var nextChoice = document.getElementById("Choices_" + choice);
        var trigger = document.getElementById("Triggers_" + line);
        if (document.getElementById("Line_" + line).contains(nextChoice)) {
            
            newDialog.push("-");
            var amount = 1;
            do {
                newDialog.push("+" + amount);
                newDialog.push(document.getElementById("CEntry_" + choice + "_" + amount).value);
                newDialog[newDialog.length - 1] = newDialog[newDialog.length - 1].trim()
                amount++;
            } while (document.getElementById("CEntry_" + choice + "_" + amount) != null);
            newDialog.push("-");
            amount--;
            var i;
            for (i = 1; i <= amount; i++) {
                var o = 1;
                newDialog.push("+"+i);
                do {
                    if (document.getElementById("ChoiceLine_" + choice + "_" + i + "_" + o).getAttribute('end') != null) {
                        newDialog.push("!");
                        o++;
                    }
                    else if (document.getElementById("Triggers_" + choice + "_" + i + "_" + o) != null) {
                        newDialog.push("?" + document.getElementById("Triggers_" + choice + "_" + i + "_" + o).value);
                        o++;
                    }
                    else {
                        newDialog.push("." + document.getElementById("DChar_" + choice + "_" + i + "_" + o).value);
                        newDialog.push(document.getElementById("DEntry_" + choice + "_" + i + "_" + o).value);
                        newDialog[newDialog.length - 1] = newDialog[newDialog.length - 1].trim()
                        o++;
                    }
                    
                } while (document.getElementById("ChoiceLine_" + choice + "_" + i + "_" + o) != null);
                
            }
            newDialog.push("_");
            choice++;
        } else if (document.getElementById("Line_" + line).contains(trigger)) {
            newDialog.push("?" + trigger.value);
        }
        else {
            newDialog.push("." + document.getElementById("DChar_" + line).value);
            newDialog.push(document.getElementById("DEntry_" + line).value);
            newDialog[newDialog.length - 1] = newDialog[newDialog.length - 1].trim()
        }
        line++;
    } while (document.getElementById("Line_" + line) != null);
    newDialog.push("!");
    for (i = 0; i < newDialog.length; i++) {
        
        if (newDialog[i].indexOf(",") > -1) {
            
            newDialog[i] = newDialog[i].replace(",", "--");
        }
    }
    
    document.getElementById("debugLog").value = newDialog;
    if (currentDialog >= startinglines.length - 1) {
        saveFile(newDialog.toString(), currentDialog, true);
        
    } else {
        saveFile(newDialog.toString(), currentDialog, false);
    }
}
function TryParseInt(str, defaultValue) {
    var retValue = defaultValue;
    if (str !== null) {
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseInt(str);
            }
        }
    }
    return retValue;
}
